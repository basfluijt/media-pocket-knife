namespace MediaSorter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Helpers;

    public partial class FrmMoveAndMerge : Form
    {
        /******** Work vars *********/


        public FrmMoveAndMerge()
        {
            InitializeComponent();

            tbConsole.Clear();

            tbSource.Enabled = false;
            tbTarget.Enabled = false;
            tbNumberOfItemsProcessed.Enabled = false;
            tbTotalNumberOfItems.Enabled = false;
            tbDuplicates.Enabled = false;

            tbNumberOfItemsProcessed.Text = @"0";
            tbTotalNumberOfItems.Text = @"0";
            tbDuplicates.Text = @"0";
            tbNumberOfItemsProcessed.Text = @"0";

            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = 1;
            progressBar.Value = 1;
            progressBar.Step = 1;

            btnStart.Enabled = !string.IsNullOrWhiteSpace(SourcePath) && !string.IsNullOrWhiteSpace(TargetPath);
        }

        /******** Paths and raw paths *********/
        private string SourcePath { get; set; }
        private List<string> SourceFiles { get; set; }
        private string TargetPath { get; set; }
        private List<string> TargetFiles { get; set; }

        /******** Workload and Checklist *********/
        private List<MediaItem> Workload { get; set; }
        private List<MediaItem> CheckList { get; set; }

        /******** Button Click-events *********/
        private void btnSource_Click(object sender, EventArgs e)
        {
            DisableUi();
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();
                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    DisableUi(false);
                    return;
                }

                tbConsole.AppendText($"\n [SOURCE] Reading files from ( {fbd.SelectedPath} )");
                Application.DoEvents();
                var files = Directory.EnumerateFiles(fbd.SelectedPath, "*", SearchOption.AllDirectories).ToList();
                tbConsole.AppendText("\n [SOURCE] Filtering media files from list");
                Application.DoEvents();
                SourceFiles = FileHelper.FilterMediaFiles(files);
                tbTotalNumberOfItems.Text = SourceFiles.Count.ToString();
                SourcePath = fbd.SelectedPath;
                tbSource.Text = SourcePath;
            }

            tbConsole.AppendText($"\n [SOURCE] Reading {SourceFiles.Count} media properties");
            Application.DoEvents();

            // Set MediaItem properties
            Workload = MediaAnalyzer.GatherMediaInformation(SourceFiles);
            tbConsole.Text += @" - Done";

            // Set Progressbar
            progressBar.Maximum = Workload.Count;

            DisableUi(false);
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            DisableUi();
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();
                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    DisableUi(false);
                    return;
                }

                if (SourcePath != null && SourcePath.Equals(fbd.SelectedPath))
                {
                    tbConsole.AppendText("\n [ERROR] TARGET folder can't be the same as the SOURCE folder. Aborting...");
                    Application.DoEvents();
                    DisableUi(false);
                    return;
                }

                tbConsole.AppendText($"\n [TARGET] Reading files from ( {fbd.SelectedPath} )");
                Application.DoEvents();
                var files = Directory.EnumerateFiles(fbd.SelectedPath, "*", SearchOption.AllDirectories).ToList();


                tbConsole.AppendText("\n [TARGET] Filtering media files from list");
                Application.DoEvents();

                TargetFiles = FileHelper.FilterMediaFiles(files);
                TargetPath = fbd.SelectedPath;
                tbTarget.Text = TargetPath;
            }

            tbConsole.AppendText($"\n [TARGET] Reading {TargetFiles.Count} media properties");
            Application.DoEvents();

            // Set MediaItem properties
            CheckList = MediaAnalyzer.GatherMediaInformation(TargetFiles);
            tbConsole.Text += @" - Done";
            Application.DoEvents();

            // Check for duplicates between source and target folders
            CheckDuplicates();

            DisableUi(false);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!Workload.Any() || !CheckList.Any() || string.IsNullOrWhiteSpace(TargetPath) || string.IsNullOrWhiteSpace(SourcePath))
            {
                btnStart.BackColor = Color.DarkRed;
                btnStart.Text = @"STOP";
                btnStart.ForeColor = Color.Azure;
                tbConsole.AppendText("\n [ERROR] There are no items to be processed or one of the paths are invalid.");
                Application.DoEvents();

                DisableUi(false);
                return;
            }

            ProcessWorkload();
        }

        /******** Methods *********/

        private void ProcessWorkload()
        {
            DisableUi();
            tbConsole.AppendText("\n ------ Starting Workload ------");
            Application.DoEvents();

            foreach (var item in Workload)
            {
                if (item.IsDuplicate && !cbOverwrite.Checked) continue;

                var formattedDate = cbCustomDateFormat.Checked && !string.IsNullOrWhiteSpace(cbCustomDateFormat.Text)
                    ? item.Date.ToString(tbCustomDateFormat.Text)
                    : item.Date.ToString("yyyy-MM-dd");

                var existingItem = CheckList.FirstOrDefault(c => c.Directory.FullName.Contains(formattedDate));
                if (existingItem != null)
                {
                    tbConsole.AppendText($"\n Existing folder found for {item.FileName} with date {formattedDate}.");
                    Application.DoEvents();

                    var targetDateDirectory = $@"{existingItem.Directory.FullName}";
                    item.MoveLocation = targetDateDirectory;

                    // If the item is labeled as a duplicate, remove the original for overwrite is enabled
                    if (item.IsDuplicate || File.Exists($@"{targetDateDirectory}\{item.FileName}"))
                        File.Delete($@"{targetDateDirectory}\{item.FileName}");

                    if (cbCopyOnly.Checked)
                        File.Copy(item.FullFileName, $@"{targetDateDirectory}\{item.FileName}");
                    else
                        File.Move(item.FullFileName, $@"{targetDateDirectory}\{item.FileName}");

                    item.IsProcessed = true;
                    tbConsole.AppendText($"\n Moved {item.FileName}.");
                    continue;
                }

                tbConsole.AppendText($"\n No matching date-folder found in target for {item.FileName} with date {formattedDate}.");
                tbConsole.AppendText($"\n Moving item to date-folder {formattedDate} in target-folder.");
                Application.DoEvents();

                try
                {
                    var targetDateDirectory = $@"{TargetPath}\{formattedDate}";
                    if (!Directory.Exists(targetDateDirectory)) Directory.CreateDirectory(targetDateDirectory);

                    item.MoveLocation = targetDateDirectory;

                    // If the item is labeled as a duplicate, remove the original for overwrite is enabled
                    if (item.IsDuplicate)
                        File.Delete($@"{targetDateDirectory}\{item.FileName}");

                    if (cbCopyOnly.Checked)
                        File.Copy(item.FullFileName, $@"{targetDateDirectory}\{item.FileName}");
                    else
                        File.Move(item.FullFileName, $@"{targetDateDirectory}\{item.FileName}");
                }
                catch (Exception)
                {
                    tbConsole.AppendText($@"\n Failed to create folder or move {TargetPath}\{formattedDate}\{item.FileName}.");
                    tbConsole.AppendText($"\n Skipping {item.FileName}");
                    Application.DoEvents();
                }

                item.IsProcessed = true;

                tbConsole.AppendText($"\n Moved {item.FileName}.");
                Application.DoEvents();

                UpdateProcessedItems();
            }

            tbConsole.AppendText("\n ALL DONE!");
            DisableUi(false);
        }

        private void UpdateProcessedItems()
        {
            tbNumberOfItemsProcessed.Text = Workload.Count(w => w.IsProcessed).ToString();
            progressBar.PerformStep();
            Application.DoEvents();
        }

        private void CheckDuplicates()
        {
            if (cbSizeContent.Checked)
                tbDuplicates.Text = Workload.Where(w => CheckList.Any(c => c.FileName.Equals(w.FileName) && c.Size.Equals(w.Size))).Select(w =>
                {
                    w.IsDuplicate = true;
                    return w;
                }).Count().ToString();
            else
                tbDuplicates.Text = Workload.Where(w => CheckList.Any(c => c.FileName.Equals(w.FileName))).Select(w =>
                {
                    w.IsDuplicate = true;
                    return w;
                }).Count().ToString();
        }

        private void DisableUi(bool disable = true)
        {
            if (disable)
            {
                btnSource.Enabled = false;
                btnTarget.Enabled = false;
                btnStart.Enabled = false;
                btnStart.BackColor = Color.MistyRose;
            }
            else
            {
                btnSource.Enabled = true;
                if (!string.IsNullOrWhiteSpace(SourcePath))
                {
                    btnSource.BackColor = Color.YellowGreen;
                    btnSource.Text = @"Change";
                }

                btnTarget.Enabled = true;
                if (!string.IsNullOrWhiteSpace(TargetPath))
                {
                    btnTarget.BackColor = Color.YellowGreen;
                    btnTarget.Text = @"Change";
                }

                btnStart.Enabled = !string.IsNullOrWhiteSpace(SourcePath) && !string.IsNullOrWhiteSpace(TargetPath);
                if (!btnStart.Enabled) return;
                btnStart.BackColor = Color.YellowGreen;
                btnStart.ForeColor = Color.Azure;
            }
        }
    }
}
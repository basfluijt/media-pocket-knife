namespace MediaSorter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Helpers;

    public partial class FormMoveAndMerge : Form
    {
        /******** Work vars *********/

        public FormMoveAndMerge()
        {
            InitializeComponent();
            MediaAnalyzer.InitProgressBar += SetProgressBarValues;
            MediaAnalyzer.ProcessProgressBar += UpdateProgressBar;

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

            lblProgressBar.Text = @"IDLE";
            lblProgressBar.BackColor = Color.Transparent;
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
                tbConsole.AppendText(" - Done");
                Application.DoEvents();
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
            progressBar.Value = 1;

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
                    tbConsole.SelectionColor = Color.IndianRed;
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
                tbConsole.AppendText(" - Done");
                Application.DoEvents();
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
            if (!Workload.Any() || string.IsNullOrWhiteSpace(TargetPath) || string.IsNullOrWhiteSpace(SourcePath))
            {
                btnStart.BackColor = Color.DarkRed;
                btnStart.Text = @"STOP";
                btnStart.ForeColor = Color.Azure;
                tbConsole.SelectionColor = Color.IndianRed;
                tbConsole.AppendText("\n [ERROR] The SOURCE or TARGET folder do not contain any media items, use merge instead.");
                Application.DoEvents();
                tbConsole.SelectionColor = Color.Black;
                DisableUi(false);
                return;
            }

            ProcessWorkload();
        }

        /******** Methods *********/

        private void UpdateProgressBar()
        {
            progressBar.PerformStep();
            if (progressBar.Value.Equals(progressBar.Maximum))
            {
                lblProgressBar.Text = @"IDLE";
                progressBar.Value = 1;
            }

            Application.DoEvents();
        }

        private void SetProgressBarValues(int minValue, int maxValue, int stepValue, string labelText, int bgColor)
        {
            lblProgressBar.Text = !string.IsNullOrWhiteSpace(labelText) ? labelText : @"PROCESSING";

            progressBar.BackColor = bgColor == 0 ? Color.Green : Color.Goldenrod;
            progressBar.Visible = true;
            progressBar.Minimum = minValue;
            progressBar.Maximum = maxValue;
            progressBar.Step = stepValue;
            Application.DoEvents();
        }

        private void ProcessWorkload()
        {
            DisableUi();
            SetProgressBarValues(1, Workload.Count, 1, "MOVING MEDIA FILES TO CORRESPONDING FOLDERS", 0);
            tbConsole.AppendText("\n ------ Starting Workload ------");
            Application.DoEvents();

            foreach (var item in Workload)
            {
                if (item.IsDuplicate && !cbOverwrite.Checked) continue;

                var formattedDate = cbCustomDateFormat.Checked && !string.IsNullOrWhiteSpace(tbCustomDateFormat.Text)
                    ? item.Date.ToString(tbCustomDateFormat.Text)
                    : item.Date.ToString(Constants.DefaultDateFormat);

                var existingItem = CheckList.FirstOrDefault(c => c.Directory.FullName.Contains(formattedDate));

                tbConsole.AppendText(existingItem != null
                    ? $"\n Existing date formatted folder found for {item.FileName}."
                    : $"\n No matching date-folder found in target for {item.FileName}.");
                Application.DoEvents();

                var targetDateDirectory = existingItem != null ? $@"{existingItem.Directory.FullName}" : $@"{TargetPath}\{formattedDate}";
                try
                {
                    if (!Directory.Exists(targetDateDirectory)) Directory.CreateDirectory(targetDateDirectory); // Create directory if it doesn't exists, should always be the case when an existing item is found.
                }
                catch (Exception ex)
                {
                    tbConsole.SelectionColor = Color.IndianRed;
                    tbConsole.AppendText("\n [ERROR] - Failed to create folder.");
                    tbConsole.AppendText($"\n Error message: {ex.Message}");
                    Application.DoEvents();
                    tbConsole.SelectionColor = Color.Black;
                }

                tbConsole.SelectionColor = Color.Green;
                tbConsole.AppendText($"\n Moving item to date-folder {formattedDate} in target-folder.");
                Application.DoEvents();
                tbConsole.SelectionColor = Color.Black;

                // If the item is labeled as a duplicate, remove the original but only if overwrite is enabled
                // Else continue and skip the media item
                if (File.Exists($@"{targetDateDirectory}\{item.FileName}") && cbOverwrite.Checked)
                    File.Delete($@"{targetDateDirectory}\{item.FileName}");
                else if (File.Exists($@"{targetDateDirectory}\{item.FileName}") && !cbOverwrite.Checked)
                    continue;

                if (cbCopyOnly.Checked)
                    File.Copy(item.FullFileName, $@"{targetDateDirectory}\{item.FileName}");
                else
                    File.Move(item.FullFileName, $@"{targetDateDirectory}\{item.FileName}");

                item.MoveLocation = targetDateDirectory;
                item.IsProcessed = true;

                tbConsole.SelectionColor = Color.Green;
                tbConsole.AppendText("- Done.");
                Application.DoEvents();
                tbConsole.SelectionColor = Color.Black;
                
                UpdateProcessedItems();
            }

            tbConsole.SelectionColor = Color.Green;
            tbConsole.AppendText("\n ALL DONE!");
            btnStart.Enabled = false;
            DisableUi(false);
        }

        private void UpdateProcessedItems()
        {
            tbNumberOfItemsProcessed.Text = Workload.Count(w => w.IsProcessed).ToString();
            UpdateProgressBar();
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
                btnStart.BackColor = Color.IndianRed;
            }
            else
            {
                btnSource.Enabled = true;
                if (!string.IsNullOrWhiteSpace(SourcePath))
                {
                    btnSource.BackColor = Color.ForestGreen;
                    btnSource.Text = @"Change";
                }

                btnTarget.Enabled = true;
                if (!string.IsNullOrWhiteSpace(TargetPath))
                {
                    btnTarget.BackColor = Color.ForestGreen;
                    btnTarget.Text = @"Change";
                }

                btnStart.Enabled = !string.IsNullOrWhiteSpace(SourcePath) && !string.IsNullOrWhiteSpace(TargetPath);
                if (!btnStart.Enabled) return;
                btnStart.BackColor = Color.ForestGreen;
            }
        }
    }
}
namespace MediaSorter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Helpers;
    using OpenCvSharp;
    using Size = System.Drawing.Size;

    public partial class FormDeleteMoveBadImages : Form
    {
        public FormDeleteMoveBadImages()
        {
            InitializeComponent();
            MediaAnalyzer.InitProgressBar += SetProgressBarValues;
            MediaAnalyzer.ProcessProgressBar += UpdateProgressBar;

            tbConsole.Clear();

            tbSource.Enabled = false;
            tbNumberOfItemsProcessed.Enabled = false;
            tbTotalNumberOfItems.Enabled = false;

            tbNumberOfItemsProcessed.Text = @"0";
            tbTotalNumberOfItems.Text = @"0";
            tbNumberOfItemsProcessed.Text = @"0";

            tbCustomThreshold.Text = $@"{Constants.DefaultThreshold}";

            lblProgressBar.Text = @"IDLE";
            lblProgressBar.BackColor = Color.Transparent;
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = 1;
            progressBar.Value = 1;
            progressBar.Step = 1;

            btnStart.Enabled = !string.IsNullOrWhiteSpace(SourcePath);
        }

        /******** Paths and raw paths *********/
        private string SourcePath { get; set; }
        private List<string> SourceFiles { get; set; }
        private string TargetPath { get; set; }

        private double Threshhold { get; set; }


        /******** Workload and Checklist *********/
        private List<MediaItem> Workload { get; set; }


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

        private void btnMoveTargetFolder_Click(object sender, EventArgs e)
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

                tbConsole.AppendText($"\n [TARGET] Path set to ( {fbd.SelectedPath} )");
                Application.DoEvents();

                TargetPath = fbd.SelectedPath;
                tbMoveTargetFolder.Text = TargetPath;
            }

            DisableUi(false);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!Workload.Any() || string.IsNullOrWhiteSpace(TargetPath) || string.IsNullOrWhiteSpace(SourcePath))
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
            SetProgressBarValues(1, Workload.Count, 1, "PROCESSING IMAGE FILES", 0);
            tbConsole.AppendText("\n ------ Starting Workload ------");
            Application.DoEvents();

            foreach (var item in Workload)
            {
                if (item.MediaType != FileHelper.MediaType.Image)
                {
                    UpdateProcessedItems();
                    continue;
                }

                Threshhold = cbCustomThreshold.Checked && !string.IsNullOrWhiteSpace(tbCustomThreshold.Text)
                    ? double.Parse(tbCustomThreshold.Text)
                    : Constants.DefaultThreshold;

                tbConsole.AppendText($"\n Analyzing");

                var tempResizeImage = Tools.ResizeImage(item.FullFileName, item.ImageOrientation == Orientation.Horizontal
                    ? new Size(1920, 1080)
                    : new Size(1080, 1920));

                if (tempResizeImage == null)
                {
                    UpdateProcessedItems();
                    continue;
                }

                var imageConverter = new ImageConverter();
                var xByte = (byte[])imageConverter.ConvertTo(tempResizeImage, typeof(byte[]));
                var src = Cv2.ImDecode(xByte.ToArray(), ImreadModes.Grayscale);
                var blurIndex = Math.Round(MediaAnalyzer.CalcBlurriness(src),1);
                src.Dispose();

                if (blurIndex > Threshhold)
                {
                    tbConsole.AppendText($" INDEX: {blurIndex} [{item.ImageSize.Width} x {item.ImageSize.Height}] - ");
                    Application.DoEvents();

                    if (cbMoveImagesToFolder.Checked)
                    {
                        File.Move(item.FullFileName, $@"{TargetPath}\{item.FileName}");
                        tbConsole.AppendText($"Moved! [{item.FileName}]");
                    }
                    else
                    {
                        File.Delete(item.FullFileName);
                        tbConsole.AppendText($"Deleted! [{item.FileName}]");
                    }

                    Application.DoEvents();

                    item.MoveLocation = TargetPath;
                    item.IsProcessed = true;

                    UpdateProcessedItems();

                    continue;
                }

                item.IsProcessed = true;

                tbConsole.AppendText($" INDEX: {blurIndex} [{item.ImageSize.Width} x {item.ImageSize.Height}] - Quality OK. [{item.FileName}]");
                Application.DoEvents();

                UpdateProcessedItems();
            }

            tbConsole.AppendText("\n ALL DONE!");
            btnStart.Enabled = false;
            DisableUi(false);
        }

        private void DisableUi(bool disable = true)
        {
            if (disable)
            {
                btnSource.Enabled = false;
                btnMoveTargetFolder.Enabled = false;
                btnStart.Enabled = false;
                btnStart.BackColor = Color.IndianRed;
            }
            else
            {
                btnSource.Enabled = true;
                btnMoveTargetFolder.Enabled = true;
                if (!string.IsNullOrWhiteSpace(SourcePath))
                {
                    btnSource.BackColor = Color.GreenYellow;
                    btnSource.Text = @"Change";
                }

                if (cbMoveImagesToFolder.Checked && !string.IsNullOrWhiteSpace(TargetPath))
                {
                    btnMoveTargetFolder.BackColor = Color.GreenYellow;
                    btnMoveTargetFolder.Text = @"Change";
                }

                btnStart.Enabled = !string.IsNullOrWhiteSpace(SourcePath);
                if (!btnStart.Enabled) return;
                btnStart.BackColor = Color.GreenYellow;
                btnStart.ForeColor = Color.Azure;
            }
        }

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

        private void UpdateProcessedItems()
        {
            tbNumberOfItemsProcessed.Text = Workload.Count(w => w.IsProcessed).ToString();
            UpdateProgressBar();
            Application.DoEvents();
        }
    }
}
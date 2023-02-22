namespace MediaSorter;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
using Models;

public partial class FormRestructure : Form
{
    /******** Work vars *********/

    public FormRestructure()
    {
        InitializeComponent();
        MediaAnalyzer.InitProgressBar += SetProgressBarValues;
        MediaAnalyzer.ProcessProgressBar += UpdateProgressBar;

        tbConsole.Clear();
        tbSource.Enabled = false;
        tbTotalNumberOfItems.Enabled = false;
        tbTotalNumberOfItems.Text = @"0";
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
    private string SelectedPath { get; set; }
    private List<string> SourceFiles { get; set; }

    /******** Workload and Checklist *********/
    private List<MediaItem> Workload { get; set; }
    private List<MediaItem> CheckList { get; set; }

    /******** Button Click-events *********/
    private async void btnSource_Click(object sender, EventArgs e)
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

            SelectedPath = fbd.SelectedPath;

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
        Workload = await MediaAnalyzer.GatherMediaInformation(SourceFiles, cbAppendAddress.Checked);
        tbConsole.Text += @" - Done";

        tbConsole.AppendText("\n Setting values for the check list, based on the source folder");
        Application.DoEvents();

        // Set same list to check against as the Source folder.
        CheckList = Workload;
        tbConsole.Text += @" - Done";

        // Set Progressbar
        progressBar.Maximum = Workload.Count;
        progressBar.Value = 1;

        CheckDuplicates();

        DisableUi(false);
    }

    private async void btnStart_Click(object sender, EventArgs e)
    {
        if (!Workload.Any() || string.IsNullOrWhiteSpace(SourcePath))
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

        await ProcessWorkload();
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

    private async Task ProcessWorkload()
    {
        DisableUi();
        SetProgressBarValues(1, Workload.Count, 1, "MOVING MEDIA FILES TO CORRESPONDING FOLDERS", 0);
        tbConsole.AppendText("\n ------ Starting Workload ------");
        Application.DoEvents();

        foreach (var item in Workload)
        {
            if (item.IsDuplicate) continue;

            var formattedDate = cbCustomDateFormat.Checked && !string.IsNullOrWhiteSpace(tbCustomDateFormat.Text)
                ? item.Date.ToString(tbCustomDateFormat.Text)
                : item.Date.ToString(Constants.DefaultDateFormat);

            var existingItem = CheckList.FirstOrDefault(c => c.Directory.FullName.Contains(formattedDate));

            tbConsole.AppendText(existingItem != null
                ? $"\n Existing date formatted folder found for {item.FileName}."
                : $"\n No matching date-folder found in target for {item.FileName}.");
            Application.DoEvents();

            var targetDateDirectory = existingItem != null
                ? $@"{existingItem.Directory.FullName}"
                : $@"{SourcePath}\{formattedDate}";
            try
            {
                if (!Directory.Exists(targetDateDirectory))
                    Directory.CreateDirectory(targetDateDirectory); // Create directory if it doesn't exists, should always be the case when an existing item is found.
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

            // If the files already exists, continue and skip the media item
            if (File.Exists($@"{targetDateDirectory}\{item.FileName}"))
            {
                tbConsole.SelectionColor = Color.DodgerBlue;
                tbConsole.AppendText($"\n File already in correct date-folder {formattedDate} SKIPPING.");
                Application.DoEvents();
                tbConsole.SelectionColor = Color.Black;
                continue;
            }

            File.Move(item.FullFileName, $@"{targetDateDirectory}\{item.FileName}");

            item.MoveLocation = targetDateDirectory;
            item.IsProcessed = true;

            tbConsole.SelectionColor = Color.Green;
            tbConsole.AppendText("- Done.");
            Application.DoEvents();
            tbConsole.SelectionColor = Color.Black;

            UpdateProcessedItems();
        }

        tbConsole.AppendText("\n Deleting empty folders in target folder.");
        Application.DoEvents();
        tbConsole.SelectionColor = Color.Black;
        DeleteEmptyDirectories(SourcePath);
        tbConsole.SelectionColor = Color.Green;
        tbConsole.AppendText("- Done.");

        if (cbAppendAddress.Checked)
        {
            tbConsole.AppendText("\n Appending address to created folders for known locations from media files.");
            Application.DoEvents();
            tbConsole.SelectionColor = Color.Black;
            await AppendAddressToDirectories();
            tbConsole.SelectionColor = Color.Green;
            tbConsole.AppendText("- Done.");
        }

        tbConsole.SelectionColor = Color.Green;
        tbConsole.AppendText("\n ALL DONE!");
        Application.DoEvents();
        btnStart.Enabled = false;

        DisableUi(false);
    }

    private async Task AppendAddressToDirectories()
    {
        var files = Directory.EnumerateFiles(SelectedPath, "*", SearchOption.AllDirectories).ToList();
        SourceFiles = FileHelper.FilterMediaFiles(files);
        Workload = await MediaAnalyzer.GatherMediaInformation(SourceFiles, cbAppendAddress.Checked);

        foreach (var item in Workload.Where(item => item.FormattedAddress != null))
        {
            try
            {
                if(!Directory.Exists(item.Directory.FullName))
                    continue;

                if(item.Directory.FullName.Contains(item.FormattedAddress)) 
                    continue;
                
                tbConsole.SelectionColor = Color.Orange;
                tbConsole.AppendText($"\n Appending address from {item.FileName} to {item.Directory.Name}");
                Application.DoEvents();
                Directory.Move(item.Directory.FullName, $@"{item.Directory.FullName} {item.FormattedAddress}");
                tbConsole.SelectionColor = Color.Green;
                tbConsole.AppendText("- Done.");
            }
            catch (Exception e)
            {
                tbConsole.SelectionColor = Color.Red;
                tbConsole.AppendText($"\n Appending address from {item.FileName} to {item.Directory.Name}. Error: {e.Message}");
                Application.DoEvents();
                tbConsole.SelectionColor = Color.Black;
            }
        }
            
    }

    private void UpdateProcessedItems()
    {
        UpdateProgressBar();
        Application.DoEvents();
    }

    private void CheckDuplicates()
    {
        foreach (var item in Workload) item.IsDuplicate = CheckList.Count(i => i.FileName.Equals(item.FileName)) > 1;
    }

    private void DeleteEmptyDirectories(string target_dir)
    {
        var dirs = Directory.GetDirectories(target_dir);

        foreach (var dir in dirs)
        {
            DeleteEmptyDirectories(dir);
            if (Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0) Directory.Delete(dir);
        }
    }

    private void DisableUi(bool disable = true)
    {
        if (disable)
        {
            btnSource.Enabled = false;
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

            btnStart.Enabled = !string.IsNullOrWhiteSpace(SourcePath);
            if (!btnStart.Enabled) return;
            btnStart.BackColor = Color.ForestGreen;
        }
    }

    private void lblTitle_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
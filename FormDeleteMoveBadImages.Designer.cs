namespace MediaSorter
{
    using System.ComponentModel;

    partial class FormDeleteMoveBadImages
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.tbNumberOfItemsProcessed = new System.Windows.Forms.TextBox();
            this.lblItemsProcessed = new System.Windows.Forms.Label();
            this.tbTotalNumberOfItems = new System.Windows.Forms.TextBox();
            this.lblTotalNumberOfItems = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.tbConsole = new System.Windows.Forms.RichTextBox();
            this.grpBoxParams = new System.Windows.Forms.GroupBox();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.lblParamSource = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.grpBoxOptions = new System.Windows.Forms.GroupBox();
            this.tbMoveTargetFolder = new System.Windows.Forms.TextBox();
            this.btnMoveTargetFolder = new System.Windows.Forms.Button();
            this.cbMoveImagesToFolder = new System.Windows.Forms.CheckBox();
            this.cbCustomThreshold = new System.Windows.Forms.CheckBox();
            this.tbCustomThreshold = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBoxStep1 = new System.Windows.Forms.GroupBox();
            this.lblSelectSource = new System.Windows.Forms.Label();
            this.btnSource = new System.Windows.Forms.Button();
            this.gbValues.SuspendLayout();
            this.grpBoxParams.SuspendLayout();
            this.grpBoxOptions.SuspendLayout();
            this.grpBoxStep1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBar.Location = new System.Drawing.Point(393, 361);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(572, 19);
            this.lblProgressBar.TabIndex = 23;
            this.lblProgressBar.Text = "No task";
            this.lblProgressBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(393, 342);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(572, 16);
            this.progressBar.TabIndex = 22;
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.tbNumberOfItemsProcessed);
            this.gbValues.Controls.Add(this.lblItemsProcessed);
            this.gbValues.Controls.Add(this.tbTotalNumberOfItems);
            this.gbValues.Controls.Add(this.lblTotalNumberOfItems);
            this.gbValues.Location = new System.Drawing.Point(393, 233);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(356, 88);
            this.gbValues.TabIndex = 21;
            this.gbValues.TabStop = false;
            this.gbValues.Text = "Values";
            // 
            // tbNumberOfItemsProcessed
            // 
            this.tbNumberOfItemsProcessed.Location = new System.Drawing.Point(182, 48);
            this.tbNumberOfItemsProcessed.Name = "tbNumberOfItemsProcessed";
            this.tbNumberOfItemsProcessed.Size = new System.Drawing.Size(75, 20);
            this.tbNumberOfItemsProcessed.TabIndex = 3;
            // 
            // lblItemsProcessed
            // 
            this.lblItemsProcessed.Location = new System.Drawing.Point(21, 51);
            this.lblItemsProcessed.Name = "lblItemsProcessed";
            this.lblItemsProcessed.Size = new System.Drawing.Size(155, 17);
            this.lblItemsProcessed.TabIndex = 2;
            this.lblItemsProcessed.Text = "Number of items processed: ";
            // 
            // tbTotalNumberOfItems
            // 
            this.tbTotalNumberOfItems.Location = new System.Drawing.Point(182, 22);
            this.tbTotalNumberOfItems.Name = "tbTotalNumberOfItems";
            this.tbTotalNumberOfItems.Size = new System.Drawing.Size(75, 20);
            this.tbTotalNumberOfItems.TabIndex = 1;
            // 
            // lblTotalNumberOfItems
            // 
            this.lblTotalNumberOfItems.Location = new System.Drawing.Point(21, 25);
            this.lblTotalNumberOfItems.Name = "lblTotalNumberOfItems";
            this.lblTotalNumberOfItems.Size = new System.Drawing.Size(155, 17);
            this.lblTotalNumberOfItems.TabIndex = 0;
            this.lblTotalNumberOfItems.Text = "Total number of items found: ";
            // 
            // lblLog
            // 
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(28, 419);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(115, 17);
            this.lblLog.TabIndex = 20;
            this.lblLog.Text = "Activity";
            // 
            // tbConsole
            // 
            this.tbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsole.Location = new System.Drawing.Point(28, 437);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(937, 228);
            this.tbConsole.TabIndex = 19;
            this.tbConsole.Text = "";
            // 
            // grpBoxParams
            // 
            this.grpBoxParams.Controls.Add(this.tbSource);
            this.grpBoxParams.Controls.Add(this.lblParamSource);
            this.grpBoxParams.Location = new System.Drawing.Point(393, 80);
            this.grpBoxParams.Name = "grpBoxParams";
            this.grpBoxParams.Size = new System.Drawing.Size(572, 70);
            this.grpBoxParams.TabIndex = 18;
            this.grpBoxParams.TabStop = false;
            this.grpBoxParams.Text = "Parameters";
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(83, 26);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(468, 20);
            this.tbSource.TabIndex = 1;
            // 
            // lblParamSource
            // 
            this.lblParamSource.Location = new System.Drawing.Point(21, 29);
            this.lblParamSource.Name = "lblParamSource";
            this.lblParamSource.Size = new System.Drawing.Size(64, 16);
            this.lblParamSource.TabIndex = 0;
            this.lblParamSource.Text = "Source";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.IndianRed;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(28, 342);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(342, 41);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpBoxOptions
            // 
            this.grpBoxOptions.Controls.Add(this.tbMoveTargetFolder);
            this.grpBoxOptions.Controls.Add(this.btnMoveTargetFolder);
            this.grpBoxOptions.Controls.Add(this.cbMoveImagesToFolder);
            this.grpBoxOptions.Controls.Add(this.cbCustomThreshold);
            this.grpBoxOptions.Controls.Add(this.tbCustomThreshold);
            this.grpBoxOptions.Location = new System.Drawing.Point(28, 184);
            this.grpBoxOptions.Name = "grpBoxOptions";
            this.grpBoxOptions.Size = new System.Drawing.Size(342, 137);
            this.grpBoxOptions.TabIndex = 16;
            this.grpBoxOptions.TabStop = false;
            this.grpBoxOptions.Text = "Options";
            // 
            // tbMoveTargetFolder
            // 
            this.tbMoveTargetFolder.Location = new System.Drawing.Point(24, 95);
            this.tbMoveTargetFolder.Name = "tbMoveTargetFolder";
            this.tbMoveTargetFolder.Size = new System.Drawing.Size(281, 20);
            this.tbMoveTargetFolder.TabIndex = 6;
            // 
            // btnMoveTargetFolder
            // 
            this.btnMoveTargetFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveTargetFolder.Location = new System.Drawing.Point(195, 59);
            this.btnMoveTargetFolder.Name = "btnMoveTargetFolder";
            this.btnMoveTargetFolder.Size = new System.Drawing.Size(110, 24);
            this.btnMoveTargetFolder.TabIndex = 2;
            this.btnMoveTargetFolder.Text = "Select";
            this.btnMoveTargetFolder.UseVisualStyleBackColor = true;
            this.btnMoveTargetFolder.Click += new System.EventHandler(this.btnMoveTargetFolder_Click);
            // 
            // cbMoveImagesToFolder
            // 
            this.cbMoveImagesToFolder.Location = new System.Drawing.Point(24, 59);
            this.cbMoveImagesToFolder.Name = "cbMoveImagesToFolder";
            this.cbMoveImagesToFolder.Size = new System.Drawing.Size(165, 24);
            this.cbMoveImagesToFolder.TabIndex = 5;
            this.cbMoveImagesToFolder.Text = "Move bad images to folder";
            this.cbMoveImagesToFolder.UseVisualStyleBackColor = true;
            // 
            // cbCustomThreshold
            // 
            this.cbCustomThreshold.Location = new System.Drawing.Point(24, 29);
            this.cbCustomThreshold.Name = "cbCustomThreshold";
            this.cbCustomThreshold.Size = new System.Drawing.Size(165, 24);
            this.cbCustomThreshold.TabIndex = 4;
            this.cbCustomThreshold.Text = "Use custom index threshold";
            this.cbCustomThreshold.UseVisualStyleBackColor = true;
            // 
            // tbCustomThreshold
            // 
            this.tbCustomThreshold.Location = new System.Drawing.Point(195, 31);
            this.tbCustomThreshold.Name = "tbCustomThreshold";
            this.tbCustomThreshold.Size = new System.Drawing.Size(110, 20);
            this.tbCustomThreshold.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(28, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(937, 37);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Handle bad/blurry images";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpBoxStep1
            // 
            this.grpBoxStep1.Controls.Add(this.lblSelectSource);
            this.grpBoxStep1.Controls.Add(this.btnSource);
            this.grpBoxStep1.Location = new System.Drawing.Point(28, 80);
            this.grpBoxStep1.Name = "grpBoxStep1";
            this.grpBoxStep1.Size = new System.Drawing.Size(342, 97);
            this.grpBoxStep1.TabIndex = 14;
            this.grpBoxStep1.TabStop = false;
            this.grpBoxStep1.Text = "Set source and target";
            // 
            // lblSelectSource
            // 
            this.lblSelectSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectSource.Location = new System.Drawing.Point(24, 41);
            this.lblSelectSource.Name = "lblSelectSource";
            this.lblSelectSource.Size = new System.Drawing.Size(62, 29);
            this.lblSelectSource.TabIndex = 1;
            this.lblSelectSource.Text = "Source";
            // 
            // btnSource
            // 
            this.btnSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSource.Location = new System.Drawing.Point(109, 35);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(110, 35);
            this.btnSource.TabIndex = 0;
            this.btnSource.Text = "Select";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // FormDeleteMoveBadImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1007, 696);
            this.Controls.Add(this.lblProgressBar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.gbValues);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.grpBoxParams);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpBoxOptions);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpBoxStep1);
            this.Name = "FormDeleteMoveBadImages";
            this.Text = "Delete of move bad images";
            this.gbValues.ResumeLayout(false);
            this.gbValues.PerformLayout();
            this.grpBoxParams.ResumeLayout(false);
            this.grpBoxParams.PerformLayout();
            this.grpBoxOptions.ResumeLayout(false);
            this.grpBoxOptions.PerformLayout();
            this.grpBoxStep1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblProgressBar;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox gbValues;
        private System.Windows.Forms.TextBox tbNumberOfItemsProcessed;
        private System.Windows.Forms.Label lblItemsProcessed;
        private System.Windows.Forms.TextBox tbTotalNumberOfItems;
        private System.Windows.Forms.Label lblTotalNumberOfItems;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.RichTextBox tbConsole;
        private System.Windows.Forms.GroupBox grpBoxParams;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Label lblParamSource;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox grpBoxOptions;
        private System.Windows.Forms.CheckBox cbCustomThreshold;
        private System.Windows.Forms.TextBox tbCustomThreshold;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpBoxStep1;
        private System.Windows.Forms.Label lblSelectSource;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.CheckBox cbMoveImagesToFolder;
        private System.Windows.Forms.Button btnMoveTargetFolder;
        private System.Windows.Forms.TextBox tbMoveTargetFolder;

        #endregion
    }
}
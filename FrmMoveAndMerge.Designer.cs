namespace MediaSorter
{
    using System.ComponentModel;

    partial class FrmMoveAndMerge
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
            this.btnSource = new System.Windows.Forms.Button();
            this.lblSelectSource = new System.Windows.Forms.Label();
            this.lblSelectTarget = new System.Windows.Forms.Label();
            this.btnTarget = new System.Windows.Forms.Button();
            this.grpBoxStep1 = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBoxOptions = new System.Windows.Forms.GroupBox();
            this.cbCustomDateFormat = new System.Windows.Forms.CheckBox();
            this.tbCustomDateFormat = new System.Windows.Forms.TextBox();
            this.cbSizeContent = new System.Windows.Forms.CheckBox();
            this.cbCopyOnly = new System.Windows.Forms.CheckBox();
            this.cbOverwrite = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.grpBoxParams = new System.Windows.Forms.GroupBox();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.lblParamTarget = new System.Windows.Forms.Label();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.lblParamSource = new System.Windows.Forms.Label();
            this.tbConsole = new System.Windows.Forms.RichTextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.tbDuplicates = new System.Windows.Forms.TextBox();
            this.lblDuplicates = new System.Windows.Forms.Label();
            this.tbNumberOfItemsProcessed = new System.Windows.Forms.TextBox();
            this.lblItemsProcessed = new System.Windows.Forms.Label();
            this.tbTotalNumberOfItems = new System.Windows.Forms.TextBox();
            this.lblTotalNumberOfItems = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.grpBoxStep1.SuspendLayout();
            this.grpBoxOptions.SuspendLayout();
            this.grpBoxParams.SuspendLayout();
            this.gbValues.SuspendLayout();
            this.SuspendLayout();
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
            // lblSelectSource
            // 
            this.lblSelectSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectSource.Location = new System.Drawing.Point(24, 41);
            this.lblSelectSource.Name = "lblSelectSource";
            this.lblSelectSource.Size = new System.Drawing.Size(62, 29);
            this.lblSelectSource.TabIndex = 1;
            this.lblSelectSource.Text = "Source";
            // 
            // lblSelectTarget
            // 
            this.lblSelectTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectTarget.Location = new System.Drawing.Point(24, 99);
            this.lblSelectTarget.Name = "lblSelectTarget";
            this.lblSelectTarget.Size = new System.Drawing.Size(62, 29);
            this.lblSelectTarget.TabIndex = 3;
            this.lblSelectTarget.Text = "Target";
            // 
            // btnTarget
            // 
            this.btnTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarget.Location = new System.Drawing.Point(109, 93);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(110, 35);
            this.btnTarget.TabIndex = 2;
            this.btnTarget.Text = "Select";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // grpBoxStep1
            // 
            this.grpBoxStep1.Controls.Add(this.lblSelectTarget);
            this.grpBoxStep1.Controls.Add(this.btnTarget);
            this.grpBoxStep1.Controls.Add(this.lblSelectSource);
            this.grpBoxStep1.Controls.Add(this.btnSource);
            this.grpBoxStep1.Location = new System.Drawing.Point(25, 73);
            this.grpBoxStep1.Name = "grpBoxStep1";
            this.grpBoxStep1.Size = new System.Drawing.Size(342, 161);
            this.grpBoxStep1.TabIndex = 4;
            this.grpBoxStep1.TabStop = false;
            this.grpBoxStep1.Text = "Set source and target";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(352, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(265, 37);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Move And Merge";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grpBoxOptions
            // 
            this.grpBoxOptions.Controls.Add(this.cbCustomDateFormat);
            this.grpBoxOptions.Controls.Add(this.tbCustomDateFormat);
            this.grpBoxOptions.Controls.Add(this.cbSizeContent);
            this.grpBoxOptions.Controls.Add(this.cbCopyOnly);
            this.grpBoxOptions.Controls.Add(this.cbOverwrite);
            this.grpBoxOptions.Location = new System.Drawing.Point(25, 252);
            this.grpBoxOptions.Name = "grpBoxOptions";
            this.grpBoxOptions.Size = new System.Drawing.Size(342, 158);
            this.grpBoxOptions.TabIndex = 6;
            this.grpBoxOptions.TabStop = false;
            this.grpBoxOptions.Text = "Options";
            // 
            // cbCustomDateFormat
            // 
            this.cbCustomDateFormat.Location = new System.Drawing.Point(24, 114);
            this.cbCustomDateFormat.Name = "cbCustomDateFormat";
            this.cbCustomDateFormat.Size = new System.Drawing.Size(165, 24);
            this.cbCustomDateFormat.TabIndex = 4;
            this.cbCustomDateFormat.Text = "Use custom date formatting";
            this.cbCustomDateFormat.UseVisualStyleBackColor = true;
            // 
            // tbCustomDateFormat
            // 
            this.tbCustomDateFormat.Location = new System.Drawing.Point(195, 116);
            this.tbCustomDateFormat.Name = "tbCustomDateFormat";
            this.tbCustomDateFormat.Size = new System.Drawing.Size(110, 20);
            this.tbCustomDateFormat.TabIndex = 3;
            // 
            // cbSizeContent
            // 
            this.cbSizeContent.Location = new System.Drawing.Point(24, 88);
            this.cbSizeContent.Name = "cbSizeContent";
            this.cbSizeContent.Size = new System.Drawing.Size(236, 24);
            this.cbSizeContent.TabIndex = 2;
            this.cbSizeContent.Text = "Check by size/content";
            this.cbSizeContent.UseVisualStyleBackColor = true;
            // 
            // cbCopyOnly
            // 
            this.cbCopyOnly.Location = new System.Drawing.Point(24, 58);
            this.cbCopyOnly.Name = "cbCopyOnly";
            this.cbCopyOnly.Size = new System.Drawing.Size(236, 24);
            this.cbCopyOnly.TabIndex = 1;
            this.cbCopyOnly.Text = "Copy files instead of move";
            this.cbCopyOnly.UseVisualStyleBackColor = true;
            // 
            // cbOverwrite
            // 
            this.cbOverwrite.Location = new System.Drawing.Point(24, 28);
            this.cbOverwrite.Name = "cbOverwrite";
            this.cbOverwrite.Size = new System.Drawing.Size(236, 24);
            this.cbOverwrite.TabIndex = 0;
            this.cbOverwrite.Text = "Overwrite all when duplicates are found";
            this.cbOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MistyRose;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(25, 454);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(342, 41);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpBoxParams
            // 
            this.grpBoxParams.Controls.Add(this.tbTarget);
            this.grpBoxParams.Controls.Add(this.lblParamTarget);
            this.grpBoxParams.Controls.Add(this.tbSource);
            this.grpBoxParams.Controls.Add(this.lblParamSource);
            this.grpBoxParams.Location = new System.Drawing.Point(390, 73);
            this.grpBoxParams.Name = "grpBoxParams";
            this.grpBoxParams.Size = new System.Drawing.Size(572, 86);
            this.grpBoxParams.TabIndex = 8;
            this.grpBoxParams.TabStop = false;
            this.grpBoxParams.Text = "Parameters";
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(83, 52);
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(468, 20);
            this.tbTarget.TabIndex = 3;
            // 
            // lblParamTarget
            // 
            this.lblParamTarget.Location = new System.Drawing.Point(21, 54);
            this.lblParamTarget.Name = "lblParamTarget";
            this.lblParamTarget.Size = new System.Drawing.Size(64, 16);
            this.lblParamTarget.TabIndex = 2;
            this.lblParamTarget.Text = "Target";
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
            // tbConsole
            // 
            this.tbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsole.Location = new System.Drawing.Point(390, 313);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(572, 182);
            this.tbConsole.TabIndex = 9;
            this.tbConsole.Text = "";
            // 
            // lblLog
            // 
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(390, 293);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(115, 17);
            this.lblLog.TabIndex = 10;
            this.lblLog.Text = "Activity";
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.tbDuplicates);
            this.gbValues.Controls.Add(this.lblDuplicates);
            this.gbValues.Controls.Add(this.tbNumberOfItemsProcessed);
            this.gbValues.Controls.Add(this.lblItemsProcessed);
            this.gbValues.Controls.Add(this.tbTotalNumberOfItems);
            this.gbValues.Controls.Add(this.lblTotalNumberOfItems);
            this.gbValues.Location = new System.Drawing.Point(390, 162);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(356, 128);
            this.gbValues.TabIndex = 11;
            this.gbValues.TabStop = false;
            this.gbValues.Text = "Values";
            // 
            // tbDuplicates
            // 
            this.tbDuplicates.Location = new System.Drawing.Point(182, 52);
            this.tbDuplicates.Name = "tbDuplicates";
            this.tbDuplicates.Size = new System.Drawing.Size(75, 20);
            this.tbDuplicates.TabIndex = 5;
            // 
            // lblDuplicates
            // 
            this.lblDuplicates.Location = new System.Drawing.Point(21, 55);
            this.lblDuplicates.Name = "lblDuplicates";
            this.lblDuplicates.Size = new System.Drawing.Size(155, 17);
            this.lblDuplicates.TabIndex = 4;
            this.lblDuplicates.Text = "Number of duplicates found: ";
            // 
            // tbNumberOfItemsProcessed
            // 
            this.tbNumberOfItemsProcessed.Location = new System.Drawing.Point(182, 87);
            this.tbNumberOfItemsProcessed.Name = "tbNumberOfItemsProcessed";
            this.tbNumberOfItemsProcessed.Size = new System.Drawing.Size(75, 20);
            this.tbNumberOfItemsProcessed.TabIndex = 3;
            // 
            // lblItemsProcessed
            // 
            this.lblItemsProcessed.Location = new System.Drawing.Point(21, 90);
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
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(25, 425);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(342, 23);
            this.progressBar.TabIndex = 12;
            // 
            // FrmMoveAndMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 528);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.gbValues);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.grpBoxParams);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpBoxOptions);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpBoxStep1);
            this.Name = "FrmMoveAndMerge";
            this.Text = "Move And Merge";
            this.grpBoxStep1.ResumeLayout(false);
            this.grpBoxOptions.ResumeLayout(false);
            this.grpBoxOptions.PerformLayout();
            this.grpBoxParams.ResumeLayout(false);
            this.grpBoxParams.PerformLayout();
            this.gbValues.ResumeLayout(false);
            this.gbValues.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ProgressBar progressBar;

        private System.Windows.Forms.Label lblTotalNumberOfItems;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblParamSource;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblParamTarget;
        private System.Windows.Forms.Label lblSelectTarget;
        private System.Windows.Forms.Label lblSelectSource;
        private System.Windows.Forms.Label lblItemsProcessed;
        private System.Windows.Forms.Label lblDuplicates;

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Button btnSource;
        
        private System.Windows.Forms.CheckBox cbOverwrite;
        private System.Windows.Forms.CheckBox cbCopyOnly;
        private System.Windows.Forms.CheckBox cbSizeContent;
        private System.Windows.Forms.CheckBox cbCustomDateFormat;
        
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.TextBox tbTotalNumberOfItems;
        private System.Windows.Forms.TextBox tbNumberOfItemsProcessed;
        private System.Windows.Forms.TextBox tbDuplicates;
        private System.Windows.Forms.TextBox tbCustomDateFormat;

        private System.Windows.Forms.RichTextBox tbConsole;
        
        private System.Windows.Forms.GroupBox grpBoxOptions;
        private System.Windows.Forms.GroupBox grpBoxStep1;
        private System.Windows.Forms.GroupBox grpBoxParams;
        private System.Windows.Forms.GroupBox gbValues;

        #endregion
    }
}
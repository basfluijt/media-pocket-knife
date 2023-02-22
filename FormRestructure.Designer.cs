namespace MediaSorter
{
    using System.ComponentModel;

    partial class FormRestructure
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
            this.grpBoxStep1 = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBoxOptions = new System.Windows.Forms.GroupBox();
            this.cbAppendAddress = new System.Windows.Forms.CheckBox();
            this.cbCustomDateFormat = new System.Windows.Forms.CheckBox();
            this.tbCustomDateFormat = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.grpBoxParams = new System.Windows.Forms.GroupBox();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.lblParamSource = new System.Windows.Forms.Label();
            this.tbConsole = new System.Windows.Forms.RichTextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.tbTotalNumberOfItems = new System.Windows.Forms.TextBox();
            this.lblTotalNumberOfItems = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.grpBoxStep1.SuspendLayout();
            this.grpBoxOptions.SuspendLayout();
            this.grpBoxParams.SuspendLayout();
            this.gbValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSource
            // 
            this.btnSource.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSource.Location = new System.Drawing.Point(109, 35);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(110, 35);
            this.btnSource.TabIndex = 0;
            this.btnSource.Text = "Select";
            this.btnSource.UseVisualStyleBackColor = false;
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
            // grpBoxStep1
            // 
            this.grpBoxStep1.Controls.Add(this.lblSelectSource);
            this.grpBoxStep1.Controls.Add(this.btnSource);
            this.grpBoxStep1.Location = new System.Drawing.Point(25, 73);
            this.grpBoxStep1.Name = "grpBoxStep1";
            this.grpBoxStep1.Size = new System.Drawing.Size(342, 86);
            this.grpBoxStep1.TabIndex = 4;
            this.grpBoxStep1.TabStop = false;
            this.grpBoxStep1.Text = "Set source";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(25, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(937, 37);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Restructure media folder";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // grpBoxOptions
            // 
            this.grpBoxOptions.Controls.Add(this.cbAppendAddress);
            this.grpBoxOptions.Controls.Add(this.cbCustomDateFormat);
            this.grpBoxOptions.Controls.Add(this.tbCustomDateFormat);
            this.grpBoxOptions.Location = new System.Drawing.Point(25, 165);
            this.grpBoxOptions.Name = "grpBoxOptions";
            this.grpBoxOptions.Size = new System.Drawing.Size(342, 128);
            this.grpBoxOptions.TabIndex = 6;
            this.grpBoxOptions.TabStop = false;
            this.grpBoxOptions.Text = "Options";
            // 
            // cbAppendAddress
            // 
            this.cbAppendAddress.Location = new System.Drawing.Point(24, 52);
            this.cbAppendAddress.Name = "cbAppendAddress";
            this.cbAppendAddress.Size = new System.Drawing.Size(165, 24);
            this.cbAppendAddress.TabIndex = 5;
            this.cbAppendAddress.Text = "Append address to folder name";
            this.cbAppendAddress.UseVisualStyleBackColor = true;
            // 
            // cbCustomDateFormat
            // 
            this.cbCustomDateFormat.Location = new System.Drawing.Point(24, 25);
            this.cbCustomDateFormat.Name = "cbCustomDateFormat";
            this.cbCustomDateFormat.Size = new System.Drawing.Size(165, 24);
            this.cbCustomDateFormat.TabIndex = 4;
            this.cbCustomDateFormat.Text = "Use custom date formatting";
            this.cbCustomDateFormat.UseVisualStyleBackColor = true;
            // 
            // tbCustomDateFormat
            // 
            this.tbCustomDateFormat.Location = new System.Drawing.Point(195, 27);
            this.tbCustomDateFormat.Name = "tbCustomDateFormat";
            this.tbCustomDateFormat.Size = new System.Drawing.Size(110, 20);
            this.tbCustomDateFormat.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.IndianRed;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(25, 326);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(342, 41);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpBoxParams
            // 
            this.grpBoxParams.Controls.Add(this.tbSource);
            this.grpBoxParams.Controls.Add(this.lblParamSource);
            this.grpBoxParams.Location = new System.Drawing.Point(390, 73);
            this.grpBoxParams.Name = "grpBoxParams";
            this.grpBoxParams.Size = new System.Drawing.Size(572, 86);
            this.grpBoxParams.TabIndex = 8;
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
            // tbConsole
            // 
            this.tbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsole.Location = new System.Drawing.Point(25, 404);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(937, 228);
            this.tbConsole.TabIndex = 9;
            this.tbConsole.Text = "";
            // 
            // lblLog
            // 
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(25, 386);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(115, 17);
            this.lblLog.TabIndex = 10;
            this.lblLog.Text = "Activity";
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.tbTotalNumberOfItems);
            this.gbValues.Controls.Add(this.lblTotalNumberOfItems);
            this.gbValues.Location = new System.Drawing.Point(390, 165);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(356, 128);
            this.gbValues.TabIndex = 11;
            this.gbValues.TabStop = false;
            this.gbValues.Text = "Values";
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
            this.progressBar.Location = new System.Drawing.Point(390, 326);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(572, 16);
            this.progressBar.TabIndex = 12;
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBar.Location = new System.Drawing.Point(390, 345);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(572, 19);
            this.lblProgressBar.TabIndex = 13;
            this.lblProgressBar.Text = "No task";
            this.lblProgressBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormRestructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(990, 664);
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
            this.Name = "FormRestructure";
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

        private System.Windows.Forms.CheckBox cbAppendAddress;


        public System.Windows.Forms.ProgressBar progressBar;

        private System.Windows.Forms.Label lblTotalNumberOfItems;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblParamSource;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblSelectSource;
        private System.Windows.Forms.Label lblProgressBar;

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSource;

        private System.Windows.Forms.CheckBox cbCustomDateFormat;
        
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.TextBox tbTotalNumberOfItems;
        private System.Windows.Forms.TextBox tbCustomDateFormat;

        private System.Windows.Forms.RichTextBox tbConsole;
        
        private System.Windows.Forms.GroupBox grpBoxOptions;
        private System.Windows.Forms.GroupBox grpBoxStep1;
        private System.Windows.Forms.GroupBox grpBoxParams;
        private System.Windows.Forms.GroupBox gbValues;

        #endregion
    }
}
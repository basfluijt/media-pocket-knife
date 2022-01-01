namespace MediaSorter
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnMoveAndMerge = new System.Windows.Forms.Button();
            this.btnUndouble = new System.Windows.Forms.Button();
            this.btnReorder = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDeleteBadImages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMoveAndMerge
            // 
            this.btnMoveAndMerge.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnMoveAndMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAndMerge.Location = new System.Drawing.Point(72, 117);
            this.btnMoveAndMerge.Name = "btnMoveAndMerge";
            this.btnMoveAndMerge.Size = new System.Drawing.Size(519, 34);
            this.btnMoveAndMerge.TabIndex = 0;
            this.btnMoveAndMerge.Text = "Merge two folders with media (date formatted)";
            this.btnMoveAndMerge.UseVisualStyleBackColor = false;
            this.btnMoveAndMerge.Click += new System.EventHandler(this.btnMoveAndMerge_Click);
            // 
            // btnUndouble
            // 
            this.btnUndouble.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnUndouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndouble.Location = new System.Drawing.Point(72, 197);
            this.btnUndouble.Name = "btnUndouble";
            this.btnUndouble.Size = new System.Drawing.Size(519, 34);
            this.btnUndouble.TabIndex = 1;
            this.btnUndouble.Text = "Handle duplicate media files";
            this.btnUndouble.UseVisualStyleBackColor = false;
            this.btnUndouble.Click += new System.EventHandler(this.btnUndouble_Click);
            // 
            // btnReorder
            // 
            this.btnReorder.BackColor = System.Drawing.Color.MistyRose;
            this.btnReorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReorder.Location = new System.Drawing.Point(72, 157);
            this.btnReorder.Name = "btnReorder";
            this.btnReorder.Size = new System.Drawing.Size(519, 34);
            this.btnReorder.TabIndex = 2;
            this.btnReorder.Text = "Restructure media within a folder (date formatted)";
            this.btnReorder.UseVisualStyleBackColor = false;
            this.btnReorder.Click += new System.EventHandler(this.btnReorder_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(199, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(269, 35);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Media Pocket Knife";
            // 
            // btnDeleteBadImages
            // 
            this.btnDeleteBadImages.BackColor = System.Drawing.Color.Thistle;
            this.btnDeleteBadImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBadImages.Location = new System.Drawing.Point(72, 237);
            this.btnDeleteBadImages.Name = "btnDeleteBadImages";
            this.btnDeleteBadImages.Size = new System.Drawing.Size(519, 34);
            this.btnDeleteBadImages.TabIndex = 4;
            this.btnDeleteBadImages.Text = "Handle bad/blurry images";
            this.btnDeleteBadImages.UseVisualStyleBackColor = false;
            this.btnDeleteBadImages.Click += new System.EventHandler(this.btnBlurred_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(661, 317);
            this.Controls.Add(this.btnDeleteBadImages);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnReorder);
            this.Controls.Add(this.btnUndouble);
            this.Controls.Add(this.btnMoveAndMerge);
            this.Name = "FormMenu";
            this.Text = "MPK - Menu";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnDeleteBadImages;
        private System.Windows.Forms.Button btnMoveAndMerge;
        private System.Windows.Forms.Button btnReorder;
        private System.Windows.Forms.Button btnUndouble;

        private System.Windows.Forms.Label lblTitle;

        #endregion
    }
}
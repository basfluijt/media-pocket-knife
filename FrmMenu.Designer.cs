namespace MediaSorter
{
    partial class FrmMenu
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
            this.lblMoveAndMerge = new System.Windows.Forms.Label();
            this.lblUnDouble = new System.Windows.Forms.Label();
            this.lblReOrder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMoveAndMerge
            // 
            this.btnMoveAndMerge.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnMoveAndMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAndMerge.Location = new System.Drawing.Point(72, 117);
            this.btnMoveAndMerge.Name = "btnMoveAndMerge";
            this.btnMoveAndMerge.Size = new System.Drawing.Size(161, 131);
            this.btnMoveAndMerge.TabIndex = 0;
            this.btnMoveAndMerge.Text = "Move and Merge";
            this.btnMoveAndMerge.UseVisualStyleBackColor = false;
            this.btnMoveAndMerge.Click += new System.EventHandler(this.btnMoveAndMerge_Click);
            // 
            // btnUndouble
            // 
            this.btnUndouble.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnUndouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndouble.Location = new System.Drawing.Point(252, 117);
            this.btnUndouble.Name = "btnUndouble";
            this.btnUndouble.Size = new System.Drawing.Size(161, 131);
            this.btnUndouble.TabIndex = 1;
            this.btnUndouble.Text = "Un-double";
            this.btnUndouble.UseVisualStyleBackColor = false;
            this.btnUndouble.Click += new System.EventHandler(this.btnUndouble_Click);
            // 
            // brnReorder
            // 
            this.btnReorder.BackColor = System.Drawing.Color.MistyRose;
            this.btnReorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReorder.Location = new System.Drawing.Point(430, 117);
            this.btnReorder.Name = "brnReorder";
            this.btnReorder.Size = new System.Drawing.Size(161, 131);
            this.btnReorder.TabIndex = 2;
            this.btnReorder.Text = "Re-order";
            this.btnReorder.UseVisualStyleBackColor = false;
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
            // lblMoveAndMerge
            // 
            this.lblMoveAndMerge.Location = new System.Drawing.Point(72, 261);
            this.lblMoveAndMerge.Name = "lblMoveAndMerge";
            this.lblMoveAndMerge.Size = new System.Drawing.Size(159, 36);
            this.lblMoveAndMerge.TabIndex = 4;
            this.lblMoveAndMerge.Text = "Order media between two folders";
            this.lblMoveAndMerge.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUnDouble
            // 
            this.lblUnDouble.Location = new System.Drawing.Point(252, 261);
            this.lblUnDouble.Name = "lblUnDouble";
            this.lblUnDouble.Size = new System.Drawing.Size(159, 36);
            this.lblUnDouble.TabIndex = 5;
            this.lblUnDouble.Text = "Undouble media in a folder";
            this.lblUnDouble.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblReOrder
            // 
            this.lblReOrder.Location = new System.Drawing.Point(432, 261);
            this.lblReOrder.Name = "lblReOrder";
            this.lblReOrder.Size = new System.Drawing.Size(159, 36);
            this.lblReOrder.TabIndex = 6;
            this.lblReOrder.Text = "Re-order media in a folder";
            this.lblReOrder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 334);
            this.Controls.Add(this.lblReOrder);
            this.Controls.Add(this.lblUnDouble);
            this.Controls.Add(this.lblMoveAndMerge);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnReorder);
            this.Controls.Add(this.btnUndouble);
            this.Controls.Add(this.btnMoveAndMerge);
            this.Name = "frmMenu";
            this.Text = "MPK - Menu";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnMoveAndMerge;
        private System.Windows.Forms.Button btnReorder;
        private System.Windows.Forms.Button btnUndouble;
        
        private System.Windows.Forms.Label lblMoveAndMerge;
        private System.Windows.Forms.Label lblReOrder;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUnDouble;

        #endregion
    }
}
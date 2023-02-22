namespace MediaSorter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            btnUndouble.Enabled = false;
            btnUndouble.BackColor = Color.LightGray;
        }

        private void btnMoveAndMerge_Click(object sender, EventArgs e)
        {
            var frmMoveAndMerge = new FormMoveAndMerge();
            frmMoveAndMerge.StartPosition = FormStartPosition.CenterParent;
            frmMoveAndMerge.Show();
        }

        private void btnUndouble_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            var frmMoveAndMerge = new FormRestructure();
            frmMoveAndMerge.StartPosition = FormStartPosition.CenterParent;
            frmMoveAndMerge.Show();
        } 
        
        private void btnBlurred_Click(object sender, EventArgs e)
        {
            var frmDeleteMoveMerge = new FormDeleteMoveBadImages();
            frmDeleteMoveMerge.StartPosition = FormStartPosition.CenterParent;
            frmDeleteMoveMerge.Show();
        }   
    }
}
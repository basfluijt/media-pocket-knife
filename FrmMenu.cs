namespace MediaSorter
{
    using System;
    using System.Windows.Forms;

    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnMoveAndMerge_Click(object sender, EventArgs e)
        {
            var frmMoveAndMerge = new FrmMoveAndMerge();
            frmMoveAndMerge.StartPosition = FormStartPosition.CenterParent;
            frmMoveAndMerge.Show();
        }

        private void btnUndouble_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void brnReorder_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
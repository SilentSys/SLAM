using System;
using System.Windows.Forms;

namespace SLAM
{
    public partial class RenameForm
    {
        public RenameForm()
        {
            InitializeComponent();
            _DoneButton.Name = "DoneButton";
        }

        public string filename;

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                MessageBox.Show("The name can not be empty.", "Naming Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                filename = NameBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void RenameForm_Load(object sender, EventArgs e)
        {
            NameBox.Text = filename;
        }
    }
}
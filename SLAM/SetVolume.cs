using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SLAM
{
    public partial class SetVolume
    {
        public SetVolume()
        {
            InitializeComponent();
            _SelectButton.Name = "SelectButton";
            _VolumeBar.Name = "VolumeBar";
            _VolumeNumber.Name = "VolumeNumber";
        }

        public int Volume;

        private void SelectButton_Click(object sender, EventArgs e)
        {
            Volume = Convert.ToInt32(VolumeNumber.Text);
            DialogResult = DialogResult.OK;
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            VolumeNumber.Text = (VolumeBar.Value * 10).ToString();
        }

        private void VolumeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) != 8)
            {
                if (Strings.Asc(e.KeyChar) < 48 | Strings.Asc(e.KeyChar) > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void VolumeNumber_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(VolumeNumber.Text))
            {
                if (Convert.ToInt32(VolumeNumber.Text) > 200)
                {
                    VolumeNumber.Text = "200";
                    VolumeNumber.SelectionStart = VolumeNumber.TextLength;
                }

                VolumeBar.Value = (int)(Convert.ToInt32(VolumeNumber.Text) / 10d);
            }
        }

        private void SetVolume_Load(object sender, EventArgs e)
        {

        }
    }
}
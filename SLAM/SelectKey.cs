using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SLAM
{
    public partial class SelectKey
    {
        public SelectKey()
        {
            InitializeComponent();
            _SelectButton.Name = "SelectButton";
            _BindKeyBox.Name = "BindKeyBox";
        }

        public string ChosenKey;
        private List<string> WholeList = new List<string>();

        private void SelectKey_Load(object sender, EventArgs e)
        {
            foreach (var item in BindKeyBox.Items)
                WholeList.Add(item.ToString());
        }

        private void BindKeyBox_TextChanged(object sender, EventArgs e)
        {
            BindKeyBox.DroppedDown = false;
            if (string.IsNullOrEmpty(BindKeyBox.Text))
            {
                BindKeyBox.Items.Clear();
                BindKeyBox.Items.AddRange(WholeList.ToArray());
            }
            else
            {
                BindKeyBox.Text = BindKeyBox.Text.ToUpper();
                BindKeyBox.SelectionStart = BindKeyBox.Text.Length;
                if (WholeList.Contains(BindKeyBox.Text))
                {
                    BindKeyBox.ForeColor = Color.Green;
                }
                else
                {
                    BindKeyBox.ForeColor = Color.Red;
                }
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (WholeList.Contains(BindKeyBox.Text))
            {
                ChosenKey = BindKeyBox.Text;
                DialogResult = DialogResult.OK;
            }
            else if (string.IsNullOrEmpty(BindKeyBox.Text))
            {
                Close();
            }
            else
            {
                MessageBox.Show("That bind key does not exist.", "Key Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
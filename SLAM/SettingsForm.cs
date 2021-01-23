using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SLAM
{
    public partial class SettingsForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            _FFMPEGRadio.Name = "FFMPEGRadio";
            _FinduserdataButton.Name = "FinduserdataButton";
            _FindsteamappsButton.Name = "FindsteamappsButton";
            _EnableOverrideBox.Name = "EnableOverrideBox";
            _ChangeRelayButton.Name = "ChangeRelayButton";
            _StartMinimizedCheckBox.Name = "StartMinimizedCheckBox";
            _MinimizeToSysTrayCheckBox.Name = "MinimizeToSysTrayCheckBox";
            _HoldToPlay.Name = "HoldToPlay";
            _ConTagsCheckBox.Name = "ConTagsCheckBox";
            _StartEnabledCheckBox.Name = "StartEnabledCheckBox";
            _LogCheckBox.Name = "LogCheckBox";
            _HintCheckBox.Name = "HintCheckBox";
            _UpdateCheckBox.Name = "UpdateCheckBox";
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            VersionLabel.Text = Strings.Join(new object[] { My.MyProject.Application.Info.Version.Major, My.MyProject.Application.Info.Version.Minor, My.MyProject.Application.Info.Version.Build }, ".");
            UpdateCheckBox.Checked = My.MySettingsProperty.Settings.UpdateCheck;
            HintCheckBox.Checked = My.MySettingsProperty.Settings.NoHint;
            LogCheckBox.Checked = My.MySettingsProperty.Settings.LogError;
            StartEnabledCheckBox.Checked = My.MySettingsProperty.Settings.StartEnabled;
            ConTagsCheckBox.Checked = My.MySettingsProperty.Settings.WriteTags;
            ChangeRelayButton.Text = string.Format("Relay key: \"{0}\" (change)", My.MySettingsProperty.Settings.RelayKey);
            HoldToPlay.Checked = My.MySettingsProperty.Settings.HoldToPlay;
            userdatatext.Text = My.MySettingsProperty.Settings.userdata;
            steamappstext.Text = My.MySettingsProperty.Settings.steamapps;
            EnableOverrideBox.Checked = My.MySettingsProperty.Settings.OverrideFolders;
            MinimizeToSysTrayCheckBox.Checked = My.MySettingsProperty.Settings.MinimizeToSysTray;
            StartMinimizedCheckBox.Checked = My.MySettingsProperty.Settings.StartMinimized;
            FFMPEGRadio.Checked = My.MySettingsProperty.Settings.UseFFMPEG;
            NAudioRadio.Checked = !My.MySettingsProperty.Settings.UseFFMPEG;
        }

        private void UpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.UpdateCheck = UpdateCheckBox.Checked;
            My.MySettingsProperty.Settings.Save();
        }

        private void HintCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.NoHint = HintCheckBox.Checked;
            My.MySettingsProperty.Settings.Save();
        }

        private void LogCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.LogError = LogCheckBox.Checked;
            My.MySettingsProperty.Settings.Save();
        }

        private void StartEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.StartEnabled = StartEnabledCheckBox.Checked;
            My.MySettingsProperty.Settings.Save();
        }

        private void ConTagsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.WriteTags = ConTagsCheckBox.Checked;
            My.MySettingsProperty.Settings.Save();
        }

        private void ChangeRelayButton_Click(object sender, EventArgs e)
        {
            var SelectKeyDialog = new SelectKey();
            if (SelectKeyDialog.ShowDialog() == DialogResult.OK)
            {
                if (!((SelectKeyDialog.ChosenKey ?? "") == (My.MySettingsProperty.Settings.PlayKey ?? "")))
                {
                    My.MySettingsProperty.Settings.RelayKey = SelectKeyDialog.ChosenKey;
                    My.MySettingsProperty.Settings.Save();
                    ChangeRelayButton.Text = string.Format("Relay key: \"{0}\" (change)", My.MySettingsProperty.Settings.RelayKey);
                }
                else
                {
                    MessageBox.Show("Play key and relay key can not be the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HoldToPlay_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.HoldToPlay = HoldToPlay.Checked;
            My.MySettingsProperty.Settings.Save();
        }


        private void EnableOverrideBox_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.OverrideFolders = EnableOverrideBox.Checked;
            My.MySettingsProperty.Settings.Save();
            foreach (Control control in OverrideGroup.Controls)
                control.Enabled = EnableOverrideBox.Checked;
            EnableOverrideBox.Enabled = true;
        }

        private void ShowFolderSelector(string name, ref string setting)
        {
            var ChangeDirDialog = new FolderBrowserDialog();
            ChangeDirDialog.Description = string.Format("Select your {0} folder:", name);
            ChangeDirDialog.ShowNewFolderButton = false;
            if (ChangeDirDialog.ShowDialog() == DialogResult.OK)
            {
                setting = ChangeDirDialog.SelectedPath + @"\";
                My.MySettingsProperty.Settings.Save();
            }
        }

        private void FindsteamappsButton_Click(object sender, EventArgs e)
        {
            string argsetting = My.MySettingsProperty.Settings.steamapps;
            ShowFolderSelector("steamapps", ref argsetting);
            My.MySettingsProperty.Settings.steamapps = argsetting;
            steamappstext.Text = My.MySettingsProperty.Settings.steamapps;
        }

        private void FinduserdataButton_Click(object sender, EventArgs e)
        {
            string argsetting = My.MySettingsProperty.Settings.userdata;
            ShowFolderSelector("userdata", ref argsetting);
            My.MySettingsProperty.Settings.userdata = argsetting;
            userdatatext.Text = My.MySettingsProperty.Settings.userdata;
        }

        private void MinimizeToSysTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.MinimizeToSysTray = MinimizeToSysTrayCheckBox.Checked;
            My.MySettingsProperty.Settings.Save();
        }

        private void StartMinimizedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.StartMinimized = StartMinimizedCheckBox.Checked;
            My.MySettingsProperty.Settings.Save();
        }

        private void FFMPEGRadio_CheckedChanged(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.UseFFMPEG = FFMPEGRadio.Checked;
            My.MySettingsProperty.Settings.Save();
        }
    }
}
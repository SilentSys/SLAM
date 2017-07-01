Public Class SettingsForm

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VersionLabel.Text = Join({My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build}, ".")
        UpdateCheckBox.Checked = My.Settings.UpdateCheck
        HintCheckBox.Checked = My.Settings.NoHint
        LogCheckBox.Checked = My.Settings.LogError
        StartEnabledCheckBox.Checked = My.Settings.StartEnabled
        ConTagsCheckBox.Checked = My.Settings.WriteTags
        ChangeRelayButton.Text = String.Format("Relay key: ""{0}"" (change)", My.Settings.RelayKey)
        HoldToPlay.Checked = My.Settings.HoldToPlay
        userdatatext.Text = My.Settings.userdata
        steamappstext.Text = My.Settings.steamapps
        EnableOverrideBox.Checked = My.Settings.OverrideFolders
        MinimizeToSysTrayCheckBox.Checked = My.Settings.MinimizeToSysTray
        StartMinimizedCheckBox.Checked = My.Settings.StartMinimized
        FFMPEGRadio.Checked = My.Settings.UseFFMPEG
        NAudioRadio.Checked = Not My.Settings.UseFFMPEG
    End Sub

    Private Sub UpdateCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles UpdateCheckBox.CheckedChanged
        My.Settings.UpdateCheck = UpdateCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub HintCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HintCheckBox.CheckedChanged
        My.Settings.NoHint = HintCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub LogCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles LogCheckBox.CheckedChanged
        My.Settings.LogError = LogCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub StartEnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles StartEnabledCheckBox.CheckedChanged
        My.Settings.StartEnabled = StartEnabledCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub ConTagsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ConTagsCheckBox.CheckedChanged
        My.Settings.WriteTags = ConTagsCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub ChangeRelayButton_Click(sender As Object, e As EventArgs) Handles ChangeRelayButton.Click
        Dim SelectKeyDialog As New SelectKey
        If SelectKeyDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not SelectKeyDialog.ChosenKey = My.Settings.PlayKey Then
                My.Settings.RelayKey = SelectKeyDialog.ChosenKey
                My.Settings.Save()
                ChangeRelayButton.Text = String.Format("Relay key: ""{0}"" (change)", My.Settings.RelayKey)
            Else
                MessageBox.Show("Play key and relay key can not be the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub HoldToPlay_CheckedChanged(sender As Object, e As EventArgs) Handles HoldToPlay.CheckedChanged
        My.Settings.HoldToPlay = HoldToPlay.Checked
        My.Settings.Save()
    End Sub

    Private Sub DonateLabel_Click(sender As Object, e As EventArgs) Handles DonateLabel.Click
        Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RVLLPGWJUG6CY")
    End Sub

    Private Sub EnableOverrideBox_CheckedChanged(sender As Object, e As EventArgs) Handles EnableOverrideBox.CheckedChanged
        My.Settings.OverrideFolders = EnableOverrideBox.Checked
        My.Settings.Save()

        For Each control In OverrideGroup.Controls
            control.enabled = EnableOverrideBox.Checked
        Next
        EnableOverrideBox.Enabled = True
    End Sub

    Private Sub ShowFolderSelector(name As String, ByRef setting As String)
        Dim ChangeDirDialog As New FolderBrowserDialog
        ChangeDirDialog.Description = String.Format("Select your {0} folder:", name)
        ChangeDirDialog.ShowNewFolderButton = False

        If ChangeDirDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            setting = ChangeDirDialog.SelectedPath & "\"
            My.Settings.Save()
        End If

    End Sub

    Private Sub FindsteamappsButton_Click(sender As Object, e As EventArgs) Handles FindsteamappsButton.Click
        ShowFolderSelector("steamapps", My.Settings.steamapps)
        steamappstext.Text = My.Settings.steamapps
    End Sub

    Private Sub FinduserdataButton_Click(sender As Object, e As EventArgs) Handles FinduserdataButton.Click
        ShowFolderSelector("userdata", My.Settings.userdata)
        userdatatext.Text = My.Settings.userdata
    End Sub

    Private Sub MinimizeToSysTrayCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles MinimizeToSysTrayCheckBox.CheckedChanged
        My.Settings.MinimizeToSysTray = MinimizeToSysTrayCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub StartMinimizedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles StartMinimizedCheckBox.CheckedChanged
        My.Settings.StartMinimized = StartMinimizedCheckBox.Checked
        My.Settings.Save()
    End Sub

    Private Sub FFMPEGRadio_CheckedChanged(sender As Object, e As EventArgs) Handles FFMPEGRadio.CheckedChanged
        My.Settings.UseFFMPEG = FFMPEGRadio.Checked
        My.Settings.Save()
    End Sub
End Class
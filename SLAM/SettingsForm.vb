Public Class SettingsForm

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VersionLabel.Text = Join({My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build}, ".")
        DirText.Text = My.Settings.SteamAppsFolder
        UserDataDir.Text = My.Settings.UserdataPath
        UpdateCheckBox.Checked = My.Settings.UpdateCheck
        HintCheckBox.Checked = My.Settings.NoHint
        LogCheckBox.Checked = My.Settings.LogError
        StartEnabledCheckBox.Checked = My.Settings.StartEnabled
        ConTagsCheckBox.Checked = My.Settings.WriteTags
        ChangeRelayButton.Text = String.Format("Relay key: ""{0}"" (change)", My.Settings.RelayKey)
    End Sub

    Private Sub ChangeDirButton_Click(sender As Object, e As EventArgs) Handles ChangeDirButton.Click
        Form1.ShowFolderSelector()
        DirText.Text = My.Settings.SteamAppsFolder
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
            My.Settings.RelayKey = SelectKeyDialog.ChosenKey
            My.Settings.Save()
            ChangeRelayButton.Text = String.Format("Relay key: ""{0}"" (change)", My.Settings.RelayKey)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ChangeDirDialog As New FolderBrowserDialog
        ChangeDirDialog.Description = "Select your userdata folder:"
        ChangeDirDialog.ShowNewFolderButton = False

        If ChangeDirDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            My.Settings.UserdataPath = ChangeDirDialog.SelectedPath & "\"
            UserDataDir.Text = My.Settings.UserdataPath
        End If
    End Sub
End Class
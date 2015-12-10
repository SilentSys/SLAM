<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.VersionLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChangeRelayButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ConTagsCheckBox = New System.Windows.Forms.CheckBox()
        Me.StartEnabledCheckBox = New System.Windows.Forms.CheckBox()
        Me.LogCheckBox = New System.Windows.Forms.CheckBox()
        Me.HintCheckBox = New System.Windows.Forms.CheckBox()
        Me.UpdateCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChangeDirButton = New System.Windows.Forms.Button()
        Me.DirText = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UserDataDir = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.VersionLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 309)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(284, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(49, 17)
        Me.ToolStripStatusLabel1.Text = "Version:"
        '
        'VersionLabel
        '
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(31, 17)
        Me.VersionLabel.Text = "0.0.0"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(276, 305)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChangeRelayButton)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 89)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 52)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Relay Key"
        '
        'ChangeRelayButton
        '
        Me.ChangeRelayButton.Location = New System.Drawing.Point(6, 19)
        Me.ChangeRelayButton.Name = "ChangeRelayButton"
        Me.ChangeRelayButton.Size = New System.Drawing.Size(248, 23)
        Me.ChangeRelayButton.TabIndex = 0
        Me.ChangeRelayButton.Text = "Relay key: """"{0}"""" (change)"
        Me.ChangeRelayButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ConTagsCheckBox)
        Me.GroupBox2.Controls.Add(Me.StartEnabledCheckBox)
        Me.GroupBox2.Controls.Add(Me.LogCheckBox)
        Me.GroupBox2.Controls.Add(Me.HintCheckBox)
        Me.GroupBox2.Controls.Add(Me.UpdateCheckBox)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 132)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Other"
        '
        'ConTagsCheckBox
        '
        Me.ConTagsCheckBox.AutoSize = True
        Me.ConTagsCheckBox.Location = New System.Drawing.Point(6, 111)
        Me.ConTagsCheckBox.Name = "ConTagsCheckBox"
        Me.ConTagsCheckBox.Size = New System.Drawing.Size(101, 17)
        Me.ConTagsCheckBox.TabIndex = 5
        Me.ConTagsCheckBox.Text = "Tags in console"
        Me.ConTagsCheckBox.UseVisualStyleBackColor = True
        '
        'StartEnabledCheckBox
        '
        Me.StartEnabledCheckBox.AutoSize = True
        Me.StartEnabledCheckBox.Location = New System.Drawing.Point(6, 88)
        Me.StartEnabledCheckBox.Name = "StartEnabledCheckBox"
        Me.StartEnabledCheckBox.Size = New System.Drawing.Size(89, 17)
        Me.StartEnabledCheckBox.TabIndex = 4
        Me.StartEnabledCheckBox.Text = "Start enabled"
        Me.StartEnabledCheckBox.UseVisualStyleBackColor = True
        '
        'LogCheckBox
        '
        Me.LogCheckBox.AutoSize = True
        Me.LogCheckBox.Location = New System.Drawing.Point(6, 65)
        Me.LogCheckBox.Name = "LogCheckBox"
        Me.LogCheckBox.Size = New System.Drawing.Size(73, 17)
        Me.LogCheckBox.TabIndex = 2
        Me.LogCheckBox.Text = "Log errors"
        Me.LogCheckBox.UseVisualStyleBackColor = True
        '
        'HintCheckBox
        '
        Me.HintCheckBox.AutoSize = True
        Me.HintCheckBox.Location = New System.Drawing.Point(6, 42)
        Me.HintCheckBox.Name = "HintCheckBox"
        Me.HintCheckBox.Size = New System.Drawing.Size(65, 17)
        Me.HintCheckBox.TabIndex = 3
        Me.HintCheckBox.Text = "No hints"
        Me.HintCheckBox.UseVisualStyleBackColor = True
        '
        'UpdateCheckBox
        '
        Me.UpdateCheckBox.AutoSize = True
        Me.UpdateCheckBox.Location = New System.Drawing.Point(6, 19)
        Me.UpdateCheckBox.Name = "UpdateCheckBox"
        Me.UpdateCheckBox.Size = New System.Drawing.Size(113, 17)
        Me.UpdateCheckBox.TabIndex = 2
        Me.UpdateCheckBox.Text = "Check for updates"
        Me.UpdateCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChangeDirButton)
        Me.GroupBox1.Controls.Add(Me.DirText)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 75)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SteamApps Directory"
        '
        'ChangeDirButton
        '
        Me.ChangeDirButton.Location = New System.Drawing.Point(179, 45)
        Me.ChangeDirButton.Name = "ChangeDirButton"
        Me.ChangeDirButton.Size = New System.Drawing.Size(75, 23)
        Me.ChangeDirButton.TabIndex = 1
        Me.ChangeDirButton.Text = "Change"
        Me.ChangeDirButton.UseVisualStyleBackColor = True
        '
        'DirText
        '
        Me.DirText.Location = New System.Drawing.Point(6, 19)
        Me.DirText.Name = "DirText"
        Me.DirText.ReadOnly = True
        Me.DirText.Size = New System.Drawing.Size(248, 20)
        Me.DirText.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(284, 331)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(276, 305)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Misc."
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.UserDataDir)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 147)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(260, 75)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "UserData Directory"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(179, 45)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Change"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UserDataDir
        '
        Me.UserDataDir.Location = New System.Drawing.Point(6, 19)
        Me.UserDataDir.Name = "UserDataDir"
        Me.UserDataDir.ReadOnly = True
        Me.UserDataDir.Size = New System.Drawing.Size(248, 20)
        Me.UserDataDir.TabIndex = 0
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 331)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SettingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents VersionLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents StartEnabledCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LogCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents HintCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents UpdateCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChangeDirButton As System.Windows.Forms.Button
    Friend WithEvents DirText As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ConTagsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChangeRelayButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UserDataDir As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
End Class

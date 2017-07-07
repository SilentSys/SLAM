<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.VersionLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DonateLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.NAudioRadio = New System.Windows.Forms.RadioButton()
        Me.FFMPEGRadio = New System.Windows.Forms.RadioButton()
        Me.OverrideGroup = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FinduserdataButton = New System.Windows.Forms.Button()
        Me.userdatatext = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FindsteamappsButton = New System.Windows.Forms.Button()
        Me.steamappstext = New System.Windows.Forms.TextBox()
        Me.EnableOverrideBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChangeRelayButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.StartMinimizedCheckBox = New System.Windows.Forms.CheckBox()
        Me.MinimizeToSysTrayCheckBox = New System.Windows.Forms.CheckBox()
        Me.HoldToPlay = New System.Windows.Forms.CheckBox()
        Me.ConTagsCheckBox = New System.Windows.Forms.CheckBox()
        Me.StartEnabledCheckBox = New System.Windows.Forms.CheckBox()
        Me.LogCheckBox = New System.Windows.Forms.CheckBox()
        Me.HintCheckBox = New System.Windows.Forms.CheckBox()
        Me.UpdateCheckBox = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CustomTabControlc1 = New SLAM.CustomTabControlc()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.OverrideGroup.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.CustomTabControlc1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.VersionLabel, Me.DonateLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 368)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(338, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(48, 17)
        Me.ToolStripStatusLabel1.Text = "Version:"
        '
        'VersionLabel
        '
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(31, 17)
        Me.VersionLabel.Text = "0.0.0"
        '
        'DonateLabel
        '
        Me.DonateLabel.IsLink = True
        Me.DonateLabel.Name = "DonateLabel"
        Me.DonateLabel.Size = New System.Drawing.Size(199, 17)
        Me.DonateLabel.Text = "Want to support SLAM by donating?"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.NAudioRadio)
        Me.TabPage2.Controls.Add(Me.FFMPEGRadio)
        Me.TabPage2.Controls.Add(Me.OverrideGroup)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 44)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(330, 295)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Advanced"
        '
        'NAudioRadio
        '
        Me.NAudioRadio.AutoSize = True
        Me.NAudioRadio.ForeColor = System.Drawing.Color.White
        Me.NAudioRadio.Location = New System.Drawing.Point(150, 207)
        Me.NAudioRadio.Name = "NAudioRadio"
        Me.NAudioRadio.Size = New System.Drawing.Size(126, 17)
        Me.NAudioRadio.TabIndex = 5
        Me.NAudioRadio.TabStop = True
        Me.NAudioRadio.Text = "Use NAudio (Legacy)"
        Me.NAudioRadio.UseVisualStyleBackColor = True
        '
        'FFMPEGRadio
        '
        Me.FFMPEGRadio.AutoSize = True
        Me.FFMPEGRadio.ForeColor = System.Drawing.Color.White
        Me.FFMPEGRadio.Location = New System.Drawing.Point(54, 207)
        Me.FFMPEGRadio.Name = "FFMPEGRadio"
        Me.FFMPEGRadio.Size = New System.Drawing.Size(90, 17)
        Me.FFMPEGRadio.TabIndex = 4
        Me.FFMPEGRadio.TabStop = True
        Me.FFMPEGRadio.Text = "Use FFMPEG"
        Me.FFMPEGRadio.UseVisualStyleBackColor = True
        '
        'OverrideGroup
        '
        Me.OverrideGroup.Controls.Add(Me.Label2)
        Me.OverrideGroup.Controls.Add(Me.FinduserdataButton)
        Me.OverrideGroup.Controls.Add(Me.userdatatext)
        Me.OverrideGroup.Controls.Add(Me.Label1)
        Me.OverrideGroup.Controls.Add(Me.FindsteamappsButton)
        Me.OverrideGroup.Controls.Add(Me.steamappstext)
        Me.OverrideGroup.Controls.Add(Me.EnableOverrideBox)
        Me.OverrideGroup.ForeColor = System.Drawing.Color.White
        Me.OverrideGroup.Location = New System.Drawing.Point(33, 105)
        Me.OverrideGroup.Name = "OverrideGroup"
        Me.OverrideGroup.Size = New System.Drawing.Size(260, 96)
        Me.OverrideGroup.TabIndex = 3
        Me.OverrideGroup.TabStop = False
        Me.OverrideGroup.Text = "Override folder detection"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(6, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "userdata:"
        '
        'FinduserdataButton
        '
        Me.FinduserdataButton.Enabled = False
        Me.FinduserdataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FinduserdataButton.Location = New System.Drawing.Point(230, 66)
        Me.FinduserdataButton.Name = "FinduserdataButton"
        Me.FinduserdataButton.Size = New System.Drawing.Size(24, 23)
        Me.FinduserdataButton.TabIndex = 5
        Me.FinduserdataButton.Text = "..."
        Me.FinduserdataButton.UseVisualStyleBackColor = True
        '
        'userdatatext
        '
        Me.userdatatext.Enabled = False
        Me.userdatatext.Location = New System.Drawing.Point(73, 68)
        Me.userdatatext.Name = "userdatatext"
        Me.userdatatext.ReadOnly = True
        Me.userdatatext.Size = New System.Drawing.Size(151, 20)
        Me.userdatatext.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(6, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "steamapps:"
        '
        'FindsteamappsButton
        '
        Me.FindsteamappsButton.Enabled = False
        Me.FindsteamappsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FindsteamappsButton.Location = New System.Drawing.Point(230, 40)
        Me.FindsteamappsButton.Name = "FindsteamappsButton"
        Me.FindsteamappsButton.Size = New System.Drawing.Size(24, 23)
        Me.FindsteamappsButton.TabIndex = 2
        Me.FindsteamappsButton.Text = "..."
        Me.FindsteamappsButton.UseVisualStyleBackColor = True
        '
        'steamappstext
        '
        Me.steamappstext.Enabled = False
        Me.steamappstext.Location = New System.Drawing.Point(73, 42)
        Me.steamappstext.Name = "steamappstext"
        Me.steamappstext.ReadOnly = True
        Me.steamappstext.Size = New System.Drawing.Size(151, 20)
        Me.steamappstext.TabIndex = 1
        '
        'EnableOverrideBox
        '
        Me.EnableOverrideBox.AutoSize = True
        Me.EnableOverrideBox.Location = New System.Drawing.Point(6, 19)
        Me.EnableOverrideBox.Name = "EnableOverrideBox"
        Me.EnableOverrideBox.Size = New System.Drawing.Size(59, 17)
        Me.EnableOverrideBox.TabIndex = 0
        Me.EnableOverrideBox.Text = "Enable"
        Me.EnableOverrideBox.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChangeRelayButton)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(33, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 52)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Relay Key"
        '
        'ChangeRelayButton
        '
        Me.ChangeRelayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChangeRelayButton.Location = New System.Drawing.Point(6, 19)
        Me.ChangeRelayButton.Name = "ChangeRelayButton"
        Me.ChangeRelayButton.Size = New System.Drawing.Size(248, 23)
        Me.ChangeRelayButton.TabIndex = 0
        Me.ChangeRelayButton.Text = "Relay key: """"{0}"""" (change)"
        Me.ChangeRelayButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.StartMinimizedCheckBox)
        Me.GroupBox2.Controls.Add(Me.MinimizeToSysTrayCheckBox)
        Me.GroupBox2.Controls.Add(Me.HoldToPlay)
        Me.GroupBox2.Controls.Add(Me.ConTagsCheckBox)
        Me.GroupBox2.Controls.Add(Me.StartEnabledCheckBox)
        Me.GroupBox2.Controls.Add(Me.LogCheckBox)
        Me.GroupBox2.Controls.Add(Me.HintCheckBox)
        Me.GroupBox2.Controls.Add(Me.UpdateCheckBox)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(39, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 227)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Other"
        '
        'StartMinimizedCheckBox
        '
        Me.StartMinimizedCheckBox.AutoSize = True
        Me.StartMinimizedCheckBox.Location = New System.Drawing.Point(6, 180)
        Me.StartMinimizedCheckBox.Name = "StartMinimizedCheckBox"
        Me.StartMinimizedCheckBox.Size = New System.Drawing.Size(117, 20)
        Me.StartMinimizedCheckBox.TabIndex = 13
        Me.StartMinimizedCheckBox.Text = "Start minimized"
        Me.StartMinimizedCheckBox.UseVisualStyleBackColor = True
        '
        'MinimizeToSysTrayCheckBox
        '
        Me.MinimizeToSysTrayCheckBox.AutoSize = True
        Me.MinimizeToSysTrayCheckBox.Location = New System.Drawing.Point(6, 157)
        Me.MinimizeToSysTrayCheckBox.Name = "MinimizeToSysTrayCheckBox"
        Me.MinimizeToSysTrayCheckBox.Size = New System.Drawing.Size(164, 20)
        Me.MinimizeToSysTrayCheckBox.TabIndex = 12
        Me.MinimizeToSysTrayCheckBox.Text = "Minimize to system tray"
        Me.MinimizeToSysTrayCheckBox.UseVisualStyleBackColor = True
        '
        'HoldToPlay
        '
        Me.HoldToPlay.AutoSize = True
        Me.HoldToPlay.Location = New System.Drawing.Point(6, 134)
        Me.HoldToPlay.Name = "HoldToPlay"
        Me.HoldToPlay.Size = New System.Drawing.Size(99, 20)
        Me.HoldToPlay.TabIndex = 11
        Me.HoldToPlay.Text = "Hold to play"
        Me.HoldToPlay.UseVisualStyleBackColor = True
        '
        'ConTagsCheckBox
        '
        Me.ConTagsCheckBox.AutoSize = True
        Me.ConTagsCheckBox.Location = New System.Drawing.Point(6, 111)
        Me.ConTagsCheckBox.Name = "ConTagsCheckBox"
        Me.ConTagsCheckBox.Size = New System.Drawing.Size(123, 20)
        Me.ConTagsCheckBox.TabIndex = 5
        Me.ConTagsCheckBox.Text = "Tags in console"
        Me.ConTagsCheckBox.UseVisualStyleBackColor = True
        '
        'StartEnabledCheckBox
        '
        Me.StartEnabledCheckBox.AutoSize = True
        Me.StartEnabledCheckBox.Location = New System.Drawing.Point(6, 88)
        Me.StartEnabledCheckBox.Name = "StartEnabledCheckBox"
        Me.StartEnabledCheckBox.Size = New System.Drawing.Size(107, 20)
        Me.StartEnabledCheckBox.TabIndex = 4
        Me.StartEnabledCheckBox.Text = "Start enabled"
        Me.StartEnabledCheckBox.UseVisualStyleBackColor = True
        '
        'LogCheckBox
        '
        Me.LogCheckBox.AutoSize = True
        Me.LogCheckBox.Location = New System.Drawing.Point(6, 65)
        Me.LogCheckBox.Name = "LogCheckBox"
        Me.LogCheckBox.Size = New System.Drawing.Size(88, 20)
        Me.LogCheckBox.TabIndex = 2
        Me.LogCheckBox.Text = "Log errors"
        Me.LogCheckBox.UseVisualStyleBackColor = True
        '
        'HintCheckBox
        '
        Me.HintCheckBox.AutoSize = True
        Me.HintCheckBox.Location = New System.Drawing.Point(6, 42)
        Me.HintCheckBox.Name = "HintCheckBox"
        Me.HintCheckBox.Size = New System.Drawing.Size(75, 20)
        Me.HintCheckBox.TabIndex = 3
        Me.HintCheckBox.Text = "No hints"
        Me.HintCheckBox.UseVisualStyleBackColor = True
        '
        'UpdateCheckBox
        '
        Me.UpdateCheckBox.AutoSize = True
        Me.UpdateCheckBox.Location = New System.Drawing.Point(6, 19)
        Me.UpdateCheckBox.Name = "UpdateCheckBox"
        Me.UpdateCheckBox.Size = New System.Drawing.Size(135, 20)
        Me.UpdateCheckBox.TabIndex = 2
        Me.UpdateCheckBox.Text = "Check for updates"
        Me.UpdateCheckBox.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(338, 25)
        Me.Panel1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(299, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 25)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Settings"
        '
        'CustomTabControlc1
        '
        Me.CustomTabControlc1.Controls.Add(Me.TabPage1)
        Me.CustomTabControlc1.Controls.Add(Me.TabPage2)
        Me.CustomTabControlc1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomTabControlc1.FontColor = System.Drawing.Color.White
        Me.CustomTabControlc1.ItemSize = New System.Drawing.Size(100, 40)
        Me.CustomTabControlc1.Location = New System.Drawing.Point(0, 25)
        Me.CustomTabControlc1.Name = "CustomTabControlc1"
        Me.CustomTabControlc1.SelectedIndex = 0
        Me.CustomTabControlc1.Size = New System.Drawing.Size(338, 343)
        Me.CustomTabControlc1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.CustomTabControlc1.TabColor = System.Drawing.Color.DeepPink
        Me.CustomTabControlc1.TabIndex = 3
        Me.CustomTabControlc1.UseLightTheme = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 44)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(330, 295)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Misc"
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 390)
        Me.Controls.Add(Me.CustomTabControlc1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SettingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.OverrideGroup.ResumeLayout(False)
        Me.OverrideGroup.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.CustomTabControlc1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents VersionLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents StartEnabledCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LogCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents HintCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents UpdateCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ConTagsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChangeRelayButton As System.Windows.Forms.Button
    Friend WithEvents HoldToPlay As System.Windows.Forms.CheckBox
    Friend WithEvents OverrideGroup As GroupBox
    Friend WithEvents FindsteamappsButton As Button
    Friend WithEvents steamappstext As TextBox
    Friend WithEvents EnableOverrideBox As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DonateLabel As ToolStripStatusLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents FinduserdataButton As Button
    Friend WithEvents userdatatext As TextBox
    Friend WithEvents MinimizeToSysTrayCheckBox As CheckBox
    Friend WithEvents StartMinimizedCheckBox As CheckBox
    Friend WithEvents NAudioRadio As RadioButton
    Friend WithEvents FFMPEGRadio As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CustomTabControlc1 As CustomTabControlc
    Friend WithEvents TabPage1 As TabPage
End Class

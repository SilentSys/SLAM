<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GameSelector = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.TrackList = New System.Windows.Forms.ListView()
        Me.LoadedCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrackCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HotKeyCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VolumeCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Trimmed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TagsCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StartButton = New System.Windows.Forms.Button()
        Me.ImportDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.WavWorker = New System.ComponentModel.BackgroundWorker()
        Me.PollRelayWorker = New System.ComponentModel.BackgroundWorker()
        Me.ChangeDirButton = New System.Windows.Forms.Button()
        Me.TrackContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveHotkeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextHotKey = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetVolumeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrimToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayKeyButton = New System.Windows.Forms.Button()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.SystemTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SystemTrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SystemTrayMenu_Open = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemTrayMenu_StartStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SystemTrayMenu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.YTButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grip = New System.Windows.Forms.PictureBox()
        Me.TrackContextMenu.SuspendLayout()
        Me.SystemTrayMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GameSelector
        '
        Me.GameSelector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GameSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GameSelector.FormattingEnabled = True
        Me.GameSelector.Location = New System.Drawing.Point(75, 52)
        Me.GameSelector.Margin = New System.Windows.Forms.Padding(4)
        Me.GameSelector.MaxDropDownItems = 100
        Me.GameSelector.Name = "GameSelector"
        Me.GameSelector.Size = New System.Drawing.Size(461, 24)
        Me.GameSelector.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Game:"
        '
        'ImportButton
        '
        Me.ImportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ImportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportButton.Location = New System.Drawing.Point(20, 405)
        Me.ImportButton.Margin = New System.Windows.Forms.Padding(4)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(72, 28)
        Me.ImportButton.TabIndex = 3
        Me.ImportButton.Text = "Import"
        Me.ImportButton.UseVisualStyleBackColor = True
        '
        'TrackList
        '
        Me.TrackList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackList.AutoArrange = False
        Me.TrackList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LoadedCol, Me.TrackCol, Me.HotKeyCol, Me.VolumeCol, Me.Trimmed, Me.TagsCol})
        Me.TrackList.FullRowSelect = True
        Me.TrackList.HideSelection = False
        Me.TrackList.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TrackList.Location = New System.Drawing.Point(20, 86)
        Me.TrackList.Margin = New System.Windows.Forms.Padding(4)
        Me.TrackList.Name = "TrackList"
        Me.TrackList.Size = New System.Drawing.Size(623, 311)
        Me.TrackList.TabIndex = 4
        Me.TrackList.UseCompatibleStateImageBehavior = False
        Me.TrackList.View = System.Windows.Forms.View.Details
        '
        'LoadedCol
        '
        Me.LoadedCol.Text = "Loaded"
        '
        'TrackCol
        '
        Me.TrackCol.Text = "Track"
        Me.TrackCol.Width = 137
        '
        'HotKeyCol
        '
        Me.HotKeyCol.Text = "Bind"
        '
        'VolumeCol
        '
        Me.VolumeCol.Text = "Volume"
        Me.VolumeCol.Width = 100
        '
        'Trimmed
        '
        Me.Trimmed.Text = "Trimmed"
        '
        'TagsCol
        '
        Me.TagsCol.Text = "Tags"
        Me.TagsCol.Width = 43
        '
        'StartButton
        '
        Me.StartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartButton.Location = New System.Drawing.Point(128, 405)
        Me.StartButton.Margin = New System.Windows.Forms.Padding(4)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(100, 28)
        Me.StartButton.TabIndex = 5
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ImportDialog
        '
        Me.ImportDialog.Filter = "Media files|*.mp3;*.wav;*.aac;*.wma;*.m4a;*.mp4;*.wmv;*.avi;*.m4v;*.mov;|Audio fi" &
    "les|*.mp3;*.wav;*.aac;*.wma;*.m4a;|Video files|*.mp4;*.wmv;*.avi;*.m4v;*.mov;|Al" &
    "l files|*.*"
        Me.ImportDialog.Multiselect = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(20, 440)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(623, 28)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 6
        '
        'WavWorker
        '
        Me.WavWorker.WorkerReportsProgress = True
        '
        'PollRelayWorker
        '
        Me.PollRelayWorker.WorkerReportsProgress = True
        Me.PollRelayWorker.WorkerSupportsCancellation = True
        '
        'ChangeDirButton
        '
        Me.ChangeDirButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeDirButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChangeDirButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.ChangeDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChangeDirButton.Location = New System.Drawing.Point(545, 50)
        Me.ChangeDirButton.Margin = New System.Windows.Forms.Padding(4)
        Me.ChangeDirButton.Name = "ChangeDirButton"
        Me.ChangeDirButton.Size = New System.Drawing.Size(100, 28)
        Me.ChangeDirButton.TabIndex = 7
        Me.ChangeDirButton.Text = "Settings"
        Me.ChangeDirButton.UseVisualStyleBackColor = True
        '
        'TrackContextMenu
        '
        Me.TrackContextMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.TrackContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextDelete, Me.GoToToolStripMenuItem, Me.ContextRefresh, Me.RemoveHotkeyToolStripMenuItem, Me.RenameToolStripMenuItem, Me.ContextHotKey, Me.SetVolumeToolStripMenuItem, Me.TrimToolStripMenuItem, Me.LoadToolStripMenuItem})
        Me.TrackContextMenu.Name = "TrackContextMenu"
        Me.TrackContextMenu.Size = New System.Drawing.Size(145, 202)
        '
        'ContextDelete
        '
        Me.ContextDelete.Name = "ContextDelete"
        Me.ContextDelete.Size = New System.Drawing.Size(144, 22)
        Me.ContextDelete.Text = "Delete"
        '
        'GoToToolStripMenuItem
        '
        Me.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem"
        Me.GoToToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.GoToToolStripMenuItem.Text = "Go To"
        '
        'ContextRefresh
        '
        Me.ContextRefresh.Name = "ContextRefresh"
        Me.ContextRefresh.Size = New System.Drawing.Size(144, 22)
        Me.ContextRefresh.Text = "Refresh"
        '
        'RemoveHotkeyToolStripMenuItem
        '
        Me.RemoveHotkeyToolStripMenuItem.Name = "RemoveHotkeyToolStripMenuItem"
        Me.RemoveHotkeyToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.RemoveHotkeyToolStripMenuItem.Text = "Remove Bind"
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'ContextHotKey
        '
        Me.ContextHotKey.Name = "ContextHotKey"
        Me.ContextHotKey.Size = New System.Drawing.Size(144, 22)
        Me.ContextHotKey.Text = "Set Bind"
        '
        'SetVolumeToolStripMenuItem
        '
        Me.SetVolumeToolStripMenuItem.Name = "SetVolumeToolStripMenuItem"
        Me.SetVolumeToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SetVolumeToolStripMenuItem.Text = "Set Volume"
        '
        'TrimToolStripMenuItem
        '
        Me.TrimToolStripMenuItem.Name = "TrimToolStripMenuItem"
        Me.TrimToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.TrimToolStripMenuItem.Text = "Trim"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.LoadToolStripMenuItem.Text = "Load"
        '
        'PlayKeyButton
        '
        Me.PlayKeyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayKeyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PlayKeyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.PlayKeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PlayKeyButton.Location = New System.Drawing.Point(416, 405)
        Me.PlayKeyButton.Margin = New System.Windows.Forms.Padding(4)
        Me.PlayKeyButton.Name = "PlayKeyButton"
        Me.PlayKeyButton.Size = New System.Drawing.Size(227, 28)
        Me.PlayKeyButton.TabIndex = 8
        Me.PlayKeyButton.Text = "Play key: """"{0}"""" (change)"
        Me.PlayKeyButton.UseVisualStyleBackColor = True
        '
        'StatusLabel
        '
        Me.StatusLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(236, 411)
        Me.StatusLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(78, 16)
        Me.StatusLabel.TabIndex = 9
        Me.StatusLabel.Text = "Status: Idle"
        '
        'SystemTrayIcon
        '
        Me.SystemTrayIcon.ContextMenuStrip = Me.SystemTrayMenu
        Me.SystemTrayIcon.Icon = CType(resources.GetObject("SystemTrayIcon.Icon"), System.Drawing.Icon)
        Me.SystemTrayIcon.Text = "SLAM"
        '
        'SystemTrayMenu
        '
        Me.SystemTrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemTrayMenu_Open, Me.SystemTrayMenu_StartStop, Me.ToolStripSeparator1, Me.SystemTrayMenu_Exit})
        Me.SystemTrayMenu.Name = "SystemTrayMenu"
        Me.SystemTrayMenu.Size = New System.Drawing.Size(104, 76)
        '
        'SystemTrayMenu_Open
        '
        Me.SystemTrayMenu_Open.Name = "SystemTrayMenu_Open"
        Me.SystemTrayMenu_Open.Size = New System.Drawing.Size(103, 22)
        Me.SystemTrayMenu_Open.Text = "Open"
        '
        'SystemTrayMenu_StartStop
        '
        Me.SystemTrayMenu_StartStop.Name = "SystemTrayMenu_StartStop"
        Me.SystemTrayMenu_StartStop.Size = New System.Drawing.Size(103, 22)
        Me.SystemTrayMenu_StartStop.Text = "Start"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(100, 6)
        '
        'SystemTrayMenu_Exit
        '
        Me.SystemTrayMenu_Exit.Name = "SystemTrayMenu_Exit"
        Me.SystemTrayMenu_Exit.Size = New System.Drawing.Size(103, 22)
        Me.SystemTrayMenu_Exit.Text = "Exit"
        '
        'YTButton
        '
        Me.YTButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.YTButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.YTButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.YTButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.YTButton.Image = CType(resources.GetObject("YTButton.Image"), System.Drawing.Image)
        Me.YTButton.Location = New System.Drawing.Point(91, 405)
        Me.YTButton.Margin = New System.Windows.Forms.Padding(4)
        Me.YTButton.Name = "YTButton"
        Me.YTButton.Size = New System.Drawing.Size(29, 28)
        Me.YTButton.TabIndex = 10
        Me.YTButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(661, 34)
        Me.Panel1.TabIndex = 11
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(508, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(51, 34)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "__"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(559, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(51, 34)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "[__]"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(610, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 34)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(13, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Source Live Audio Mixer"
        '
        'Grip
        '
        Me.Grip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grip.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Grip.Image = Global.SLAM.My.Resources.Resources.grip
        Me.Grip.Location = New System.Drawing.Point(643, 461)
        Me.Grip.Name = "Grip"
        Me.Grip.Size = New System.Drawing.Size(18, 20)
        Me.Grip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Grip.TabIndex = 12
        Me.Grip.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(661, 483)
        Me.Controls.Add(Me.Grip)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.YTButton)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.PlayKeyButton)
        Me.Controls.Add(Me.ChangeDirButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.TrackList)
        Me.Controls.Add(Me.ImportButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GameSelector)
        Me.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(661, 483)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Source Live Audio Mixer"
        Me.TrackContextMenu.ResumeLayout(False)
        Me.SystemTrayMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GameSelector As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImportButton As System.Windows.Forms.Button
    Friend WithEvents TrackList As System.Windows.Forms.ListView
    Friend WithEvents LoadedCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents TrackCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents TagsCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents ImportDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents WavWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents PollRelayWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ChangeDirButton As System.Windows.Forms.Button
    Friend WithEvents TrackContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextHotKey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HotKeyCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents RemoveHotkeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayKeyButton As System.Windows.Forms.Button
    Friend WithEvents VolumeCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents SetVolumeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrimToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Trimmed As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SystemTrayIcon As NotifyIcon
    Friend WithEvents SystemTrayMenu As ContextMenuStrip
    Friend WithEvents SystemTrayMenu_Open As ToolStripMenuItem
    Friend WithEvents SystemTrayMenu_StartStop As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SystemTrayMenu_Exit As ToolStripMenuItem
    Friend WithEvents YTButton As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Grip As PictureBox
End Class

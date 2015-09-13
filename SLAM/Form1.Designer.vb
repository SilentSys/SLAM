<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GameSelector = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.TrackList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StartButton = New System.Windows.Forms.Button()
        Me.ImportDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.WavWorker = New System.ComponentModel.BackgroundWorker()
        Me.PollRelayWorker = New System.ComponentModel.BackgroundWorker()
        Me.ChangeDirButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PlayKeyTextBox = New System.Windows.Forms.TextBox()
        Me.ChangeDirDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'GameSelector
        '
        Me.GameSelector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GameSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GameSelector.FormattingEnabled = True
        Me.GameSelector.Location = New System.Drawing.Point(56, 12)
        Me.GameSelector.MaxDropDownItems = 100
        Me.GameSelector.Name = "GameSelector"
        Me.GameSelector.Size = New System.Drawing.Size(335, 21)
        Me.GameSelector.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Game:"
        '
        'ImportButton
        '
        Me.ImportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImportButton.Location = New System.Drawing.Point(15, 288)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(75, 23)
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
        Me.TrackList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.TrackList.FullRowSelect = True
        Me.TrackList.HideSelection = False
        Me.TrackList.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TrackList.Location = New System.Drawing.Point(15, 39)
        Me.TrackList.MultiSelect = False
        Me.TrackList.Name = "TrackList"
        Me.TrackList.Size = New System.Drawing.Size(457, 243)
        Me.TrackList.TabIndex = 4
        Me.TrackList.UseCompatibleStateImageBehavior = False
        Me.TrackList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Loaded"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Track"
        Me.ColumnHeader2.Width = 137
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Tags"
        Me.ColumnHeader3.Width = 43
        '
        'StartButton
        '
        Me.StartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartButton.Location = New System.Drawing.Point(96, 288)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 5
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ImportDialog
        '
        Me.ImportDialog.FileName = "ImportDialog"
        Me.ImportDialog.Filter = "Audio Files|*.mp3;*.wav"
        Me.ImportDialog.Multiselect = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 317)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(457, 23)
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
        Me.ChangeDirButton.Location = New System.Drawing.Point(397, 10)
        Me.ChangeDirButton.Name = "ChangeDirButton"
        Me.ChangeDirButton.Size = New System.Drawing.Size(75, 23)
        Me.ChangeDirButton.TabIndex = 7
        Me.ChangeDirButton.Text = "Change Dir"
        Me.ChangeDirButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(390, 293)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Play Key:"
        '
        'PlayKeyTextBox
        '
        Me.PlayKeyTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayKeyTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.PlayKeyTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PlayKeyTextBox.Location = New System.Drawing.Point(447, 290)
        Me.PlayKeyTextBox.MaxLength = 2
        Me.PlayKeyTextBox.Name = "PlayKeyTextBox"
        Me.PlayKeyTextBox.Size = New System.Drawing.Size(25, 20)
        Me.PlayKeyTextBox.TabIndex = 9
        Me.PlayKeyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChangeDirDialog
        '
        Me.ChangeDirDialog.Description = "Select your steamapps folder:"
        Me.ChangeDirDialog.ShowNewFolderButton = False
        '
        'BackgroundWorker1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 352)
        Me.Controls.Add(Me.PlayKeyTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChangeDirButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.TrackList)
        Me.Controls.Add(Me.ImportButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GameSelector)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Source Live Audio Mixer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GameSelector As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImportButton As System.Windows.Forms.Button
    Friend WithEvents TrackList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents ImportDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents WavWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents PollRelayWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ChangeDirButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PlayKeyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ChangeDirDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class

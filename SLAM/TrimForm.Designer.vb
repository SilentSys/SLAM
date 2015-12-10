<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrimForm
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
        Me.NumericRight = New System.Windows.Forms.NumericUpDown()
        Me.DoneButton = New System.Windows.Forms.Button()
        Me.NumericLeft = New System.Windows.Forms.NumericUpDown()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumericLeftS = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericRightS = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BackgroundPlayer = New System.ComponentModel.BackgroundWorker()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.AdvWaveViewer1 = New SLAM.AdvWaveViewer()
        CType(Me.NumericRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericLeftS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericRightS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericRight
        '
        Me.NumericRight.Location = New System.Drawing.Point(57, 19)
        Me.NumericRight.Name = "NumericRight"
        Me.NumericRight.Size = New System.Drawing.Size(150, 20)
        Me.NumericRight.TabIndex = 2
        Me.NumericRight.ThousandsSeparator = True
        '
        'DoneButton
        '
        Me.DoneButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DoneButton.Location = New System.Drawing.Point(557, 203)
        Me.DoneButton.Name = "DoneButton"
        Me.DoneButton.Size = New System.Drawing.Size(215, 23)
        Me.DoneButton.TabIndex = 5
        Me.DoneButton.Text = "Done"
        Me.DoneButton.UseVisualStyleBackColor = True
        '
        'NumericLeft
        '
        Me.NumericLeft.Location = New System.Drawing.Point(57, 19)
        Me.NumericLeft.Name = "NumericLeft"
        Me.NumericLeft.Size = New System.Drawing.Size(150, 20)
        Me.NumericLeft.TabIndex = 6
        Me.NumericLeft.ThousandsSeparator = True
        '
        'ResetButton
        '
        Me.ResetButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResetButton.Location = New System.Drawing.Point(557, 174)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(100, 23)
        Me.ResetButton.TabIndex = 7
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.NumericLeftS)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NumericLeft)
        Me.GroupBox1.Location = New System.Drawing.Point(557, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 75)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Start"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Second:"
        '
        'NumericLeftS
        '
        Me.NumericLeftS.DecimalPlaces = 3
        Me.NumericLeftS.Location = New System.Drawing.Point(57, 45)
        Me.NumericLeftS.Name = "NumericLeftS"
        Me.NumericLeftS.Size = New System.Drawing.Size(150, 20)
        Me.NumericLeftS.TabIndex = 8
        Me.NumericLeftS.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Sample:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.NumericRightS)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.NumericRight)
        Me.GroupBox2.Location = New System.Drawing.Point(557, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(215, 75)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "End"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Second:"
        '
        'NumericRightS
        '
        Me.NumericRightS.DecimalPlaces = 3
        Me.NumericRightS.Location = New System.Drawing.Point(57, 45)
        Me.NumericRightS.Name = "NumericRightS"
        Me.NumericRightS.Size = New System.Drawing.Size(150, 20)
        Me.NumericRightS.TabIndex = 9
        Me.NumericRightS.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Sample:"
        '
        'BackgroundPlayer
        '
        Me.BackgroundPlayer.WorkerReportsProgress = True
        Me.BackgroundPlayer.WorkerSupportsCancellation = True
        '
        'PlayButton
        '
        Me.PlayButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayButton.Location = New System.Drawing.Point(672, 174)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(100, 23)
        Me.PlayButton.TabIndex = 10
        Me.PlayButton.Text = "Play"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'AdvWaveViewer1
        '
        Me.AdvWaveViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdvWaveViewer1.BackColor = System.Drawing.Color.White
        Me.AdvWaveViewer1.leftpos = 0
        Me.AdvWaveViewer1.leftSample = 0
        Me.AdvWaveViewer1.Location = New System.Drawing.Point(0, 0)
        Me.AdvWaveViewer1.Name = "AdvWaveViewer1"
        'Me.AdvWaveViewer1.Position = CType(0, Long)
        Me.AdvWaveViewer1.rightpos = 0
        Me.AdvWaveViewer1.rightSample = 0
        Me.AdvWaveViewer1.SamplesPerPixel = 128
        Me.AdvWaveViewer1.Size = New System.Drawing.Size(551, 231)
        Me.AdvWaveViewer1.StartPosition = CType(0, Long)
        Me.AdvWaveViewer1.TabIndex = 0
        Me.AdvWaveViewer1.WaveStream = Nothing
        '
        'TrimForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 231)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.DoneButton)
        Me.Controls.Add(Me.AdvWaveViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(16, 270)
        Me.Name = "TrimForm"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trim"
        CType(Me.NumericRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericLeftS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericRightS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdvWaveViewer1 As SLAM.AdvWaveViewer
    Friend WithEvents NumericRight As System.Windows.Forms.NumericUpDown
    Friend WithEvents DoneButton As System.Windows.Forms.Button
    Friend WithEvents NumericLeft As System.Windows.Forms.NumericUpDown
    Friend WithEvents ResetButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NumericLeftS As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericRightS As System.Windows.Forms.NumericUpDown
    Friend WithEvents BackgroundPlayer As System.ComponentModel.BackgroundWorker
    Friend WithEvents PlayButton As System.Windows.Forms.Button
End Class

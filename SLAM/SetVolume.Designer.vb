<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetVolume
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
        Me.SelectButton = New System.Windows.Forms.Button()
        Me.VolumeBar = New System.Windows.Forms.TrackBar()
        Me.VolumeNumber = New System.Windows.Forms.TextBox()
        CType(Me.VolumeBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SelectButton
        '
        Me.SelectButton.Location = New System.Drawing.Point(272, 63)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(100, 23)
        Me.SelectButton.TabIndex = 1
        Me.SelectButton.Text = "Done"
        Me.SelectButton.UseVisualStyleBackColor = True
        '
        'VolumeBar
        '
        Me.VolumeBar.Location = New System.Drawing.Point(12, 12)
        Me.VolumeBar.Maximum = 20
        Me.VolumeBar.Name = "VolumeBar"
        Me.VolumeBar.Size = New System.Drawing.Size(360, 45)
        Me.VolumeBar.TabIndex = 3
        Me.VolumeBar.Value = 10
        '
        'VolumeNumber
        '
        Me.VolumeNumber.Location = New System.Drawing.Point(12, 59)
        Me.VolumeNumber.MaxLength = 3
        Me.VolumeNumber.Name = "VolumeNumber"
        Me.VolumeNumber.Size = New System.Drawing.Size(100, 20)
        Me.VolumeNumber.TabIndex = 4
        Me.VolumeNumber.Text = "100"
        '
        'SetVolume
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 91)
        Me.Controls.Add(Me.VolumeNumber)
        Me.Controls.Add(Me.VolumeBar)
        Me.Controls.Add(Me.SelectButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetVolume"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Volume"
        CType(Me.VolumeBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelectButton As System.Windows.Forms.Button
    Friend WithEvents VolumeBar As System.Windows.Forms.TrackBar
    Friend WithEvents VolumeNumber As System.Windows.Forms.TextBox
End Class

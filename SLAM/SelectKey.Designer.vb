<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectKey
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BindKeyBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'SelectButton
        '
        Me.SelectButton.Location = New System.Drawing.Point(12, 33)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(185, 23)
        Me.SelectButton.TabIndex = 1
        Me.SelectButton.Text = "Done"
        Me.SelectButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select a key:"
        '
        'BindKeyBox
        '
        Me.BindKeyBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.BindKeyBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.BindKeyBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.BindKeyBox.FormattingEnabled = True
        Me.BindKeyBox.Items.AddRange(New Object() {"'", "-", ",", ".", "/", "[", "\", "]", "`", "=", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "ALT", "B", "BACKSPACE", "C", "CAPSLOCK", "CTRL", "D", "DEL", "DOWNARROW", "E", "END", "ENTER", "ESCAPE", "F", "F1", "F10", "F11", "F12", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "G", "H", "HOME", "I", "INS", "J", "K", "KP_5", "KP_DEL", "KP_DOWNARROW", "KP_END", "KP_ENTER", "KP_HOME", "KP_INS", "KP_LEFTARROW", "KP_MINUS", "KP_MULTIPLY", "KP_PGDN", "KP_PGUP", "KP_PLUS", "KP_RIGHTARROW", "KP_SLASH", "KP_UPARROW", "L", "LEFTARROW", "LWIN", "M", "MOUSE1", "MOUSE2", "MOUSE3", "MOUSE4", "MOUSE5", "MWHEELDOWN", "MWHEELUP", "N", "NUMLOCK", "O", "P", "PGDN", "PGUP", "Q", "R", "RCTRL", "RIGHTARROW", "RSHIFT", "RWIN", "S", "SCROLLOCK", "SEMICOLON", "SHIFT", "SPACE", "T", "TAB", "U", "UPARROW", "V", "W", "X", "Y", "Z"})
        Me.BindKeyBox.Location = New System.Drawing.Point(84, 6)
        Me.BindKeyBox.Name = "BindKeyBox"
        Me.BindKeyBox.Size = New System.Drawing.Size(113, 21)
        Me.BindKeyBox.TabIndex = 0
        '
        'SelectKey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(209, 64)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SelectButton)
        Me.Controls.Add(Me.BindKeyBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectKey"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Key Selector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelectButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindKeyBox As System.Windows.Forms.ComboBox
End Class

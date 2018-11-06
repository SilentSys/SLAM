Public Class RenameForm

    Public filename As String

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        If String.IsNullOrWhiteSpace(NameBox.Text) Then
            MessageBox.Show("The name can not be empty.", "Naming Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            filename = NameBox.Text
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub RenameForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                DoneButton_Click(sender, Nothing)
            Case Keys.Escape
                DialogResult = Windows.Forms.DialogResult.Cancel
        End Select
    End Sub

    Private Sub RenameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NameBox.Text = filename
        KeyPreview = True
    End Sub
End Class
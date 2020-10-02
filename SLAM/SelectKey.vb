Public Class SelectKey

    Public ChosenKey As String
    Dim WholeList As New List(Of String)

    Private Sub SelectKey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item In BindKeyBox.Items
            WholeList.Add(item.ToString)
        Next
        KeyPreview = True
    End Sub

    Private Sub SelectKey_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                DoneButton_Click(sender, Nothing)
            Case Keys.Escape
                DialogResult = Windows.Forms.DialogResult.Cancel
        End Select
    End Sub

    Private Sub BindKeyBox_TextChanged(sender As Object, e As EventArgs) Handles BindKeyBox.TextChanged
        BindKeyBox.DroppedDown = False

        If String.IsNullOrEmpty(BindKeyBox.Text) Then
            BindKeyBox.Items.Clear()
            BindKeyBox.Items.AddRange(WholeList.ToArray)
        Else

            BindKeyBox.Text = BindKeyBox.Text.ToUpper
            BindKeyBox.SelectionStart = BindKeyBox.Text.Length

            If WholeList.Contains(BindKeyBox.Text) Then
                BindKeyBox.ForeColor = Color.Green
            Else
                BindKeyBox.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        If WholeList.Contains(BindKeyBox.Text) Then
            ChosenKey = BindKeyBox.Text
            DialogResult = Windows.Forms.DialogResult.OK

        ElseIf String.IsNullOrEmpty(BindKeyBox.Text) Then
            Me.Close()

        Else
            MessageBox.Show("That bind key does not exist.", "Key Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
Public Class SetVolume

    Public Volume As Integer

    Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        Volume = Convert.ToInt32(VolumeNumber.Text)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub VolumeBar_Scroll(sender As Object, e As EventArgs) Handles VolumeBar.Scroll
        VolumeNumber.Text = VolumeBar.Value * 10
    End Sub

    Private Sub VolumeNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles VolumeNumber.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub VolumeNumber_TextChanged(sender As Object, e As EventArgs) Handles VolumeNumber.TextChanged
        If Not String.IsNullOrEmpty(VolumeNumber.Text) Then
            If Convert.ToInt32(VolumeNumber.Text) > 200 Then
                VolumeNumber.Text = "200"
                VolumeNumber.SelectionStart = VolumeNumber.TextLength
            End If

            VolumeBar.Value = Convert.ToInt32(VolumeNumber.Text) / 10

        End If
    End Sub
End Class
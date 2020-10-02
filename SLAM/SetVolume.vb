﻿Public Class SetVolume

    Public Volume As Integer
    Const MAX_VOLUME = 200

    Private Sub SetVolume_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VolumeNumber.Text = Volume.ToString
        VolumeBar.Value = Volume / 5
        KeyPreview = True
    End Sub

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        Volume = Convert.ToInt32(VolumeNumber.Text)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub SetVolume_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                DoneButton_Click(sender, Nothing)
            Case Keys.Escape
                DialogResult = Windows.Forms.DialogResult.Cancel
        End Select
    End Sub

    Private Sub VolumeBar_Scroll(sender As Object, e As EventArgs) Handles VolumeBar.Scroll
        VolumeNumber.Text = VolumeBar.Value * 5
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
            If Convert.ToInt32(VolumeNumber.Text) > MAX_VOLUME Then
                VolumeNumber.Text = MAX_VOLUME.ToString
                VolumeNumber.SelectionStart = VolumeNumber.TextLength
            End If

            VolumeBar.Value = Convert.ToInt32(VolumeNumber.Text) / 5

        End If
    End Sub
End Class
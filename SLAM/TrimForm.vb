Imports NAudio
Imports NAudio.Wave
Imports System.Threading
Imports System.IO

Public Class TrimForm
    Public WavFile As String
    Public startpos As Integer
    Public endpos As Integer

    Private Sub TrimForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(WavFile) Then
            Using reader As New Wave.WaveFileReader(WavFile)
                AdvWaveViewer1.WaveStream = New Wave.WaveFileReader(WavFile)
                'reader.WaveFormat.SampleRate
            End Using

            NumericRightS.Maximum = Decimal.MaxValue
            NumericRight.Maximum = AdvWaveViewer1.MaxSamples
            NumericRight.Increment = AdvWaveViewer1.SamplesPerPixel

            NumericLeftS.Maximum = Decimal.MaxValue
            NumericLeft.Maximum = Decimal.MaxValue
            NumericLeft.Increment = AdvWaveViewer1.SamplesPerPixel

            If startpos = endpos And endpos = 0 Then
                NumericRight.Value = AdvWaveViewer1.MaxSamples
            Else
                AdvWaveViewer1.rightpos = endpos
                AdvWaveViewer1.leftpos = startpos
                NumericRight.Value = AdvWaveViewer1.rightSample
                NumericLeft.Value = AdvWaveViewer1.leftSample
            End If

        End If
    End Sub

    Private Sub TrimForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If BackgroundPlayer.IsBusy Then
            BackgroundPlayer.CancelAsync()
        End If
    End Sub

    Private Sub AdvWaveViewer1_MouseUp(sender As Object, e As MouseEventArgs) Handles AdvWaveViewer1.MouseUp
        NumericRight.Value = AdvWaveViewer1.rightSample
        NumericLeft.Value = AdvWaveViewer1.leftSample
    End Sub

    Private Sub NumericLeft_ValueChanged(sender As Object, e As EventArgs) Handles NumericLeft.ValueChanged
        If NumericLeft.Value >= AdvWaveViewer1.rightSample Then
            NumericLeft.Value = NumericRight.Value - 1
        End If
        AdvWaveViewer1.leftSample = NumericLeft.Value
        NumericLeftS.Value = NumericLeft.Value / AdvWaveViewer1.SampleRate
    End Sub

    Private Sub NumericRight_ValueChanged(sender As Object, e As EventArgs) Handles NumericRight.ValueChanged
        If NumericRight.Value <= AdvWaveViewer1.leftSample Then
            NumericRight.Value = NumericLeft.Value + 1
        End If
        AdvWaveViewer1.rightSample = NumericRight.Value
        NumericRightS.Value = NumericRight.Value / AdvWaveViewer1.SampleRate
    End Sub

    Private Sub DoneButton_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        startpos = AdvWaveViewer1.leftpos

        If AdvWaveViewer1.rightSample = AdvWaveViewer1.MaxSamples And AdvWaveViewer1.leftpos = 0 Then
            endpos = 0
        Else
            endpos = AdvWaveViewer1.rightpos
        End If


        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub TrimForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        NumericLeft.Increment = AdvWaveViewer1.SamplesPerPixel
        NumericRight.Increment = AdvWaveViewer1.SamplesPerPixel
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        NumericLeft.Value = 0
        NumericRight.Value = AdvWaveViewer1.MaxSamples
    End Sub

    Private Sub NumericLeftS_ValueChanged(sender As Object, e As EventArgs) Handles NumericLeftS.ValueChanged
        NumericLeft.Value = NumericLeftS.Value * AdvWaveViewer1.SampleRate
    End Sub

    Private Sub NumericRightS_ValueChanged(sender As Object, e As EventArgs) Handles NumericRightS.ValueChanged
        If (NumericRightS.Value * AdvWaveViewer1.SampleRate) <= NumericRight.Maximum Then
            NumericRight.Value = NumericRightS.Value * AdvWaveViewer1.SampleRate
        Else
            NumericRight.Value = NumericRight.Maximum
            NumericRightS.Value = NumericRight.Value / AdvWaveViewer1.SampleRate
        End If

    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        If BackgroundPlayer.IsBusy = False Then
            BackgroundPlayer.RunWorkerAsync(New Object(2) {AdvWaveViewer1.WaveStream, AdvWaveViewer1.leftpos, AdvWaveViewer1.rightpos})
            PlayButton.Text = "Stop"
            DisableInterface()
            PlayButton.Enabled = True
        Else
            BackgroundPlayer.CancelAsync()
            PlayButton.Text = "Play"
        End If
    End Sub

    Private Sub BackgroundPlayer_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundPlayer.DoWork
        Dim WaveFloat As WaveStream = e.Argument(0)
        Dim LeftPos As Integer = e.Argument(1)
        Dim RightPos As Integer = e.Argument(2)

        Dim bytes((RightPos - LeftPos)) As Byte

        WaveFloat.Position = LeftPos
        WaveFloat.Read(bytes, 0, (RightPos - LeftPos))

        WaveFloat = New RawSourceWaveStream(New MemoryStream(bytes), WaveFloat.WaveFormat)
        'WaveFloat.PadWithZeroes = False

        Using output = New WaveOutEvent()
            output.Init(WaveFloat)
            output.Play()
            While output.PlaybackState = PlaybackState.Playing And Not BackgroundPlayer.CancellationPending
                Thread.Sleep(45)
                BackgroundPlayer.ReportProgress(output.GetPosition() / (WaveFloat.WaveFormat.BitsPerSample / 8))
            End While
        End Using
    End Sub

    Private Sub BackgroundPlayer_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundPlayer.ProgressChanged
        AdvWaveViewer1.marker = e.ProgressPercentage
    End Sub

    Private Sub BackgroundPlayer_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundPlayer.RunWorkerCompleted
        PlayButton.Text = "Play"
        AdvWaveViewer1.marker = 0
        EnableInterface()
    End Sub

    Private Sub EnableInterface()
        For Each Control In Me.Controls
            Control.Enabled = True
        Next
    End Sub

    Private Sub DisableInterface()
        For Each Control In Me.Controls
            Control.Enabled = False
        Next
    End Sub
End Class
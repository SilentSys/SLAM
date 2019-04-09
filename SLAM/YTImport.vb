Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions
Imports YoutubeExtractor
Public Class YTImport

    Public file As String
    Sub ProgressChangedHandler(sender, args)
        Console.WriteLine(args.ProgressPercentage)
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click
        Dim youtubeMatch As Match = New Regex("youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(TextBox1.Text)

        If youtubeMatch.Success Then
            TextBox1.Enabled = False
            ImportButton.Enabled = False
            DownloadWorker.RunWorkerAsync("youtube.com/watch?v=" & youtubeMatch.Groups(1).Value)
            ToolStripStatusLabel1.Text = "Status: Downloading"
        Else
            MessageBox.Show("Invalid YouTube URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Enabled = True
            ImportButton.Enabled = True
        End If
    End Sub

    Private Sub YTImport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If ImportButton.Enabled Then
                    ImportButton_Click(sender, Nothing)
                End If
            Case Keys.Escape
                DialogResult = Windows.Forms.DialogResult.Cancel
        End Select
    End Sub

    Private Sub DownloadWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles DownloadWorker.DoWork
        Try
            Dim videoInfos As IEnumerable(Of VideoInfo) = DownloadUrlResolver.GetDownloadUrls(e.Argument).OrderBy(Function(vid) vid.Resolution)

            Dim video As VideoInfo = videoInfos.First(Function(info) info.AdaptiveType = AdaptiveType.Audio AndAlso info.AudioType = AudioType.Aac OrElse info.AdaptiveType = AdaptiveType.None AndAlso info.VideoType = VideoType.Mp4 AndAlso info.AudioBitrate >= 128)
            If IsNothing(video) Then
                If videoInfos.Any(Function(info) info.AdaptiveType = AdaptiveType.None AndAlso info.VideoType = VideoType.Mp4) Then
                    video = videoInfos.First(Function(info) info.AdaptiveType = AdaptiveType.None AndAlso info.VideoType = VideoType.Mp4)
                Else
                    Throw New System.Exception("Could not find download.")
                End If
            End If

            If video.RequiresDecryption Then
                DownloadUrlResolver.DecryptDownloadUrl(video)
            End If


            If Not Directory.Exists(Path.GetFullPath("temp\")) Then
                Directory.CreateDirectory(Path.GetFullPath("temp\"))
            End If

            Dim filename As String = String.Join("", video.Title.Split(Path.GetInvalidFileNameChars()))

            Dim VideoDownloader = New VideoDownloader(video, Path.GetFullPath("temp\" & filename & video.VideoExtension))

            AddHandler VideoDownloader.DownloadProgressChanged, Sub(send, args) DownloadWorker.ReportProgress(Convert.ToInt32(args.ProgressPercentage))

            VideoDownloader.Execute()

            e.Result = Path.GetFullPath("temp\" & filename & video.VideoExtension)
        Catch ex As Exception
            Form1.LogError(ex)

            e.Result = ex
        End Try
    End Sub

    Private Sub DownloadWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles DownloadWorker.ProgressChanged
        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub DownloadWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles DownloadWorker.RunWorkerCompleted
        Dim ExceptionType = e.Result.GetType()

        While ExceptionType IsNot Nothing
            If ExceptionType = GetType(Exception) Then
                MessageBox.Show(e.Result.Message & " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Enabled = True
                ImportButton.Enabled = True
                Return
            End If

            ExceptionType = ExceptionType.BaseType
        End While

        file = e.Result
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub DonateLabel_Click(sender As Object, e As EventArgs) Handles DonateLabel.Click
        Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RVLLPGWJUG6CY")
    End Sub

    Private Sub YTImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()
        KeyPreview = True
    End Sub
End Class
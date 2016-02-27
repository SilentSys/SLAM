Imports System.IO
Imports System.Media
Imports NAudio.Wave
Imports YoutubeExtractor

Public Class YTDL

    Dim linkas As [String] = "null"
    Dim pavadinimas As [String]
    Dim SteamappsPath As String = My.Settings.SteamAppsFolder



    Private Async Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click



        If TextBox1.Text <> "" Then
            For Each c As Char In TextBox1.Text
                If c = " "c Then
                    TextBox1.Text = TextBox1.Text.Replace(c.ToString(), "")
                Else
                    Exit For
                End If
            Next
            linkas = TextBox1.Text
            TextBox1.Clear()
        Else

            linkas = WebBrowser1.Url.ToString()
        End If


        If linkas.StartsWith("https://www.youtube.com/watch?") Then

        Else

            Return
        End If




        WebBrowser1.Navigate("about:blank")
        Await Task.Delay(100)

        Dim videoInfos As IEnumerable(Of VideoInfo) = DownloadUrlResolver.GetDownloadUrls(linkas)
        Dim video As VideoInfo = videoInfos.Where(Function(info) info.CanExtractAudio).OrderByDescending(Function(info) info.AudioBitrate).First()
        If video.RequiresDecryption Then
            DownloadUrlResolver.DecryptDownloadUrl(video)
        End If
        Dim audioDownloader = New AudioDownloader(video, "1.mp3")



        Try

            audioDownloader.Execute()

        Catch ex As Exception

            If WebBrowser1.CanGoBack Then
                WebBrowser1.GoBack()
                WebBrowser1.GoBack()
            Else
                WebBrowser1.Navigate("http://www.youtube.com/")
            End If
            MsgBox("Can't download this video, try other one", 0, "")
            Return
        End Try



        pavadinimas = video.Title

        For Each c As Char In Path.GetInvalidFileNameChars()
            pavadinimas = pavadinimas.Replace(c.ToString(), "")
        Next


        WebBrowser1.Navigate("http://www.youtube.com/")


        Await Task.Delay(100)


        ' Form1.WaveCreator("1.mp3", "csgo/" + pavadinimas + ".wav", Form1.GetCurrentGame())

        Dim reader = New WaveChannel32(New Mp3FileReader("1.mp3"))
        reader.PadWithZeroes = False
        Dim newFormat = New WaveFormat(22050, 16, 1)

        Dim resampler = New MediaFoundationResampler(reader, newFormat)

        resampler.ResamplerQuality = 60
        Await Task.Delay(10)


        WaveFileWriter.CreateWaveFile("csgo/" + pavadinimas + ".wav", resampler)
        resampler.Dispose()
        reader.Dispose()
        My.Computer.FileSystem.DeleteFile("1.mp3")


        Await Task.Delay(10)
        SystemSounds.Beep.Play()
        Threading.Thread.Sleep(100)
        SystemSounds.Beep.Play()
        Threading.Thread.Sleep(100)
        SystemSounds.Beep.Play()

        Form1.RefreshListAndCfgFiles()


        If CheckBox1.Checked = True Then
            Form1.autoload(pavadinimas)
        End If


    End Sub

End Class
Imports NAudio 'Modified Version which does not write "extraSize"
Imports NAudio.Wave
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Form1
    Dim Games As New List(Of SourceGame)

    Dim SteamappsPath As String = My.Settings.SteamAppsFolder
    Public PlayKey As String = My.Settings.PlayKey
    Dim running As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisableInterface()

        PlayKeyTextBox.Text = PlayKey

        Dim csgo As New SourceGame
        csgo.name = "Counter-Strike: Global Offensive"
        csgo.directory = "common\Counter-Strike Global Offensive\"
        csgo.ToCfg = "csgo\cfg\"
        csgo.libraryname = "csgo\"
        csgo.samplerate = 22050
        Games.Add(csgo)

        Dim tf2 As New SourceGame
        tf2.name = "Team Fortress 2"
        tf2.directory = "common\Team Fortress 2\"
        tf2.ToCfg = "tf\cfg\"
        tf2.libraryname = "tf2\"
        Games.Add(tf2)

        If String.IsNullOrEmpty(SteamappsPath) Then
            If ChangeDirDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                SteamappsPath = ChangeDirDialog.SelectedPath & "\"
            Else
                Me.Close()
            End If
        End If

        LoadGames()
    End Sub

    Public Shared Sub WaveCreator(File As String, outputFile As String)
        Dim reader

        If Path.GetExtension(File) = ".mp3" Then
            reader = New Mp3FileReader(File)
        ElseIf Path.GetExtension(File) = ".wav" Then
            reader = New WaveFileReader(File)
        End If

        Dim outFormat = New WaveFormat(22050, 16, 1)

        Dim resampler = New MediaFoundationResampler(reader, outFormat)

        resampler.ResamplerQuality = 60

        WaveFileWriter.CreateWaveFile(outputFile, resampler)

        resampler.Dispose()
    End Sub

    Private Sub GameSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GameSelector.SelectedIndexChanged
        ReloadTracks(GetCurrentGame)
        RefreshTrackList()
        My.Settings.LastGame = GameSelector.Text
        My.Settings.Save()
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click
        If ImportDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ProgressBar1.Maximum = ImportDialog.FileNames.Count

            Dim WorkerPassthrough() As Object = {GetCurrentGame(), ImportDialog.FileNames}

            WavWorker.RunWorkerAsync(WorkerPassthrough)
            DisableInterface()
        End If
    End Sub

    Private Sub WavWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WavWorker.DoWork
        Dim Game As SourceGame = e.Argument(0)
        Dim Files() As String = e.Argument(1)
        Dim FailedFiles As New List(Of String)

        For Each File In Files

            Try
                Dim OutFile As String = Path.Combine(Game.libraryname, Path.GetFileNameWithoutExtension(File) & ".wav")

                WaveCreator(File, OutFile)

            Catch ex As Exception
                FailedFiles.Add(File)
            End Try
            WavWorker.ReportProgress(0)
        Next

        e.Result = FailedFiles

    End Sub

    Private Sub WavWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles WavWorker.ProgressChanged
        ProgressBar1.PerformStep()
        ReloadTracks(GetCurrentGame)
        RefreshTrackList()
    End Sub

    Private Sub WavWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WavWorker.RunWorkerCompleted
        ProgressBar1.Value = 0
        Dim MsgBoxText As String = "Conversion complete!"
        Dim FailedFiles As New List(Of String)

        For Each FilePath In e.Result
            FailedFiles.Add(Path.GetFileName(FilePath))
        Next

        If FailedFiles.Count > 0 Then
            MsgBoxText = MsgBoxText & " However, the following files failed to convert: " & String.Join(", ", FailedFiles)
        End If

        ReloadTracks(GetCurrentGame)
        RefreshTrackList()
        MsgBox(MsgBoxText)
        EnableInterface()
    End Sub

    Private Function GetCurrentGame() As SourceGame
        For Each Game In Games
            If Game.name = GameSelector.SelectedItem.ToString Then
                Return Game
            End If
        Next
    End Function

    Private Sub ReloadTracks(Game As SourceGame)
        If Directory.Exists(Game.libraryname) Then

            Game.tracks.Clear()
            For Each File In Directory.GetFiles(Game.libraryname)

                If Game.FileExtension = Path.GetExtension(File) Then
                    Dim track As New SourceGame.track
                    track.name = Path.GetFileNameWithoutExtension(File)
                    Game.tracks.Add(track)
                End If

            Next

            CreateTags(Game)

        Else
            Directory.CreateDirectory(Game.libraryname)
        End If
    End Sub

    Private Sub RefreshTrackList()
        TrackList.Items.Clear()

        Dim Game As SourceGame = GetCurrentGame()

        For Each Track In Game.tracks
            TrackList.Items.Add(New ListViewItem({"False", Track.name, """" & String.Join(""", """, Track.tags) & """"}))
        Next


        TrackList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)
        TrackList.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If running Then
            StopPoll()
        Else
            StartPoll()
            MsgBox("Don't forget to type ""exec slam"" in colsole!")
        End If
    End Sub

    Private Sub StartPoll()
        running = True
        StartButton.Text = "Stop"
        CreateCfgFiles()
        DisableInterface()
        StartButton.Enabled = True
        PollRelayWorker.RunWorkerAsync(GetCurrentGame)
    End Sub

    Private Sub StopPoll()
        running = False
        StartButton.Text = "Start"
        EnableInterface()
        PollRelayWorker.CancelAsync()
    End Sub

    Private Sub CreateCfgFiles()
        Dim Game As SourceGame = GetCurrentGame()
        Dim GameDir As String = Path.Combine(SteamappsPath, Game.directory)
        Dim GameCfgFolder As String = Path.Combine(GameDir, Game.ToCfg)

        Using slam_cfg As StreamWriter = New StreamWriter(GameCfgFolder & "slam.cfg")
            slam_cfg.WriteLine("alias slam_listtracks ""exec slam_tracklist.cfg""")
            slam_cfg.WriteLine("alias list slam_listtracks")
            slam_cfg.WriteLine("alias tracks slam_listtracks")
            slam_cfg.WriteLine("alias la slam_listtracks")
            slam_cfg.WriteLine("alias slam_play slam_play_on")
            slam_cfg.WriteLine("alias slam_play_on ""alias slam_play slam_play_off; voice_inputfromfile 1; voice_loopback 1; +voicerecord""")
            slam_cfg.WriteLine("alias slam_play_off ""-voicerecord; voice_inputfromfile 0; voice_loopback 0; alias slam_play slam_play_on""")
            slam_cfg.WriteLine("alias slam_updatecfg ""host_writeconfig slam_relay""")
            slam_cfg.WriteLine("bind {0} slam_play", PlayKey)
            For Each Track In Game.tracks
                Dim index As String = Game.tracks.IndexOf(Track)
                slam_cfg.WriteLine("alias {0} ""bind {1} {0}; slam_updatecfg; echo Loaded: {2}""", index + 1, Game.RelayKey, Track.name)

                For Each TrackTag In Track.tags
                    slam_cfg.WriteLine("alias {0} ""bind {1} {2}; slam_updatecfg; echo Loaded: {3}""", TrackTag, Game.RelayKey, index + 1, Track.name)
                Next
            Next
            slam_cfg.WriteLine("voice_enable 1; voice_modenable 1; voice_forcemicrecord 0; voice_fadeouttime 0.0; con_enable 1")
        End Using

        Using slam_tracklist_cfg As StreamWriter = New StreamWriter(GameCfgFolder & "slam_tracklist.cfg")
            slam_tracklist_cfg.WriteLine("echo ""You can select tracks either by typing a tag, or their track number.""")
            slam_tracklist_cfg.WriteLine("echo ""--------------------Tracks--------------------""")
            For Each Track In Game.tracks
                Dim index As String = Game.tracks.IndexOf(Track)
                slam_tracklist_cfg.WriteLine("echo ""{0}. {1} [{2}]""", index + 1, Track.name, "'" & String.Join("', '", Track.tags) & "'")
            Next
            slam_tracklist_cfg.WriteLine("echo ""----------------------------------------------""")
        End Using

    End Sub

    Private Function LoadTrack(ByVal Game As SourceGame, ByVal index As Integer) As Boolean
        Dim TrackName As String
        If Game.tracks.Count > index Then
            TrackName = Game.tracks(index).name
            Dim voicefile As String = Path.Combine(SteamappsPath, Game.directory) & "voice_input.wav"

            Try
                If File.Exists(voicefile) Then
                    File.Delete(voicefile)
                End If
                File.Copy(Game.libraryname & TrackName & ".wav", voicefile)

            Catch ex As Exception
                Return False
            End Try

        End If
        Return True
    End Function

    Public Shared Function recog(ByVal str As String, ByVal reg As String) As String
        Dim keyd As Match = Regex.Match(str, reg)
        Return (keyd.Groups(1).ToString)
    End Function

    Private Sub PollRelayWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles PollRelayWorker.DoWork
        Dim Game As SourceGame = e.Argument
        Dim GameDir As String = Path.Combine(SteamappsPath, Game.directory)
        Dim GameCfg As String = Path.Combine(GameDir, Game.ToCfg) & "slam_relay.cfg"

        Do
            If PollRelayWorker.CancellationPending Then
                Exit Do
            End If

            If File.Exists(GameCfg) Then
                Dim RelayCfg As String
                Using reader As StreamReader = New StreamReader(GameCfg)
                    RelayCfg = reader.ReadToEnd
                End Using

                Dim command As String = recog(RelayCfg, String.Format("bind ""{0}"" ""(.*?)""", Game.RelayKey))
                If Not String.IsNullOrEmpty(command) Then
                    'load audiofile
                    If IsNumeric(command) Then
                        If LoadTrack(Game, Convert.ToInt32(command) - 1) Then
                            PollRelayWorker.ReportProgress(Convert.ToInt32(command) - 1)
                        End If
                    End If
                    File.Delete(GameCfg)
                End If
            End If

            Thread.Sleep(Game.PollInterval)
        Loop
    End Sub

    Private Sub PollRelayWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles PollRelayWorker.ProgressChanged
        DisplayLoaded(e.ProgressPercentage)
    End Sub

    Private Sub CreateTags(ByVal Game As SourceGame)
        Dim NameWords As New Dictionary(Of String, Integer)

        Dim index As Integer
        For Each Track In Game.tracks
            Dim Words As List(Of String) = Track.name.Split({" "c, "."c, "-"c, "_"c}).ToList

            For Each Word In Words

                If Not IsNumeric(Word) Then
                    If NameWords.ContainsKey(Word) Then
                        NameWords.Remove(Word)
                    Else
                        NameWords.Add(Word, index)
                    End If
                End If

            Next
            index += 1
        Next

        For Each Tag As KeyValuePair(Of String, Integer) In NameWords
            Game.tracks(Tag.Value).tags.Add(Tag.Key)
        Next
    End Sub

    Public Sub EnableInterface()
        GameSelector.Enabled = True
        TrackList.Enabled = True
        ImportButton.Enabled = True
        StartButton.Enabled = True
        ChangeDirButton.Enabled = True
        PlayKeyTextBox.Enabled = True
    End Sub

    Public Sub DisableInterface()
        GameSelector.Enabled = False
        TrackList.Enabled = False
        ImportButton.Enabled = False
        StartButton.Enabled = False
        ChangeDirButton.Enabled = False
        PlayKeyTextBox.Enabled = False
        PlayKeyTextBox.Text = PlayKey
    End Sub

    Public Sub DisplayLoaded(ByVal track As Integer)
        For i As Integer = 0 To TrackList.Items.Count - 1
            TrackList.Items(i).SubItems(0).Text = "False"
        Next
        TrackList.Items(track).SubItems(0).Text = "True"
    End Sub

    Private Sub PlayKeyTextBox_Enter(sender As Object, e As EventArgs) Handles PlayKeyTextBox.Enter
        BeginInvoke(DirectCast(Sub() PlayKeyTextBox.SelectAll(), Action))
    End Sub

    Private Sub PlayKey_TextChanged(sender As Object, e As EventArgs) Handles PlayKeyTextBox.TextChanged
        If String.IsNullOrEmpty(PlayKeyTextBox.Text) Then
            PlayKeyTextBox.Text = PlayKey
        End If

        If PlayKeyTextBox.Text.Count > 1 Then
            PlayKeyTextBox.Text = PlayKeyTextBox.Text.Substring(1)
        End If

        PlayKeyTextBox.SelectAll()
        PlayKey = PlayKeyTextBox.Text

        My.Settings.PlayKey = PlayKey
        My.Settings.Save()
    End Sub

    Private Sub ChangeDirButton_Click(sender As Object, e As EventArgs) Handles ChangeDirButton.Click
        If ChangeDirDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            SteamappsPath = ChangeDirDialog.SelectedPath & "\"
            LoadGames()
        End If
    End Sub

    Public Sub LoadGames()
        GameSelector.Items.Clear()

        For Each Game In Games
            Dim GameFullPath As String = Path.Combine(SteamappsPath, Game.directory)

            If Directory.Exists(GameFullPath) Then
                GameSelector.Items.Add(Game.name)
            End If

        Next


        If GameSelector.Items.Count > 0 Then
            Dim GoToIndex As String = 0

            If GameSelector.Items.Contains(My.Settings.LastGame) Then
                GoToIndex = GameSelector.Items.IndexOf(My.Settings.LastGame)
            End If

            GameSelector.Text = GameSelector.Items(GoToIndex).ToString
            ReloadTracks(GetCurrentGame)
            RefreshTrackList()

            My.Settings.SteamAppsFolder = SteamappsPath
            My.Settings.Save()

            EnableInterface()

        Else
            MsgBox("There are no games in your steamapps filder. Please click ""Change Dir"" and select a valid steamapps folder.")
            DisableInterface()
            ChangeDirButton.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub
End Class

Public Class SourceGame
    Public name As String
    Public directory As String
    Public ToCfg As String
    Public libraryname As String

    Public FileExtension As String = ".wav"
    Public samplerate As Integer = 11025
    Public bits As Integer = 16
    Public channels As Integer = 1

    Public PollInterval As Integer = 100
    Public RelayKey As String = "="

    Public tracks As New List(Of track)
    Public Class track
        Public name As String
        Public tags As New List(Of String)
    End Class
End Class

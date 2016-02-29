Imports NAudio 'Modified Version which does not write "extraSize"
Imports NAudio.Wave
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports SLAM.XmlSerialization
Imports System.Net.Http

Public Class Form1

    Dim Games As New List(Of SourceGame)

    Dim SteamappsPath As String = My.Settings.SteamAppsFolder
    Dim running As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisableInterface()

        RefreshPlayKey()

        If My.Settings.UpdateCheck Then
            CheckForUpdate()
        End If

        Dim csgo As New SourceGame
        csgo.name = "Counter-Strike: Global Offensive"
        csgo.id = 730
        csgo.directory = "common\Counter-Strike Global Offensive\"
        csgo.ToCfg = "csgo\cfg\"
        csgo.libraryname = "csgo\"
        csgo.samplerate = 22050
        csgo.blacklist.AddRange({"drop", "buy", "go", "fallback", "sticktog", "holdpos", "followme", "coverme", "regroup", "roger", "negative", "cheer", "compliment", "thanks", "enemydown", "reportingin", "enemyspot", "takepoint", "sectorclear", "inposition", "takingfire", "report", "getout"})
        Games.Add(csgo)

        Dim css As New SourceGame
        css.name = "Counter-Strike: Source"
        css.directory = "common\Counter-Strike Source\"
        css.ToCfg = "cstrike\cfg\"
        css.libraryname = "css\"
        Games.Add(css)

        Dim tf2 As New SourceGame
        tf2.name = "Team Fortress 2"
        tf2.directory = "common\Team Fortress 2\"
        tf2.ToCfg = "tf\cfg\"
        tf2.libraryname = "tf2\"
        Games.Add(tf2)

        LoadGames()

        If My.Settings.StartEnabled Then
            StartPoll()
        End If
    End Sub

    Public Sub WaveCreator(File As String, outputFile As String, Game As SourceGame)
        Dim reader As New MediaFoundationReader(File)

        Dim outFormat = New WaveFormat(Game.samplerate, Game.bits, Game.channels)

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
        If File.Exists("NAudio.dll") Then
            DisableInterface()
            If ImportDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ProgressBar1.Maximum = ImportDialog.FileNames.Count
                Dim WorkerPassthrough() As Object = {GetCurrentGame(), ImportDialog.FileNames}
                WavWorker.RunWorkerAsync(WorkerPassthrough)
            Else
                EnableInterface()
            End If

        Else
            MessageBox.Show("You are missing NAudio.dll! Cannot import without it!", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub WavWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WavWorker.DoWork
        Dim Game As SourceGame = e.Argument(0)
        Dim Files() As String = e.Argument(1)
        Dim FailedFiles As New List(Of String)

        For Each File In Files

            Try
                Dim OutFile As String = Path.Combine(Game.libraryname, Path.GetFileNameWithoutExtension(File) & ".wav")

                WaveCreator(File, OutFile, Game)

            Catch ex As Exception
                LogError(ex)
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

    Public Function GetCurrentGame() As SourceGame
        For Each Game In Games
            If Game.name = GameSelector.SelectedItem.ToString Then
                Return Game
            End If
        Next
        Return Nothing 'Null if nothing found
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
            LoadTrackKeys(Game)
            SaveTrackKeys(Game) 'To prune hotkeys from non-existing tracks

        Else
            Directory.CreateDirectory(Game.libraryname)
        End If
    End Sub

    Public Sub RefreshTrackList()
        TrackList.Items.Clear()

        Dim Game As SourceGame = GetCurrentGame()

        For Each Track In Game.tracks

            Dim trimmed As String = ""
            If Track.endpos > 0 Then
                trimmed = "Yes"
            End If

            TrackList.Items.Add(New ListViewItem({"False", Track.name, Track.hotkey, Track.volume & "%", trimmed, """" & String.Join(""", """, Track.tags) & """"}))
        Next


        TrackList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)
        TrackList.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize)
        TrackList.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If running Then
            StopPoll()
        Else
            StartPoll()
            If Not My.Settings.NoHint Then
                If MessageBox.Show("Don't forget to type ""exec slam"" in console! Click ""Cancel"" if you don't ever want to see this message again.", "SLAM", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                    My.Settings.NoHint = True
                    My.Settings.Save()
                End If
            End If
        End If
    End Sub

    Private Sub StartPoll()

        Dim Game As SourceGame = GetCurrentGame()
        If Not Game.id = 0 And My.Settings.UserDataEnabled Then 'The CFG's are located in the userdata folder
            Dim CFGExists As Boolean = False
            If Directory.Exists(My.Settings.UserdataPath) Then
                For Each userdir As String In Directory.GetDirectories(My.Settings.UserdataPath)
                    Dim CFGPath As String = Path.Combine(userdir, Game.id.ToString) & "\local\cfg\"
                    If Directory.Exists(CFGPath) Then
                        CFGExists = True
                        Exit For
                    End If
                Next
            End If
            If Not CFGExists Then
                MessageBox.Show("The set ""UserData"" folder does not seem to be correct! Please choose the correct folder.", "Folder does not exist!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If ShowUserDataSelector() Then
                    StartPoll()
                End If
                Return
            End If
        End If

        running = True
        StartButton.Text = "Stop"
        CreateCfgFiles()
        DisableInterface()
        StartButton.Enabled = True
        TrackList.Enabled = True
        SetVolumeToolStripMenuItem.Enabled = True
        LoadToolStripMenuItem.Enabled = True
        PollRelayWorker.RunWorkerAsync(GetCurrentGame)
    End Sub

    Private Sub StopPoll()
        running = False
        StartButton.Text = "Start"
        DeleteCFGs(GetCurrentGame)
        EnableInterface()
        PollRelayWorker.CancelAsync()
    End Sub

    Private Sub CreateCfgFiles()
        Dim Game As SourceGame = GetCurrentGame()
        Dim GameDir As String = Path.Combine(SteamappsPath, Game.directory)
        Dim GameCfgFolder As String = Path.Combine(GameDir, Game.ToCfg)

        'slam.cfg
        Using slam_cfg As StreamWriter = New StreamWriter(GameCfgFolder & "slam.cfg")
            slam_cfg.WriteLine("alias slam_listtracks ""exec slam_tracklist.cfg""")
            slam_cfg.WriteLine("alias list slam_listtracks")
            slam_cfg.WriteLine("alias tracks slam_listtracks")
            slam_cfg.WriteLine("alias la slam_listtracks")
            slam_cfg.WriteLine("alias slam_play slam_play_on")
            slam_cfg.WriteLine("alias slam_play_on ""alias slam_play slam_play_off; voice_inputfromfile 1; voice_loopback 1; +voicerecord""")
            slam_cfg.WriteLine("alias slam_play_off ""-voicerecord; voice_inputfromfile 0; voice_loopback 0; alias slam_play slam_play_on""")
            slam_cfg.WriteLine("alias slam_updatecfg ""host_writeconfig slam_relay""")
            slam_cfg.WriteLine("bind {0} slam_play", My.Settings.PlayKey)
            slam_cfg.WriteLine("alias slam_curtrack ""exec slam_curtrack.cfg""")
            slam_cfg.WriteLine("alias slam_saycurtrack ""exec slam_saycurtrack.cfg""")
            slam_cfg.WriteLine("alias slam_sayteamcurtrack ""exec slam_sayteamcurtrack.cfg""")




            If Game.id = 730 Then
                slam_cfg.WriteLine("voice_enable 1; voice_modenable 1; voice_forcemicrecord 0; con_enable 1")

            Else slam_cfg.WriteLine("voice_enable 1; voice_modenable 1; voice_forcemicrecord 0; voice_fadeouttime 0.0; con_enable 1")

            End If


        End Using

        'slam_tracklist.cfg
        Using slam_tracklist_cfg As StreamWriter = New StreamWriter(GameCfgFolder & "slam_tracklist.cfg")
            For Each Track In Game.tracks
                Dim index As String = Game.tracks.IndexOf(Track)
                slam_tracklist_cfg.WriteLine("alias {0} ""bind {1} {0}; slam_updatecfg; echo Loaded: {2}""", index + 1, My.Settings.RelayKey, Track.name)

                For Each TrackTag In Track.tags
                    slam_tracklist_cfg.WriteLine("alias {0} ""bind {1} {2}; slam_updatecfg; echo Loaded: {3}""", TrackTag, My.Settings.RelayKey, index + 1, Track.name)
                Next

                If Not String.IsNullOrEmpty(Track.hotkey) Then
                    slam_tracklist_cfg.WriteLine("bind {0} ""bind {1} {2}; slam_updatecfg; echo Loaded: {3}""", Track.hotkey, My.Settings.RelayKey, index + 1, Track.name)
                End If
            Next

            slam_tracklist_cfg.WriteLine("echo ""You can select tracks either by typing a tag, or their track number.""")
            slam_tracklist_cfg.WriteLine("echo ""--------------------Tracks--------------------""")
            For Each Track In Game.tracks
                Dim index As String = Game.tracks.IndexOf(Track)
                If My.Settings.WriteTags Then
                    slam_tracklist_cfg.WriteLine("echo ""{0}. {1} [{2}]""", index + 1, Track.name, "'" & String.Join("', '", Track.tags) & "'")
                Else
                    slam_tracklist_cfg.WriteLine("echo ""{0}. {1}""", index + 1, Track.name)
                End If
            Next
            slam_tracklist_cfg.WriteLine("echo ""----------------------------------------------""")
        End Using

    End Sub

    Private Function LoadTrack(ByVal Game As SourceGame, ByVal index As Integer) As Boolean
        Dim Track As SourceGame.track
        If Game.tracks.Count > index Then
            Track = Game.tracks(index)
            Dim voicefile As String = Path.Combine(SteamappsPath, Game.directory) & "voice_input.wav"

            Try
                If File.Exists(voicefile) Then
                    File.Delete(voicefile)
                End If

                Dim trackfile As String = Game.libraryname & Track.name & Game.FileExtension
                If File.Exists(trackfile) Then

                    If Track.volume = 100 And Track.startpos = -1 And Track.endpos = -1 Then
                        File.Copy(trackfile, voicefile)
                    Else

                        Dim WaveFloat As New WaveChannel32(New WaveFileReader(trackfile))

                        If Not Track.volume = 100 Then
                            WaveFloat.Volume = (Track.volume / 100) ^ 6
                        End If

                        If Not Track.startpos = Track.endpos And Track.endpos > 0 Then
                            Dim bytes((Track.endpos - Track.startpos) * 4) As Byte

                            WaveFloat.Position = Track.startpos * 4
                            WaveFloat.Read(bytes, 0, (Track.endpos - Track.startpos) * 4)

                            WaveFloat = New WaveChannel32(New RawSourceWaveStream(New MemoryStream(bytes), WaveFloat.WaveFormat))
                        End If

                        WaveFloat.PadWithZeroes = False
                        Dim outFormat = New WaveFormat(Game.samplerate, Game.bits, Game.channels)
                        Dim resampler = New MediaFoundationResampler(WaveFloat, outFormat)
                        resampler.ResamplerQuality = 60
                        WaveFileWriter.CreateWaveFile(voicefile, resampler)

                        resampler.Dispose()
                        WaveFloat.Dispose()

                    End If

                    Dim GameCfgFolder As String = Path.Combine(SteamappsPath, Game.directory, Game.ToCfg)
                    Using slam_curtrack As StreamWriter = New StreamWriter(GameCfgFolder & "slam_curtrack.cfg")
                        slam_curtrack.WriteLine("echo ""[SLAM] Track name: {0}""", Track.name)
                    End Using
                    Using slam_saycurtrack As StreamWriter = New StreamWriter(GameCfgFolder & "slam_saycurtrack.cfg")
                        slam_saycurtrack.WriteLine("say ""[SLAM] Track name: {0}""", Track.name)
                    End Using
                    Using slam_sayteamcurtrack As StreamWriter = New StreamWriter(GameCfgFolder & "slam_sayteamcurtrack.cfg")
                        slam_sayteamcurtrack.WriteLine("say_team ""[SLAM] Track name: {0}""", Track.name)
                    End Using


                End If

            Catch ex As Exception
                LogError(ex)
                Return False
            End Try

        End If
        Return True
    End Function

    Private Function recog(ByVal str As String, ByVal reg As String) As String
        Dim keyd As Match = Regex.Match(str, reg)
        Return (keyd.Groups(1).ToString)
    End Function

    Private Sub PollRelayWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles PollRelayWorker.DoWork
        Dim Game As SourceGame = e.Argument
        Dim GameDir As String = Path.Combine(SteamappsPath, Game.directory)
        Dim GameCfg As String = Path.Combine(GameDir, Game.ToCfg) & "slam_relay.cfg"

        Try
            Do
                If PollRelayWorker.CancellationPending Then
                    Exit Do
                End If

                If Not Game.id = 0 And My.Settings.UserDataEnabled Then
                    GameCfg = UserDataCFG(Game)
                End If

                If File.Exists(GameCfg) Then
                    Dim RelayCfg As String
                    Using reader As StreamReader = New StreamReader(GameCfg)
                        RelayCfg = reader.ReadToEnd
                    End Using

                    Dim command As String = recog(RelayCfg, String.Format("bind ""{0}"" ""(.*?)""", My.Settings.RelayKey))
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
        Catch ex As Exception
            LogError(ex)
            e.Result = ex
        End Try
    End Sub

    Public Function UserDataCFG(Game As SourceGame) As String
        If Directory.Exists(My.Settings.UserdataPath) Then
            For Each userdir As String In Directory.GetDirectories(My.Settings.UserdataPath)
                Dim CFGPath As String = Path.Combine(userdir, Game.id.ToString) & "\local\cfg\slam_relay.cfg"
                If File.Exists(CFGPath) Then
                    Return CFGPath
                End If
            Next
        End If
        Return vbNullString
    End Function

    Private Sub PollRelayWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles PollRelayWorker.ProgressChanged
        DisplayLoaded(e.ProgressPercentage)
    End Sub

    Private Sub PollRelayWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles PollRelayWorker.RunWorkerCompleted
        If running Then
            StopPoll()
        End If

        If Not IsNothing(e.Result) Then 'Result is always an exception
            MessageBox.Show(e.Result.Message & " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CreateTags(ByVal Game As SourceGame)
        Dim NameWords As New Dictionary(Of String, Integer)

        Dim index As Integer
        For Each Track In Game.tracks
            Dim Words As List(Of String) = Track.name.Split({" "c, "."c, "-"c, "_"c}).ToList

            For Each Word In Words

                If Not IsNumeric(Word) And Not Game.blacklist.Contains(Word.ToLower) And Word.Length < 32 Then
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

    Private Sub EnableInterface()
        For Each Control In Me.Controls
            Control.Enabled = True
        Next
    End Sub

    Private Sub DisableInterface()
        For Each Control In Me.Controls
            Control.Enabled = False
        Next
        DownladerFormButton.Enabled = True




    End Sub

    Private Sub DisplayLoaded(ByVal track As Integer)
        For i As Integer = 0 To TrackList.Items.Count - 1
            TrackList.Items(i).SubItems(0).Text = "False"
        Next
        TrackList.Items(track).SubItems(0).Text = "True"
    End Sub

    Private Sub LoadGames()
        GameSelector.Items.Clear()

        For Each Game In Games
            Dim GameFullPath As String = Path.Combine(SteamappsPath, Game.directory, Game.ToCfg)

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

            'This should set the UserData path drive to the same as the drive on the SteamApps path on first run
            If String.IsNullOrEmpty(My.Settings.UserdataPath) Then
                My.Settings.UserdataPath = SteamappsPath.Split("\")(0) & "\Program Files (x86)\Steam\userdata\"
            End If


            My.Settings.SteamAppsFolder = SteamappsPath
            My.Settings.Save()

            EnableInterface()

        Else
            DisableInterface()
            ChangeDirButton.Enabled = True
            ShowFolderSelector()
        End If

    End Sub

    Public Function ShowFolderSelector() As Boolean
        Dim ChangeDirDialog As New FolderBrowserDialog
        ChangeDirDialog.Description = "Select your steamapps folder:"
        ChangeDirDialog.ShowNewFolderButton = False

        If ChangeDirDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            SteamappsPath = ChangeDirDialog.SelectedPath & "\"
            LoadGames()
            Return True
        End If

        Return False
    End Function

    Private Sub LoadTrackKeys(ByVal Game As SourceGame)
        Dim SettingsList As New List(Of SourceGame.track)
        Dim SettingsFile As String = Path.Combine(Game.libraryname, "TrackSettings.xml")

        If File.Exists(SettingsFile) Then
            Dim XmlFile As String
            Using reader As StreamReader = New StreamReader(SettingsFile)
                XmlFile = reader.ReadToEnd
            End Using
            SettingsList = Deserialize(Of List(Of SourceGame.track))(XmlFile)
        End If


        For Each Track In Game.tracks
            For Each SetTrack In SettingsList
                If Track.name = SetTrack.name Then
                    'Please tell me that there is a better way to do the following...
                    Track.hotkey = SetTrack.hotkey
                    Track.volume = SetTrack.volume
                    Track.startpos = SetTrack.startpos
                    Track.endpos = SetTrack.endpos
                End If
            Next
        Next

    End Sub

    Private Sub SaveTrackKeys(ByVal Game As SourceGame)
        Dim SettingsList As New List(Of SourceGame.track)
        Dim SettingsFile As String = Path.Combine(Game.libraryname, "TrackSettings.xml")

        For Each Track In Game.tracks
            If Not String.IsNullOrEmpty(Track.hotkey) Or Not Track.volume = 100 Or Track.endpos > 0 Then

                SettingsList.Add(Track)

            End If
        Next

        If SettingsList.Count > 0 Then
            Using writer As StreamWriter = New StreamWriter(SettingsFile)
                writer.Write(Serialize(SettingsList))
            End Using
        Else
            If File.Exists(SettingsFile) Then
                File.Delete(SettingsFile)
            End If
        End If

    End Sub

    Private Sub TrackList_MouseClick(sender As Object, e As MouseEventArgs) Handles TrackList.MouseClick
        If e.Button = MouseButtons.Right Then
            If TrackList.FocusedItem.Bounds.Contains(e.Location) = True Then

                For Each Control In TrackContextMenu.Items 'everything invisible
                    Control.visible = False
                Next

                SetVolumeToolStripMenuItem.Visible = True 'always visible
                ContextRefresh.Visible = True

                If TrackList.SelectedItems.Count > 1 Then
                    If Not running Then 'visible when multiple selected AND is not running
                        ContextDelete.Visible = True
                    End If

                Else
                    If running Then
                        LoadToolStripMenuItem.Visible = True 'visible when only one selected AND is running
                        TrimToolStripMenuItem.Visible = True
                    Else
                        For Each Control In TrackContextMenu.Items 'visible when only one selected AND is not running (all)
                            Control.visible = True
                        Next
                    End If

                End If
                'Maybe I should have used a case... Maybe...

            End If



            TrackContextMenu.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ContextRefresh_Click(sender As Object, e As EventArgs) Handles ContextRefresh.Click
        ReloadTracks(GetCurrentGame)
        RefreshTrackList()
    End Sub

    Private Sub ContextDelete_Click(sender As Object, e As EventArgs) Handles ContextDelete.Click
        Dim game As SourceGame = GetCurrentGame()

        Dim SelectedNames As New List(Of String)
        For Each item In TrackList.SelectedItems
            SelectedNames.Add(item.SubItems(1).Text)
        Next

        If MessageBox.Show(String.Format("Are you sure you want to delete {0}?", String.Join(", ", SelectedNames)), "Delete Track?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            For Each item In SelectedNames
                Dim FilePath As String = Path.Combine(game.libraryname, item & game.FileExtension)

                If File.Exists(FilePath) Then
                    Try
                        File.Delete(FilePath)
                    Catch ex As Exception
                        LogError(ex)
                        MsgBox(String.Format("Failed to delete {0}.", FilePath))
                    End Try
                End If
            Next

        End If

        ReloadTracks(GetCurrentGame)
        RefreshTrackList()
    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        LoadTrack(GetCurrentGame, TrackList.SelectedItems(0).Index)
        DisplayLoaded(TrackList.SelectedItems(0).Index)
    End Sub

    Private Sub ContextHotKey_Click(sender As Object, e As EventArgs) Handles ContextHotKey.Click
        Dim SelectKeyDialog As New SelectKey
        Dim SelectedIndex = TrackList.SelectedItems(0).Index
        If SelectKeyDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Game = GetCurrentGame()



            Dim KeyIsFree As Boolean = True
            For Each track In Game.tracks
                If track.hotkey = SelectKeyDialog.ChosenKey Then 'Checking to see if any other track is already using this key
                    KeyIsFree = False
                End If
            Next

            If KeyIsFree Then
                Game.tracks(SelectedIndex).hotkey = SelectKeyDialog.ChosenKey
                SaveTrackKeys(GetCurrentGame)
                ReloadTracks(GetCurrentGame)
                RefreshTrackList()
            Else
                MessageBox.Show(String.Format("""{0}"" has already been assigned!", SelectKeyDialog.ChosenKey), "Invalid Key")
            End If


        End If
    End Sub

    Private Sub RemoveHotkeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveHotkeyToolStripMenuItem.Click
        For Each SelectedIndex In TrackList.SelectedItems
            Dim Game = GetCurrentGame()
            Game.tracks(SelectedIndex.index).hotkey = vbNullString
            SaveTrackKeys(GetCurrentGame)
            ReloadTracks(GetCurrentGame)

        Next
        RefreshTrackList()
    End Sub

    Private Sub GoToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToToolStripMenuItem.Click
        Dim Games As SourceGame = GetCurrentGame()
        Dim FilePath As String = Path.Combine(Games.libraryname, Games.tracks(TrackList.SelectedItems(0).Index).name & Games.FileExtension)


        Dim Args As String = String.Format("/Select, ""{0}""", FilePath)
        Dim pfi As New ProcessStartInfo("Explorer.exe", Args)

        System.Diagnostics.Process.Start(pfi)
    End Sub

    Private Sub SetVolumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetVolumeToolStripMenuItem.Click
        Dim SetVolumeDialog As New SetVolume

        If SetVolumeDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            For Each index In TrackList.SelectedIndices
                GetCurrentGame.tracks(index).volume = SetVolumeDialog.Volume
                SaveTrackKeys(GetCurrentGame)
                ReloadTracks(GetCurrentGame)
                RefreshTrackList()
            Next

        End If

    End Sub

    Private Sub TrimToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrimToolStripMenuItem.Click
        Dim Game As SourceGame = GetCurrentGame()
        Dim TrimDialog As New TrimForm

        TrimDialog.WavFile = Path.Combine(Game.libraryname, Game.tracks(TrackList.SelectedIndices(0)).name & Game.FileExtension)
        TrimDialog.startpos = Game.tracks(TrackList.SelectedIndices(0)).startpos
        TrimDialog.endpos = Game.tracks(TrackList.SelectedIndices(0)).endpos


        If TrimDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Game.tracks(TrackList.SelectedIndices(0)).startpos = TrimDialog.startpos
            Game.tracks(TrackList.SelectedIndices(0)).endpos = TrimDialog.endpos
            SaveTrackKeys(GetCurrentGame)
            ReloadTracks(GetCurrentGame)
            RefreshTrackList()
        End If
    End Sub

    Private Async Sub CheckForUpdate()
        Dim UpdateText As String

        Using client As New HttpClient
            Dim UpdateTextTask As Task(Of String) = client.GetStringAsync("http://slam.flankers.net/updates.php")
            UpdateText = Await UpdateTextTask
        End Using

        Dim NewVersion As New Version("0.0.0.0") 'generic
        Dim UpdateURL As String = UpdateText.Split()(1)
        If Version.TryParse(UpdateText.Split()(0), NewVersion) Then
            If My.Application.Info.Version.CompareTo(NewVersion) < 0 Then
                If MessageBox.Show(String.Format("An update ({0}) is available! Click ""OK"" to be taken to the download page.", NewVersion.ToString), "SLAM Update", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                    Process.Start(UpdateURL)
                End If
            End If
        End If
    End Sub

    Private Sub PlayKeyButton_Click(sender As Object, e As EventArgs) Handles PlayKeyButton.Click
        Dim SelectKeyDialog As New SelectKey
        If SelectKeyDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.PlayKey = SelectKeyDialog.ChosenKey
            My.Settings.Save()
            RefreshPlayKey()
        End If
    End Sub

    Private Sub RefreshPlayKey()
        PlayKeyButton.Text = String.Format("Play key: ""{0}"" (change)", My.Settings.PlayKey)
    End Sub

    Private Sub LogError(ByVal ex As Exception)
        If My.Settings.LogError Then
            Using log As StreamWriter = New StreamWriter("errorlog.txt", True)
                log.WriteLine("--------------------{0}--------------------", DateTime.Now)
                log.WriteLine(ex.ToString)
            End Using
        End If
    End Sub

    Private Sub ChangeDirButton_Click(sender As Object, e As EventArgs) Handles ChangeDirButton.Click
        SettingsForm.ShowDialog()
    End Sub

    Private Sub DeleteCFGs(ByVal Game As SourceGame)
        Dim GameDir As String = Path.Combine(SteamappsPath, Game.directory)
        Dim GameCfgFolder As String = Path.Combine(GameDir, Game.ToCfg)
        Dim SlamFiles() As String = {"slam.cfg", "slam_tracklist.cfg", "slam_relay.cfg", "slam_curtrack.cfg", "slam_saycurtrack.cfg", "slam_sayteamcurtrack.cfg"}
        Dim voicefile As String = Path.Combine(SteamappsPath, Game.directory) & "voice_input.wav"


        Try
            If File.Exists(voicefile) Then
                File.Delete(voicefile)
            End If

            For Each FileName In SlamFiles

                If File.Exists(GameCfgFolder & FileName) Then
                    File.Delete(GameCfgFolder & FileName)
                End If

            Next

        Catch ex As Exception
            LogError(ex)
        End Try

    End Sub

    Public Function ShowUserDataSelector() As Boolean
        Dim ChangeDirDialog As New FolderBrowserDialog
        ChangeDirDialog.Description = "Select your userdata folder:"
        ChangeDirDialog.ShowNewFolderButton = False

        If ChangeDirDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            My.Settings.UserdataPath = ChangeDirDialog.SelectedPath & "\"
            Return True
        End If

        Return False
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If running Then
            StopPoll()
        End If
    End Sub

    Private Sub DownladerFormButton_Click(sender As Object, e As EventArgs) Handles DownladerFormButton.Click
        Dim form = New YTDL()
        If Application.OpenForms(form.Name) Is Nothing Then
            form.Show()
        Else

            If Application.OpenForms(form.Name).WindowState = FormWindowState.Minimized Then
                Application.OpenForms(form.Name).WindowState = FormWindowState.Normal
            End If

            Application.OpenForms(form.Name).Activate()
        End If

    End Sub

    Public Sub RefreshListAndCfgFiles()
        ReloadTracks(GetCurrentGame)
        RefreshTrackList()
        CreateCfgFiles()
    End Sub

    Public Sub autoload(ByVal q As String)
        Dim Game As SourceGame = GetCurrentGame()
        For i As Integer = 0 To TrackList.Items.Count - 1
            Dim ii As Integer = 1
            If TrackList.Items(i).SubItems(ii).Text = q Then
                LoadTrack(GetCurrentGame, i)
            End If
            ii += 1
        Next







    End Sub

End Class

Public Class SourceGame
    Public name As String
    Public id As Integer
    Public directory As String
    Public ToCfg As String
    Public libraryname As String

    Public FileExtension As String = ".wav"
    Public samplerate As Integer = 11025
    Public bits As Integer = 16
    Public channels As Integer = 1

    Public PollInterval As Integer = 100

    Public tracks As New List(Of track)
    Public blacklist As New List(Of String) From {"slam", "slam_listtracks", "list", "tracks", "la", "slam_play", "slam_play_on", "slam_play_off", "slam_updatecfg", "slam_curtrack", "slam_saycurtrack", "slam_sayteamcurtrack"}
    Public Class track
        Public name As String
        Public tags As New List(Of String)
        Public hotkey As String = vbNullString
        Public volume As Integer = 100
        Public startpos As Integer
        Public endpos As Integer
    End Class
End Class

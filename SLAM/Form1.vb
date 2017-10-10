Imports NAudio 'Modified Version which does not write "extraSize"
Imports NAudio.Wave
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports SLAM.XmlSerialization
Imports SLAM.SourceGame
Imports System.Management
Imports System.Net.Http
Imports NReco.VideoConverter

Public Class Form1

    Dim Games As New List(Of SourceGame)
    Dim running As Boolean = False
    Dim ClosePending As Boolean = False
    Dim SteamAppsPath As String
    Dim status As Integer = IDLE

    Const IDLE = -1
    Const SEARCHING = -2
    Const WORKING = -3


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshPlayKey()
        If My.Settings.PlayKey = My.Settings.RelayKey Then
            My.Settings.RelayKey = "="
            My.Settings.Save()
        End If

        If My.Settings.UpdateCheck Then
            CheckForUpdate()
        End If

        Dim csgo As New SourceGame
        csgo.name = "Counter-Strike: Global Offensive"
        csgo.id = 730
        csgo.directory = "common\Counter-Strike Global Offensive\"
        csgo.ToCfg = "csgo\cfg\"
        csgo.libraryname = "csgo\"
        csgo.exename = "csgo"
        csgo.samplerate = 22050
        csgo.blacklist.AddRange({"attack", "attack2", "autobuy", "back", "buy", "buyammo1", "buyammo2", "buymenu", "callvote", "cancelselect", "cheer", "compliment", "coverme", "drop", "duck", "enemydown", "enemyspot", "fallback", "followme", "forward", "getout", "go", "holdpos", "inposition", "invnext", "invprev", "jump", "lastinv", "messagemode", "messagemode2", "moveleft", "moveright", "mute", "negative", "quit", "radio1", "radio2", "radio3", "rebuy", "regroup", "reload", "report", "reportingin", "roger", "sectorclear", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "speed", "sticktog", "takepoint", "takingfire", "teammenu", "thanks", "toggleconsole", "use", "voicerecord"})
        csgo.VoiceFadeOut = False
        Games.Add(csgo)

        Dim css As New SourceGame
        css.name = "Counter-Strike: Source"
        css.directory = "common\Counter-Strike Source\"
        css.ToCfg = "cstrike\cfg\"
        css.libraryname = "css\"
        css.blacklist.AddRange({"attack", "attack2", "back", "boom", "buyammo1", "buyammo2", "buyequip", "buymenu", "cancelselect", "cheer", "chooseteam", "commandmenu", "disconnect", "drop", "duck", "forward", "invnext", "invprev", "jump", "messagemode", "messagemode2", "moveleft", "moveright", "pause", "reload", "showbriefing", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "speed", "toggleconsole", "use"})
        Games.Add(css)

        Dim tf2 As New SourceGame
        tf2.name = "Team Fortress 2"
        tf2.directory = "common\Team Fortress 2\"
        tf2.ToCfg = "tf\cfg\"
        tf2.libraryname = "tf2\"
        tf2.samplerate = 22050
        tf2.blacklist.AddRange({"attack", "attack2", "attack3", "back", "build", "cancelselect", "centerview", "changeclass", "changeteam", "disguiseteam", "duck", "forward", "grab", "invnext", "invprev", "jump", "kill", "klook", "lastdisguise", "lookdown", "lookup", "moveleft", "moveright", "moveup", "pause", "quit", "reload", "say", "screenshot", "showmapinfo", "showroundinfo", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "strafe", "toggleconsole", "voicerecord"})
        Games.Add(tf2)

        Dim gmod As New SourceGame
        gmod.name = "Garry's Mod"
        gmod.directory = "common\GarrysMod\"
        gmod.ToCfg = "garrysmod\cfg\"
        gmod.libraryname = "gmod\"
        Games.Add(gmod)

        Dim hl2dm As New SourceGame
        hl2dm.name = "Half-Life 2 Deathmatch"
        hl2dm.directory = "common\half-life 2 deathmatch\"
        hl2dm.ToCfg = "hl2mp\cfg\"
        hl2dm.libraryname = "hl2dm\"
        Games.Add(hl2dm)

        Dim l4d As New SourceGame
        l4d.name = "Left 4 Dead"
        l4d.directory = "common\Left 4 Dead\"
        l4d.ToCfg = "left4dead\cfg\"
        l4d.libraryname = "l4d\"
        l4d.exename = "left4dead"
        Games.Add(l4d)

        Dim l4d2 As New SourceGame
        l4d2.name = "Left 4 Dead 2"
        l4d2.directory = "common\Left 4 Dead 2\"
        l4d2.ToCfg = "left4dead2\cfg\"
        l4d2.libraryname = "l4d2\"
        l4d2.exename = "left4dead2"
        l4d2.VoiceFadeOut = False
        Games.Add(l4d2)

        Dim dods As New SourceGame
        dods.name = "Day of Defeat Source"
        dods.directory = "common\day of defeat source\"
        dods.ToCfg = "dod\cfg\"
        dods.libraryname = "dods\"
        Games.Add(dods)

        'NEEDS EXENAME!!!
        'Dim goldeye As New SourceGame
        'goldeye.name = "Goldeneye Source"
        'goldeye.directory = "sourcemods\"
        'goldeye.ToCfg = "gesource\cfg\"
        'goldeye.libraryname = "goldeye\"
        'Games.Add(goldeye)

        Dim insurg As New SourceGame
        insurg.name = "Insurgency"
        insurg.directory = "common\insurgency2\"
        insurg.ToCfg = "insurgency\cfg\"
        insurg.libraryname = "insurgen\"
        insurg.exename = "insurgency"
        Games.Add(insurg)

        For Each Game In Games
            GameSelector.Items.Add(Game.name)
        Next

        If GameSelector.Items.Contains(My.Settings.LastGame) Then
            GameSelector.Text = GameSelector.Items(GameSelector.Items.IndexOf(My.Settings.LastGame)).ToString
        Else
            GameSelector.Text = GameSelector.Items(0).ToString
        End If

        ReloadTracks(GetCurrentGame)
        RefreshTrackList()

        If My.Settings.StartEnabled Then
            StartPoll()
        End If

        If My.Settings.StartMinimized Then
            WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub WaveCreator(File As String, outputFile As String, Game As SourceGame)
        Dim reader As New MediaFoundationReader(File)


        Dim outFormat = New WaveFormat(Game.samplerate, Game.bits, Game.channels)

        Dim resampler = New MediaFoundationResampler(reader, outFormat)

        resampler.ResamplerQuality = 60

        WaveFileWriter.CreateWaveFile(outputFile, resampler)

        resampler.Dispose()
    End Sub

    Private Sub FFMPEG_WaveCreator(File As String, outputFile As String, Game As SourceGame)
        Dim convert As New FFMpegConverter()
        convert.ExtractFFmpeg()

        Dim command As String = String.Format("-i ""{0}"" -n -f wav -flags bitexact -map_metadata -1 -vn -acodec pcm_s16le -ar {1} -ac {2} ""{3}""", Path.GetFullPath(File), Game.samplerate, Game.channels, Path.GetFullPath(outputFile))
        convert.Invoke(command)
    End Sub

    Private Sub FFMPEG_ConvertAndTrim(inpath As String, outpath As String, samplerate As Integer, channels As Integer, starttrim As Double, length As Double, volume As Double)
        Dim convert As New FFMpegConverter()
        convert.ExtractFFmpeg()

        Dim trimstring As String
        If length > 0 Then
            trimstring = String.Format("-ss {0} -t {1} ", starttrim.ToString("F5", Globalization.CultureInfo.InvariantCulture), length.ToString("F5", Globalization.CultureInfo.InvariantCulture))
        End If

        Dim command As String = String.Format("-i ""{0}"" -n -f wav -flags bitexact -map_metadata -1 -vn -acodec pcm_s16le -ar {1} -ac {2} {3}-af ""volume={4}"" ""{5}""", Path.GetFullPath(inpath), samplerate, channels, trimstring, volume.ToString("F5", Globalization.CultureInfo.InvariantCulture), Path.GetFullPath(outpath))
        convert.Invoke(command)
    End Sub

    Private Sub GameSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GameSelector.SelectedIndexChanged
        ReloadTracks(GetCurrentGame)
        RefreshTrackList()
        My.Settings.LastGame = GameSelector.Text
        My.Settings.Save()
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click
        If (My.Settings.UseFFMPEG = True And File.Exists("NReco.VideoConverter.dll")) Or (My.Settings.UseFFMPEG = False And File.Exists("NAudio.dll")) Then
            DisableInterface()
            If ImportDialog.ShowDialog() = DialogResult.OK Then
                ProgressBar1.Maximum = ImportDialog.FileNames.Count
                Dim WorkerPassthrough() As Object = {GetCurrentGame(), ImportDialog.FileNames, False}
                WavWorker.RunWorkerAsync(WorkerPassthrough)
            Else
                EnableInterface()
            End If

        Else
            MessageBox.Show("You are missing NAudio.dll or NReco.VideoConverter.dll! Cannot import without it!", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub YTButton_Click(sender As Object, e As EventArgs) Handles YTButton.Click
        If File.Exists("NAudio.dll") AndAlso File.Exists("Newtonsoft.Json.dll") AndAlso File.Exists("NReco.VideoConverter.dll") AndAlso File.Exists("YoutubeExtractor.dll") Then
            DisableInterface()
            Dim YTImporter As New YTImport
            If YTImporter.ShowDialog() = DialogResult.OK Then
                ProgressBar1.Maximum = 1
                Dim WorkerPassthrough() As Object = {GetCurrentGame(), New String() {YTImporter.file}, True}
                WavWorker.RunWorkerAsync(WorkerPassthrough)
            Else
                EnableInterface()
            End If

        Else
            MessageBox.Show("You are missing either NAudio.dll, Newtonsoft.Json.dll, NReco.VideoConverter.dll, or YoutubeExtractor.dll! Cannot import from YouTube without them!", "Missing File(s)", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub WavWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles WavWorker.DoWork
        Dim Game As SourceGame = e.Argument(0)
        Dim Files() As String = e.Argument(1)
        Dim DeleteSource As Boolean = e.Argument(2)
        Dim FailedFiles As New List(Of String)

        For Each File In Files

            Try
                Dim OutFile As String = Path.Combine(Game.libraryname, Path.GetFileNameWithoutExtension(File) & ".wav")

                If My.Settings.UseFFMPEG Then
                    FFMPEG_WaveCreator(File, OutFile, Game)
                Else
                    WaveCreator(File, OutFile, Game)
                End If


                If DeleteSource Then
                    IO.File.Delete(File)
                End If
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

    Private Function GetCurrentGame() As SourceGame
        For Each Game In Games
            If Game.name = GameSelector.SelectedItem.ToString Then
                Return Game
            End If
        Next
        Return Nothing 'Null if nothing found
    End Function

    Private Sub ReloadTracks(Game As SourceGame)
        If IO.Directory.Exists(Game.libraryname) Then

            Game.tracks.Clear()
            For Each File In System.IO.Directory.GetFiles(Game.libraryname)

                If Game.FileExtension = Path.GetExtension(File) Then
                    Dim track As New track
                    track.name = Path.GetFileNameWithoutExtension(File)
                    Game.tracks.Add(track)
                End If

            Next

            CreateTags(Game)
            LoadTrackKeys(Game)
            SaveTrackKeys(Game) 'To prune hotkeys from non-existing tracks

        Else
            System.IO.Directory.CreateDirectory(Game.libraryname)
        End If
    End Sub

    Private Sub RefreshTrackList()
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
        running = True
        StartButton.Text = "Stop"
        SystemTrayMenu_StartStop.Text = "Stop"
        DisableInterface()
        StartButton.Enabled = True
        TrackList.Enabled = True
        SetVolumeToolStripMenuItem.Enabled = True
        If PollRelayWorker.IsBusy <> True Then
            PollRelayWorker.RunWorkerAsync(GetCurrentGame)
        End If
    End Sub

    Private Sub StopPoll()
        running = False
        StartButton.Text = "Start"
        SystemTrayMenu_StartStop.Text = "Start"
        EnableInterface()
        PollRelayWorker.CancelAsync()
    End Sub

    Private Sub CreateCfgFiles(Game As SourceGame, SteamappsPath As String)
        Dim GameDir As String = Path.Combine(SteamappsPath, Game.directory)
        Dim GameCfgFolder As String = Path.Combine(GameDir, Game.ToCfg)

        If Not IO.Directory.Exists(GameCfgFolder) Then
            Throw New System.Exception("Steamapps folder is incorrect. Disable ""override folder detection"", or select a correct folder.")
        End If

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
            If My.Settings.HoldToPlay Then
                slam_cfg.WriteLine("alias +slam_hold_play slam_play_on")
                slam_cfg.WriteLine("alias -slam_hold_play slam_play_off")
                slam_cfg.WriteLine("bind {0} +slam_hold_play", My.Settings.PlayKey)
            Else
                slam_cfg.WriteLine("bind {0} slam_play", My.Settings.PlayKey)
            End If
            slam_cfg.WriteLine("alias slam_curtrack ""exec slam_curtrack.cfg""")
            slam_cfg.WriteLine("alias slam_saycurtrack ""exec slam_saycurtrack.cfg""")
            slam_cfg.WriteLine("alias slam_sayteamcurtrack ""exec slam_sayteamcurtrack.cfg""")

            For Each Track In Game.tracks
                Dim index As String = Game.tracks.IndexOf(Track)
                slam_cfg.WriteLine("alias {0} ""bind {1} {0}; slam_updatecfg; echo Loaded: {2}""", index + 1, My.Settings.RelayKey, Track.name)

                For Each TrackTag In Track.tags
                    slam_cfg.WriteLine("alias {0} ""bind {1} {2}; slam_updatecfg; echo Loaded: {3}""", TrackTag, My.Settings.RelayKey, index + 1, Track.name)
                Next

                If Not String.IsNullOrEmpty(Track.hotkey) Then
                    slam_cfg.WriteLine("bind {0} ""bind {1} {2}; slam_updatecfg; echo Loaded: {3}""", Track.hotkey, My.Settings.RelayKey, index + 1, Track.name)
                End If
            Next

            Dim CfgData As String
            CfgData = "voice_enable 1; voice_modenable 1; voice_forcemicrecord 0; con_enable 1"

            If Game.VoiceFadeOut Then
                CfgData = CfgData + "; voice_fadeouttime 0.0"
            End If

            slam_cfg.WriteLine(CfgData)

        End Using

        'slam_tracklist.cfg
        Using slam_tracklist_cfg As StreamWriter = New StreamWriter(GameCfgFolder & "slam_tracklist.cfg")
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
        Dim Track As track
        If Game.tracks.Count > index Then
            Track = Game.tracks(index)
            Dim voicefile As String = Path.Combine(SteamAppsPath, Game.directory) & "voice_input.wav"
            Try
                If File.Exists(voicefile) Then
                    File.Delete(voicefile)
                End If

                Dim trackfile As String = Game.libraryname & Track.name & Game.FileExtension
                If File.Exists(trackfile) Then

                    If Track.volume = 100 And Track.startpos <= 0 And Track.endpos <= 0 Then
                        File.Copy(trackfile, voicefile)
                    Else

                        If My.Settings.UseFFMPEG Then

                            FFMPEG_ConvertAndTrim(trackfile, voicefile, Game.samplerate, Game.channels, Track.startpos / Game.samplerate / 2, (Track.endpos - Track.startpos) / Game.samplerate / 2, (Track.volume / 100) ^ 6) ' /2 because SLAM stores Track.startpos and Track.endpos as # of bytes not sample. With 16-bit audio, there are 2 bytes per sample.

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
                            WaveFileWriter.CreateWaveFile(voicefile, resampler) 'wav

                            resampler.Dispose()
                            WaveFloat.Dispose()

                        End If

                    End If

                    Dim GameCfgFolder As String = Path.Combine(SteamAppsPath, Game.directory, Game.ToCfg)
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

        Else
            Return False
        End If

        Return True
    End Function

    Private Function recog(ByVal str As String, ByVal reg As String) As String
        Dim keyd As Match = Regex.Match(str, reg, RegexOptions.IgnoreCase) 'RegexOptions.IgnoreCase because bind could be saved as lowercase
        Return (keyd.Groups(1).ToString)
    End Function

    Private Sub PollRelayWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles PollRelayWorker.DoWork
        PollRelayWorker.ReportProgress(SEARCHING) 'Report that SLAM is searching.

        Dim Game As SourceGame = e.Argument
        Dim GameDir As String = Game.directory & Game.exename & ".exe"

        SteamAppsPath = vbNullString
        Dim UserDataPath As String = vbNullString

        Try
            If Not My.Settings.OverrideFolders Then

                Do While Not PollRelayWorker.CancellationPending

                    Dim GameProcess As String = GetFilepath(Game.exename)
                    If Not String.IsNullOrEmpty(GameProcess) AndAlso GameProcess.EndsWith(GameDir) Then
                        SteamAppsPath = GameProcess.Remove(GameProcess.Length - GameDir.Length)
                    End If

                    Dim SteamProcess As String = GetFilepath("Steam")
                    If Not String.IsNullOrEmpty(SteamProcess) Then
                        UserDataPath = SteamProcess.Remove(SteamProcess.Length - "Steam.exe".Length) & "userdata\"
                    End If

                    If IO.Directory.Exists(SteamAppsPath) Then
                        If Not Game.id = 0 Then

                            If IO.Directory.Exists(UserDataPath) Then
                                Exit Do
                            End If

                        Else
                            Exit Do
                        End If
                    End If

                    Thread.Sleep(Game.PollInterval)
                Loop

            Else
                SteamAppsPath = My.Settings.steamapps
                If IO.Directory.Exists(My.Settings.userdata) Then
                    UserDataPath = My.Settings.userdata
                Else
                    Throw New System.Exception("Userdata folder does not exist. Disable ""override folder detection"", or select a correct folder.")
                End If
            End If

            If Not String.IsNullOrEmpty(SteamAppsPath) Then
                CreateCfgFiles(Game, SteamAppsPath)
            End If

        Catch ex As Exception
            LogError(ex)
            e.Result = ex
            Return
        End Try


        PollRelayWorker.ReportProgress(WORKING) 'Report that SLAM is working.

        Do While Not PollRelayWorker.CancellationPending
            Try
                Dim GameFolder As String = Path.Combine(SteamAppsPath, Game.directory)
                Dim GameCfg As String = Path.Combine(GameFolder, Game.ToCfg) & "slam_relay.cfg"

                If Not Game.id = 0 Then
                    GameCfg = UserDataCFG(Game, UserDataPath)
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

            Catch ex As Exception
                If Not ex.HResult = -2147024864 Then '-2147024864 = "System.IO.IOException: The process cannot access the file because it is being used by another process."
                    LogError(ex)
                    e.Result = ex
                    Return
                End If
            End Try
        Loop

        If Not String.IsNullOrEmpty(SteamAppsPath) Then
            DeleteCFGs(Game, SteamAppsPath)
        End If

    End Sub

    Public Function UserDataCFG(Game As SourceGame, UserdataPath As String) As String
        If IO.Directory.Exists(UserdataPath) Then
            For Each userdir As String In System.IO.Directory.GetDirectories(UserdataPath)
                Dim CFGPath As String = Path.Combine(userdir, Game.id.ToString) & "\local\cfg\slam_relay.cfg"
                If File.Exists(CFGPath) Then
                    Return CFGPath
                End If
            Next
        End If
        Return vbNullString
    End Function

    Private Function GetFilepath(ProcessName As String) As String

        Dim wmiQueryString As String = "Select * from Win32_Process Where Name = """ & ProcessName & ".exe"""

        Using searcher = New ManagementObjectSearcher(wmiQueryString)
            Using results = searcher.Get()

                Dim Process As ManagementObject = results.Cast(Of ManagementObject)().FirstOrDefault()
                If Process IsNot Nothing Then
                    Dim exePath = Process("ExecutablePath")
                    ' Check Process("ExecutablePath") for null before calling ToString.
                    ' Fixes error that occurs if you start steam / csgo while SLAM is searching.
                    Dim procPath = If(exePath IsNot Nothing, exePath.ToString(), vbNullString)
                    If Not String.IsNullOrWhiteSpace(procPath) Then
                        Return Process("ExecutablePath").ToString
                    End If
                End If

            End Using
        End Using

        Return Nothing
    End Function

    Private Sub PollRelayWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles PollRelayWorker.ProgressChanged
        Select Case e.ProgressPercentage
            Case SEARCHING
                status = SEARCHING
                StatusLabel.Text = "Status: Searching..."
            Case WORKING
                status = WORKING
                StatusLabel.Text = "Status: Working."
            Case Else
                DisplayLoaded(e.ProgressPercentage)
        End Select

    End Sub

    Private Sub PollRelayWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles PollRelayWorker.RunWorkerCompleted
        If running Then
            StopPoll()
        End If

        status = IDLE
        StatusLabel.Text = "Status: Idle."
        RefreshTrackList()

        If Not IsNothing(e.Result) Then 'Result is always an exception
            MessageBox.Show(e.Result.Message & " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If ClosePending Then
            Me.Close()
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
    End Sub

    Private Sub DisplayLoaded(ByVal track As Integer)
        For i As Integer = 0 To TrackList.Items.Count - 1
            TrackList.Items(i).SubItems(0).Text = "False"
        Next
        TrackList.Items(track).SubItems(0).Text = "True"
    End Sub

    Private Sub LoadTrackKeys(ByVal Game As SourceGame)
        Dim SettingsList As New List(Of track)
        Dim SettingsFile As String = Path.Combine(Game.libraryname, "TrackSettings.xml")

        If File.Exists(SettingsFile) Then
            Dim XmlFile As String
            Using reader As StreamReader = New StreamReader(SettingsFile)
                XmlFile = reader.ReadToEnd
            End Using
            SettingsList = Deserialize(Of List(Of track))(XmlFile)
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
        Dim SettingsList As New List(Of track)
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
            If TrackList.FocusedItem.Bounds.Contains(e.Location) Then

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
                        TrimToolStripMenuItem.Visible = True 'visible when only one selected AND is running
                        If status = WORKING Then
                            LoadToolStripMenuItem.Visible = True
                        End If
                    Else
                        For Each Control In TrackContextMenu.Items 'visible when only one selected AND is not running (all)
                            Control.visible = True
                        Next
                        LoadToolStripMenuItem.Visible = False
                    End If

                End If
                'Maybe I should have used a case... Maybe...

            End If



            TrackContextMenu.Show(Cursor.Position)
        End If
    End Sub

    Private Sub TrackList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrackList.MouseDoubleClick
        If TrackList.FocusedItem.Bounds.Contains(e.Location) AndAlso status = WORKING Then
            LoadTrack(GetCurrentGame, TrackList.SelectedItems(0).Index)
            DisplayLoaded(TrackList.SelectedItems(0).Index)
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
            Next
            SaveTrackKeys(GetCurrentGame)
            ReloadTracks(GetCurrentGame)
            RefreshTrackList()

        End If

    End Sub

    Private Sub TrimToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrimToolStripMenuItem.Click
        If File.Exists("NAudio.dll") Then

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

        Else
            MessageBox.Show("You are missing NAudio.dll! Cannot trim without it!", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        Dim Game As SourceGame = GetCurrentGame()
        Dim RenameDialog As New RenameForm
        Dim SelectedTrack As SourceGame.track = GetCurrentGame.tracks(TrackList.SelectedIndices(0))

        RenameDialog.filename = SelectedTrack.name

        If RenameDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try

                FileSystem.Rename(Game.libraryname & SelectedTrack.name & Game.FileExtension, Game.libraryname & RenameDialog.filename & Game.FileExtension)
                GetCurrentGame.tracks(TrackList.SelectedIndices(0)).name = RenameDialog.filename

                SaveTrackKeys(GetCurrentGame)
                ReloadTracks(GetCurrentGame)
                RefreshTrackList()

            Catch ex As Exception
                Select Case ex.HResult
                    Case -2147024809
                        MessageBox.Show("""" & RenameDialog.filename & """ contains invalid characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Case -2146232800
                        MessageBox.Show("A track with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Case Else
                        MessageBox.Show(ex.Message & " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select

            End Try
        End If
    End Sub

    Private Async Sub CheckForUpdate()
        Dim UpdateText As String

        Dim NeatVersion As String = My.Application.Info.Version.ToString.Remove(My.Application.Info.Version.ToString.LastIndexOf("."))

        Try

            Using client As New HttpClient
                Dim UpdateTextTask As Task(Of String) = client.GetStringAsync("http://slam.flankers.net/updates.php?version=" & NeatVersion)
                UpdateText = Await UpdateTextTask
            End Using

        Catch ex As Exception
            Return
        End Try

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
            If Not SelectKeyDialog.ChosenKey = My.Settings.RelayKey Then
                My.Settings.PlayKey = SelectKeyDialog.ChosenKey
                My.Settings.Save()
                RefreshPlayKey()
            Else
                MessageBox.Show("Play key and relay key can not be the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub RefreshPlayKey()
        PlayKeyButton.Text = String.Format("Play key: ""{0}"" (change)", My.Settings.PlayKey)
    End Sub

    Public Sub LogError(ByVal ex As Exception)
        If My.Settings.LogError Then
            Using log As StreamWriter = New StreamWriter("errorlog.txt", True)
                log.WriteLine("--------------------{0} UTC--------------------", DateTime.Now.ToUniversalTime)
                log.WriteLine(ex.ToString)
            End Using
        End If
    End Sub

    Private Sub ChangeDirButton_Click(sender As Object, e As EventArgs) Handles ChangeDirButton.Click
        SettingsForm.ShowDialog()
    End Sub

    Private Sub DeleteCFGs(ByVal Game As SourceGame, ByVal SteamappsPath As String)
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

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If running Then
            StopPoll()
            ClosePending = True
            e.Cancel = True
        End If
    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        LoadTrack(GetCurrentGame, TrackList.SelectedItems(0).Index)
        DisplayLoaded(TrackList.SelectedItems(0).Index)
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If My.Settings.MinimizeToSysTray Then
            If WindowState = FormWindowState.Minimized Then
                SystemTrayIcon.Visible = True
                SystemTrayIcon.BalloonTipIcon = ToolTipIcon.Info
                SystemTrayIcon.BalloonTipTitle = "SLAM"
                SystemTrayIcon.BalloonTipText = "Minimized to tray"
                SystemTrayIcon.ShowBalloonTip(50000)
                Hide()
                ShowInTaskbar = False
            End If
        End If
    End Sub

    Private Sub SystemTrayIcon_DoubleClick(sender As Object, e As EventArgs) Handles SystemTrayIcon.DoubleClick
        Show()
        ShowInTaskbar = True
        WindowState = FormWindowState.Normal
        SystemTrayIcon.Visible = False
    End Sub

    Private Sub SystemTrayMenu_OpenHandler(sender As Object, e As EventArgs) Handles SystemTrayMenu_Open.Click
        Show()
        ShowInTaskbar = True
        WindowState = FormWindowState.Normal
        SystemTrayIcon.Visible = False
    End Sub

    Private Sub SystemTrayMenu_StartStopHandler(sender As Object, e As EventArgs) Handles SystemTrayMenu_StartStop.Click
        If running Then
            StopPoll()
        Else
            StartPoll()
        End If
    End Sub

    Private Sub SystemTrayMenu_ExitHandler(sender As Object, e As EventArgs) Handles SystemTrayMenu_Exit.Click
        If running Then
            StopPoll()
            ClosePending = True
        Else
            Me.Close()
        End If
    End Sub
End Class

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NAudio.Wave;
using NReco.VideoConverter;

namespace SLAM
{
    public partial class Form1
    {
        public Form1()
        {
            InitializeComponent();
            _GameSelector.Name = "GameSelector";
            _ImportButton.Name = "ImportButton";
            _TrackList.Name = "TrackList";
            _StartButton.Name = "StartButton";
            _ChangeDirButton.Name = "ChangeDirButton";
            _ContextDelete.Name = "ContextDelete";
            _GoToToolStripMenuItem.Name = "GoToToolStripMenuItem";
            _ContextRefresh.Name = "ContextRefresh";
            _RemoveHotkeyToolStripMenuItem.Name = "RemoveHotkeyToolStripMenuItem";
            _RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            _ContextHotKey.Name = "ContextHotKey";
            _SetVolumeToolStripMenuItem.Name = "SetVolumeToolStripMenuItem";
            _TrimToolStripMenuItem.Name = "TrimToolStripMenuItem";
            _LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            _PlayKeyButton.Name = "PlayKeyButton";
            _SystemTrayMenu_Open.Name = "SystemTrayMenu_Open";
            _SystemTrayMenu_StartStop.Name = "SystemTrayMenu_StartStop";
            _SystemTrayMenu_Exit.Name = "SystemTrayMenu_Exit";
            _YTButton.Name = "YTButton";
        }

        private List<SourceGame> Games = new List<SourceGame>();
        private bool running = false;
        private bool ClosePending = false;
        private string SteamAppsPath;
        private int status = IDLE;
        private const int IDLE = -1;
        private const int SEARCHING = -2;
        private const int WORKING = -3;

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPlayKey();
            if ((My.MySettingsProperty.Settings.PlayKey ?? "") == (My.MySettingsProperty.Settings.RelayKey ?? ""))
            {
                My.MySettingsProperty.Settings.RelayKey = "=";
                My.MySettingsProperty.Settings.Save();
            }

            if (My.MySettingsProperty.Settings.UpdateCheck)
            {
                CheckForUpdate();
            }

            var csgo = new SourceGame();
            csgo.name = "Counter-Strike: Global Offensive";
            csgo.id = 730;
            csgo.directory = @"common\Counter-Strike Global Offensive\";
            csgo.ToCfg = @"csgo\cfg\";
            csgo.libraryname = @"csgo\";
            csgo.exename = "csgo";
            csgo.samplerate = 22050;
            csgo.blacklist.AddRange(new[] { "attack", "attack2", "autobuy", "back", "buy", "buyammo1", "buyammo2", "buymenu", "callvote", "cancelselect", "cheer", "compliment", "coverme", "drop", "duck", "enemydown", "enemyspot", "fallback", "followme", "forward", "getout", "go", "holdpos", "inposition", "invnext", "invprev", "jump", "lastinv", "messagemode", "messagemode2", "moveleft", "moveright", "mute", "negative", "quit", "radio1", "radio2", "radio3", "rebuy", "regroup", "reload", "report", "reportingin", "roger", "sectorclear", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "speed", "sticktog", "takepoint", "takingfire", "teammenu", "thanks", "toggleconsole", "use", "voicerecord" });
            csgo.VoiceFadeOut = false;
            Games.Add(csgo);
            var css = new SourceGame();
            css.name = "Counter-Strike: Source";
            css.directory = @"common\Counter-Strike Source\";
            css.ToCfg = @"cstrike\cfg\";
            css.libraryname = @"css\";
            css.blacklist.AddRange(new[] { "attack", "attack2", "back", "boom", "buyammo1", "buyammo2", "buyequip", "buymenu", "cancelselect", "cheer", "chooseteam", "commandmenu", "disconnect", "drop", "duck", "forward", "invnext", "invprev", "jump", "messagemode", "messagemode2", "moveleft", "moveright", "pause", "reload", "showbriefing", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "speed", "toggleconsole", "use" });
            Games.Add(css);
            var tf2 = new SourceGame();
            tf2.name = "Team Fortress 2";
            tf2.directory = @"common\Team Fortress 2\";
            tf2.ToCfg = @"tf\cfg\";
            tf2.libraryname = @"tf2\";
            tf2.samplerate = 22050;
            tf2.blacklist.AddRange(new[] { "attack", "attack2", "attack3", "back", "build", "cancelselect", "centerview", "changeclass", "changeteam", "disguiseteam", "duck", "forward", "grab", "invnext", "invprev", "jump", "kill", "klook", "lastdisguise", "lookdown", "lookup", "moveleft", "moveright", "moveup", "pause", "quit", "reload", "say", "screenshot", "showmapinfo", "showroundinfo", "showscores", "slot1", "slot10", "slot2", "slot3", "slot4", "slot5", "slot6", "slot7", "slot8", "slot9", "strafe", "toggleconsole", "voicerecord" });
            Games.Add(tf2);
            var gmod = new SourceGame();
            gmod.name = "Garry's Mod";
            gmod.directory = @"common\GarrysMod\";
            gmod.ToCfg = @"garrysmod\cfg\";
            gmod.libraryname = @"gmod\";
            Games.Add(gmod);
            var hl2dm = new SourceGame();
            hl2dm.name = "Half-Life 2 Deathmatch";
            hl2dm.directory = @"common\half-life 2 deathmatch\";
            hl2dm.ToCfg = @"hl2mp\cfg\";
            hl2dm.libraryname = @"hl2dm\";
            Games.Add(hl2dm);
            var l4d = new SourceGame();
            l4d.name = "Left 4 Dead";
            l4d.directory = @"common\Left 4 Dead\";
            l4d.ToCfg = @"left4dead\cfg\";
            l4d.libraryname = @"l4d\";
            l4d.exename = "left4dead";
            Games.Add(l4d);
            var l4d2 = new SourceGame();
            l4d2.name = "Left 4 Dead 2";
            l4d2.directory = @"common\Left 4 Dead 2\";
            l4d2.ToCfg = @"left4dead2\cfg\";
            l4d2.libraryname = @"l4d2\";
            l4d2.exename = "left4dead2";
            l4d2.VoiceFadeOut = false;
            Games.Add(l4d2);
            var dods = new SourceGame();
            dods.name = "Day of Defeat Source";
            dods.directory = @"common\day of defeat source\";
            dods.ToCfg = @"dod\cfg\";
            dods.libraryname = @"dods\";
            Games.Add(dods);

            // NEEDS EXENAME!!!
            // Dim goldeye As New SourceGame
            // goldeye.name = "Goldeneye Source"
            // goldeye.directory = "sourcemods\"
            // goldeye.ToCfg = "gesource\cfg\"
            // goldeye.libraryname = "goldeye\"
            // Games.Add(goldeye)

            var insurg = new SourceGame();
            insurg.name = "Insurgency";
            insurg.directory = @"common\insurgency2\";
            insurg.ToCfg = @"insurgency\cfg\";
            insurg.libraryname = @"insurgen\";
            insurg.exename = "insurgency";
            Games.Add(insurg);
            foreach (var Game in Games)
                GameSelector.Items.Add(Game.name);
            if (GameSelector.Items.Contains(My.MySettingsProperty.Settings.LastGame))
            {
                GameSelector.Text = GameSelector.Items[GameSelector.Items.IndexOf(My.MySettingsProperty.Settings.LastGame)].ToString();
            }
            else
            {
                GameSelector.Text = GameSelector.Items[0].ToString();
            }

            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
            if (My.MySettingsProperty.Settings.StartEnabled)
            {
                StartPoll();
            }

            if (My.MySettingsProperty.Settings.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void WaveCreator(string File, string outputFile, SourceGame Game)
        {
            var reader = new MediaFoundationReader(File);
            var outFormat = new WaveFormat(Game.samplerate, Game.bits, Game.channels);
            var resampler = new MediaFoundationResampler(reader, outFormat);
            resampler.ResamplerQuality = 60;
            WaveFileWriter.CreateWaveFile(outputFile, resampler);
            resampler.Dispose();
        }

        private void FFMPEG_WaveCreator(string File, string outputFile, SourceGame Game)
        {
            var convert = new FFMpegConverter();
            convert.ExtractFFmpeg();
            string command = string.Format("-i \"{0}\" -n -f wav -flags bitexact -map_metadata -1 -vn -acodec pcm_s16le -ar {1} -ac {2} \"{3}\"", Path.GetFullPath(File), Game.samplerate, Game.channels, Path.GetFullPath(outputFile));
            convert.Invoke(command);
        }

        private void FFMPEG_ConvertAndTrim(string inpath, string outpath, int samplerate, int channels, double starttrim, double length, double volume)
        {
            var convert = new FFMpegConverter();
            convert.ExtractFFmpeg();
            var trimstring = default(string);
            if (length > 0d)
            {
                trimstring = string.Format("-ss {0} -t {1} ", starttrim.ToString("F5", System.Globalization.CultureInfo.InvariantCulture), length.ToString("F5", System.Globalization.CultureInfo.InvariantCulture));
            }

            string command = string.Format("-i \"{0}\" -n -f wav -flags bitexact -map_metadata -1 -vn -acodec pcm_s16le -ar {1} -ac {2} {3}-af \"volume={4}\" \"{5}\"", Path.GetFullPath(inpath), samplerate, channels, trimstring, volume.ToString("F5", System.Globalization.CultureInfo.InvariantCulture), Path.GetFullPath(outpath));
            convert.Invoke(command);
        }

        private void GameSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
            My.MySettingsProperty.Settings.LastGame = GameSelector.Text;
            My.MySettingsProperty.Settings.Save();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (My.MySettingsProperty.Settings.UseFFMPEG == true & File.Exists("NReco.VideoConverter.dll") | My.MySettingsProperty.Settings.UseFFMPEG == false & File.Exists("NAudio.dll"))
            {
                DisableInterface();
                if (ImportDialog.ShowDialog() == DialogResult.OK)
                {
                    ProgressBar1.Maximum = ImportDialog.FileNames.Count();
                    var WorkerPassthrough = new object[] { GetCurrentGame(), ImportDialog.FileNames, false };
                    WavWorker.RunWorkerAsync(WorkerPassthrough);
                }
                else
                {
                    EnableInterface();
                }
            }
            else
            {
                MessageBox.Show("You are missing NAudio.dll or NReco.VideoConverter.dll! Cannot import without it!", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void YTButton_Click(object sender, EventArgs e)
        {
            if (File.Exists("NAudio.dll") && File.Exists("Newtonsoft.Json.dll") && File.Exists("NReco.VideoConverter.dll") && File.Exists("YoutubeExtractor.dll"))
            {
                DisableInterface();
                var YTImporter = new YTImport();
                if (YTImporter.ShowDialog() == DialogResult.OK)
                {
                    ProgressBar1.Maximum = 1;
                    var WorkerPassthrough = new object[] { GetCurrentGame(), new string[] { YTImporter.file }, true };
                    WavWorker.RunWorkerAsync(WorkerPassthrough);
                }
                else
                {
                    EnableInterface();
                }
            }
            else
            {
                MessageBox.Show("You are missing either NAudio.dll, Newtonsoft.Json.dll, NReco.VideoConverter.dll, or YoutubeExtractor.dll! Cannot import from YouTube without them!", "Missing File(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WavWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SourceGame Game = (SourceGame)e.Argument(0);
            string[] Files = (string[])e.Argument(1);
            bool DeleteSource = Conversions.ToBoolean(e.Argument((object)2));
            var FailedFiles = new List<string>();
            foreach (var File in Files)
            {
                try
                {
                    string OutFile = Path.Combine(Game.libraryname, Path.GetFileNameWithoutExtension(File) + ".wav");
                    if (My.MySettingsProperty.Settings.UseFFMPEG)
                    {
                        FFMPEG_WaveCreator(File, OutFile, Game);
                    }
                    else
                    {
                        WaveCreator(File, OutFile, Game);
                    }

                    if (DeleteSource)
                    {
                        System.IO.File.Delete(File);
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    FailedFiles.Add(File);
                }

                WavWorker.ReportProgress(0);
            }

            e.Result = FailedFiles;
        }

        private void WavWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ProgressBar1.PerformStep();
            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
        }

        private void WavWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ProgressBar1.Value = 0;
            string MsgBoxText = "Conversion complete!";
            var FailedFiles = new List<string>();
            foreach (var FilePath in (IEnumerable)e.Result)
                FailedFiles.Add(Path.GetFileName(Conversions.ToString(FilePath)));
            if (FailedFiles.Count > 0)
            {
                MsgBoxText = MsgBoxText + " However, the following files failed to convert: " + string.Join(", ", FailedFiles);
            }

            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
            Interaction.MsgBox(MsgBoxText);
            EnableInterface();
        }

        private SourceGame GetCurrentGame()
        {
            foreach (var Game in Games)
            {
                if ((Game.name ?? "") == (GameSelector.SelectedItem.ToString() ?? ""))
                {
                    return Game;
                }
            }

            return null; // Null if nothing found
        }

        private void ReloadTracks(SourceGame Game)
        {
            if (Directory.Exists(Game.libraryname))
            {
                Game.tracks.Clear();
                foreach (var File in Directory.GetFiles(Game.libraryname))
                {
                    if ((Game.FileExtension ?? "") == (Path.GetExtension(File) ?? ""))
                    {
                        var track = new SourceGame.track();
                        track.name = Path.GetFileNameWithoutExtension(File);
                        Game.tracks.Add(track);
                    }
                }

                CreateTags(Game);
                LoadTrackKeys(Game);
                SaveTrackKeys(Game); // To prune hotkeys from non-existing tracks
            }
            else
            {
                Directory.CreateDirectory(Game.libraryname);
            }
        }

        private void RefreshTrackList()
        {
            TrackList.Items.Clear();
            var Game = GetCurrentGame();
            foreach (var Track in Game.tracks)
            {
                string trimmed = "";
                if (Track.endpos > 0)
                {
                    trimmed = "Yes";
                }

                TrackList.Items.Add(new ListViewItem(new[] { "False", Track.name, Track.hotkey, Track.volume + "%", trimmed, "\"" + string.Join("\", \"", Track.tags) + "\"" }));
            }

            TrackList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            TrackList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            TrackList.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            TrackList.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            TrackList.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            TrackList.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (running)
            {
                StopPoll();
            }
            else
            {
                StartPoll();
                if (!My.MySettingsProperty.Settings.NoHint)
                {
                    if (MessageBox.Show("Don't forget to type \"exec slam\" in console! Click \"Cancel\" if you don't ever want to see this message again.", "SLAM", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        My.MySettingsProperty.Settings.NoHint = true;
                        My.MySettingsProperty.Settings.Save();
                    }
                }
            }
        }

        private void StartPoll()
        {
            running = true;
            StartButton.Text = "Stop";
            SystemTrayMenu_StartStop.Text = "Stop";
            DisableInterface();
            StartButton.Enabled = true;
            TrackList.Enabled = true;
            SetVolumeToolStripMenuItem.Enabled = true;
            if (PollRelayWorker.IsBusy != true)
            {
                PollRelayWorker.RunWorkerAsync(GetCurrentGame());
            }
        }

        private void StopPoll()
        {
            running = false;
            StartButton.Text = "Start";
            SystemTrayMenu_StartStop.Text = "Start";
            EnableInterface();
            PollRelayWorker.CancelAsync();
        }

        private void CreateCfgFiles(SourceGame Game, string SteamappsPath)
        {
            string GameDir = Path.Combine(SteamappsPath, Game.directory);
            string GameCfgFolder = Path.Combine(GameDir, Game.ToCfg);
            if (!Directory.Exists(GameCfgFolder))
            {
                throw new Exception("Steamapps folder is incorrect. Disable \"override folder detection\", or select a correct folder.");
            }

            // slam.cfg
            using (var slam_cfg = new StreamWriter(GameCfgFolder + "slam.cfg"))
            {
                slam_cfg.WriteLine("alias slam_listtracks \"exec slam_tracklist.cfg\"");
                slam_cfg.WriteLine("alias list slam_listtracks");
                slam_cfg.WriteLine("alias tracks slam_listtracks");
                slam_cfg.WriteLine("alias la slam_listtracks");
                slam_cfg.WriteLine("alias slam_play slam_play_on");
                slam_cfg.WriteLine("alias slam_play_on \"alias slam_play slam_play_off; voice_inputfromfile 1; voice_loopback 1; +voicerecord\"");
                slam_cfg.WriteLine("alias slam_play_off \"-voicerecord; voice_inputfromfile 0; voice_loopback 0; alias slam_play slam_play_on\"");
                slam_cfg.WriteLine("alias slam_updatecfg \"host_writeconfig slam_relay\"");
                if (My.MySettingsProperty.Settings.HoldToPlay)
                {
                    slam_cfg.WriteLine("alias +slam_hold_play slam_play_on");
                    slam_cfg.WriteLine("alias -slam_hold_play slam_play_off");
                    slam_cfg.WriteLine("bind {0} +slam_hold_play", My.MySettingsProperty.Settings.PlayKey);
                }
                else
                {
                    slam_cfg.WriteLine("bind {0} slam_play", My.MySettingsProperty.Settings.PlayKey);
                }

                slam_cfg.WriteLine("alias slam_curtrack \"exec slam_curtrack.cfg\"");
                slam_cfg.WriteLine("alias slam_saycurtrack \"exec slam_saycurtrack.cfg\"");
                slam_cfg.WriteLine("alias slam_sayteamcurtrack \"exec slam_sayteamcurtrack.cfg\"");
                foreach (var Track in Game.tracks)
                {
                    string index = Game.tracks.IndexOf(Track).ToString();
                    slam_cfg.WriteLine("alias {0} \"bind {1} {0}; slam_updatecfg; echo Loaded: {2}\"", Conversions.ToDouble(index) + 1d, My.MySettingsProperty.Settings.RelayKey, Track.name);
                    foreach (var TrackTag in Track.tags)
                        slam_cfg.WriteLine("alias {0} \"bind {1} {2}; slam_updatecfg; echo Loaded: {3}\"", TrackTag, My.MySettingsProperty.Settings.RelayKey, Conversions.ToDouble(index) + 1d, Track.name);
                    if (!string.IsNullOrEmpty(Track.hotkey))
                    {
                        slam_cfg.WriteLine("bind {0} \"bind {1} {2}; slam_updatecfg; echo Loaded: {3}\"", Track.hotkey, My.MySettingsProperty.Settings.RelayKey, Conversions.ToDouble(index) + 1d, Track.name);
                    }
                }

                string CfgData;
                CfgData = "voice_enable 1; voice_modenable 1; voice_forcemicrecord 0; con_enable 1";
                if (Game.VoiceFadeOut)
                {
                    CfgData = CfgData + "; voice_fadeouttime 0.0";
                }

                slam_cfg.WriteLine(CfgData);
            }

            // slam_tracklist.cfg
            using (var slam_tracklist_cfg = new StreamWriter(GameCfgFolder + "slam_tracklist.cfg"))
            {
                slam_tracklist_cfg.WriteLine("echo \"You can select tracks either by typing a tag, or their track number.\"");
                slam_tracklist_cfg.WriteLine("echo \"--------------------Tracks--------------------\"");
                foreach (var Track in Game.tracks)
                {
                    string index = Game.tracks.IndexOf(Track).ToString();
                    if (My.MySettingsProperty.Settings.WriteTags)
                    {
                        slam_tracklist_cfg.WriteLine("echo \"{0}. {1} [{2}]\"", Conversions.ToDouble(index) + 1d, Track.name, "'" + string.Join("', '", Track.tags) + "'");
                    }
                    else
                    {
                        slam_tracklist_cfg.WriteLine("echo \"{0}. {1}\"", Conversions.ToDouble(index) + 1d, Track.name);
                    }
                }

                slam_tracklist_cfg.WriteLine("echo \"----------------------------------------------\"");
            }
        }

        private bool LoadTrack(SourceGame Game, int index)
        {
            SourceGame.track Track;
            if (Game.tracks.Count > index)
            {
                Track = Game.tracks[index];
                string voicefile = Path.Combine(SteamAppsPath, Game.directory) + "voice_input.wav";
                try
                {
                    if (File.Exists(voicefile))
                    {
                        File.Delete(voicefile);
                    }

                    string trackfile = Game.libraryname + Track.name + Game.FileExtension;
                    if (File.Exists(trackfile))
                    {
                        if (Track.volume == 100 & Track.startpos <= 0 & Track.endpos <= 0)
                        {
                            File.Copy(trackfile, voicefile);
                        }
                        else if (My.MySettingsProperty.Settings.UseFFMPEG)
                        {
                            FFMPEG_ConvertAndTrim(trackfile, voicefile, Game.samplerate, Game.channels, Track.startpos / (double)Game.samplerate / 2d, (Track.endpos - Track.startpos) / (double)Game.samplerate / 2d, Math.Pow(Track.volume / 100d, 6d)); // /2 because SLAM stores Track.startpos and Track.endpos as # of bytes not sample. With 16-bit audio, there are 2 bytes per sample.
                        }
                        else
                        {
                            var WaveFloat = new WaveChannel32(new WaveFileReader(trackfile));
                            if (!(Track.volume == 100))
                            {
                                WaveFloat.Volume = (float)Math.Pow(Track.volume / 100d, 6d);
                            }

                            if (!(Track.startpos == Track.endpos) & Track.endpos > 0)
                            {
                                var bytes = new byte[(Track.endpos - Track.startpos) * 4 + 1];
                                WaveFloat.Position = Track.startpos * 4;
                                WaveFloat.Read(bytes, 0, (Track.endpos - Track.startpos) * 4);
                                WaveFloat = new WaveChannel32(new RawSourceWaveStream(new MemoryStream(bytes), WaveFloat.WaveFormat));
                            }

                            WaveFloat.PadWithZeroes = false;
                            var outFormat = new WaveFormat(Game.samplerate, Game.bits, Game.channels);
                            var resampler = new MediaFoundationResampler(WaveFloat, outFormat);
                            resampler.ResamplerQuality = 60;
                            WaveFileWriter.CreateWaveFile(voicefile, resampler); // wav
                            resampler.Dispose();
                            WaveFloat.Dispose();
                        }

                        string GameCfgFolder = Path.Combine(SteamAppsPath, Game.directory, Game.ToCfg);
                        using (var slam_curtrack = new StreamWriter(GameCfgFolder + "slam_curtrack.cfg"))
                        {
                            slam_curtrack.WriteLine("echo \"[SLAM] Track name: {0}\"", Track.name);
                        }

                        using (var slam_saycurtrack = new StreamWriter(GameCfgFolder + "slam_saycurtrack.cfg"))
                        {
                            slam_saycurtrack.WriteLine("say \"[SLAM] Track name: {0}\"", Track.name);
                        }

                        using (var slam_sayteamcurtrack = new StreamWriter(GameCfgFolder + "slam_sayteamcurtrack.cfg"))
                        {
                            slam_sayteamcurtrack.WriteLine("say_team \"[SLAM] Track name: {0}\"", Track.name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private string recog(string str, string reg)
        {
            var keyd = Regex.Match(str, reg, RegexOptions.IgnoreCase); // RegexOptions.IgnoreCase because bind could be saved as lowercase
            return keyd.Groups[1].ToString();
        }

        private void PollRelayWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            PollRelayWorker.ReportProgress(SEARCHING); // Report that SLAM is searching.
            SourceGame Game = (SourceGame)e.Argument;
            string GameDir = Game.directory + Game.exename + ".exe";
            SteamAppsPath = Constants.vbNullString;
            string UserDataPath = Constants.vbNullString;
            try
            {
                if (!My.MySettingsProperty.Settings.OverrideFolders)
                {
                    while (!PollRelayWorker.CancellationPending)
                    {
                        string GameProcess = GetFilepath(Game.exename);
                        if (!string.IsNullOrEmpty(GameProcess) && GameProcess.EndsWith(GameDir))
                        {
                            SteamAppsPath = GameProcess.Remove(GameProcess.Length - GameDir.Length);
                        }

                        string SteamProcess = GetFilepath("Steam");
                        if (!string.IsNullOrEmpty(SteamProcess))
                        {
                            UserDataPath = SteamProcess.Remove(SteamProcess.Length - "Steam.exe".Length) + @"userdata\";
                        }

                        if (Directory.Exists(SteamAppsPath))
                        {
                            if (!(Game.id == 0))
                            {
                                if (Directory.Exists(UserDataPath))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        Thread.Sleep(Game.PollInterval);
                    }
                }
                else
                {
                    SteamAppsPath = My.MySettingsProperty.Settings.steamapps;
                    if (Directory.Exists(My.MySettingsProperty.Settings.userdata))
                    {
                        UserDataPath = My.MySettingsProperty.Settings.userdata;
                    }
                    else
                    {
                        throw new Exception("Userdata folder does not exist. Disable \"override folder detection\", or select a correct folder.");
                    }
                }

                if (!string.IsNullOrEmpty(SteamAppsPath))
                {
                    CreateCfgFiles(Game, SteamAppsPath);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                e.Result = ex;
                return;
            }

            PollRelayWorker.ReportProgress(WORKING); // Report that SLAM is working.
            while (!PollRelayWorker.CancellationPending)
            {
                try
                {
                    string GameFolder = Path.Combine(SteamAppsPath, Game.directory);
                    string GameCfg = Path.Combine(GameFolder, Game.ToCfg) + "slam_relay.cfg";
                    if (!(Game.id == 0))
                    {
                        GameCfg = UserDataCFG(Game, UserDataPath);
                    }

                    if (File.Exists(GameCfg))
                    {
                        string RelayCfg;
                        using (var reader = new StreamReader(GameCfg))
                        {
                            RelayCfg = reader.ReadToEnd();
                        }

                        string command = recog(RelayCfg, string.Format("bind \"{0}\" \"(.*?)\"", My.MySettingsProperty.Settings.RelayKey));
                        if (!string.IsNullOrEmpty(command))
                        {
                            // load audiofile
                            if (Information.IsNumeric(command))
                            {
                                if (LoadTrack(Game, Convert.ToInt32(command) - 1))
                                {
                                    PollRelayWorker.ReportProgress(Convert.ToInt32(command) - 1);
                                }
                            }

                            File.Delete(GameCfg);
                        }
                    }

                    Thread.Sleep(Game.PollInterval);
                }
                catch (Exception ex)
                {
                    if (!(ex.HResult == -2147024864)) // -2147024864 = "System.IO.IOException: The process cannot access the file because it is being used by another process."
                    {
                        LogError(ex);
                        e.Result = ex;
                        return;
                    }
                }
            }

            if (!string.IsNullOrEmpty(SteamAppsPath))
            {
                DeleteCFGs(Game, SteamAppsPath);
            }
        }

        public string UserDataCFG(SourceGame Game, string UserdataPath)
        {
            if (Directory.Exists(UserdataPath))
            {
                foreach (string userdir in Directory.GetDirectories(UserdataPath))
                {
                    string CFGPath = Path.Combine(userdir, Game.id.ToString()) + @"\local\cfg\slam_relay.cfg";
                    if (File.Exists(CFGPath))
                    {
                        return CFGPath;
                    }
                }
            }

            return Constants.vbNullString;
        }

        private string GetFilepath(string ProcessName)
        {
            string wmiQueryString = "Select * from Win32_Process Where Name = \"" + ProcessName + ".exe\"";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    var Process = results.Cast<ManagementObject>().FirstOrDefault();
                    if (Process is object)
                    {
                        var exePath = Process["ExecutablePath"];
                        // Check Process("ExecutablePath") for null before calling ToString.
                        // Fixes error that occurs if you start steam / csgo while SLAM is searching.
                        string procPath = exePath is object ? exePath.ToString() : Constants.vbNullString;
                        if (!string.IsNullOrWhiteSpace(procPath))
                        {
                            return Process["ExecutablePath"].ToString();
                        }
                    }
                }
            }

            return null;
        }

        private void PollRelayWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case SEARCHING:
                    {
                        status = SEARCHING;
                        StatusLabel.Text = "Status: Searching...";
                        break;
                    }

                case WORKING:
                    {
                        status = WORKING;
                        StatusLabel.Text = "Status: Working.";
                        break;
                    }

                default:
                    {
                        DisplayLoaded(e.ProgressPercentage);
                        break;
                    }
            }
        }

        private void PollRelayWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (running)
            {
                StopPoll();
            }

            status = IDLE;
            StatusLabel.Text = "Status: Idle.";
            RefreshTrackList();
            if (!Information.IsNothing(e.Result)) // Result is always an exception
            {
                MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(e.Result.Message, " See errorlog.txt for more info.")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ClosePending)
            {
                Close();
            }
        }

        private void CreateTags(SourceGame Game)
        {
            var NameWords = new Dictionary<string, int>();
            var index = default(int);
            foreach (var Track in Game.tracks)
            {
                var Words = Track.name.Split(new[] { ' ', '.', '-', '_' }).ToList();
                foreach (var Word in Words)
                {
                    if (!Information.IsNumeric(Word) & !Game.blacklist.Contains(Word.ToLower()) & Word.Length < 32)
                    {
                        if (NameWords.ContainsKey(Word))
                        {
                            NameWords.Remove(Word);
                        }
                        else
                        {
                            NameWords.Add(Word, index);
                        }
                    }
                }

                index += 1;
            }

            foreach (KeyValuePair<string, int> Tag in NameWords)
                Game.tracks[Tag.Value].tags.Add(Tag.Key);
        }

        private void EnableInterface()
        {
            foreach (var Control in Controls)
                Control.Enabled = true;
        }

        private void DisableInterface()
        {
            foreach (var Control in Controls)
                Control.Enabled = false;
        }

        private void DisplayLoaded(int track)
        {
            for (int i = 0, loopTo = TrackList.Items.Count - 1; i <= loopTo; i++)
                TrackList.Items[i].SubItems[0].Text = "False";
            TrackList.Items[track].SubItems[0].Text = "True";
        }

        private void LoadTrackKeys(SourceGame Game)
        {
            var SettingsList = new List<SourceGame.track>();
            string SettingsFile = Path.Combine(Game.libraryname, "TrackSettings.xml");
            if (File.Exists(SettingsFile))
            {
                string XmlFile;
                using (var reader = new StreamReader(SettingsFile))
                {
                    XmlFile = reader.ReadToEnd();
                }

                SettingsList = Deserialize<List<SourceGame.track>>(XmlFile);
            }

            foreach (var Track in Game.tracks)
            {
                foreach (var SetTrack in SettingsList)
                {
                    if ((Track.name ?? "") == (SetTrack.name ?? ""))
                    {
                        // Please tell me that there is a better way to do the following...
                        Track.hotkey = SetTrack.hotkey;
                        Track.volume = SetTrack.volume;
                        Track.startpos = SetTrack.startpos;
                        Track.endpos = SetTrack.endpos;
                    }
                }
            }
        }

        private void SaveTrackKeys(SourceGame Game)
        {
            var SettingsList = new List<SourceGame.track>();
            string SettingsFile = Path.Combine(Game.libraryname, "TrackSettings.xml");
            foreach (var Track in Game.tracks)
            {
                if (!string.IsNullOrEmpty(Track.hotkey) | !(Track.volume == 100) | Track.endpos > 0)
                {
                    SettingsList.Add(Track);
                }
            }

            if (SettingsList.Count > 0)
            {
                using (var writer = new StreamWriter(SettingsFile))
                {
                    writer.Write(XmlSerialization.Serialize(SettingsList));
                }
            }
            else if (File.Exists(SettingsFile))
            {
                File.Delete(SettingsFile);
            }
        }

        private void TrackList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (TrackList.FocusedItem.Bounds.Contains(e.Location))
                {
                    foreach (var Control in TrackContextMenu.Items) // everything invisible
                        Control.visible = false;
                    SetVolumeToolStripMenuItem.Visible = true; // always visible
                    ContextRefresh.Visible = true;
                    if (TrackList.SelectedItems.Count > 1)
                    {
                        if (!running) // visible when multiple selected AND is not running
                        {
                            ContextDelete.Visible = true;
                        }
                    }
                    else if (running)
                    {
                        TrimToolStripMenuItem.Visible = true; // visible when only one selected AND is running
                        if (status == WORKING)
                        {
                            LoadToolStripMenuItem.Visible = true;
                        }
                    }
                    else
                    {
                        foreach (var Control in TrackContextMenu.Items) // visible when only one selected AND is not running (all)
                            Control.visible = true;
                        LoadToolStripMenuItem.Visible = false;
                    }
                    // Maybe I should have used a case... Maybe...

                }

                TrackContextMenu.Show(Cursor.Position);
            }
        }

        private void TrackList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TrackList.FocusedItem.Bounds.Contains(e.Location) && status == WORKING)
            {
                LoadTrack(GetCurrentGame(), TrackList.SelectedItems[0].Index);
                DisplayLoaded(TrackList.SelectedItems[0].Index);
            }
        }

        private void ContextRefresh_Click(object sender, EventArgs e)
        {
            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
        }

        private void ContextDelete_Click(object sender, EventArgs e)
        {
            var game = GetCurrentGame();
            var SelectedNames = new List<string>();
            foreach (var item in TrackList.SelectedItems)
                SelectedNames.Add(Conversions.ToString(item.SubItems((object)1).Text));
            if (MessageBox.Show(string.Format("Are you sure you want to delete {0}?", string.Join(", ", SelectedNames)), "Delete Track?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var item in SelectedNames)
                {
                    string FilePath = Path.Combine(game.libraryname, item + game.FileExtension);
                    if (File.Exists(FilePath))
                    {
                        try
                        {
                            File.Delete(FilePath);
                        }
                        catch (Exception ex)
                        {
                            LogError(ex);
                            Interaction.MsgBox(string.Format("Failed to delete {0}.", FilePath));
                        }
                    }
                }
            }

            ReloadTracks(GetCurrentGame());
            RefreshTrackList();
        }

        private void ContextHotKey_Click(object sender, EventArgs e)
        {
            var SelectKeyDialog = new SelectKey();
            int SelectedIndex = TrackList.SelectedItems[0].Index;
            if (SelectKeyDialog.ShowDialog() == DialogResult.OK)
            {
                var Game = GetCurrentGame();
                bool KeyIsFree = true;
                foreach (var track in Game.tracks)
                {
                    if ((track.hotkey ?? "") == (SelectKeyDialog.ChosenKey ?? "")) // Checking to see if any other track is already using this key
                    {
                        KeyIsFree = false;
                    }
                }

                if (KeyIsFree)
                {
                    Game.tracks[SelectedIndex].hotkey = SelectKeyDialog.ChosenKey;
                    SaveTrackKeys(GetCurrentGame());
                    ReloadTracks(GetCurrentGame());
                    RefreshTrackList();
                }
                else
                {
                    MessageBox.Show(string.Format("\"{0}\" has already been assigned!", SelectKeyDialog.ChosenKey), "Invalid Key");
                }
            }
        }

        private void RemoveHotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var SelectedIndex in TrackList.SelectedItems)
            {
                var Game = GetCurrentGame();
                Game.tracks[Conversions.ToInteger(SelectedIndex.index)].hotkey = Constants.vbNullString;
                SaveTrackKeys(GetCurrentGame());
                ReloadTracks(GetCurrentGame());
            }

            RefreshTrackList();
        }

        private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Games = GetCurrentGame();
            string FilePath = Path.Combine(Games.libraryname, Games.tracks[TrackList.SelectedItems[0].Index].name + Games.FileExtension);
            string Args = string.Format("/Select, \"{0}\"", FilePath);
            var pfi = new ProcessStartInfo("Explorer.exe", Args);
            Process.Start(pfi);
        }

        private void SetVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SetVolumeDialog = new SetVolume();
            if (SetVolumeDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var index in TrackList.SelectedIndices)
                    GetCurrentGame().tracks[Conversions.ToInteger(index)].volume = SetVolumeDialog.Volume;
                SaveTrackKeys(GetCurrentGame());
                ReloadTracks(GetCurrentGame());
                RefreshTrackList();
            }
        }

        private void TrimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("NAudio.dll"))
            {
                var Game = GetCurrentGame();
                var TrimDialog = new TrimForm();
                TrimDialog.WavFile = Path.Combine(Game.libraryname, Game.tracks[TrackList.SelectedIndices[0]].name + Game.FileExtension);
                TrimDialog.startpos = Game.tracks[TrackList.SelectedIndices[0]].startpos;
                TrimDialog.endpos = Game.tracks[TrackList.SelectedIndices[0]].endpos;
                if (TrimDialog.ShowDialog() == DialogResult.OK)
                {
                    Game.tracks[TrackList.SelectedIndices[0]].startpos = TrimDialog.startpos;
                    Game.tracks[TrackList.SelectedIndices[0]].endpos = TrimDialog.endpos;
                    SaveTrackKeys(GetCurrentGame());
                    ReloadTracks(GetCurrentGame());
                    RefreshTrackList();
                }
            }
            else
            {
                MessageBox.Show("You are missing NAudio.dll! Cannot trim without it!", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Game = GetCurrentGame();
            var RenameDialog = new RenameForm();
            var SelectedTrack = GetCurrentGame().tracks[TrackList.SelectedIndices[0]];
            RenameDialog.filename = SelectedTrack.name;
            if (RenameDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileSystem.Rename(Game.libraryname + SelectedTrack.name + Game.FileExtension, Game.libraryname + RenameDialog.filename + Game.FileExtension);
                    GetCurrentGame().tracks[TrackList.SelectedIndices[0]].name = RenameDialog.filename;
                    SaveTrackKeys(GetCurrentGame());
                    ReloadTracks(GetCurrentGame());
                    RefreshTrackList();
                }
                catch (Exception ex)
                {
                    switch (ex.HResult)
                    {
                        case -2147024809:
                            {
                                MessageBox.Show("\"" + RenameDialog.filename + "\" contains invalid characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                        case -2146232800:
                            {
                                MessageBox.Show("A track with that name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }

                        default:
                            {
                                MessageBox.Show(ex.Message + " See errorlog.txt for more info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                    }
                }
            }
        }

        private async void CheckForUpdate()
        {
            string UpdateText;
            string NeatVersion = My.MyProject.Application.Info.Version.ToString().Remove(My.MyProject.Application.Info.Version.ToString().LastIndexOf("."));
            try
            {
                using (var client = new HttpClient())
                {
                    var UpdateTextTask = client.GetStringAsync("http://slam.flankers.net/updates.php?version=" + NeatVersion);
                    UpdateText = await UpdateTextTask;
                }
            }
            catch (Exception ex)
            {
                return;
            }

            var NewVersion = new Version("0.0.0.0"); // generic
            string UpdateURL = UpdateText.Split()[1];
            if (Version.TryParse(UpdateText.Split()[0], out NewVersion))
            {
                if (My.MyProject.Application.Info.Version.CompareTo(NewVersion) < 0)
                {
                    if (MessageBox.Show(string.Format("An update ({0}) is available! Click \"OK\" to be taken to the download page.", NewVersion.ToString()), "SLAM Update", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Process.Start(UpdateURL);
                    }
                }
            }
        }

        private void PlayKeyButton_Click(object sender, EventArgs e)
        {
            var SelectKeyDialog = new SelectKey();
            if (SelectKeyDialog.ShowDialog() == DialogResult.OK)
            {
                if (!((SelectKeyDialog.ChosenKey ?? "") == (My.MySettingsProperty.Settings.RelayKey ?? "")))
                {
                    My.MySettingsProperty.Settings.PlayKey = SelectKeyDialog.ChosenKey;
                    My.MySettingsProperty.Settings.Save();
                    RefreshPlayKey();
                }
                else
                {
                    MessageBox.Show("Play key and relay key can not be the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshPlayKey()
        {
            PlayKeyButton.Text = string.Format("Play key: \"{0}\" (change)", My.MySettingsProperty.Settings.PlayKey);
        }

        public void LogError(Exception ex)
        {
            if (My.MySettingsProperty.Settings.LogError)
            {
                using (var log = new StreamWriter("errorlog.txt", true))
                {
                    log.WriteLine("--------------------{0} UTC--------------------", DateTime.Now.ToUniversalTime());
                    log.WriteLine(ex.ToString());
                }
            }
        }

        private void ChangeDirButton_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.SettingsForm.ShowDialog();
        }

        private void DeleteCFGs(SourceGame Game, string SteamappsPath)
        {
            string GameDir = Path.Combine(SteamappsPath, Game.directory);
            string GameCfgFolder = Path.Combine(GameDir, Game.ToCfg);
            var SlamFiles = new string[] { "slam.cfg", "slam_tracklist.cfg", "slam_relay.cfg", "slam_curtrack.cfg", "slam_saycurtrack.cfg", "slam_sayteamcurtrack.cfg" };
            string voicefile = Path.Combine(SteamappsPath, Game.directory) + "voice_input.wav";
            try
            {
                if (File.Exists(voicefile))
                {
                    File.Delete(voicefile);
                }

                foreach (var FileName in SlamFiles)
                {
                    if (File.Exists(GameCfgFolder + FileName))
                    {
                        File.Delete(GameCfgFolder + FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (running)
            {
                StopPoll();
                ClosePending = true;
                e.Cancel = true;
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTrack(GetCurrentGame(), TrackList.SelectedItems[0].Index);
            DisplayLoaded(TrackList.SelectedItems[0].Index);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (My.MySettingsProperty.Settings.MinimizeToSysTray)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    SystemTrayIcon.Visible = true;
                    SystemTrayIcon.BalloonTipIcon = ToolTipIcon.Info;
                    SystemTrayIcon.BalloonTipTitle = "SLAM";
                    SystemTrayIcon.BalloonTipText = "Minimized to tray";
                    SystemTrayIcon.ShowBalloonTip(50000);
                    Hide();
                    ShowInTaskbar = false;
                }
            }
        }

        private void SystemTrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            SystemTrayIcon.Visible = false;
        }

        private void SystemTrayMenu_OpenHandler(object sender, EventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            SystemTrayIcon.Visible = false;
        }

        private void SystemTrayMenu_StartStopHandler(object sender, EventArgs e)
        {
            if (running)
            {
                StopPoll();
            }
            else
            {
                StartPoll();
            }
        }

        private void SystemTrayMenu_ExitHandler(object sender, EventArgs e)
        {
            if (running)
            {
                StopPoll();
                ClosePending = true;
            }
            else
            {
                Close();
            }
        }
    }
}
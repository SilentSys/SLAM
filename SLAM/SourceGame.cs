using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace SLAM
{
    public class SourceGame
    {
        public SourceGame()
        {
            blacklist = new List<string>() { "slam", "slam_listtracks", "list", "tracks", "la", "slam_play", "slam_play_on", "slam_play_off", "slam_updatecfg", "slam_curtrack", "slam_saycurtrack", "slam_sayteamcurtrack" };
        }

        public string name;
        public int id;
        public string directory;
        public string ToCfg;
        public string libraryname;
        public bool VoiceFadeOut = true;
        public string exename = "hl2";
        public string FileExtension = ".wav";
        public int samplerate = 11025;
        public int bits = 16;
        public int channels = 1;
        public int PollInterval = 100;
        public List<track> tracks = new List<track>();
        public List<string> blacklist;

        public class track
        {
            public string name;
            public List<string> tags = new List<string>();
            public string hotkey = Constants.vbNullString;
            public int volume = 100;
            public int startpos;
            public int endpos;
        }
    }
}
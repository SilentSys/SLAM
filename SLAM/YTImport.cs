using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using YoutubeExtractor;

namespace SLAM
{
    public partial class YTImport
    {
        public YTImport()
        {
            InitializeComponent();
            _ImportButton.Name = "ImportButton";
            _DonateLabel.Name = "DonateLabel";
        }

        public string file;

        public void ProgressChangedHandler(object sender, object args)
        {
            Console.WriteLine(args.ProgressPercentage);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            var youtubeMatch = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(TextBox1.Text);
            if (youtubeMatch.Success)
            {
                TextBox1.Enabled = false;
                ImportButton.Enabled = false;
                DownloadWorker.RunWorkerAsync("youtube.com/watch?v=" + youtubeMatch.Groups[1].Value);
                ToolStripStatusLabel1.Text = "Status: Downloading";
            }
            else
            {
                MessageBox.Show("Invalid YouTube URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox1.Enabled = true;
                ImportButton.Enabled = true;
            }
        }

        private void DownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(Conversions.ToString(e.Argument)).OrderBy(vid => vid.Resolution);
                var video = videoInfos.First(info => info.AdaptiveType == AdaptiveType.Audio && info.AudioType == AudioType.Aac || info.AdaptiveType == AdaptiveType.None && info.VideoType == VideoType.Mp4 && info.AudioBitrate >= 128);
                if (Information.IsNothing(video))
                {
                    if (videoInfos.Any(info => info.AdaptiveType == AdaptiveType.None && info.VideoType == VideoType.Mp4))
                    {
                        video = videoInfos.First(info => info.AdaptiveType == AdaptiveType.None && info.VideoType == VideoType.Mp4);
                    }
                    else
                    {
                        throw new Exception("Could not find download.");
                    }
                }

                if (video.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(video);
                }

                if (!Directory.Exists(Path.GetFullPath(@"temp\")))
                {
                    Directory.CreateDirectory(Path.GetFullPath(@"temp\"));
                }

                string filename = string.Join("", video.Title.Split(Path.GetInvalidFileNameChars()));
                var VideoDownloader = new VideoDownloader(video, Path.GetFullPath(@"temp\" + filename + video.VideoExtension));
                VideoDownloader.DownloadProgressChanged += (send, args) => DownloadWorker.ReportProgress(Convert.ToInt32(args.ProgressPercentage));
                VideoDownloader.Execute();
                e.Result = Path.GetFullPath(@"temp\" + filename + video.VideoExtension);
            }
            catch (Exception ex)
            {
                My.MyProject.Forms.Form1.LogError(ex);
                e.Result = ex;
            }
        }

        private void DownloadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ToolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void DownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.GetType() == typeof(Exception))
            {
                MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(e.Result.Message, " See errorlog.txt for more info.")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                file = Conversions.ToString(e.Result);
                DialogResult = DialogResult.OK;
            }
        }

        private void DonateLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RVLLPGWJUG6CY");
        }

        private void YTImport_Load(object sender, EventArgs e)
        {
            TextBox1.Select();
        }
    }
}
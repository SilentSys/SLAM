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
using VideoLibrary;

namespace SLAM
{
    public partial class YTImport
    {
        const string tempPath = @"temp\";

        public YTImport()
        {
            InitializeComponent();
            _ImportButton.Name = "ImportButton";
        }

        public string file;

        public void ProgressChangedHandler(object sender, object args)
        {
            Console.WriteLine(args);
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

        // returns path where the video has been downloaded to
        private string DownloadVideo(string url)
        {
            YouTube youTube = YouTube.Default;
            var video = youTube.GetVideo(url);

            string filename = string.Join("", video.Title.Split(Path.GetInvalidFileNameChars()));
            File.WriteAllBytes(Path.GetFullPath(tempPath + filename + video.FileExtension), video.GetBytes());
            return Path.GetFullPath(@"temp\" + filename + video.FileExtension);
        }

        private void DownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CheckForTempDir();
                e.Result = DownloadVideo((string)e.Argument);

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
                MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(e.Result, " See errorlog.txt for more info.")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private bool TempDirectoryExists()
        {
            return Directory.Exists(Path.GetFullPath(tempPath));
        }
        
        private void CheckForTempDir()
        {
            if (!TempDirectoryExists())
            {
                Directory.CreateDirectory(Path.GetFullPath(@"temp\"));
            }
        }
    }
}
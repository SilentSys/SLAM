using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using NAudio.Wave;

namespace SLAM
{
    public partial class TrimForm
    {
        public TrimForm()
        {
            InitializeComponent();
            _NumericRight.Name = "NumericRight";
            _DoneButton.Name = "DoneButton";
            _NumericLeft.Name = "NumericLeft";
            _ResetButton.Name = "ResetButton";
            _NumericLeftS.Name = "NumericLeftS";
            _NumericRightS.Name = "NumericRightS";
            _PlayButton.Name = "PlayButton";
            _AdvWaveViewer1.Name = "AdvWaveViewer1";
        }

        public string WavFile;
        public int startpos;
        public int endpos;

        private void TrimForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(WavFile))
            {
                using (var reader = new WaveFileReader(WavFile))
                {
                    AdvWaveViewer1.WaveStream = new WaveFileReader(WavFile);
                    // reader.WaveFormat.SampleRate
                }

                NumericRightS.Maximum = decimal.MaxValue;
                NumericRight.Maximum = AdvWaveViewer1.MaxSamples;
                NumericRight.Increment = AdvWaveViewer1.SamplesPerPixel;
                NumericLeftS.Maximum = decimal.MaxValue;
                NumericLeft.Maximum = decimal.MaxValue;
                NumericLeft.Increment = AdvWaveViewer1.SamplesPerPixel;
                if (startpos == endpos & endpos == 0)
                {
                    NumericRight.Value = AdvWaveViewer1.MaxSamples;
                }
                else
                {
                    AdvWaveViewer1.rightpos = endpos;
                    AdvWaveViewer1.leftpos = startpos;
                    NumericRight.Value = AdvWaveViewer1.rightSample;
                    NumericLeft.Value = AdvWaveViewer1.leftSample;
                }
            }
        }

        private void TrimForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BackgroundPlayer.IsBusy)
            {
                BackgroundPlayer.CancelAsync();
            }
        }

        private void AdvWaveViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            NumericRight.Value = AdvWaveViewer1.rightSample;
            NumericLeft.Value = AdvWaveViewer1.leftSample;
        }

        private void NumericLeft_ValueChanged(object sender, EventArgs e)
        {
            if (NumericLeft.Value >= AdvWaveViewer1.rightSample)
            {
                NumericLeft.Value = NumericRight.Value - 1m;
            }

            AdvWaveViewer1.leftSample = (int)NumericLeft.Value;
            NumericLeftS.Value = NumericLeft.Value / AdvWaveViewer1.SampleRate;
        }

        private void NumericRight_ValueChanged(object sender, EventArgs e)
        {
            if (NumericRight.Value <= AdvWaveViewer1.leftSample)
            {
                NumericRight.Value = NumericLeft.Value + 1m;
            }

            AdvWaveViewer1.rightSample = (int)NumericRight.Value;
            NumericRightS.Value = NumericRight.Value / AdvWaveViewer1.SampleRate;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            startpos = AdvWaveViewer1.leftpos;
            if (AdvWaveViewer1.rightSample == AdvWaveViewer1.MaxSamples & AdvWaveViewer1.leftpos == 0)
            {
                endpos = 0;
            }
            else
            {
                endpos = AdvWaveViewer1.rightpos;
            }

            DialogResult = DialogResult.OK;
        }

        private void TrimForm_Resize(object sender, EventArgs e)
        {
            NumericLeft.Increment = AdvWaveViewer1.SamplesPerPixel;
            NumericRight.Increment = AdvWaveViewer1.SamplesPerPixel;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            NumericLeft.Value = 0m;
            NumericRight.Value = AdvWaveViewer1.MaxSamples;
        }

        private void NumericLeftS_ValueChanged(object sender, EventArgs e)
        {
            NumericLeft.Value = NumericLeftS.Value * AdvWaveViewer1.SampleRate;
        }

        private void NumericRightS_ValueChanged(object sender, EventArgs e)
        {
            if (NumericRightS.Value * AdvWaveViewer1.SampleRate <= NumericRight.Maximum)
            {
                NumericRight.Value = NumericRightS.Value * AdvWaveViewer1.SampleRate;
            }
            else
            {
                NumericRight.Value = NumericRight.Maximum;
                NumericRightS.Value = NumericRight.Value / AdvWaveViewer1.SampleRate;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (BackgroundPlayer.IsBusy == false)
            {
                BackgroundPlayer.RunWorkerAsync(new object[3] { AdvWaveViewer1.WaveStream, AdvWaveViewer1.leftpos, AdvWaveViewer1.rightpos });
                PlayButton.Text = "Stop";
                DisableInterface();
                PlayButton.Enabled = true;
            }
            else
            {
                BackgroundPlayer.CancelAsync();
                PlayButton.Text = "Play";
            }
        }

        private void BackgroundPlayer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            object[] arguments = e.Argument as object[];

            WaveStream WaveFloat = (WaveStream)arguments[0];
            int LeftPos = Conversions.ToInteger(arguments[1]);
            int RightPos = Conversions.ToInteger(arguments[2]);
            var bytes = new byte[RightPos - LeftPos + 1];
            WaveFloat.Position = LeftPos;
            WaveFloat.Read(bytes, 0, RightPos - LeftPos);
            WaveFloat = new RawSourceWaveStream(new MemoryStream(bytes), WaveFloat.WaveFormat);
            // WaveFloat.PadWithZeroes = False

            using (var output = new WaveOutEvent())
            {
                output.Init(WaveFloat);
                output.Play();
                while (output.PlaybackState == PlaybackState.Playing & !BackgroundPlayer.CancellationPending)
                {
                    Thread.Sleep(45);
                    BackgroundPlayer.ReportProgress((int)(output.GetPosition() / (WaveFloat.WaveFormat.BitsPerSample / 8d)));
                }
            }
        }

        private void BackgroundPlayer_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            AdvWaveViewer1.marker = e.ProgressPercentage;
        }

        private void BackgroundPlayer_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            PlayButton.Text = "Play";
            AdvWaveViewer1.marker = 0L;
            EnableInterface();
        }

        private void EnableInterface()
        {
            foreach (Control Control in Controls)
                Control.Enabled = true;
        }

        private void DisableInterface()
        {
            foreach (Control Control in Controls)
                Control.Enabled = false;
        }
    }
}
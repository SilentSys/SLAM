using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Wave;

namespace SLAM
{

    /// <summary>
/// Control for viewing waveforms
/// </summary>
    public class AdvWaveViewer : UserControl
    {
        /// <summary>
    /// Required designer variable.
    /// </summary>
        private Container components = null;
        private WaveStream m_waveStream;
        private int m_samplesPerPixel = 128;
        private long m_startPosition;
        private int bytesPerSample = 2;
        /// <summary>
    /// Creates a new WaveViewer control
    /// </summary>
        public AdvWaveViewer()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void Fit()
        {
            if (m_waveStream is null)
            {
                return;
            }

            if (!(Width > 0))
            {
                return;
            }

            int samples = (int)(m_waveStream.Length / (double)bytesPerSample);
            m_startPosition = 0L;
            SamplesPerPixel = (int)(samples / (double)Width);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Fit();
        }

        private Point mousePos;
        private Point startPos;
        private bool mouseDrag = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & Enabled)
            {
                startPos = e.Location;
                mousePos = new Point(-1, -1);
                mouseDrag = true;
                DrawVerticalLine(e.X);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.X >= 0 & e.X <= Width & Enabled)
            {
                if (mouseDrag)
                {
                    DrawVerticalLine(e.X);
                    if (mousePos.X != -1)
                    {
                        DrawVerticalLine(mousePos.X);
                    }

                    mousePos = e.Location;
                }
            }

            base.OnMouseMove(e);
        }

        public int MaxSamples
        {
            get
            {
                return (int)(m_waveStream.Length / (double)bytesPerSample);
            }
        }

        private int m_leftSample = -1;

        public int leftSample
        {
            get
            {
                return m_leftSample;
            }

            set
            {
                m_leftSample = value;
                Invalidate();
            }
        }

        private int m_rightSample = -1;

        public int rightSample
        {
            get
            {
                return m_rightSample;
            }

            set
            {
                m_rightSample = value;
                Invalidate();
            }
        }

        public int leftpos
        {
            get
            {
                return m_leftSample * bytesPerSample;
            }

            set
            {
                m_leftSample = (int)(value / (double)bytesPerSample);
                Invalidate();
            }
        }

        public int rightpos
        {
            get
            {
                return m_rightSample * bytesPerSample;
            }

            set
            {
                m_rightSample = (int)(value / (double)bytesPerSample);
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (mouseDrag && e.Button == MouseButtons.Left && Enabled)
            {
                mouseDrag = false;
                // DrawVerticalLine(startPos.X)

                if (mousePos.X == -1)
                {
                    if (!(startPos.X == 0))
                    {
                        DrawVerticalLine(startPos.X);
                    }

                    return;
                }
                // DrawVerticalLine(mousePos.X)

                m_leftSample = (int)(StartPosition / bytesPerSample + m_samplesPerPixel * Math.Min(startPos.X, mousePos.X));
                m_rightSample = (int)(StartPosition / bytesPerSample + m_samplesPerPixel * Math.Max(startPos.X, mousePos.X));
                Invalidate();
            }

            base.OnMouseUp(e);
        }

        private void DrawVerticalLine(int x)
        {
            ControlPaint.DrawReversibleLine(PointToScreen(new Point(x, 0)), PointToScreen(new Point(x, Height)), Color.Black);
        }

        /// <summary>
    /// sets the associated wavestream
    /// </summary>
        public WaveStream WaveStream
        {
            get
            {
                return m_waveStream;
            }

            set
            {
                m_waveStream = value;
                if (m_waveStream is object)
                {
                    bytesPerSample = (int)(m_waveStream.WaveFormat.BitsPerSample / 8d * m_waveStream.WaveFormat.Channels);
                    Fit();
                }

                Invalidate();
            }
        }

        public int SampleRate
        {
            get
            {
                return m_waveStream.WaveFormat.SampleRate;
            }
        }

        /// <summary>
    /// The zoom level, in samples per pixel
    /// </summary>
        public int SamplesPerPixel
        {
            get
            {
                return m_samplesPerPixel;
            }

            set
            {
                m_samplesPerPixel = value;
                Invalidate();
            }
        }

        /// <summary>
    /// Start position (currently in bytes)
    /// </summary>
        public long StartPosition
        {
            get
            {
                return m_startPosition;
            }

            set
            {
                m_startPosition = value;
            }
        }

        private int m_marker;

        public long marker
        {
            get
            {
                return m_marker;
            }

            set
            {
                if (value <= MaxSamples)
                {
                    m_marker = (int)value;
                    Invalidate();
                }
            }
        }

        /// <summary>
    /// Clean up any resources being used.
    /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components is object)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
    /// <see cref="Control.OnPaint"/>
    /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_waveStream is object)
            {
                m_waveStream.Position = 0L;
                int bytesRead;
                var waveData = new byte[(m_samplesPerPixel * bytesPerSample)];
                m_waveStream.Position = m_startPosition + e.ClipRectangle.Left * bytesPerSample * m_samplesPerPixel;
                int leftpos = (int)(m_leftSample / m_samplesPerPixel - StartPosition / bytesPerSample / m_samplesPerPixel);
                int rightpos = (int)(m_rightSample / m_samplesPerPixel - StartPosition / bytesPerSample / m_samplesPerPixel);
                int markerpos = (int)((m_marker + m_leftSample) / m_samplesPerPixel - StartPosition / bytesPerSample / m_samplesPerPixel);
                for (float x = e.ClipRectangle.X, loopTo = e.ClipRectangle.Right - 1; x <= loopTo; x++)
                {
                    short low = 0;
                    short high = 0;
                    bytesRead = m_waveStream.Read(waveData, 0, m_samplesPerPixel * bytesPerSample);
                    if (bytesRead == 0)
                    {
                        break;
                    }

                    for (int n = 0, loopTo1 = bytesRead - 1; n <= loopTo1; n += 2)
                    {
                        short sample = BitConverter.ToInt16(waveData, n);
                        if (sample < low)
                        {
                            low = sample;
                        }

                        if (sample > high)
                        {
                            high = sample;
                        }
                    }

                    float lowPercent = (low - (float)short.MinValue) / ushort.MaxValue;
                    float highPercent = (high - (float)short.MinValue) / ushort.MaxValue;
                    using (var DodgerBluePen = new Pen(Color.DodgerBlue))
                    using (var BluePen = new Pen(Color.Blue))
                    using (var RedPen = new Pen(Color.Red))
                    using (var GreenPen = new Pen(Color.Green))
                    {
                        if (x == leftpos & !(leftSample == rightSample) | x == rightpos & !(rightSample == leftSample))
                        {
                            e.Graphics.DrawLine(RedPen, x, 0f, x, Height);
                        }
                        else if (x == markerpos & m_marker > 0)
                        {
                            e.Graphics.DrawLine(GreenPen, x, 0f, x, Height);
                        }
                        else if (x > leftpos & x < rightpos)
                        {
                            e.Graphics.DrawLine(BluePen, x, Height * lowPercent, x, Height * highPercent);
                        }
                        else
                        {
                            e.Graphics.DrawLine(DodgerBluePen, x, Height * lowPercent, x, Height * highPercent);
                        }
                    }
                }
            }

            base.OnPaint(e);
        }


        /* TODO ERROR: Skipped RegionDirectiveTrivia */    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
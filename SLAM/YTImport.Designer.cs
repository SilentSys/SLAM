using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SLAM
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class YTImport : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _ImportButton = new Button();
            _ImportButton.Click += new EventHandler(ImportButton_Click);
            TextBox1 = new TextBox();
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            ToolStripProgressBar1 = new ToolStripProgressBar();
            _DonateLabel = new ToolStripStatusLabel();
            _DonateLabel.Click += new EventHandler(DonateLabel_Click);
            _DownloadWorker = new System.ComponentModel.BackgroundWorker();
            _DownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(DownloadWorker_DoWork);
            _DownloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(DownloadWorker_ProgressChanged);
            _DownloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(DownloadWorker_RunWorkerCompleted);
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ImportButton
            // 
            _ImportButton.Location = new Point(396, 10);
            _ImportButton.Name = "_ImportButton";
            _ImportButton.Size = new Size(75, 23);
            _ImportButton.TabIndex = 0;
            _ImportButton.Text = "Import";
            _ImportButton.UseVisualStyleBackColor = true;
            // 
            // TextBox1
            // 
            TextBox1.Location = new Point(12, 12);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(378, 20);
            TextBox1.TabIndex = 4;
            TextBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, ToolStripProgressBar1, _DonateLabel });
            StatusStrip1.Location = new Point(0, 42);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(483, 22);
            StatusStrip1.SizingGrip = false;
            StatusStrip1.TabIndex = 6;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(117, 17);
            ToolStripStatusLabel1.Spring = true;
            ToolStripStatusLabel1.Text = "Status: Idle";
            ToolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolStripProgressBar1
            // 
            ToolStripProgressBar1.Name = "ToolStripProgressBar1";
            ToolStripProgressBar1.Size = new Size(150, 16);
            // 
            // DonateLabel
            // 
            _DonateLabel.Alignment = ToolStripItemAlignment.Right;
            _DonateLabel.IsLink = true;
            _DonateLabel.Name = "_DonateLabel";
            _DonateLabel.Size = new Size(199, 17);
            _DonateLabel.Text = "Want to support SLAM by donating?";
            // 
            // DownloadWorker
            // 
            _DownloadWorker.WorkerReportsProgress = true;
            _DownloadWorker.WorkerSupportsCancellation = true;
            // 
            // YTImport
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 64);
            Controls.Add(StatusStrip1);
            Controls.Add(TextBox1);
            Controls.Add(_ImportButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "YTImport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "YouTube Import";
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            Load += new EventHandler(YTImport_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button _ImportButton;

        internal Button ImportButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ImportButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ImportButton != null)
                {
                    _ImportButton.Click -= ImportButton_Click;
                }

                _ImportButton = value;
                if (_ImportButton != null)
                {
                    _ImportButton.Click += ImportButton_Click;
                }
            }
        }

        internal TextBox TextBox1;
        internal StatusStrip StatusStrip1;
        internal ToolStripProgressBar ToolStripProgressBar1;
        private ToolStripStatusLabel _DonateLabel;

        internal ToolStripStatusLabel DonateLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DonateLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DonateLabel != null)
                {
                    _DonateLabel.Click -= DonateLabel_Click;
                }

                _DonateLabel = value;
                if (_DonateLabel != null)
                {
                    _DonateLabel.Click += DonateLabel_Click;
                }
            }
        }

        private System.ComponentModel.BackgroundWorker _DownloadWorker;

        internal System.ComponentModel.BackgroundWorker DownloadWorker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DownloadWorker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DownloadWorker != null)
                {
                    _DownloadWorker.DoWork -= DownloadWorker_DoWork;
                    _DownloadWorker.ProgressChanged -= DownloadWorker_ProgressChanged;
                    _DownloadWorker.RunWorkerCompleted -= DownloadWorker_RunWorkerCompleted;
                }

                _DownloadWorker = value;
                if (_DownloadWorker != null)
                {
                    _DownloadWorker.DoWork += DownloadWorker_DoWork;
                    _DownloadWorker.ProgressChanged += DownloadWorker_ProgressChanged;
                    _DownloadWorker.RunWorkerCompleted += DownloadWorker_RunWorkerCompleted;
                }
            }
        }

        internal ToolStripStatusLabel ToolStripStatusLabel1;
    }
}
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
            this._ImportButton = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this._DownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ImportButton
            // 
            this._ImportButton.Location = new System.Drawing.Point(396, 10);
            this._ImportButton.Name = "_ImportButton";
            this._ImportButton.Size = new System.Drawing.Size(75, 23);
            this._ImportButton.TabIndex = 0;
            this._ImportButton.Text = "Import";
            this._ImportButton.UseVisualStyleBackColor = true;
            this._ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(12, 12);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(378, 20);
            this.TextBox1.TabIndex = 4;
            this.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripProgressBar1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 42);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(483, 22);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 6;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(285, 17);
            this.ToolStripStatusLabel1.Spring = true;
            this.ToolStripStatusLabel1.Text = "Status: Idle";
            this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolStripProgressBar1
            // 
            this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
            this.ToolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            // 
            // _DownloadWorker
            // 
            this._DownloadWorker.WorkerReportsProgress = true;
            this._DownloadWorker.WorkerSupportsCancellation = true;
            this._DownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DownloadWorker_DoWork);
            this._DownloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DownloadWorker_ProgressChanged);
            this._DownloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DownloadWorker_RunWorkerCompleted);
            // 
            // YTImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 64);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this._ImportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "YTImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "YouTube Import";
            this.Load += new System.EventHandler(this.YTImport_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
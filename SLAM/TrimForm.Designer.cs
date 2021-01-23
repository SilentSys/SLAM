using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace SLAM
{
    [DesignerGenerated()]
    public partial class TrimForm : Form
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
            _NumericRight = new NumericUpDown();
            _NumericRight.ValueChanged += new EventHandler(NumericRight_ValueChanged);
            _DoneButton = new Button();
            _DoneButton.Click += new EventHandler(DoneButton_Click);
            _NumericLeft = new NumericUpDown();
            _NumericLeft.ValueChanged += new EventHandler(NumericLeft_ValueChanged);
            _ResetButton = new Button();
            _ResetButton.Click += new EventHandler(ResetButton_Click);
            GroupBox1 = new GroupBox();
            Label3 = new Label();
            _NumericLeftS = new NumericUpDown();
            _NumericLeftS.ValueChanged += new EventHandler(NumericLeftS_ValueChanged);
            Label1 = new Label();
            GroupBox2 = new GroupBox();
            Label4 = new Label();
            _NumericRightS = new NumericUpDown();
            _NumericRightS.ValueChanged += new EventHandler(NumericRightS_ValueChanged);
            Label2 = new Label();
            _BackgroundPlayer = new System.ComponentModel.BackgroundWorker();
            _BackgroundPlayer.DoWork += new System.ComponentModel.DoWorkEventHandler(BackgroundPlayer_DoWork);
            _BackgroundPlayer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(BackgroundPlayer_ProgressChanged);
            _BackgroundPlayer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(BackgroundPlayer_RunWorkerCompleted);
            _PlayButton = new Button();
            _PlayButton.Click += new EventHandler(PlayButton_Click);
            _AdvWaveViewer1 = new AdvWaveViewer();
            _AdvWaveViewer1.MouseUp += new MouseEventHandler(AdvWaveViewer1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)_NumericRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_NumericLeft).BeginInit();
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericLeftS).BeginInit();
            GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericRightS).BeginInit();
            SuspendLayout();
            // 
            // NumericRight
            // 
            _NumericRight.Location = new Point(57, 19);
            _NumericRight.Name = "_NumericRight";
            _NumericRight.Size = new Size(150, 20);
            _NumericRight.TabIndex = 2;
            _NumericRight.ThousandsSeparator = true;
            // 
            // DoneButton
            // 
            _DoneButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _DoneButton.Location = new Point(557, 203);
            _DoneButton.Name = "_DoneButton";
            _DoneButton.Size = new Size(215, 23);
            _DoneButton.TabIndex = 5;
            _DoneButton.Text = "Done";
            _DoneButton.UseVisualStyleBackColor = true;
            // 
            // NumericLeft
            // 
            _NumericLeft.Location = new Point(57, 19);
            _NumericLeft.Name = "_NumericLeft";
            _NumericLeft.Size = new Size(150, 20);
            _NumericLeft.TabIndex = 6;
            _NumericLeft.ThousandsSeparator = true;
            // 
            // ResetButton
            // 
            _ResetButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _ResetButton.Location = new Point(557, 174);
            _ResetButton.Name = "_ResetButton";
            _ResetButton.Size = new Size(100, 23);
            _ResetButton.TabIndex = 7;
            _ResetButton.Text = "Reset";
            _ResetButton.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GroupBox1.Controls.Add(Label3);
            GroupBox1.Controls.Add(_NumericLeftS);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Controls.Add(_NumericLeft);
            GroupBox1.Location = new Point(557, 12);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(215, 75);
            GroupBox1.TabIndex = 8;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Start";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(6, 47);
            Label3.Name = "Label3";
            Label3.Size = new Size(47, 13);
            Label3.TabIndex = 9;
            Label3.Text = "Second:";
            // 
            // NumericLeftS
            // 
            _NumericLeftS.DecimalPlaces = 3;
            _NumericLeftS.Location = new Point(57, 45);
            _NumericLeftS.Name = "_NumericLeftS";
            _NumericLeftS.Size = new Size(150, 20);
            _NumericLeftS.TabIndex = 8;
            _NumericLeftS.ThousandsSeparator = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(6, 21);
            Label1.Name = "Label1";
            Label1.Size = new Size(45, 13);
            Label1.TabIndex = 7;
            Label1.Text = "Sample:";
            // 
            // GroupBox2
            // 
            GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GroupBox2.Controls.Add(Label4);
            GroupBox2.Controls.Add(_NumericRightS);
            GroupBox2.Controls.Add(Label2);
            GroupBox2.Controls.Add(_NumericRight);
            GroupBox2.Location = new Point(557, 93);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(215, 75);
            GroupBox2.TabIndex = 9;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "End";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(6, 47);
            Label4.Name = "Label4";
            Label4.Size = new Size(47, 13);
            Label4.TabIndex = 10;
            Label4.Text = "Second:";
            // 
            // NumericRightS
            // 
            _NumericRightS.DecimalPlaces = 3;
            _NumericRightS.Location = new Point(57, 45);
            _NumericRightS.Name = "_NumericRightS";
            _NumericRightS.Size = new Size(150, 20);
            _NumericRightS.TabIndex = 9;
            _NumericRightS.ThousandsSeparator = true;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(6, 21);
            Label2.Name = "Label2";
            Label2.Size = new Size(45, 13);
            Label2.TabIndex = 8;
            Label2.Text = "Sample:";
            // 
            // BackgroundPlayer
            // 
            _BackgroundPlayer.WorkerReportsProgress = true;
            _BackgroundPlayer.WorkerSupportsCancellation = true;
            // 
            // PlayButton
            // 
            _PlayButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _PlayButton.Location = new Point(672, 174);
            _PlayButton.Name = "_PlayButton";
            _PlayButton.Size = new Size(100, 23);
            _PlayButton.TabIndex = 10;
            _PlayButton.Text = "Play";
            _PlayButton.UseVisualStyleBackColor = true;
            // 
            // AdvWaveViewer1
            // 
            _AdvWaveViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _AdvWaveViewer1.BackColor = Color.White;
            _AdvWaveViewer1.leftpos = 0;
            _AdvWaveViewer1.leftSample = 0;
            _AdvWaveViewer1.Location = new Point(0, 0);
            _AdvWaveViewer1.Name = "_AdvWaveViewer1";
            _AdvWaveViewer1.rightpos = 0;
            _AdvWaveViewer1.rightSample = 0;
            _AdvWaveViewer1.SamplesPerPixel = 128;
            _AdvWaveViewer1.Size = new Size(551, 231);
            _AdvWaveViewer1.StartPosition = Conversions.ToLong(0);
            _AdvWaveViewer1.TabIndex = 0;
            _AdvWaveViewer1.WaveStream = null;
            // 
            // TrimForm
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 231);
            Controls.Add(_PlayButton);
            Controls.Add(_ResetButton);
            Controls.Add(_DoneButton);
            Controls.Add(_AdvWaveViewer1);
            Controls.Add(GroupBox1);
            Controls.Add(GroupBox2);
            MinimizeBox = false;
            MinimumSize = new Size(16, 270);
            Name = "TrimForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trim";
            ((System.ComponentModel.ISupportInitialize)_NumericRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)_NumericLeft).EndInit();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericLeftS).EndInit();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_NumericRightS).EndInit();
            Load += new EventHandler(TrimForm_Load);
            FormClosing += new FormClosingEventHandler(TrimForm_FormClosing);
            Resize += new EventHandler(TrimForm_Resize);
            ResumeLayout(false);
        }

        private AdvWaveViewer _AdvWaveViewer1;

        internal AdvWaveViewer AdvWaveViewer1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AdvWaveViewer1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AdvWaveViewer1 != null)
                {
                    _AdvWaveViewer1.MouseUp -= AdvWaveViewer1_MouseUp;
                }

                _AdvWaveViewer1 = value;
                if (_AdvWaveViewer1 != null)
                {
                    _AdvWaveViewer1.MouseUp += AdvWaveViewer1_MouseUp;
                }
            }
        }

        private NumericUpDown _NumericRight;

        internal NumericUpDown NumericRight
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericRight;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericRight != null)
                {
                    _NumericRight.ValueChanged -= NumericRight_ValueChanged;
                }

                _NumericRight = value;
                if (_NumericRight != null)
                {
                    _NumericRight.ValueChanged += NumericRight_ValueChanged;
                }
            }
        }

        private Button _DoneButton;

        internal Button DoneButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DoneButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DoneButton != null)
                {
                    _DoneButton.Click -= DoneButton_Click;
                }

                _DoneButton = value;
                if (_DoneButton != null)
                {
                    _DoneButton.Click += DoneButton_Click;
                }
            }
        }

        private NumericUpDown _NumericLeft;

        internal NumericUpDown NumericLeft
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericLeft;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericLeft != null)
                {
                    _NumericLeft.ValueChanged -= NumericLeft_ValueChanged;
                }

                _NumericLeft = value;
                if (_NumericLeft != null)
                {
                    _NumericLeft.ValueChanged += NumericLeft_ValueChanged;
                }
            }
        }

        private Button _ResetButton;

        internal Button ResetButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ResetButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ResetButton != null)
                {
                    _ResetButton.Click -= ResetButton_Click;
                }

                _ResetButton = value;
                if (_ResetButton != null)
                {
                    _ResetButton.Click += ResetButton_Click;
                }
            }
        }

        internal GroupBox GroupBox1;
        internal Label Label3;
        private NumericUpDown _NumericLeftS;

        internal NumericUpDown NumericLeftS
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericLeftS;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericLeftS != null)
                {
                    _NumericLeftS.ValueChanged -= NumericLeftS_ValueChanged;
                }

                _NumericLeftS = value;
                if (_NumericLeftS != null)
                {
                    _NumericLeftS.ValueChanged += NumericLeftS_ValueChanged;
                }
            }
        }

        internal Label Label1;
        internal GroupBox GroupBox2;
        internal Label Label2;
        internal Label Label4;
        private NumericUpDown _NumericRightS;

        internal NumericUpDown NumericRightS
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericRightS;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericRightS != null)
                {
                    _NumericRightS.ValueChanged -= NumericRightS_ValueChanged;
                }

                _NumericRightS = value;
                if (_NumericRightS != null)
                {
                    _NumericRightS.ValueChanged += NumericRightS_ValueChanged;
                }
            }
        }

        private System.ComponentModel.BackgroundWorker _BackgroundPlayer;

        internal System.ComponentModel.BackgroundWorker BackgroundPlayer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BackgroundPlayer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BackgroundPlayer != null)
                {
                    _BackgroundPlayer.DoWork -= BackgroundPlayer_DoWork;
                    _BackgroundPlayer.ProgressChanged -= BackgroundPlayer_ProgressChanged;
                    _BackgroundPlayer.RunWorkerCompleted -= BackgroundPlayer_RunWorkerCompleted;
                }

                _BackgroundPlayer = value;
                if (_BackgroundPlayer != null)
                {
                    _BackgroundPlayer.DoWork += BackgroundPlayer_DoWork;
                    _BackgroundPlayer.ProgressChanged += BackgroundPlayer_ProgressChanged;
                    _BackgroundPlayer.RunWorkerCompleted += BackgroundPlayer_RunWorkerCompleted;
                }
            }
        }

        private Button _PlayButton;

        internal Button PlayButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PlayButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PlayButton != null)
                {
                    _PlayButton.Click -= PlayButton_Click;
                }

                _PlayButton = value;
                if (_PlayButton != null)
                {
                    _PlayButton.Click += PlayButton_Click;
                }
            }
        }
    }
}
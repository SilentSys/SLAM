using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace SLAM
{
    [DesignerGenerated()]
    public partial class Form1 : Form
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            _GameSelector = new ComboBox();
            _GameSelector.SelectedIndexChanged += new EventHandler(GameSelector_SelectedIndexChanged);
            Label1 = new Label();
            _ImportButton = new Button();
            _ImportButton.Click += new EventHandler(ImportButton_Click);
            _TrackList = new ListView();
            _TrackList.MouseClick += new MouseEventHandler(TrackList_MouseClick);
            _TrackList.MouseDoubleClick += new MouseEventHandler(TrackList_MouseDoubleClick);
            LoadedCol = new ColumnHeader();
            TrackCol = new ColumnHeader();
            HotKeyCol = new ColumnHeader();
            VolumeCol = new ColumnHeader();
            Trimmed = new ColumnHeader();
            TagsCol = new ColumnHeader();
            _StartButton = new Button();
            _StartButton.Click += new EventHandler(StartButton_Click);
            ImportDialog = new OpenFileDialog();
            ProgressBar1 = new ProgressBar();
            _WavWorker = new System.ComponentModel.BackgroundWorker();
            _WavWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(WavWorker_DoWork);
            _WavWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(WavWorker_ProgressChanged);
            _WavWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(WavWorker_RunWorkerCompleted);
            _PollRelayWorker = new System.ComponentModel.BackgroundWorker();
            _PollRelayWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(PollRelayWorker_DoWork);
            _PollRelayWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(PollRelayWorker_ProgressChanged);
            _PollRelayWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(PollRelayWorker_RunWorkerCompleted);
            _ChangeDirButton = new Button();
            _ChangeDirButton.Click += new EventHandler(ChangeDirButton_Click);
            TrackContextMenu = new ContextMenuStrip(components);
            _ContextDelete = new ToolStripMenuItem();
            _ContextDelete.Click += new EventHandler(ContextDelete_Click);
            _GoToToolStripMenuItem = new ToolStripMenuItem();
            _GoToToolStripMenuItem.Click += new EventHandler(GoToToolStripMenuItem_Click);
            _ContextRefresh = new ToolStripMenuItem();
            _ContextRefresh.Click += new EventHandler(ContextRefresh_Click);
            _RemoveHotkeyToolStripMenuItem = new ToolStripMenuItem();
            _RemoveHotkeyToolStripMenuItem.Click += new EventHandler(RemoveHotkeyToolStripMenuItem_Click);
            _RenameToolStripMenuItem = new ToolStripMenuItem();
            _RenameToolStripMenuItem.Click += new EventHandler(RenameToolStripMenuItem_Click);
            _ContextHotKey = new ToolStripMenuItem();
            _ContextHotKey.Click += new EventHandler(ContextHotKey_Click);
            _SetVolumeToolStripMenuItem = new ToolStripMenuItem();
            _SetVolumeToolStripMenuItem.Click += new EventHandler(SetVolumeToolStripMenuItem_Click);
            _TrimToolStripMenuItem = new ToolStripMenuItem();
            _TrimToolStripMenuItem.Click += new EventHandler(TrimToolStripMenuItem_Click);
            _LoadToolStripMenuItem = new ToolStripMenuItem();
            _LoadToolStripMenuItem.Click += new EventHandler(LoadToolStripMenuItem_Click);
            _PlayKeyButton = new Button();
            _PlayKeyButton.Click += new EventHandler(PlayKeyButton_Click);
            StatusLabel = new Label();
            _SystemTrayIcon = new NotifyIcon(components);
            _SystemTrayIcon.DoubleClick += new EventHandler(SystemTrayIcon_DoubleClick);
            SystemTrayMenu = new ContextMenuStrip(components);
            _SystemTrayMenu_Open = new ToolStripMenuItem();
            _SystemTrayMenu_Open.Click += new EventHandler(SystemTrayMenu_OpenHandler);
            _SystemTrayMenu_StartStop = new ToolStripMenuItem();
            _SystemTrayMenu_StartStop.Click += new EventHandler(SystemTrayMenu_StartStopHandler);
            ToolStripSeparator1 = new ToolStripSeparator();
            _SystemTrayMenu_Exit = new ToolStripMenuItem();
            _SystemTrayMenu_Exit.Click += new EventHandler(SystemTrayMenu_ExitHandler);
            _YTButton = new Button();
            _YTButton.Click += new EventHandler(YTButton_Click);
            TrackContextMenu.SuspendLayout();
            SystemTrayMenu.SuspendLayout();
            SuspendLayout();
            // 
            // GameSelector
            // 
            _GameSelector.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GameSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            _GameSelector.FormattingEnabled = true;
            _GameSelector.Location = new Point(56, 12);
            _GameSelector.MaxDropDownItems = 100;
            _GameSelector.Name = "_GameSelector";
            _GameSelector.Size = new Size(435, 21);
            _GameSelector.TabIndex = 0;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(12, 15);
            Label1.Name = "Label1";
            Label1.Size = new Size(38, 13);
            Label1.TabIndex = 1;
            Label1.Text = "Game:";
            // 
            // ImportButton
            // 
            _ImportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _ImportButton.Location = new Point(15, 297);
            _ImportButton.Name = "_ImportButton";
            _ImportButton.Size = new Size(54, 23);
            _ImportButton.TabIndex = 3;
            _ImportButton.Text = "Import";
            _ImportButton.UseVisualStyleBackColor = true;
            // 
            // TrackList
            // 
            _TrackList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TrackList.AutoArrange = false;
            _TrackList.Columns.AddRange(new ColumnHeader[] { LoadedCol, TrackCol, HotKeyCol, VolumeCol, Trimmed, TagsCol });
            _TrackList.FullRowSelect = true;
            _TrackList.HideSelection = false;
            _TrackList.ImeMode = ImeMode.Off;
            _TrackList.Location = new Point(15, 39);
            _TrackList.Name = "_TrackList";
            _TrackList.Size = new Size(557, 252);
            _TrackList.TabIndex = 4;
            _TrackList.UseCompatibleStateImageBehavior = false;
            _TrackList.View = View.Details;
            // 
            // LoadedCol
            // 
            LoadedCol.Text = "Loaded";
            // 
            // TrackCol
            // 
            TrackCol.Text = "Track";
            TrackCol.Width = 137;
            // 
            // HotKeyCol
            // 
            HotKeyCol.Text = "Bind";
            // 
            // VolumeCol
            // 
            VolumeCol.Text = "Volume";
            VolumeCol.Width = 100;
            // 
            // Trimmed
            // 
            Trimmed.Text = "Trimmed";
            // 
            // TagsCol
            // 
            TagsCol.Text = "Tags";
            TagsCol.Width = 43;
            // 
            // StartButton
            // 
            _StartButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _StartButton.Location = new Point(96, 297);
            _StartButton.Name = "_StartButton";
            _StartButton.Size = new Size(75, 23);
            _StartButton.TabIndex = 5;
            _StartButton.Text = "Start";
            _StartButton.UseVisualStyleBackColor = true;
            // 
            // ImportDialog
            // 
            ImportDialog.Filter = "Media files|*.mp3;*.wav;*.aac;*.wma;*.m4a;*.mp4;*.wmv;*.avi;*.m4v;*.mov;|Audio fi" + "les|*.mp3;*.wav;*.aac;*.wma;*.m4a;|Video files|*.mp4;*.wmv;*.avi;*.m4v;*.mov;|Al" + "l files|*.*";
            ImportDialog.Multiselect = true;
            // 
            // ProgressBar1
            // 
            ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProgressBar1.Location = new Point(15, 326);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(557, 23);
            ProgressBar1.Step = 1;
            ProgressBar1.TabIndex = 6;
            // 
            // WavWorker
            // 
            _WavWorker.WorkerReportsProgress = true;
            // 
            // PollRelayWorker
            // 
            _PollRelayWorker.WorkerReportsProgress = true;
            _PollRelayWorker.WorkerSupportsCancellation = true;
            // 
            // ChangeDirButton
            // 
            _ChangeDirButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _ChangeDirButton.Location = new Point(497, 10);
            _ChangeDirButton.Name = "_ChangeDirButton";
            _ChangeDirButton.Size = new Size(75, 23);
            _ChangeDirButton.TabIndex = 7;
            _ChangeDirButton.Text = "Settings";
            _ChangeDirButton.UseVisualStyleBackColor = true;
            // 
            // TrackContextMenu
            // 
            TrackContextMenu.ImageScalingSize = new Size(24, 24);
            TrackContextMenu.Items.AddRange(new ToolStripItem[] { _ContextDelete, _GoToToolStripMenuItem, _ContextRefresh, _RemoveHotkeyToolStripMenuItem, _RenameToolStripMenuItem, _ContextHotKey, _SetVolumeToolStripMenuItem, _TrimToolStripMenuItem, _LoadToolStripMenuItem });
            TrackContextMenu.Name = "TrackContextMenu";
            TrackContextMenu.Size = new Size(145, 202);
            // 
            // ContextDelete
            // 
            _ContextDelete.Name = "_ContextDelete";
            _ContextDelete.Size = new Size(144, 22);
            _ContextDelete.Text = "Delete";
            // 
            // GoToToolStripMenuItem
            // 
            _GoToToolStripMenuItem.Name = "_GoToToolStripMenuItem";
            _GoToToolStripMenuItem.Size = new Size(144, 22);
            _GoToToolStripMenuItem.Text = "Go To";
            // 
            // ContextRefresh
            // 
            _ContextRefresh.Name = "_ContextRefresh";
            _ContextRefresh.Size = new Size(144, 22);
            _ContextRefresh.Text = "Refresh";
            // 
            // RemoveHotkeyToolStripMenuItem
            // 
            _RemoveHotkeyToolStripMenuItem.Name = "_RemoveHotkeyToolStripMenuItem";
            _RemoveHotkeyToolStripMenuItem.Size = new Size(144, 22);
            _RemoveHotkeyToolStripMenuItem.Text = "Remove Bind";
            // 
            // RenameToolStripMenuItem
            // 
            _RenameToolStripMenuItem.Name = "_RenameToolStripMenuItem";
            _RenameToolStripMenuItem.Size = new Size(144, 22);
            _RenameToolStripMenuItem.Text = "Rename";
            // 
            // ContextHotKey
            // 
            _ContextHotKey.Name = "_ContextHotKey";
            _ContextHotKey.Size = new Size(144, 22);
            _ContextHotKey.Text = "Set Bind";
            // 
            // SetVolumeToolStripMenuItem
            // 
            _SetVolumeToolStripMenuItem.Name = "_SetVolumeToolStripMenuItem";
            _SetVolumeToolStripMenuItem.Size = new Size(144, 22);
            _SetVolumeToolStripMenuItem.Text = "Set Volume";
            // 
            // TrimToolStripMenuItem
            // 
            _TrimToolStripMenuItem.Name = "_TrimToolStripMenuItem";
            _TrimToolStripMenuItem.Size = new Size(144, 22);
            _TrimToolStripMenuItem.Text = "Trim";
            // 
            // LoadToolStripMenuItem
            // 
            _LoadToolStripMenuItem.Name = "_LoadToolStripMenuItem";
            _LoadToolStripMenuItem.Size = new Size(144, 22);
            _LoadToolStripMenuItem.Text = "Load";
            // 
            // PlayKeyButton
            // 
            _PlayKeyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _PlayKeyButton.Location = new Point(380, 297);
            _PlayKeyButton.Name = "_PlayKeyButton";
            _PlayKeyButton.Size = new Size(192, 23);
            _PlayKeyButton.TabIndex = 8;
            _PlayKeyButton.Text = "Play key: \"\"{0}\"\" (change)";
            _PlayKeyButton.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(177, 302);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(60, 13);
            StatusLabel.TabIndex = 9;
            StatusLabel.Text = "Status: Idle";
            // 
            // SystemTrayIcon
            // 
            _SystemTrayIcon.ContextMenuStrip = SystemTrayMenu;
            _SystemTrayIcon.Icon = (Icon)resources.GetObject("SystemTrayIcon.Icon");
            _SystemTrayIcon.Text = "SLAM";
            // 
            // SystemTrayMenu
            // 
            SystemTrayMenu.Items.AddRange(new ToolStripItem[] { _SystemTrayMenu_Open, _SystemTrayMenu_StartStop, ToolStripSeparator1, _SystemTrayMenu_Exit });
            SystemTrayMenu.Name = "SystemTrayMenu";
            SystemTrayMenu.Size = new Size(104, 76);
            // 
            // SystemTrayMenu_Open
            // 
            _SystemTrayMenu_Open.Name = "_SystemTrayMenu_Open";
            _SystemTrayMenu_Open.Size = new Size(103, 22);
            _SystemTrayMenu_Open.Text = "Open";
            // 
            // SystemTrayMenu_StartStop
            // 
            _SystemTrayMenu_StartStop.Name = "_SystemTrayMenu_StartStop";
            _SystemTrayMenu_StartStop.Size = new Size(103, 22);
            _SystemTrayMenu_StartStop.Text = "Start";
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(100, 6);
            // 
            // SystemTrayMenu_Exit
            // 
            _SystemTrayMenu_Exit.Name = "_SystemTrayMenu_Exit";
            _SystemTrayMenu_Exit.Size = new Size(103, 22);
            _SystemTrayMenu_Exit.Text = "Exit";
            // 
            // YTButton
            // 
            _YTButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _YTButton.Image = (Image)resources.GetObject("YTButton.Image");
            _YTButton.Location = new Point(68, 297);
            _YTButton.Name = "_YTButton";
            _YTButton.Size = new Size(22, 23);
            _YTButton.TabIndex = 10;
            _YTButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(_YTButton);
            Controls.Add(StatusLabel);
            Controls.Add(_PlayKeyButton);
            Controls.Add(_ChangeDirButton);
            Controls.Add(ProgressBar1);
            Controls.Add(_StartButton);
            Controls.Add(_TrackList);
            Controls.Add(_ImportButton);
            Controls.Add(Label1);
            Controls.Add(_GameSelector);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(500, 400);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Source Live Audio Mixer";
            TrackContextMenu.ResumeLayout(false);
            SystemTrayMenu.ResumeLayout(false);
            Load += new EventHandler(Form1_Load);
            FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            Resize += new EventHandler(Form1_Resize);
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox _GameSelector;

        internal ComboBox GameSelector
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GameSelector;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GameSelector != null)
                {
                    _GameSelector.SelectedIndexChanged -= GameSelector_SelectedIndexChanged;
                }

                _GameSelector = value;
                if (_GameSelector != null)
                {
                    _GameSelector.SelectedIndexChanged += GameSelector_SelectedIndexChanged;
                }
            }
        }

        internal Label Label1;
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

        private ListView _TrackList;

        internal ListView TrackList
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TrackList;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TrackList != null)
                {
                    _TrackList.MouseClick -= TrackList_MouseClick;
                    _TrackList.MouseDoubleClick -= TrackList_MouseDoubleClick;
                }

                _TrackList = value;
                if (_TrackList != null)
                {
                    _TrackList.MouseClick += TrackList_MouseClick;
                    _TrackList.MouseDoubleClick += TrackList_MouseDoubleClick;
                }
            }
        }

        internal ColumnHeader LoadedCol;
        internal ColumnHeader TrackCol;
        internal ColumnHeader TagsCol;
        private Button _StartButton;

        internal Button StartButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StartButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StartButton != null)
                {
                    _StartButton.Click -= StartButton_Click;
                }

                _StartButton = value;
                if (_StartButton != null)
                {
                    _StartButton.Click += StartButton_Click;
                }
            }
        }

        internal OpenFileDialog ImportDialog;
        internal ProgressBar ProgressBar1;
        private System.ComponentModel.BackgroundWorker _WavWorker;

        internal System.ComponentModel.BackgroundWorker WavWorker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _WavWorker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_WavWorker != null)
                {
                    _WavWorker.DoWork -= WavWorker_DoWork;
                    _WavWorker.ProgressChanged -= WavWorker_ProgressChanged;
                    _WavWorker.RunWorkerCompleted -= WavWorker_RunWorkerCompleted;
                }

                _WavWorker = value;
                if (_WavWorker != null)
                {
                    _WavWorker.DoWork += WavWorker_DoWork;
                    _WavWorker.ProgressChanged += WavWorker_ProgressChanged;
                    _WavWorker.RunWorkerCompleted += WavWorker_RunWorkerCompleted;
                }
            }
        }

        private System.ComponentModel.BackgroundWorker _PollRelayWorker;

        internal System.ComponentModel.BackgroundWorker PollRelayWorker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PollRelayWorker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PollRelayWorker != null)
                {
                    _PollRelayWorker.DoWork -= PollRelayWorker_DoWork;
                    _PollRelayWorker.ProgressChanged -= PollRelayWorker_ProgressChanged;
                    _PollRelayWorker.RunWorkerCompleted -= PollRelayWorker_RunWorkerCompleted;
                }

                _PollRelayWorker = value;
                if (_PollRelayWorker != null)
                {
                    _PollRelayWorker.DoWork += PollRelayWorker_DoWork;
                    _PollRelayWorker.ProgressChanged += PollRelayWorker_ProgressChanged;
                    _PollRelayWorker.RunWorkerCompleted += PollRelayWorker_RunWorkerCompleted;
                }
            }
        }

        private Button _ChangeDirButton;

        internal Button ChangeDirButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ChangeDirButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ChangeDirButton != null)
                {
                    _ChangeDirButton.Click -= ChangeDirButton_Click;
                }

                _ChangeDirButton = value;
                if (_ChangeDirButton != null)
                {
                    _ChangeDirButton.Click += ChangeDirButton_Click;
                }
            }
        }

        internal ContextMenuStrip TrackContextMenu;
        private ToolStripMenuItem _ContextDelete;

        internal ToolStripMenuItem ContextDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContextDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContextDelete != null)
                {
                    _ContextDelete.Click -= ContextDelete_Click;
                }

                _ContextDelete = value;
                if (_ContextDelete != null)
                {
                    _ContextDelete.Click += ContextDelete_Click;
                }
            }
        }

        private ToolStripMenuItem _ContextRefresh;

        internal ToolStripMenuItem ContextRefresh
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContextRefresh;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContextRefresh != null)
                {
                    _ContextRefresh.Click -= ContextRefresh_Click;
                }

                _ContextRefresh = value;
                if (_ContextRefresh != null)
                {
                    _ContextRefresh.Click += ContextRefresh_Click;
                }
            }
        }

        private ToolStripMenuItem _ContextHotKey;

        internal ToolStripMenuItem ContextHotKey
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContextHotKey;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContextHotKey != null)
                {
                    _ContextHotKey.Click -= ContextHotKey_Click;
                }

                _ContextHotKey = value;
                if (_ContextHotKey != null)
                {
                    _ContextHotKey.Click += ContextHotKey_Click;
                }
            }
        }

        internal ColumnHeader HotKeyCol;
        private ToolStripMenuItem _RemoveHotkeyToolStripMenuItem;

        internal ToolStripMenuItem RemoveHotkeyToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RemoveHotkeyToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RemoveHotkeyToolStripMenuItem != null)
                {
                    _RemoveHotkeyToolStripMenuItem.Click -= RemoveHotkeyToolStripMenuItem_Click;
                }

                _RemoveHotkeyToolStripMenuItem = value;
                if (_RemoveHotkeyToolStripMenuItem != null)
                {
                    _RemoveHotkeyToolStripMenuItem.Click += RemoveHotkeyToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _GoToToolStripMenuItem;

        internal ToolStripMenuItem GoToToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GoToToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GoToToolStripMenuItem != null)
                {
                    _GoToToolStripMenuItem.Click -= GoToToolStripMenuItem_Click;
                }

                _GoToToolStripMenuItem = value;
                if (_GoToToolStripMenuItem != null)
                {
                    _GoToToolStripMenuItem.Click += GoToToolStripMenuItem_Click;
                }
            }
        }

        private Button _PlayKeyButton;

        internal Button PlayKeyButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PlayKeyButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PlayKeyButton != null)
                {
                    _PlayKeyButton.Click -= PlayKeyButton_Click;
                }

                _PlayKeyButton = value;
                if (_PlayKeyButton != null)
                {
                    _PlayKeyButton.Click += PlayKeyButton_Click;
                }
            }
        }

        internal ColumnHeader VolumeCol;
        private ToolStripMenuItem _SetVolumeToolStripMenuItem;

        internal ToolStripMenuItem SetVolumeToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SetVolumeToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SetVolumeToolStripMenuItem != null)
                {
                    _SetVolumeToolStripMenuItem.Click -= SetVolumeToolStripMenuItem_Click;
                }

                _SetVolumeToolStripMenuItem = value;
                if (_SetVolumeToolStripMenuItem != null)
                {
                    _SetVolumeToolStripMenuItem.Click += SetVolumeToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _TrimToolStripMenuItem;

        internal ToolStripMenuItem TrimToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TrimToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TrimToolStripMenuItem != null)
                {
                    _TrimToolStripMenuItem.Click -= TrimToolStripMenuItem_Click;
                }

                _TrimToolStripMenuItem = value;
                if (_TrimToolStripMenuItem != null)
                {
                    _TrimToolStripMenuItem.Click += TrimToolStripMenuItem_Click;
                }
            }
        }

        internal ColumnHeader Trimmed;
        internal Label StatusLabel;
        private ToolStripMenuItem _RenameToolStripMenuItem;

        internal ToolStripMenuItem RenameToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RenameToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RenameToolStripMenuItem != null)
                {
                    _RenameToolStripMenuItem.Click -= RenameToolStripMenuItem_Click;
                }

                _RenameToolStripMenuItem = value;
                if (_RenameToolStripMenuItem != null)
                {
                    _RenameToolStripMenuItem.Click += RenameToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _LoadToolStripMenuItem;

        internal ToolStripMenuItem LoadToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LoadToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LoadToolStripMenuItem != null)
                {
                    _LoadToolStripMenuItem.Click -= LoadToolStripMenuItem_Click;
                }

                _LoadToolStripMenuItem = value;
                if (_LoadToolStripMenuItem != null)
                {
                    _LoadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
                }
            }
        }

        private NotifyIcon _SystemTrayIcon;

        internal NotifyIcon SystemTrayIcon
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SystemTrayIcon;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SystemTrayIcon != null)
                {
                    _SystemTrayIcon.DoubleClick -= SystemTrayIcon_DoubleClick;
                }

                _SystemTrayIcon = value;
                if (_SystemTrayIcon != null)
                {
                    _SystemTrayIcon.DoubleClick += SystemTrayIcon_DoubleClick;
                }
            }
        }

        internal ContextMenuStrip SystemTrayMenu;
        private ToolStripMenuItem _SystemTrayMenu_Open;

        internal ToolStripMenuItem SystemTrayMenu_Open
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SystemTrayMenu_Open;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SystemTrayMenu_Open != null)
                {
                    _SystemTrayMenu_Open.Click -= SystemTrayMenu_OpenHandler;
                }

                _SystemTrayMenu_Open = value;
                if (_SystemTrayMenu_Open != null)
                {
                    _SystemTrayMenu_Open.Click += SystemTrayMenu_OpenHandler;
                }
            }
        }

        private ToolStripMenuItem _SystemTrayMenu_StartStop;

        internal ToolStripMenuItem SystemTrayMenu_StartStop
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SystemTrayMenu_StartStop;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SystemTrayMenu_StartStop != null)
                {
                    _SystemTrayMenu_StartStop.Click -= SystemTrayMenu_StartStopHandler;
                }

                _SystemTrayMenu_StartStop = value;
                if (_SystemTrayMenu_StartStop != null)
                {
                    _SystemTrayMenu_StartStop.Click += SystemTrayMenu_StartStopHandler;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator1;
        private ToolStripMenuItem _SystemTrayMenu_Exit;

        internal ToolStripMenuItem SystemTrayMenu_Exit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SystemTrayMenu_Exit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SystemTrayMenu_Exit != null)
                {
                    _SystemTrayMenu_Exit.Click -= SystemTrayMenu_ExitHandler;
                }

                _SystemTrayMenu_Exit = value;
                if (_SystemTrayMenu_Exit != null)
                {
                    _SystemTrayMenu_Exit.Click += SystemTrayMenu_ExitHandler;
                }
            }
        }

        private Button _YTButton;

        internal Button YTButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _YTButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_YTButton != null)
                {
                    _YTButton.Click -= YTButton_Click;
                }

                _YTButton = value;
                if (_YTButton != null)
                {
                    _YTButton.Click += YTButton_Click;
                }
            }
        }
    }
}
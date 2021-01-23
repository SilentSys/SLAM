using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SLAM
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class SettingsForm : Form
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
            StatusStrip1 = new StatusStrip();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            VersionLabel = new ToolStripStatusLabel();
            _DonateLabel = new ToolStripStatusLabel();
            _DonateLabel.Click += new EventHandler(DonateLabel_Click);
            TabPage2 = new TabPage();
            NAudioRadio = new RadioButton();
            _FFMPEGRadio = new RadioButton();
            _FFMPEGRadio.CheckedChanged += new EventHandler(FFMPEGRadio_CheckedChanged);
            OverrideGroup = new GroupBox();
            Label2 = new Label();
            _FinduserdataButton = new Button();
            _FinduserdataButton.Click += new EventHandler(FinduserdataButton_Click);
            userdatatext = new TextBox();
            Label1 = new Label();
            _FindsteamappsButton = new Button();
            _FindsteamappsButton.Click += new EventHandler(FindsteamappsButton_Click);
            steamappstext = new TextBox();
            _EnableOverrideBox = new CheckBox();
            _EnableOverrideBox.CheckedChanged += new EventHandler(EnableOverrideBox_CheckedChanged);
            GroupBox3 = new GroupBox();
            _ChangeRelayButton = new Button();
            _ChangeRelayButton.Click += new EventHandler(ChangeRelayButton_Click);
            GroupBox2 = new GroupBox();
            _StartMinimizedCheckBox = new CheckBox();
            _StartMinimizedCheckBox.CheckedChanged += new EventHandler(StartMinimizedCheckBox_CheckedChanged);
            _MinimizeToSysTrayCheckBox = new CheckBox();
            _MinimizeToSysTrayCheckBox.CheckedChanged += new EventHandler(MinimizeToSysTrayCheckBox_CheckedChanged);
            _HoldToPlay = new CheckBox();
            _HoldToPlay.CheckedChanged += new EventHandler(HoldToPlay_CheckedChanged);
            _ConTagsCheckBox = new CheckBox();
            _ConTagsCheckBox.CheckedChanged += new EventHandler(ConTagsCheckBox_CheckedChanged);
            _StartEnabledCheckBox = new CheckBox();
            _StartEnabledCheckBox.CheckedChanged += new EventHandler(StartEnabledCheckBox_CheckedChanged);
            _LogCheckBox = new CheckBox();
            _LogCheckBox.CheckedChanged += new EventHandler(LogCheckBox_CheckedChanged);
            _HintCheckBox = new CheckBox();
            _HintCheckBox.CheckedChanged += new EventHandler(HintCheckBox_CheckedChanged);
            _UpdateCheckBox = new CheckBox();
            _UpdateCheckBox.CheckedChanged += new EventHandler(UpdateCheckBox_CheckedChanged);
            TabControl1 = new TabControl();
            TabPage1 = new TabPage();
            StatusStrip1.SuspendLayout();
            TabPage2.SuspendLayout();
            OverrideGroup.SuspendLayout();
            GroupBox3.SuspendLayout();
            GroupBox2.SuspendLayout();
            TabControl1.SuspendLayout();
            TabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // StatusStrip1
            // 
            StatusStrip1.ImageScalingSize = new Size(24, 24);
            StatusStrip1.Items.AddRange(new ToolStripItem[] { ToolStripStatusLabel1, VersionLabel, _DonateLabel });
            StatusStrip1.Location = new Point(0, 309);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Size = new Size(284, 22);
            StatusStrip1.SizingGrip = false;
            StatusStrip1.TabIndex = 1;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(49, 17);
            ToolStripStatusLabel1.Text = "Version:";
            // 
            // VersionLabel
            // 
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(31, 17);
            VersionLabel.Text = "0.0.0";
            // 
            // DonateLabel
            // 
            _DonateLabel.IsLink = true;
            _DonateLabel.Name = "_DonateLabel";
            _DonateLabel.Size = new Size(199, 17);
            _DonateLabel.Text = "Want to support SLAM by donating?";
            // 
            // TabPage2
            // 
            TabPage2.Controls.Add(NAudioRadio);
            TabPage2.Controls.Add(_FFMPEGRadio);
            TabPage2.Controls.Add(OverrideGroup);
            TabPage2.Controls.Add(GroupBox3);
            TabPage2.Location = new Point(4, 22);
            TabPage2.Name = "TabPage2";
            TabPage2.Padding = new Padding(3);
            TabPage2.Size = new Size(276, 305);
            TabPage2.TabIndex = 0;
            TabPage2.Text = "Advanced";
            TabPage2.UseVisualStyleBackColor = true;
            // 
            // NAudioRadio
            // 
            NAudioRadio.AutoSize = true;
            NAudioRadio.Location = new Point(125, 166);
            NAudioRadio.Name = "NAudioRadio";
            NAudioRadio.Size = new Size(126, 17);
            NAudioRadio.TabIndex = 5;
            NAudioRadio.TabStop = true;
            NAudioRadio.Text = "Use NAudio (Legacy)";
            NAudioRadio.UseVisualStyleBackColor = true;
            // 
            // FFMPEGRadio
            // 
            _FFMPEGRadio.AutoSize = true;
            _FFMPEGRadio.Location = new Point(29, 166);
            _FFMPEGRadio.Name = "_FFMPEGRadio";
            _FFMPEGRadio.Size = new Size(90, 17);
            _FFMPEGRadio.TabIndex = 4;
            _FFMPEGRadio.TabStop = true;
            _FFMPEGRadio.Text = "Use FFMPEG";
            _FFMPEGRadio.UseVisualStyleBackColor = true;
            // 
            // OverrideGroup
            // 
            OverrideGroup.Controls.Add(Label2);
            OverrideGroup.Controls.Add(_FinduserdataButton);
            OverrideGroup.Controls.Add(userdatatext);
            OverrideGroup.Controls.Add(Label1);
            OverrideGroup.Controls.Add(_FindsteamappsButton);
            OverrideGroup.Controls.Add(steamappstext);
            OverrideGroup.Controls.Add(_EnableOverrideBox);
            OverrideGroup.Location = new Point(8, 64);
            OverrideGroup.Name = "OverrideGroup";
            OverrideGroup.Size = new Size(260, 96);
            OverrideGroup.TabIndex = 3;
            OverrideGroup.TabStop = false;
            OverrideGroup.Text = "Override folder detection";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Enabled = false;
            Label2.Location = new Point(6, 71);
            Label2.Name = "Label2";
            Label2.Size = new Size(51, 13);
            Label2.TabIndex = 6;
            Label2.Text = "userdata:";
            // 
            // FinduserdataButton
            // 
            _FinduserdataButton.Enabled = false;
            _FinduserdataButton.Location = new Point(230, 66);
            _FinduserdataButton.Name = "_FinduserdataButton";
            _FinduserdataButton.Size = new Size(24, 23);
            _FinduserdataButton.TabIndex = 5;
            _FinduserdataButton.Text = "...";
            _FinduserdataButton.UseVisualStyleBackColor = true;
            // 
            // userdatatext
            // 
            userdatatext.Enabled = false;
            userdatatext.Location = new Point(73, 68);
            userdatatext.Name = "userdatatext";
            userdatatext.ReadOnly = true;
            userdatatext.Size = new Size(151, 20);
            userdatatext.TabIndex = 4;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Enabled = false;
            Label1.Location = new Point(6, 45);
            Label1.Name = "Label1";
            Label1.Size = new Size(61, 13);
            Label1.TabIndex = 3;
            Label1.Text = "steamapps:";
            // 
            // FindsteamappsButton
            // 
            _FindsteamappsButton.Enabled = false;
            _FindsteamappsButton.Location = new Point(230, 40);
            _FindsteamappsButton.Name = "_FindsteamappsButton";
            _FindsteamappsButton.Size = new Size(24, 23);
            _FindsteamappsButton.TabIndex = 2;
            _FindsteamappsButton.Text = "...";
            _FindsteamappsButton.UseVisualStyleBackColor = true;
            // 
            // steamappstext
            // 
            steamappstext.Enabled = false;
            steamappstext.Location = new Point(73, 42);
            steamappstext.Name = "steamappstext";
            steamappstext.ReadOnly = true;
            steamappstext.Size = new Size(151, 20);
            steamappstext.TabIndex = 1;
            // 
            // EnableOverrideBox
            // 
            _EnableOverrideBox.AutoSize = true;
            _EnableOverrideBox.Location = new Point(6, 19);
            _EnableOverrideBox.Name = "_EnableOverrideBox";
            _EnableOverrideBox.Size = new Size(59, 17);
            _EnableOverrideBox.TabIndex = 0;
            _EnableOverrideBox.Text = "Enable";
            _EnableOverrideBox.UseVisualStyleBackColor = true;
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(_ChangeRelayButton);
            GroupBox3.Location = new Point(8, 6);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Size = new Size(260, 52);
            GroupBox3.TabIndex = 2;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "Relay Key";
            // 
            // ChangeRelayButton
            // 
            _ChangeRelayButton.Location = new Point(6, 19);
            _ChangeRelayButton.Name = "_ChangeRelayButton";
            _ChangeRelayButton.Size = new Size(248, 23);
            _ChangeRelayButton.TabIndex = 0;
            _ChangeRelayButton.Text = "Relay key: \"\"{0}\"\" (change)";
            _ChangeRelayButton.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(_StartMinimizedCheckBox);
            GroupBox2.Controls.Add(_MinimizeToSysTrayCheckBox);
            GroupBox2.Controls.Add(_HoldToPlay);
            GroupBox2.Controls.Add(_ConTagsCheckBox);
            GroupBox2.Controls.Add(_StartEnabledCheckBox);
            GroupBox2.Controls.Add(_LogCheckBox);
            GroupBox2.Controls.Add(_HintCheckBox);
            GroupBox2.Controls.Add(_UpdateCheckBox);
            GroupBox2.Location = new Point(8, 6);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(260, 217);
            GroupBox2.TabIndex = 2;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Other";
            // 
            // StartMinimizedCheckBox
            // 
            _StartMinimizedCheckBox.AutoSize = true;
            _StartMinimizedCheckBox.Location = new Point(6, 180);
            _StartMinimizedCheckBox.Name = "_StartMinimizedCheckBox";
            _StartMinimizedCheckBox.Size = new Size(96, 17);
            _StartMinimizedCheckBox.TabIndex = 13;
            _StartMinimizedCheckBox.Text = "Start minimized";
            _StartMinimizedCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinimizeToSysTrayCheckBox
            // 
            _MinimizeToSysTrayCheckBox.AutoSize = true;
            _MinimizeToSysTrayCheckBox.Location = new Point(6, 157);
            _MinimizeToSysTrayCheckBox.Name = "_MinimizeToSysTrayCheckBox";
            _MinimizeToSysTrayCheckBox.Size = new Size(133, 17);
            _MinimizeToSysTrayCheckBox.TabIndex = 12;
            _MinimizeToSysTrayCheckBox.Text = "Minimize to system tray";
            _MinimizeToSysTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // HoldToPlay
            // 
            _HoldToPlay.AutoSize = true;
            _HoldToPlay.Location = new Point(6, 134);
            _HoldToPlay.Name = "_HoldToPlay";
            _HoldToPlay.Size = new Size(82, 17);
            _HoldToPlay.TabIndex = 11;
            _HoldToPlay.Text = "Hold to play";
            _HoldToPlay.UseVisualStyleBackColor = true;
            // 
            // ConTagsCheckBox
            // 
            _ConTagsCheckBox.AutoSize = true;
            _ConTagsCheckBox.Location = new Point(6, 111);
            _ConTagsCheckBox.Name = "_ConTagsCheckBox";
            _ConTagsCheckBox.Size = new Size(101, 17);
            _ConTagsCheckBox.TabIndex = 5;
            _ConTagsCheckBox.Text = "Tags in console";
            _ConTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartEnabledCheckBox
            // 
            _StartEnabledCheckBox.AutoSize = true;
            _StartEnabledCheckBox.Location = new Point(6, 88);
            _StartEnabledCheckBox.Name = "_StartEnabledCheckBox";
            _StartEnabledCheckBox.Size = new Size(89, 17);
            _StartEnabledCheckBox.TabIndex = 4;
            _StartEnabledCheckBox.Text = "Start enabled";
            _StartEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // LogCheckBox
            // 
            _LogCheckBox.AutoSize = true;
            _LogCheckBox.Location = new Point(6, 65);
            _LogCheckBox.Name = "_LogCheckBox";
            _LogCheckBox.Size = new Size(73, 17);
            _LogCheckBox.TabIndex = 2;
            _LogCheckBox.Text = "Log errors";
            _LogCheckBox.UseVisualStyleBackColor = true;
            // 
            // HintCheckBox
            // 
            _HintCheckBox.AutoSize = true;
            _HintCheckBox.Location = new Point(6, 42);
            _HintCheckBox.Name = "_HintCheckBox";
            _HintCheckBox.Size = new Size(65, 17);
            _HintCheckBox.TabIndex = 3;
            _HintCheckBox.Text = "No hints";
            _HintCheckBox.UseVisualStyleBackColor = true;
            // 
            // UpdateCheckBox
            // 
            _UpdateCheckBox.AutoSize = true;
            _UpdateCheckBox.Location = new Point(6, 19);
            _UpdateCheckBox.Name = "_UpdateCheckBox";
            _UpdateCheckBox.Size = new Size(113, 17);
            _UpdateCheckBox.TabIndex = 2;
            _UpdateCheckBox.Text = "Check for updates";
            _UpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // TabControl1
            // 
            TabControl1.Controls.Add(TabPage1);
            TabControl1.Controls.Add(TabPage2);
            TabControl1.Dock = DockStyle.Fill;
            TabControl1.Location = new Point(0, 0);
            TabControl1.Name = "TabControl1";
            TabControl1.SelectedIndex = 0;
            TabControl1.Size = new Size(284, 331);
            TabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            TabPage1.Controls.Add(GroupBox2);
            TabPage1.Location = new Point(4, 22);
            TabPage1.Name = "TabPage1";
            TabPage1.Padding = new Padding(3);
            TabPage1.Size = new Size(276, 305);
            TabPage1.TabIndex = 1;
            TabPage1.Text = "Misc.";
            TabPage1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 331);
            Controls.Add(StatusStrip1);
            Controls.Add(TabControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            TabPage2.ResumeLayout(false);
            TabPage2.PerformLayout();
            OverrideGroup.ResumeLayout(false);
            OverrideGroup.PerformLayout();
            GroupBox3.ResumeLayout(false);
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            TabControl1.ResumeLayout(false);
            TabPage1.ResumeLayout(false);
            Load += new EventHandler(SettingsForm_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal ToolStripStatusLabel VersionLabel;
        internal TabPage TabPage2;
        internal GroupBox GroupBox2;
        private CheckBox _StartEnabledCheckBox;

        internal CheckBox StartEnabledCheckBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StartEnabledCheckBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StartEnabledCheckBox != null)
                {
                    _StartEnabledCheckBox.CheckedChanged -= StartEnabledCheckBox_CheckedChanged;
                }

                _StartEnabledCheckBox = value;
                if (_StartEnabledCheckBox != null)
                {
                    _StartEnabledCheckBox.CheckedChanged += StartEnabledCheckBox_CheckedChanged;
                }
            }
        }

        private CheckBox _LogCheckBox;

        internal CheckBox LogCheckBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LogCheckBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LogCheckBox != null)
                {
                    _LogCheckBox.CheckedChanged -= LogCheckBox_CheckedChanged;
                }

                _LogCheckBox = value;
                if (_LogCheckBox != null)
                {
                    _LogCheckBox.CheckedChanged += LogCheckBox_CheckedChanged;
                }
            }
        }

        private CheckBox _HintCheckBox;

        internal CheckBox HintCheckBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HintCheckBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HintCheckBox != null)
                {
                    _HintCheckBox.CheckedChanged -= HintCheckBox_CheckedChanged;
                }

                _HintCheckBox = value;
                if (_HintCheckBox != null)
                {
                    _HintCheckBox.CheckedChanged += HintCheckBox_CheckedChanged;
                }
            }
        }

        private CheckBox _UpdateCheckBox;

        internal CheckBox UpdateCheckBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UpdateCheckBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UpdateCheckBox != null)
                {
                    _UpdateCheckBox.CheckedChanged -= UpdateCheckBox_CheckedChanged;
                }

                _UpdateCheckBox = value;
                if (_UpdateCheckBox != null)
                {
                    _UpdateCheckBox.CheckedChanged += UpdateCheckBox_CheckedChanged;
                }
            }
        }

        internal TabControl TabControl1;
        private CheckBox _ConTagsCheckBox;

        internal CheckBox ConTagsCheckBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ConTagsCheckBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ConTagsCheckBox != null)
                {
                    _ConTagsCheckBox.CheckedChanged -= ConTagsCheckBox_CheckedChanged;
                }

                _ConTagsCheckBox = value;
                if (_ConTagsCheckBox != null)
                {
                    _ConTagsCheckBox.CheckedChanged += ConTagsCheckBox_CheckedChanged;
                }
            }
        }

        internal GroupBox GroupBox3;
        private Button _ChangeRelayButton;

        internal Button ChangeRelayButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ChangeRelayButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ChangeRelayButton != null)
                {
                    _ChangeRelayButton.Click -= ChangeRelayButton_Click;
                }

                _ChangeRelayButton = value;
                if (_ChangeRelayButton != null)
                {
                    _ChangeRelayButton.Click += ChangeRelayButton_Click;
                }
            }
        }

        internal TabPage TabPage1;
        private CheckBox _HoldToPlay;

        internal CheckBox HoldToPlay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HoldToPlay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HoldToPlay != null)
                {
                    _HoldToPlay.CheckedChanged -= HoldToPlay_CheckedChanged;
                }

                _HoldToPlay = value;
                if (_HoldToPlay != null)
                {
                    _HoldToPlay.CheckedChanged += HoldToPlay_CheckedChanged;
                }
            }
        }

        internal GroupBox OverrideGroup;
        private Button _FindsteamappsButton;

        internal Button FindsteamappsButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FindsteamappsButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FindsteamappsButton != null)
                {
                    _FindsteamappsButton.Click -= FindsteamappsButton_Click;
                }

                _FindsteamappsButton = value;
                if (_FindsteamappsButton != null)
                {
                    _FindsteamappsButton.Click += FindsteamappsButton_Click;
                }
            }
        }

        internal TextBox steamappstext;
        private CheckBox _EnableOverrideBox;

        internal CheckBox EnableOverrideBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _EnableOverrideBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_EnableOverrideBox != null)
                {
                    _EnableOverrideBox.CheckedChanged -= EnableOverrideBox_CheckedChanged;
                }

                _EnableOverrideBox = value;
                if (_EnableOverrideBox != null)
                {
                    _EnableOverrideBox.CheckedChanged += EnableOverrideBox_CheckedChanged;
                }
            }
        }

        internal Label Label1;
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

        internal Label Label2;
        private Button _FinduserdataButton;

        internal Button FinduserdataButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FinduserdataButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FinduserdataButton != null)
                {
                    _FinduserdataButton.Click -= FinduserdataButton_Click;
                }

                _FinduserdataButton = value;
                if (_FinduserdataButton != null)
                {
                    _FinduserdataButton.Click += FinduserdataButton_Click;
                }
            }
        }

        internal TextBox userdatatext;
        private CheckBox _MinimizeToSysTrayCheckBox;

        internal CheckBox MinimizeToSysTrayCheckBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MinimizeToSysTrayCheckBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MinimizeToSysTrayCheckBox != null)
                {
                    _MinimizeToSysTrayCheckBox.CheckedChanged -= MinimizeToSysTrayCheckBox_CheckedChanged;
                }

                _MinimizeToSysTrayCheckBox = value;
                if (_MinimizeToSysTrayCheckBox != null)
                {
                    _MinimizeToSysTrayCheckBox.CheckedChanged += MinimizeToSysTrayCheckBox_CheckedChanged;
                }
            }
        }

        private CheckBox _StartMinimizedCheckBox;

        internal CheckBox StartMinimizedCheckBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StartMinimizedCheckBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StartMinimizedCheckBox != null)
                {
                    _StartMinimizedCheckBox.CheckedChanged -= StartMinimizedCheckBox_CheckedChanged;
                }

                _StartMinimizedCheckBox = value;
                if (_StartMinimizedCheckBox != null)
                {
                    _StartMinimizedCheckBox.CheckedChanged += StartMinimizedCheckBox_CheckedChanged;
                }
            }
        }

        internal RadioButton NAudioRadio;
        private RadioButton _FFMPEGRadio;

        internal RadioButton FFMPEGRadio
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FFMPEGRadio;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FFMPEGRadio != null)
                {
                    _FFMPEGRadio.CheckedChanged -= FFMPEGRadio_CheckedChanged;
                }

                _FFMPEGRadio = value;
                if (_FFMPEGRadio != null)
                {
                    _FFMPEGRadio.CheckedChanged += FFMPEGRadio_CheckedChanged;
                }
            }
        }
    }
}
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
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.VersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.NAudioRadio = new System.Windows.Forms.RadioButton();
            this._FFMPEGRadio = new System.Windows.Forms.RadioButton();
            this.OverrideGroup = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this._FinduserdataButton = new System.Windows.Forms.Button();
            this.userdatatext = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this._FindsteamappsButton = new System.Windows.Forms.Button();
            this.steamappstext = new System.Windows.Forms.TextBox();
            this._EnableOverrideBox = new System.Windows.Forms.CheckBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this._ChangeRelayButton = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this._StartMinimizedCheckBox = new System.Windows.Forms.CheckBox();
            this._MinimizeToSysTrayCheckBox = new System.Windows.Forms.CheckBox();
            this._HoldToPlay = new System.Windows.Forms.CheckBox();
            this._ConTagsCheckBox = new System.Windows.Forms.CheckBox();
            this._StartEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this._LogCheckBox = new System.Windows.Forms.CheckBox();
            this._HintCheckBox = new System.Windows.Forms.CheckBox();
            this._UpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.StatusStrip1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.OverrideGroup.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.VersionLabel});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 309);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(284, 22);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 1;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.ToolStripStatusLabel1.Text = "Version:";
            // 
            // VersionLabel
            // 
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(31, 17);
            this.VersionLabel.Text = "0.0.0";
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.NAudioRadio);
            this.TabPage2.Controls.Add(this._FFMPEGRadio);
            this.TabPage2.Controls.Add(this.OverrideGroup);
            this.TabPage2.Controls.Add(this.GroupBox3);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(276, 305);
            this.TabPage2.TabIndex = 0;
            this.TabPage2.Text = "Advanced";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // NAudioRadio
            // 
            this.NAudioRadio.AutoSize = true;
            this.NAudioRadio.Location = new System.Drawing.Point(125, 166);
            this.NAudioRadio.Name = "NAudioRadio";
            this.NAudioRadio.Size = new System.Drawing.Size(126, 17);
            this.NAudioRadio.TabIndex = 5;
            this.NAudioRadio.TabStop = true;
            this.NAudioRadio.Text = "Use NAudio (Legacy)";
            this.NAudioRadio.UseVisualStyleBackColor = true;
            // 
            // _FFMPEGRadio
            // 
            this._FFMPEGRadio.AutoSize = true;
            this._FFMPEGRadio.Location = new System.Drawing.Point(29, 166);
            this._FFMPEGRadio.Name = "_FFMPEGRadio";
            this._FFMPEGRadio.Size = new System.Drawing.Size(90, 17);
            this._FFMPEGRadio.TabIndex = 4;
            this._FFMPEGRadio.TabStop = true;
            this._FFMPEGRadio.Text = "Use FFMPEG";
            this._FFMPEGRadio.UseVisualStyleBackColor = true;
            this._FFMPEGRadio.CheckedChanged += new System.EventHandler(this.FFMPEGRadio_CheckedChanged);
            // 
            // OverrideGroup
            // 
            this.OverrideGroup.Controls.Add(this.Label2);
            this.OverrideGroup.Controls.Add(this._FinduserdataButton);
            this.OverrideGroup.Controls.Add(this.userdatatext);
            this.OverrideGroup.Controls.Add(this.Label1);
            this.OverrideGroup.Controls.Add(this._FindsteamappsButton);
            this.OverrideGroup.Controls.Add(this.steamappstext);
            this.OverrideGroup.Controls.Add(this._EnableOverrideBox);
            this.OverrideGroup.Location = new System.Drawing.Point(8, 64);
            this.OverrideGroup.Name = "OverrideGroup";
            this.OverrideGroup.Size = new System.Drawing.Size(260, 96);
            this.OverrideGroup.TabIndex = 3;
            this.OverrideGroup.TabStop = false;
            this.OverrideGroup.Text = "Override folder detection";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Enabled = false;
            this.Label2.Location = new System.Drawing.Point(6, 71);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(51, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "userdata:";
            // 
            // _FinduserdataButton
            // 
            this._FinduserdataButton.Enabled = false;
            this._FinduserdataButton.Location = new System.Drawing.Point(230, 66);
            this._FinduserdataButton.Name = "_FinduserdataButton";
            this._FinduserdataButton.Size = new System.Drawing.Size(24, 23);
            this._FinduserdataButton.TabIndex = 5;
            this._FinduserdataButton.Text = "...";
            this._FinduserdataButton.UseVisualStyleBackColor = true;
            this._FinduserdataButton.Click += new System.EventHandler(this.FinduserdataButton_Click);
            // 
            // userdatatext
            // 
            this.userdatatext.Enabled = false;
            this.userdatatext.Location = new System.Drawing.Point(73, 68);
            this.userdatatext.Name = "userdatatext";
            this.userdatatext.ReadOnly = true;
            this.userdatatext.Size = new System.Drawing.Size(151, 20);
            this.userdatatext.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Enabled = false;
            this.Label1.Location = new System.Drawing.Point(6, 45);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "steamapps:";
            // 
            // _FindsteamappsButton
            // 
            this._FindsteamappsButton.Enabled = false;
            this._FindsteamappsButton.Location = new System.Drawing.Point(230, 40);
            this._FindsteamappsButton.Name = "_FindsteamappsButton";
            this._FindsteamappsButton.Size = new System.Drawing.Size(24, 23);
            this._FindsteamappsButton.TabIndex = 2;
            this._FindsteamappsButton.Text = "...";
            this._FindsteamappsButton.UseVisualStyleBackColor = true;
            this._FindsteamappsButton.Click += new System.EventHandler(this.FindsteamappsButton_Click);
            // 
            // steamappstext
            // 
            this.steamappstext.Enabled = false;
            this.steamappstext.Location = new System.Drawing.Point(73, 42);
            this.steamappstext.Name = "steamappstext";
            this.steamappstext.ReadOnly = true;
            this.steamappstext.Size = new System.Drawing.Size(151, 20);
            this.steamappstext.TabIndex = 1;
            // 
            // _EnableOverrideBox
            // 
            this._EnableOverrideBox.AutoSize = true;
            this._EnableOverrideBox.Location = new System.Drawing.Point(6, 19);
            this._EnableOverrideBox.Name = "_EnableOverrideBox";
            this._EnableOverrideBox.Size = new System.Drawing.Size(59, 17);
            this._EnableOverrideBox.TabIndex = 0;
            this._EnableOverrideBox.Text = "Enable";
            this._EnableOverrideBox.UseVisualStyleBackColor = true;
            this._EnableOverrideBox.CheckedChanged += new System.EventHandler(this.EnableOverrideBox_CheckedChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this._ChangeRelayButton);
            this.GroupBox3.Location = new System.Drawing.Point(8, 6);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(260, 52);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Relay Key";
            // 
            // _ChangeRelayButton
            // 
            this._ChangeRelayButton.Location = new System.Drawing.Point(6, 19);
            this._ChangeRelayButton.Name = "_ChangeRelayButton";
            this._ChangeRelayButton.Size = new System.Drawing.Size(248, 23);
            this._ChangeRelayButton.TabIndex = 0;
            this._ChangeRelayButton.Text = "Relay key: \"\"{0}\"\" (change)";
            this._ChangeRelayButton.UseVisualStyleBackColor = true;
            this._ChangeRelayButton.Click += new System.EventHandler(this.ChangeRelayButton_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this._StartMinimizedCheckBox);
            this.GroupBox2.Controls.Add(this._MinimizeToSysTrayCheckBox);
            this.GroupBox2.Controls.Add(this._HoldToPlay);
            this.GroupBox2.Controls.Add(this._ConTagsCheckBox);
            this.GroupBox2.Controls.Add(this._StartEnabledCheckBox);
            this.GroupBox2.Controls.Add(this._LogCheckBox);
            this.GroupBox2.Controls.Add(this._HintCheckBox);
            this.GroupBox2.Controls.Add(this._UpdateCheckBox);
            this.GroupBox2.Location = new System.Drawing.Point(8, 6);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(260, 217);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Other";
            // 
            // _StartMinimizedCheckBox
            // 
            this._StartMinimizedCheckBox.AutoSize = true;
            this._StartMinimizedCheckBox.Location = new System.Drawing.Point(6, 180);
            this._StartMinimizedCheckBox.Name = "_StartMinimizedCheckBox";
            this._StartMinimizedCheckBox.Size = new System.Drawing.Size(96, 17);
            this._StartMinimizedCheckBox.TabIndex = 13;
            this._StartMinimizedCheckBox.Text = "Start minimized";
            this._StartMinimizedCheckBox.UseVisualStyleBackColor = true;
            this._StartMinimizedCheckBox.CheckedChanged += new System.EventHandler(this.StartMinimizedCheckBox_CheckedChanged);
            // 
            // _MinimizeToSysTrayCheckBox
            // 
            this._MinimizeToSysTrayCheckBox.AutoSize = true;
            this._MinimizeToSysTrayCheckBox.Location = new System.Drawing.Point(6, 157);
            this._MinimizeToSysTrayCheckBox.Name = "_MinimizeToSysTrayCheckBox";
            this._MinimizeToSysTrayCheckBox.Size = new System.Drawing.Size(133, 17);
            this._MinimizeToSysTrayCheckBox.TabIndex = 12;
            this._MinimizeToSysTrayCheckBox.Text = "Minimize to system tray";
            this._MinimizeToSysTrayCheckBox.UseVisualStyleBackColor = true;
            this._MinimizeToSysTrayCheckBox.CheckedChanged += new System.EventHandler(this.MinimizeToSysTrayCheckBox_CheckedChanged);
            // 
            // _HoldToPlay
            // 
            this._HoldToPlay.AutoSize = true;
            this._HoldToPlay.Location = new System.Drawing.Point(6, 134);
            this._HoldToPlay.Name = "_HoldToPlay";
            this._HoldToPlay.Size = new System.Drawing.Size(82, 17);
            this._HoldToPlay.TabIndex = 11;
            this._HoldToPlay.Text = "Hold to play";
            this._HoldToPlay.UseVisualStyleBackColor = true;
            this._HoldToPlay.CheckedChanged += new System.EventHandler(this.HoldToPlay_CheckedChanged);
            // 
            // _ConTagsCheckBox
            // 
            this._ConTagsCheckBox.AutoSize = true;
            this._ConTagsCheckBox.Location = new System.Drawing.Point(6, 111);
            this._ConTagsCheckBox.Name = "_ConTagsCheckBox";
            this._ConTagsCheckBox.Size = new System.Drawing.Size(101, 17);
            this._ConTagsCheckBox.TabIndex = 5;
            this._ConTagsCheckBox.Text = "Tags in console";
            this._ConTagsCheckBox.UseVisualStyleBackColor = true;
            this._ConTagsCheckBox.CheckedChanged += new System.EventHandler(this.ConTagsCheckBox_CheckedChanged);
            // 
            // _StartEnabledCheckBox
            // 
            this._StartEnabledCheckBox.AutoSize = true;
            this._StartEnabledCheckBox.Location = new System.Drawing.Point(6, 88);
            this._StartEnabledCheckBox.Name = "_StartEnabledCheckBox";
            this._StartEnabledCheckBox.Size = new System.Drawing.Size(89, 17);
            this._StartEnabledCheckBox.TabIndex = 4;
            this._StartEnabledCheckBox.Text = "Start enabled";
            this._StartEnabledCheckBox.UseVisualStyleBackColor = true;
            this._StartEnabledCheckBox.CheckedChanged += new System.EventHandler(this.StartEnabledCheckBox_CheckedChanged);
            // 
            // _LogCheckBox
            // 
            this._LogCheckBox.AutoSize = true;
            this._LogCheckBox.Location = new System.Drawing.Point(6, 65);
            this._LogCheckBox.Name = "_LogCheckBox";
            this._LogCheckBox.Size = new System.Drawing.Size(73, 17);
            this._LogCheckBox.TabIndex = 2;
            this._LogCheckBox.Text = "Log errors";
            this._LogCheckBox.UseVisualStyleBackColor = true;
            this._LogCheckBox.CheckedChanged += new System.EventHandler(this.LogCheckBox_CheckedChanged);
            // 
            // _HintCheckBox
            // 
            this._HintCheckBox.AutoSize = true;
            this._HintCheckBox.Location = new System.Drawing.Point(6, 42);
            this._HintCheckBox.Name = "_HintCheckBox";
            this._HintCheckBox.Size = new System.Drawing.Size(65, 17);
            this._HintCheckBox.TabIndex = 3;
            this._HintCheckBox.Text = "No hints";
            this._HintCheckBox.UseVisualStyleBackColor = true;
            this._HintCheckBox.CheckedChanged += new System.EventHandler(this.HintCheckBox_CheckedChanged);
            // 
            // _UpdateCheckBox
            // 
            this._UpdateCheckBox.AutoSize = true;
            this._UpdateCheckBox.Location = new System.Drawing.Point(6, 19);
            this._UpdateCheckBox.Name = "_UpdateCheckBox";
            this._UpdateCheckBox.Size = new System.Drawing.Size(113, 17);
            this._UpdateCheckBox.TabIndex = 2;
            this._UpdateCheckBox.Text = "Check for updates";
            this._UpdateCheckBox.UseVisualStyleBackColor = true;
            this._UpdateCheckBox.CheckedChanged += new System.EventHandler(this.UpdateCheckBox_CheckedChanged);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(284, 331);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(276, 305);
            this.TabPage1.TabIndex = 1;
            this.TabPage1.Text = "Misc.";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.OverrideGroup.ResumeLayout(false);
            this.OverrideGroup.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
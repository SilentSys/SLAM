using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SLAM
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class SelectKey : Form
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
            _SelectButton = new Button();
            _SelectButton.Click += new EventHandler(SelectButton_Click);
            Label1 = new Label();
            _BindKeyBox = new ComboBox();
            _BindKeyBox.TextChanged += new EventHandler(BindKeyBox_TextChanged);
            SuspendLayout();
            // 
            // SelectButton
            // 
            _SelectButton.Location = new Point(12, 33);
            _SelectButton.Name = "_SelectButton";
            _SelectButton.Size = new Size(185, 23);
            _SelectButton.TabIndex = 1;
            _SelectButton.Text = "Done";
            _SelectButton.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(12, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(69, 13);
            Label1.TabIndex = 2;
            Label1.Text = "Select a key:";
            // 
            // BindKeyBox
            // 
            _BindKeyBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            _BindKeyBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            _BindKeyBox.Cursor = Cursors.Default;
            _BindKeyBox.FormattingEnabled = true;
            _BindKeyBox.Items.AddRange(new object[] { "'", "-", ",", ".", "/", "[", @"\", "]", "`", "=", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "ALT", "B", "BACKSPACE", "C", "CAPSLOCK", "CTRL", "D", "DEL", "DOWNARROW", "E", "END", "ENTER", "ESCAPE", "F", "F1", "F10", "F11", "F12", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "G", "H", "HOME", "I", "INS", "J", "K", "KP_5", "KP_DEL", "KP_DOWNARROW", "KP_END", "KP_ENTER", "KP_HOME", "KP_INS", "KP_LEFTARROW", "KP_MINUS", "KP_MULTIPLY", "KP_PGDN", "KP_PGUP", "KP_PLUS", "KP_RIGHTARROW", "KP_SLASH", "KP_UPARROW", "L", "LEFTARROW", "LWIN", "M", "MOUSE1", "MOUSE2", "MOUSE3", "MOUSE4", "MOUSE5", "MWHEELDOWN", "MWHEELUP", "N", "NUMLOCK", "O", "P", "PGDN", "PGUP", "Q", "R", "RCTRL", "RIGHTARROW", "RSHIFT", "RWIN", "S", "SCROLLOCK", "SEMICOLON", "SHIFT", "SPACE", "T", "TAB", "U", "UPARROW", "V", "W", "X", "Y", "Z" });
            _BindKeyBox.Location = new Point(84, 6);
            _BindKeyBox.Name = "_BindKeyBox";
            _BindKeyBox.Size = new Size(113, 21);
            _BindKeyBox.TabIndex = 0;
            // 
            // SelectKey
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(209, 64);
            Controls.Add(Label1);
            Controls.Add(_SelectButton);
            Controls.Add(_BindKeyBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectKey";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Key Selector";
            Load += new EventHandler(SelectKey_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button _SelectButton;

        internal Button SelectButton
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SelectButton;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SelectButton != null)
                {
                    _SelectButton.Click -= SelectButton_Click;
                }

                _SelectButton = value;
                if (_SelectButton != null)
                {
                    _SelectButton.Click += SelectButton_Click;
                }
            }
        }

        internal Label Label1;
        private ComboBox _BindKeyBox;

        internal ComboBox BindKeyBox
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BindKeyBox;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BindKeyBox != null)
                {
                    _BindKeyBox.TextChanged -= BindKeyBox_TextChanged;
                }

                _BindKeyBox = value;
                if (_BindKeyBox != null)
                {
                    _BindKeyBox.TextChanged += BindKeyBox_TextChanged;
                }
            }
        }
    }
}
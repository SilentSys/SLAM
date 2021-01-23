using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SLAM
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class RenameForm : Form
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
            NameBox = new TextBox();
            _DoneButton = new Button();
            _DoneButton.Click += new EventHandler(DoneButton_Click);
            Label1 = new Label();
            SuspendLayout();
            // 
            // NameBox
            // 
            NameBox.Location = new Point(79, 12);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(183, 20);
            NameBox.TabIndex = 0;
            // 
            // DoneButton
            // 
            _DoneButton.Location = new Point(268, 10);
            _DoneButton.Name = "_DoneButton";
            _DoneButton.Size = new Size(75, 23);
            _DoneButton.TabIndex = 1;
            _DoneButton.Text = "Done";
            _DoneButton.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(12, 15);
            Label1.Name = "Label1";
            Label1.Size = new Size(61, 13);
            Label1.TabIndex = 2;
            Label1.Text = "New name:";
            // 
            // RenameForm
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 42);
            Controls.Add(Label1);
            Controls.Add(_DoneButton);
            Controls.Add(NameBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "RenameForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rename";
            Load += new EventHandler(RenameForm_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal TextBox NameBox;
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

        internal Label Label1;
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace SLAM
{
    [DesignerGenerated()]
    public partial class SetVolume : Form
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
            this._SelectButton = new System.Windows.Forms.Button();
            this._VolumeBar = new System.Windows.Forms.TrackBar();
            this._VolumeNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._VolumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // _SelectButton
            // 
            this._SelectButton.Location = new System.Drawing.Point(272, 63);
            this._SelectButton.Name = "_SelectButton";
            this._SelectButton.Size = new System.Drawing.Size(100, 23);
            this._SelectButton.TabIndex = 1;
            this._SelectButton.Text = "Done";
            this._SelectButton.UseVisualStyleBackColor = true;
            this._SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // _VolumeBar
            // 
            this._VolumeBar.Location = new System.Drawing.Point(12, 12);
            this._VolumeBar.Maximum = 20;
            this._VolumeBar.Name = "_VolumeBar";
            this._VolumeBar.Size = new System.Drawing.Size(360, 45);
            this._VolumeBar.TabIndex = 3;
            this._VolumeBar.Value = 10;
            this._VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // _VolumeNumber
            // 
            this._VolumeNumber.Location = new System.Drawing.Point(12, 59);
            this._VolumeNumber.MaxLength = 3;
            this._VolumeNumber.Name = "_VolumeNumber";
            this._VolumeNumber.Size = new System.Drawing.Size(100, 20);
            this._VolumeNumber.TabIndex = 4;
            this._VolumeNumber.Text = "100";
            this._VolumeNumber.TextChanged += new System.EventHandler(this.VolumeNumber_TextChanged);
            this._VolumeNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VolumeNumber_KeyPress);
            // 
            // SetVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 91);
            this.Controls.Add(this._VolumeNumber);
            this.Controls.Add(this._VolumeBar);
            this.Controls.Add(this._SelectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetVolume";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Volume";
            this.Load += new System.EventHandler(this.SetVolume_Load);
            ((System.ComponentModel.ISupportInitialize)(this._VolumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private TrackBar _VolumeBar;

        internal TrackBar VolumeBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _VolumeBar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_VolumeBar != null)
                {
                    _VolumeBar.Scroll -= VolumeBar_Scroll;
                }

                _VolumeBar = value;
                if (_VolumeBar != null)
                {
                    _VolumeBar.Scroll += VolumeBar_Scroll;
                }
            }
        }

        private TextBox _VolumeNumber;

        internal TextBox VolumeNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _VolumeNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_VolumeNumber != null)
                {
                    _VolumeNumber.KeyPress -= VolumeNumber_KeyPress;
                    _VolumeNumber.TextChanged -= VolumeNumber_TextChanged;
                }

                _VolumeNumber = value;
                if (_VolumeNumber != null)
                {
                    _VolumeNumber.KeyPress += VolumeNumber_KeyPress;
                    _VolumeNumber.TextChanged += VolumeNumber_TextChanged;
                }
            }
        }
    }
}
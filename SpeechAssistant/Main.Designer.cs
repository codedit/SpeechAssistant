namespace SpeechAssistant
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Mic = new System.Windows.Forms.PictureBox();
            this.MicPanel = new System.Windows.Forms.Panel();
            this.MessagePanelz = new System.Windows.Forms.Panel();
            this.ManualAsk = new System.Windows.Forms.TextBox();
            this.DebuggerPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Mic)).BeginInit();
            this.MicPanel.SuspendLayout();
            this.DebuggerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mic
            // 
            this.Mic.Image = ((System.Drawing.Image)(resources.GetObject("Mic.Image")));
            this.Mic.Location = new System.Drawing.Point(0, 0);
            this.Mic.Name = "Mic";
            this.Mic.Size = new System.Drawing.Size(59, 120);
            this.Mic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mic.TabIndex = 0;
            this.Mic.TabStop = false;
            this.Mic.Click += new System.EventHandler(this.Mic_Click);
            // 
            // MicPanel
            // 
            this.MicPanel.Controls.Add(this.Mic);
            this.MicPanel.Location = new System.Drawing.Point(12, 42);
            this.MicPanel.Name = "MicPanel";
            this.MicPanel.Size = new System.Drawing.Size(59, 120);
            this.MicPanel.TabIndex = 1;
            // 
            // MessagePanelz
            // 
            this.MessagePanelz.AutoSize = true;
            this.MessagePanelz.BackColor = System.Drawing.Color.Transparent;
            this.MessagePanelz.Location = new System.Drawing.Point(0, 0);
            this.MessagePanelz.Name = "MessagePanelz";
            this.MessagePanelz.Size = new System.Drawing.Size(366, 40);
            this.MessagePanelz.TabIndex = 2;
            // 
            // ManualAsk
            // 
            this.ManualAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualAsk.Location = new System.Drawing.Point(18, 7);
            this.ManualAsk.Name = "ManualAsk";
            this.ManualAsk.Size = new System.Drawing.Size(217, 26);
            this.ManualAsk.TabIndex = 0;
            this.ManualAsk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ManualAsk_KeyPress);
            // 
            // DebuggerPanel
            // 
            this.DebuggerPanel.AutoSize = true;
            this.DebuggerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(136)))), ((int)(((byte)(69)))));
            this.DebuggerPanel.Controls.Add(this.ManualAsk);
            this.DebuggerPanel.Location = new System.Drawing.Point(0, 0);
            this.DebuggerPanel.Name = "DebuggerPanel";
            this.DebuggerPanel.Size = new System.Drawing.Size(500, 36);
            this.DebuggerPanel.TabIndex = 3;
            this.DebuggerPanel.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(136)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(665, 571);
            this.Controls.Add(this.DebuggerPanel);
            this.Controls.Add(this.MessagePanelz);
            this.Controls.Add(this.MicPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Click += new System.EventHandler(this.Main_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.Mic)).EndInit();
            this.MicPanel.ResumeLayout(false);
            this.DebuggerPanel.ResumeLayout(false);
            this.DebuggerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Mic;
        private System.Windows.Forms.Panel MicPanel;
        private System.Windows.Forms.Panel MessagePanelz;
        private System.Windows.Forms.TextBox ManualAsk;
        private System.Windows.Forms.Panel DebuggerPanel;
    }
}


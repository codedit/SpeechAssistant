using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;
using System.IO;

namespace SpeechAssistant
{
    public partial class Main : Form
    {
       private int asked = 0;
        private int top = 60;
        private int questionnumber = 0;
        private int responsenumber = 0;
        private bool hidden = false;
        private int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        private int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists("firstrun"))
            {
                MessageBox.Show("Just a few little things:\n 1) Read the readme, no really do read it\n 2) If you paid for this software DEMAND A REFUND! This is free software\n 3) if your computer blows up, it's not my fault");
                File.Delete("firstrun");
            }
            this.Width = ScreenWidth / 3;
            this.Location = new System.Drawing.Point(ScreenWidth / 3, ScreenHeight);
            this.TopMost = true;
            MicPanel.Location = new System.Drawing.Point(((ScreenWidth / 3)-MicPanel.Width)/2, Mic.Location.Y+10);
            MessagePanelz.Location = new System.Drawing.Point(0, 0);
            MessagePanelz.Width = this.Width;
            MessagePanelz.Height = 10;
            MessagePanelz.Visible = false;
            ManualAsk.Width = this.Width / 2;
            ManualAsk.Location = new System.Drawing.Point(this.Width / 4, 20);
            ShowAssistant();
        }
        private void t_TransitionCompletedEvent(object sender, Transition.Args e) {
            DebuggerPanel.Visible = true;
            MessagePanelz.Visible = true;
        }
        private void Main_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void ShowAssistant()
        {
            MicPanel.Location = new System.Drawing.Point(((ScreenWidth / 3) - MicPanel.Width) / 2, Mic.Location.Y + 10);
            Transition t = new Transition(new TransitionType_Deceleration(500));
            t.add(this, "Top", ScreenHeight - 150);
            hidden = false;
            t.run();
       }
        private void DisplayResponse(string response)
        {
            Panel MessagePanel = new Panel();
            MessagePanel.BackColor = System.Drawing.Color.FromArgb(16, 161, 81);
            MessagePanel.Name = "p" + questionnumber.ToString();
            MessagePanel.Height = 30;
            MessagePanel.Width = this.Width - 80;
            MessagePanel.Location = new System.Drawing.Point(20, top);
            MessagePanelz.Controls.Add(MessagePanel);
            Label MessageText = new Label();
            MessageText.AutoSize = true;
            MessageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MessageText.ForeColor = System.Drawing.Color.White;
            MessageText.Location = new System.Drawing.Point(5, 5);
            MessageText.Name = "l" + questionnumber.ToString();
            MessageText.Size = new System.Drawing.Size(44, 20);
            MessageText.TabIndex = 2;
            MessageText.Text = "\"" + response + "\"";
            MessagePanel.Controls.Add(MessageText);
            top += 50;
            responsenumber += 1;
        }
        private void SpeakResponse()
        {

        }
        private void DisplayQuestion(string question)
        {
            Panel MessagePanel = new Panel();
            MessagePanel.BackColor = System.Drawing.Color.FromArgb(16, 161, 81);
            MessagePanel.Name = "p"+questionnumber.ToString();
            MessagePanel.Height = 30;
            MessagePanel.Width = this.Width - 80;
            MessagePanel.Location = new System.Drawing.Point(this.Width-MessagePanel.Width-20, top);
            MessagePanelz.Controls.Add(MessagePanel);
            Label MessageText = new Label();
            MessageText.AutoSize = true;
            MessageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MessageText.ForeColor = System.Drawing.Color.White;
            MessageText.Location = new System.Drawing.Point(5, 5);
            MessageText.Name = "l"+questionnumber.ToString();
            MessageText.Size = new System.Drawing.Size(44, 20);
            MessageText.TabIndex = 2;
            MessageText.Text = question;
            MessagePanel.Controls.Add(MessageText);
            top += 50;
            questionnumber += 1;
        }
        private void HideAssistant()
        {
            Transition t = new Transition(new TransitionType_Deceleration(500));
            t.add(this, "Top", ScreenHeight-1);
            hidden = true;
            t.run();
            MessagePanelz.Visible = false;
            DebuggerPanel.Visible = false;
            MessagePanelz.Height = 5;
  
        }
        public void Ask(string question)
        {
            if (question == "quit")
            {
                HideAssistant();
                Application.Exit();
            }
            if (asked == 3)
            {
                Transition t = new Transition(new TransitionType_Deceleration(500));
                t.add(MessagePanelz, "Top", MessagePanelz.Location.Y - 290);
                t.run();
                asked = 0;
            } 
            DisplayQuestion(question);
            try
            {
                string uriString = "http://infini-dev.com/WISA/WISA.php"; //post request to server and get response
                WebClient myWebClient = new WebClient();
                NameValueCollection PostParams = new NameValueCollection();
                PostParams.Add("request", question);
                byte[] responseArray =
                myWebClient.UploadValues(uriString, "POST", PostParams);
                string response = Encoding.ASCII.GetString(responseArray);
                DisplayResponse(response);
            }
            catch
            {
                DisplayResponse("I'm sorry, I could not connect to the server");
            }
            asked++;
        }
        private void Main_Click(object sender, EventArgs e)
        {
            if (hidden == false)
            {
                HideAssistant();
            }
            else
            {
                ShowAssistant();
            }
        }

        private void AssistantGoUp()
        {
            //debug.Visible = true;
            Transition t = new Transition(new TransitionType_Deceleration(500));
            t.add(this, "Top", ScreenHeight/3);
           t.add(MicPanel, "Top", ScreenHeight/3*2-Mic.Height-10);
           //t.add(MessagePanelz, "Height", this.Height - 200);
            hidden = false;
            t.run();
            t.TransitionCompletedEvent += new EventHandler<Transition.Args>(t_TransitionCompletedEvent);
        }
        private void Mic_Click(object sender, EventArgs e)
        {
            AssistantGoUp();
        }

        private void ManualAsk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Ask(ManualAsk.Text.ToString());
                ManualAsk.Text = "";
            }
        }
    }
}

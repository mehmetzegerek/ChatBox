using ChatBot.Business.ChatBot.Manager.Concrete;
using ChatBot.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.ChatItems;

namespace UI
{
    public partial class Form1 : Form
    {
        Sender _sender = new Sender();
        int imageState = 1;
        
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            StartScreen();
            
            
            
            
        }
        private void StartScreen()
        {
            imageState = 1;
            pxLoading.Image = Properties.Resources.main;
            pxLoading.Size = new Size(200, 200);
            pxLoading.Location = new Point(80, 50);
            pxLoading.Visible = true;
            lblConnecting.Location = new Point(40, 300);
            lblConnecting.Visible = true;
            lblConnecting.Text = "Lütfen ders linkini girin..";
        }

        private void ConnectScreen()
        {
            imageState = 2;
            pxLoading.Image = Properties.Resources.loading;
            pxLoading.Size = new Size(200, 200);
            pxLoading.Location = new Point(90, 50);
            pxLoading.Visible = true;
            lblConnecting.Location = new Point(115, 300);
            lblConnecting.Visible = true;
            lblConnecting.Text = "Bağlanılıyor..";
        }
        private void ExceptionScreen()
        {
            imageState = 3;
            pxLoading.Image = Properties.Resources.not_found;
            pxLoading.Size = new Size(200, 200);
            pxLoading.Location = new Point(80, 50);
            pxLoading.Visible = true;
            lblConnecting.Location = new Point(25, 300);
            lblConnecting.Visible = true;
            lblConnecting.TextAlign = ContentAlignment.MiddleCenter;
            lblConnecting.Font = new Font("Segoe UI Light", 14, FontStyle.Regular);
            lblConnecting.Text = "Üzgünüz\nbağlantı sırasında hata meydana geldi";
        }
        private void EmptyBoxScreen()
        {
            imageState = 4;
            pxLoading.Image = Properties.Resources.Empty;
            pxLoading.Size = new Size(200, 200);
            pxLoading.Location = new Point(80, 50);
            pxLoading.Visible = true;
            lblConnecting.Location = new Point(40, 300);
            lblConnecting.Visible = true;
            lblConnecting.Text = "Henüz mesaj yazan olmadı..";
        }
        private void MainStart()
        {
            if (tbxUrl.Text.Contains("https://eu.bbcollab.com/guest/"))
            {
                _sender.BrowserReady(tbxUrl.Text,500);
                EmptyBoxScreen();
                IMessage message = _sender.GetData();
                int id = message.Id;
                
                bool same = false;
                while (true)
                {

                    message = _sender.GetData();
                    if (message.Name != null && message.Id != id)
                    {
                        pxLoading.Visible = false;
                        lblConnecting.Visible = false;
                        same = message.Name.Contains("chat");
                    }

                    Thread.Sleep(1000);
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {


                            if (message.Title != null && message.Id != id && message.Name != string.Empty && !same)
                            {
                                pxLoading.Visible = false;
                                lblConnecting.Visible = false;
                                this.AddIncoming(message.Title, message.Name, message.Hour);
                                id = message.Id;
                            }
                            else if (message.Title != null && message.Id != id && message.Name == "" && !same)
                            {
                                pxLoading.Visible = false;
                                lblConnecting.Visible = false;
                                //this.AddIncomingContiune(message.Name, message.Hour);
                                this.AddIncomingContiune(message.Title, message.Hour);
                                id = message.Id;
                            }

                        });
                    }
                    //string title = message.Title;
                    //AddIncoming(title);


                }
            }
            else
            {
                MessageBox.Show("lütfen geçerli bir link girin");
            }
           
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            
           
        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();      
        }

        void Send()
        {
            _sender.SendMessage(txtMessage.Text);
            AddOutgoing(txtMessage.Text);
            txtMessage.Text = string.Empty;
        }

        public void AddIncoming(string message,string name,string hour)
        {
            var bubble = new ChatItems.Inncoming();
            pnlContainer.Controls.Add(bubble);
            bubble.BringToFront();
            bubble.Dock = DockStyle.Top;
            bubble.Message = message;
            bubble.Name = name;
            bubble.Hour = hour;
            
        }

        public void AddIncomingContiune(string message,string hour)
        {
            var bubble = new ChatItems.InncomingContiune();
            pnlContainer.Controls.Add(bubble);
            bubble.BringToFront();
            bubble.Dock = DockStyle.Top;
            bubble.Message = message;
            bubble.Hour = hour;
        }

        public void AddOutgoing(string message)
        {
            var bubble = new ChatItems.OutGoingg();
            pnlContainer.Controls.Add(bubble);
            bubble.BringToFront();
            bubble.Dock = DockStyle.Top;
            bubble.Message = message;

        }

        private void incomming1_Load(object sender, EventArgs e)
        {

        }

        private void ıncom1_Load(object sender, EventArgs e)
        {

        }

        private void incomming1_Load_1(object sender, EventArgs e)
        {

        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Return)
            {
                Send();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool state = false;
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
            if (state)
            {
                state = false;
                pnlSettings.Hide();
            }
            else
            {
                state = true;
                pnlSettings.BringToFront();
                pnlSettings.Show();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbxUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {


        }

        
        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (swhFix.Checked == true)
            {
                Form1.ActiveForm.TopMost = true;
            }
            else
            {
                Form1.ActiveForm.TopMost = false;
            }
        }

        private void pnlContainer_Click(object sender, EventArgs e)
        {

        }
        
        
        private void btnUrlSend_Click(object sender, EventArgs e)
        {
            
            if (!bw.IsBusy)
            {
                ConnectScreen();
                btnUrlSendEnabled = false;
                bw.RunWorkerAsync();
            }
               
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
          
            try
            {
                MainStart();
            }
            catch (Exception ex)
            {
                bw.CancelAsync();
                _sender.IsDone();
                ExceptionScreen();
                _sender.TakeScreenShot();
                MessageBox.Show(ex.Message);

                
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                     
            _sender.IsDone();
            this.Close();

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        bool btnUrlSendEnabled = true;
        private void Form1_Activated(object sender, EventArgs e)
        {
            if(btnUrlSendEnabled)
            {
                btnUrlSend.Enabled = true;
            }
            else
            {
                btnUrlSendEnabled = false;
            }
        }
    }
}

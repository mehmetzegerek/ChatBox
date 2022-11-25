using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.ChatItems;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            AddOutgoing(txtMessage.Text);
            txtMessage.Text = string.Empty;
        }

        public void AddIncoming(string message)
        {
            var bubble = new ChatItems.Inncoming();
            pnlContainer.Controls.Add(bubble);
            bubble.BringToFront();
            bubble.Dock = DockStyle.Top;
            bubble.Message = message;
            
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
    }
}

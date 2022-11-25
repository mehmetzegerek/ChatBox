using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.ChatItems
{
    public partial class OutGoingg : UserControl
    {
        public OutGoingg()
        {
            InitializeComponent();
        }
        public string Message { get { AdjustHeight(); return lblTitle.Text;  } set { lblTitle.Text = value; } }

        private void AdjustHeight()
        {
            lblTitle.Height = Utils.GetTextHeight(lblTitle) + 10;
            bunifuUserControl1.Height = lblTitle.Top + bunifuUserControl1.Top + lblTitle.Height;

            this.Height = bunifuUserControl1.Bottom + 10;

        }

        private void Inncoming_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Inncoming_Resize(object sender, EventArgs e)
        {
            AdjustHeight();
        }
    }
}

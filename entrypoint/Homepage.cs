using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Homepage: Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnHomepage.FlatStyle = FlatStyle.Flat;
            btnHomepage.FlatAppearance.BorderSize = 0;
        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {
            Homepage Homepage = new Homepage();
            Homepage.Show();
            this.Hide();
        }

        private void btnApplyNow_Click(object sender, EventArgs e)
        {
            Acc_Login loginForm = new Acc_Login();
            loginForm.Show();
            this.Hide();
        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            Acc_Login loginForm = new Acc_Login();
            loginForm.Show();
            this.Hide();
        }
    }
}

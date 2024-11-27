using entrypoint;
using entrypoint.PROCESSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Ad_Dashboard : Form
    {
        public Ad_Dashboard()
        {
            InitializeComponent();
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPanel(new frmDashburd());
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnCourseMan.FlatStyle = FlatStyle.Flat;
            btnCourseMan.FlatAppearance.BorderSize = 0;
            btnAppList.FlatStyle = FlatStyle.Flat;
            btnAppList.FlatAppearance.BorderSize = 0;
            btnPaymentList.FlatStyle = FlatStyle.Flat;
            btnPaymentList.FlatAppearance.BorderSize = 0;
        }

        private void btnCourseMan_Click(object sender, EventArgs e)
        {
            ShowPanel(new Ad_CourseManagement());
        }

        private void btnAppList_Click(object sender, EventArgs e)
        {
            ShowPanel(new ApplicationList());
        }

        private void btnPaymentList_Click(object sender, EventArgs e)
        {
            ShowPanel(new Ad_PaymentList());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                                          "Confirm Logout",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Homepage Homepage = new Homepage();
                Homepage.Show();
                this.Hide();
            }
        }
        private void ShowPanel(Form form)
        {
            panel9.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel9.Controls.Add(form);
            form.Show();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowPanel(new frmDashburd());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowPanel(new Ad_FinalList());
        }
    }
}
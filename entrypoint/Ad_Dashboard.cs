using entrypoint;
using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Student;
using entrypoint.PROCESSES.System_Processes;
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
            // ...
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.Gold;

            btnAppList.FlatStyle = FlatStyle.Flat;
            btnAppList.FlatAppearance.BorderSize = 0;
            btnAppList.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod;
            btnAppList.FlatAppearance.MouseOverBackColor = Color.Gold;

            btnPaymentList.FlatStyle = FlatStyle.Flat;
            btnPaymentList.FlatAppearance.BorderSize = 0;
            btnPaymentList.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod;
            btnPaymentList.FlatAppearance.MouseOverBackColor = Color.Gold;

            btnAdList.FlatStyle = FlatStyle.Flat;
            btnAdList.FlatAppearance.BorderSize = 0;
            btnAdList.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod;
            btnAdList.FlatAppearance.MouseOverBackColor = Color.Gold;

            // Set the default active color to darkgoldenrod for btnDashboard
            btnDashboard.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.DarkGoldenrod;
            btnDashboard.BackColor = Color.DarkGoldenrod;
            pictureBox10.BackColor = Color.DarkGoldenrod;

            ShowPanel(new frmDashburd());
        }

        public void btnDashboard_MouseLeave(object sender, EventArgs e)
        {
            if (btnDashboard != activeButton)
            {
                btnDashboard.BackColor = Color.Transparent;
            }
        }

        public void btnAppList_MouseLeave(object sender, EventArgs e)
        {
            if (btnAppList != activeButton)
            {
                btnAppList.BackColor = Color.Transparent;
            }
        }

        public void btnPaymentList_MouseLeave(object sender, EventArgs e)
        {
            if (btnPaymentList != activeButton)
            {
                btnPaymentList.BackColor = Color.Transparent;
            }
        }

        public void btnAdList_MouseLeave(object sender, EventArgs e)
        {
            if (btnAdList != activeButton)
            {
                btnAdList.BackColor = Color.Transparent;
            }
        }

        public Button activeButton;

        public void btnDashboard_Click(object sender, EventArgs e)
        {
            activeButton = btnDashboard;
            ShowPanel(new frmDashburd());
            ResetButtonColors();
            btnDashboard.BackColor = Color.DarkGoldenrod;

            pictureBox10.BackColor = Color.DarkGoldenrod;
        }

        public void btnAppList_Click(object sender, EventArgs e)
        {
            activeButton = btnAppList;
            ShowPanel(new ApplicationList());
            ResetButtonColors();
            btnAppList.BackColor = Color.DarkGoldenrod;

            pictureBox11.BackColor = Color.DarkGoldenrod;
        }

        public void btnPaymentList_Click(object sender, EventArgs e)
        {
            activeButton = btnPaymentList;
            ShowPanel(new Ad_PaymentList());
            ResetButtonColors();
            btnPaymentList.BackColor = Color.DarkGoldenrod;

            pictureBox12.BackColor = Color.DarkGoldenrod;
        }

        public void btnAdList_Click(object sender, EventArgs e)
        {
            activeButton = btnAdList;
            ShowPanel(new Ad_FinalList());
            ResetButtonColors();
            btnAdList.BackColor = Color.DarkGoldenrod;

            pictureBox13.BackColor = Color.DarkGoldenrod;
        }

        public void ResetButtonColors()
        {
            btnDashboard.BackColor = Color.Transparent;
            btnAppList.BackColor = Color.Transparent;
            btnPaymentList.BackColor = Color.Transparent;
            btnAdList.BackColor = Color.Transparent;

            pictureBox10.BackColor = Color.Transparent;
            pictureBox11.BackColor = Color.Transparent;
            pictureBox12.BackColor = Color.Transparent;
            pictureBox13.BackColor = Color.Transparent;
        }


        public void btnLogout_Click(object sender, EventArgs e)
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
                UserSession.ApplicationId = 0;
                UserSession.NAME = "";
                UserSession.ROLE = "";
                UserSession.ID = 0;
            }
        }
        public void ShowPanel(Form form)
        {
            panel9.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel9.Controls.Add(form);
            form.Show();
        }
    }
}
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
    public partial class PaymentList : Form
    {
        public PaymentList()
        {
            InitializeComponent();
        }

        private void exitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();         }

        private void PaymentList_Load(object sender, EventArgs e)
        {
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnCourseMan.FlatStyle = FlatStyle.Flat;
            btnCourseMan.FlatAppearance.BorderSize = 0;
            btnAppList.FlatStyle = FlatStyle.Flat;
            btnAppList.FlatAppearance.BorderSize = 0;
            btnPaymentList.FlatStyle = FlatStyle.Flat;
            btnPaymentList.FlatAppearance.BorderSize = 0;

            payListDataGrid.EnableHeadersVisualStyles = false;
            payListDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void btnCourseMan_Click(object sender, EventArgs e)
        {
            CourseManagement courseManagementForm = new CourseManagement();
            courseManagementForm.Show();
            this.Hide();
        }

        private void btnAppList_Click(object sender, EventArgs e)
        {
            ApplicationList applicationListForm = new ApplicationList();
            applicationListForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                                          "Confirm Logout",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // NOTE THAT THIS SHOULD BE ON THE LANDING PAGE.. dito kolang nilagay habang dipa nacocompile.
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnPayListFilter_Click(object sender, EventArgs e)
        {
            PayListFilter payFilterForm = new PayListFilter();
            payFilterForm.Show();
        }
    }
}

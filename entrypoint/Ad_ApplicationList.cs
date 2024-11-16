using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace entrypoint
{
    public partial class ApplicationList : Form
    {
        public ApplicationList()
        {
            InitializeComponent();
        }

        private void ApplicationList_Load(object sender, EventArgs e)
        {
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnCourseMan.FlatStyle = FlatStyle.Flat;
            btnCourseMan.FlatAppearance.BorderSize = 0;
            btnAppList.FlatStyle = FlatStyle.Flat;
            btnAppList.FlatAppearance.BorderSize = 0;
            btnPaymentList.FlatStyle = FlatStyle.Flat;
            btnPaymentList.FlatAppearance.BorderSize = 0;

            appListDataGrid.EnableHeadersVisualStyles = false;
            appListDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void exitIcon_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Ad_Dashboard dashboardForm = new Ad_Dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void btnCourseMan_Click(object sender, EventArgs e)
        {
            Ad_CourseManagement courseManagementForm = new Ad_CourseManagement();
            courseManagementForm.Show();
            this.Hide(); 
        }

        private void btnPaymentList_Click(object sender, EventArgs e)
        {
            Ad_PaymentList paymentListForm = new Ad_PaymentList();
            paymentListForm.Show();
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
                Homepage Homepage = new Homepage();
                Homepage.Show();
                this.Hide();
            }
        }

        private void btnAppListFilter_Click(object sender, EventArgs e)
        {
            Ad_AppListFilter appListFilterForm = new Ad_AppListFilter();
            appListFilterForm.Show();
        }
    }
}

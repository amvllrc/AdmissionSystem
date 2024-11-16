using entrypoint;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Ad_CourseManagement : Form
    {
        public Ad_CourseManagement()
        {
            InitializeComponent();
        }

        private void exitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CourseManagement_Load(object sender, EventArgs e)
        {
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnCourseMan.FlatStyle = FlatStyle.Flat;
            btnCourseMan.FlatAppearance.BorderSize = 0;
            btnAppList.FlatStyle = FlatStyle.Flat;
            btnAppList.FlatAppearance.BorderSize = 0;
            btnPaymentList.FlatStyle = FlatStyle.Flat;
            btnPaymentList.FlatAppearance.BorderSize = 0;
            listView1.DrawColumnHeader += ListView1_DrawColumnHeader;
        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Set the background color for the header
            e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);

            // Draw the header text
            e.DrawText(TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Ad_Dashboard dashboardForm = new Ad_Dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void btnAppList_Click(object sender, EventArgs e)
        {
            ApplicationList applicationListForm = new ApplicationList();
            applicationListForm.Show();
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
    }
}

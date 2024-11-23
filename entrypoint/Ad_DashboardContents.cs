using entrypoint.PROCESSES.Admin;
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
    public partial class frmDashburd : Form
    {
        private DashboardContents dc; 
        public frmDashburd()
        {
            InitializeComponent();
            dc=new DashboardContents();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDashburd_Load(object sender, EventArgs e)
        {
            valueApprovedApplicants.Text = dc.GetApprovedApp().ToString();
            valueNumCourses.Text = dc.GetNumCourse().ToString();
            valuePendingApplicants.Text = dc.GetPendingApp().ToString(); 
            valueRejectedApplicants.Text = dc.GetRejectApp().ToString();
            valueTotalApplicants.Text = dc.GetTotalApp().ToString();
            valueTotalUsers.Text = dc.GetTotalUse().ToString();



        }
    }
}

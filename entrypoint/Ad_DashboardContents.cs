using entrypoint.PROCESSES.Admin;
using entrypoint.PROCESSES.Student;
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
            valuePendingApplicants.Text = dc.GetPendingApp().ToString(); 
            valueRejectedApplicants.Text = dc.GetRejectApp().ToString();
            valueTotalApplicants.Text = dc.GetTotalApp().ToString();
            valueTotalUsers.Text = dc.GetTotalUse().ToString();
            label2.Text = dc.GetTotalAddmitted().ToString();
            label4.Text = dc.GetTotalRejected().ToString();
            label6.Text = dc.GetTotalPending().ToString();
            loadnotifs();


        }

        private void loadnotifs()
        {
            lblnotif.Text = $"Application period ends at {TimePeriods.ApplicationPeriodEnd.ToString("MMMM dd, yyyy")}, so make sure to take action until {TimePeriods.ApplicationApprovalEnd.ToString("MMMM dd, yyyy")}.";
            label7.Text = $"Payment period ends at {TimePeriods.PaymentPeriodEnd.ToString("MMMM dd, yyyy")}, so make sure to take action until {TimePeriods.PaymentApprovalEnd.ToString("MMMM dd, yyyy")}.";

            if (TimePeriods.CurrentDate > TimePeriods.ExamPeriodStart)
            {
                lblnotif.Text = $"Examination period ends at {TimePeriods.ExamPeriodEnd.ToString("MMMM dd, yyyy")}, so make sure to approve or reject admission until {TimePeriods.AdmissionApprovalEnd.ToString("MMMM dd, yyyy")}.";
                label7.Text = "";
            }
            if(TimePeriods.CurrentDate > TimePeriods.ExamPeriodEnd)
            {
                lblnotif.Text = $"Please make sure to approve or reject admission until {TimePeriods.AdmissionApprovalEnd.ToString("MMMM dd, yyyy")}.";
                label7.Text = "";
            }
        }

        private void adminwelcome_Click(object sender, EventArgs e)
        {

        }

        private void frmDashburd_Shown(object sender, EventArgs e)
        {
            loadMessage();
        }

        private void loadMessage()
        {
            DateTime oneDayBeforeCurrentDate = TimePeriods.CurrentDate.AddDays(1);

            if (TimePeriods.CurrentDate > TimePeriods.ExamPeriodStart && TimePeriods.ExamPeriodEnd == oneDayBeforeCurrentDate)
            {
                MessageBox.Show($"Examination period ends tomorrow at {TimePeriods.ExamPeriodEnd.ToString("MMMM dd, yyyy")}. Please make sure to approve or reject admission until {TimePeriods.AdmissionApprovalEnd.ToString("MMMM dd, yyyy")}.");
            }
            if (TimePeriods.CurrentDate.AddDays(1) == TimePeriods.AdmissionApprovalEnd)
            {
                MessageBox.Show($"The admission approval period ends tomorrow at {TimePeriods.AdmissionApprovalEnd.ToString("MMMM dd, yyyy")}. Please approve or reject the admission.");
            }
            if (TimePeriods.CurrentDate.AddDays(1) == TimePeriods.PaymentApprovalEnd)
            {
                MessageBox.Show($"The payment approval period ends tomorrow at {TimePeriods.PaymentApprovalEnd.ToString("MMMM dd, yyyy")}. Please complete the payment process.");
            }

            
        }

        private void panel6_DoubleClick(object sender, EventArgs e)
        {
           Ad_Dashboard app=new Ad_Dashboard();
            app.btnPaymentList_Click(sender, e);
        }
    }
}

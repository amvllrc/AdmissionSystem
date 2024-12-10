using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Admin;
using entrypoint.PROCESSES.Student;
using entrypoint.PROCESSES.Student_application;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Stu_AdmissionStatus : Form
    { 
    private Stu_Status stats;
        private ProcessTracker tracker;
        private Notification notification;
        public Stu_AdmissionStatus()
        {
            InitializeComponent();
            btnPaymentExam.Enabled = false;
            btnExamination.Enabled = false;
            stats= new Stu_Status();
            tracker= new ProcessTracker();
            notification= new Notification();
        }

    
        private void ChangeButtonColor(Button clickedButton)
        {
            btnAdmissionStatus.BackColor = Color.Transparent;
            btnApplication.BackColor = Color.Transparent;
            btnPaymentExam.BackColor = Color.Transparent;
            btnExamination.BackColor = Color.Transparent;
            btnAdmissionStatus.ForeColor = Color.White;
            btnApplication.ForeColor = Color.White;
            btnPaymentExam.ForeColor = Color.White;
            btnExamination.ForeColor = Color.White;
            clickedButton.BackColor = Color.DarkGoldenrod;
            clickedButton.ForeColor = Color.White;

        }

        
        public void pictureBox1_Click(object sender, EventArgs e)
        {
            UserSession.ApplicationId = 0;
            UserSession.NAME = "";
            UserSession.ROLE = "";
            UserSession.ID = 0;
            Application.Exit();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            tracker.validatethisbutton();
            picIconAdmission.BackColor = Color.DarkGoldenrod;
            btnAdmissionStatus.BackColor = Color.DarkGoldenrod;
            ShowPanel(new Stu_Status());


            if (tracker.getStatus()=="approved"&&TimePeriods.CurrentDate>=TimePeriods.PaymentPeriodStart)
           {
   enableControls();
            }
            if (tracker.getStatus2()=="paid"&&TimePeriods.CurrentDate>=TimePeriods.ExamPeriodStart&&TimePeriods.CurrentDate==tracker.getExamDate()&&TimePeriods.CurrentDate<=TimePeriods.ExamPeriodEnd)
            {
                enableControls1();
            }
           
                btnAdmissionStatus.FlatStyle = FlatStyle.Flat;
            btnAdmissionStatus.FlatAppearance.BorderSize = 0;
            btnApplication.FlatStyle = FlatStyle.Flat;
            btnApplication.FlatAppearance.BorderSize = 0;
            btnPaymentExam.FlatStyle = FlatStyle.Flat;
            btnPaymentExam.FlatAppearance.BorderSize = 0;
            btnExamination.FlatStyle = FlatStyle.Flat;
            btnExamination.FlatAppearance.BorderSize = 0;
        }

       public void enableControls()
        {
           
                pictureBox1.Visible = false;
                btnPaymentExam.Enabled = true;
           
            
        }

        public void enableControls1()//
        {

            pictureBox3.Visible = false;
            btnExamination.Enabled = true;
        }

        private void ShowPanel(Form form)
        {
            panel3.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel3.Controls.Add(form);
            form.Show();
        }

        private void btnAdmissionStatus_Click(object sender, EventArgs e)
        {

            StudentChangeIconColor imageUpdater = new StudentChangeIconColor();
            imageUpdater.UpdateButtonImages(
                picIconApplication, picIconAdmission, picIconPay, picIconExamination,
                "AppListWhite.png", "admission(White).png", "iconpayment(White).png", "exams(White).png"
            );
            picIconAdmission.BackColor = Color.DarkGoldenrod;
            picIconApplication.BackColor = Color.Transparent;
            picIconPay.BackColor = Color.Transparent;
            picIconExamination.BackColor = Color.Transparent;
            ShowPanel(new Stu_Status());
            ChangeButtonColor(btnAdmissionStatus); 
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            StudentChangeIconColor imageUpdater = new StudentChangeIconColor();

            imageUpdater.UpdateButtonImages(
                picIconApplication, picIconAdmission, picIconPay, picIconExamination,
                "AppListWhite.png", "admission(White).png", "iconpayment(White).png", "exams(White).png"
            );
            picIconAdmission.BackColor = Color.Transparent;
            picIconApplication.BackColor = Color.DarkGoldenrod;
            picIconPay.BackColor = Color.Transparent;
            picIconExamination.BackColor = Color.Transparent;
            Stu_ApplicationForm appForm = new Stu_ApplicationForm(this); 
            ShowPanel(appForm);
            ChangeButtonColor(btnApplication);
         
 


        }

        private void btnPaymentExam_Click(object sender, EventArgs e)
        {
          
            StudentChangeIconColor imageUpdater = new StudentChangeIconColor();

            imageUpdater.UpdateButtonImages(
                picIconApplication, picIconAdmission, picIconPay, picIconExamination,
                "AppListWhite.png", "application(White).png", "iconpayment(White).png", "exams(White).png"
            );
            picIconAdmission.BackColor = Color.Transparent;
            picIconApplication.BackColor = Color.Transparent;
            picIconPay.BackColor = Color.DarkGoldenrod;
            picIconExamination.BackColor = Color.Transparent;
            ShowPanel(new Stu_PaymentForm());

                ChangeButtonColor(btnPaymentExam);
           
                pictureBox1.Visible = false;

            

           
            
            }

        private void btnExamination_Click(object sender, EventArgs e)
        {
            StudentChangeIconColor imageUpdater = new StudentChangeIconColor();
            imageUpdater.UpdateButtonImages(
       picIconApplication, picIconAdmission, picIconPay, picIconExamination,
       "AppListWhite.png", "application(White).png", "iconpayment(White).png", "exams(White).png"
        );
            picIconAdmission.BackColor = Color.Transparent;
            picIconApplication.BackColor = Color.Transparent;
            picIconPay.BackColor = Color.Transparent;
            picIconExamination.BackColor = Color.DarkGoldenrod;
            ShowPanel(new Stu_Examination());
            ChangeButtonColor(btnExamination); // Change to black icon for this button
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                                          "Confirm Logout",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Homepage Homepage = new Homepage();
                Homepage.Show();
                Stu_ApplicationForm form = new Stu_ApplicationForm(this);
                Stu_PaymentForm form2 = new Stu_PaymentForm();
                Stu_Examination form3 = new Stu_Examination();
                form.Close();
                form2.Close();
                form3.Close();
                this.Close();

                UserSession.ApplicationId = 0;
                UserSession.NAME = "";
                UserSession.ROLE = "";
                UserSession.ID = 0;
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle DataGridView cell content click here (if needed)
        }

        private void Notif()
        {
            if (tracker.getStatus() == "pending" && TimePeriods.CurrentDate > TimePeriods.ApplicationApprovalEnd)
            {
                MessageBox.Show("Your application has not been processed. Please proceed to our admission department");
            }
            else if (tracker.getStatus2()== "pending" && TimePeriods.CurrentDate > TimePeriods.PaymentApprovalEnd)
            {
                MessageBox.Show("Your payment has not been processed. Please proceed to our admission department");
            }
            else if (tracker.isDoneExam() && TimePeriods.CurrentDate > TimePeriods.AdmissionApprovalEnd)
            {
                MessageBox.Show("Your admission has not been processed. Please proceed to our admission department");
            }

            else if (tracker.getStatus() == "" && TimePeriods.CurrentDate == TimePeriods.ApplicationPeriodEnd.AddDays(-1))
            {
                MessageBox.Show("Don't forget to apply until tomorrow");
            }
            else if (tracker.getStatus() == "approved" && TimePeriods.CurrentDate == TimePeriods.PaymentPeriodEnd.AddDays(-1))
            {
                MessageBox.Show("Don't forget to pay until tomorrow");
            }
            else if (tracker.getStatus2() == "paid")
            {
                DateTime dateexam = (DateTime)tracker.getExamDate();

                if (TimePeriods.CurrentDate == dateexam.AddDays(-1))
                {
                    MessageBox.Show("Don't forget to take your exam tomorrow");
                }
            }

        }
        private void Stu_AdmissionStatus_Shown(object sender, EventArgs e)
            
        {
            Notif();

            if (tracker.displayNOA()=="Admitted"&&!notification.isadmitShown())
            {
                Stu_NOA noa = new Stu_NOA();
                noa.ShowDialog();
                notification.updateBit("admitted", 1);
            }
            else if (tracker.displayNOA() == "Rejected"&&!notification.isrejectedShown()&&tracker.getStatus1())
            {
                MessageBox.Show(
                    "We understand that this news may be disappointing, but remember, this is not the end of your journey. " +
                    "We believe in your potential, and there are many other opportunities ahead. " +
                    "Keep striving, stay positive, and we wish you all the best in your future endeavors. " +
                    "Your hard work and determination will lead you to success. Don't give up, your time will come!",
                    "Admission Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                notification.updateBit("rejectedapplication", 1);
                notification.updateBit("rejected", 1);
            }
           else if (notification.isrejectedShown())
            {
                MessageBox.Show("You are already rejected. Redirecting to homepage");
                this.Close();
                UserSession.ApplicationId = 0;
                UserSession.NAME = "";
                UserSession.ROLE = "";
                UserSession.ID = 0;
                Homepage homepage = new Homepage();
                homepage.Show();
            }

            else if (notification.isRejectedShown())
            {
                MessageBox.Show("You are already rejected. Redirecting to homepage");
                this.Close();
                UserSession.ApplicationId = 0;
                UserSession.NAME = "";
                UserSession.ROLE = "";
                UserSession.ID = 0;
                Homepage homepage = new Homepage();
                homepage.Show();
            }

            else if (notification.isRejPaymentShown()&&tracker.getStatus()=="approved")
            {
                MessageBox.Show("You are already rejected due to rejection of payment. Redirecting to homepage");
                this.Close();
                UserSession.ApplicationId = 0;
                UserSession.NAME = "";
                UserSession.ROLE = "";
                UserSession.ID = 0;
                Homepage homepage = new Homepage();
                homepage.Show();
            }
       
       


        }
    }
}

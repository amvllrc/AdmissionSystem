﻿using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Admin;
using entrypoint.PROCESSES.Student;
using entrypoint.PROCESSES.Student_application;
using entrypoint.PROCESSES.System_Processes;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Stu_Status : Form
    {
        private ProcessTracker tracker;
        private AutomaticRejectAppStudent autom;
        private Notification notification;
        private NOA noa;

        Homepage homepage = new Homepage();
        public Stu_Status()
        {
            InitializeComponent();
            tracker = new ProcessTracker();
            autom= new AutomaticRejectAppStudent();
            notification= new Notification();
            noa=new NOA();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabel1.Visible = false;
            lblwelcomestudent.Text = $"Welcome, {UserSession.NAME}";
            lblnotif.Text = "Admission";


        }
        public void loadStatus()
        {

            if (tracker.getStatus()=="pending"|| tracker.getStatus() == "approved"|| tracker.getStatus() == "rejected")
            {
                label13.Text = "Done";
                label13.BackColor = Color.Green;
            }

            else
            {
                if (TimePeriods.CurrentDate > TimePeriods.ApplicationPeriodEnd)
                {
                    MessageBox.Show("You failed to submit your application on time, which results in not qualifying for this admission.");
                   
                    
                    homepage.Show();
                    UserSession.ApplicationId = 0;
                    UserSession.NAME = "";
                    UserSession.ROLE = "";
                    UserSession.ID = 0;
                    this.Close();
                }
                else
                {


                    label13.Text = "On Going";
                    label13.BackColor = Color.Yellow;
                    lblnotif.Text = "Please ensure you submit your application on or before "
                   + TimePeriods.ApplicationPeriodEnd.ToString("MMMM dd, yyyy") + ". Applications not submitted by the deadline\n will not be accepted.";
                }

            }
        }
        public void loadStatus0()
        {
            if (tracker.getStatus() == "approved")
            {
                label18.Text = "Approved";
                label18.BackColor = Color.Green;
            }
            else if (tracker.getStatus() == "rejected")
            {
                label18.Text = "Rejected";
                label18.BackColor = Color.Red;
            }
            else if (tracker.getStatus() == "pending") 
            {
                label18.Text = "Pending";
                label18.BackColor = Color.Gray;
                lblnotif.Text = "You have already submitted your application. Please wait for approval.";

            }
            else
            {
                label18.Text = "-";
            }
           
        }
        public void loadStatus1()
        {
            if (tracker.getStatus1())
            {
                label14.Text = "Done";
                label14.BackColor = Color.Green;
            }
            else if (tracker.getStatus()== "approved" && !tracker.getStatus1()){ 
                label14.Text = "On Going";
                label14.BackColor = Color.Yellow;
                if (!notification.isApprovedShown())
                {
                    MessageBox.Show("Congatulations! You're application has been approved");
                    notification.updateBit("approvedapplication",1);
                }
                lblnotif.Text = $"Please ensure that you complete your payment by {TimePeriods.PaymentPeriodEnd.ToString("MMMM dd, yyyy")}. If payment is not received by this date\n your admission will be rejected.";
            }
            else if (tracker.getStatus() == "rejected" && !tracker.getStatus1())
            {
                label18.Text = "Rejected";
                label18.BackColor = Color.Red;
                if (!notification.isRejectedShown())
                {
                    MessageBox.Show("We're sorry, but your application has been rejected. We understand this is disappointing, but don't give up. We encourage you to try again next year. Best of luck with your future endeavors!");
                    homepage.Show();
                    this.Hide();
                    UserSession.ApplicationId = 0;
                    UserSession.NAME = "";
                    UserSession.ROLE = "";
                    UserSession.ID = 0;
                    notification.updateBit("rejectedapplication", 1);
                    notification.updateBit("rejected", 1);


                }
                lblnotif.Text = $"Your application has been rejected.";
            }
        }

        public void loadStatus2()
        {
            String status = tracker.getStatus2();
            if (status=="pending")
            {
                label15.Text = "Pending";
                label15.BackColor = Color.Gray;
                lblnotif.Text = $"Your payment is being processed.";

            }
            else if (status == "rejected")
            {
                label15.Text = "Rejected";
                label15.BackColor = Color.Red;
                if (!notification.isRejPaymentShown())
                {
                    MessageBox.Show("We're sorry, but your payment has been rejected which results to rejection of admission");
                    homepage.Show();
                    UserSession.ApplicationId = 0;
                    UserSession.NAME = "";
                    UserSession.ROLE = "";
                    UserSession.ID = 0;
                    this.Hide();
                    notification.updateBit("rejectedpayment", 1);
                }

                lblnotif.Text = $"Your payment has been rejected.";
            }
            else if (status == "paid")
            {

                label15.Text = "Paid";
                label15.BackColor = Color.Green;
                if (!notification.isApPaymentShown())
                {
                    MessageBox.Show("Congatulations! You're payment has been approved");
                    notification.updateBit("approvedpayment", 1);
                }
                string examDate = tracker.getExamDate().ToString();
                if (!string.IsNullOrEmpty(examDate) && DateTime.TryParse(examDate, out DateTime parsedDate))
                {
                    lblnotif.Text = $"Please ensure that you take your exam by {parsedDate.ToString("MMMM dd, yyyy")}. If the exam is not taken by this date,\nyour admission will be rejected.";
                }
                if(TimePeriods.CurrentDate >= TimePeriods.PaymentPeriodStart)
                {
                    
                }

                

            }
            else
            {
                if (TimePeriods.CurrentDate > TimePeriods.PaymentPeriodEnd&&tracker.getStatus() == "approved")
                {
                    MessageBox.Show("You failed to settle your payment on time, which results in not qualifying for this admission.");
                    autom.RejectAll();
                    notification.updateBit("rejected", 1);
                    notification.updateBit("rejectedapplication", 1);
                    UserSession.ApplicationId = 0;
                    UserSession.NAME = "";
                    UserSession.ROLE = "";
                    UserSession.ID = 0;
                    homepage.Show();
                    this.Close();
                }
            }
        }
        public void loadStatus3()
        {
            if (tracker.getExamDate() <= TimePeriods.ExamPeriodEnd && tracker.getExamDate() == TimePeriods.CurrentDate)
            {
                if (!notification.isexamShown())
                {
                    MessageBox.Show("Best of luck! Today is you're examination day, don't forget to take it as it will be the final basis for this admission");
                    notification.updateBit("examdate", 1);
                }
                lblnotif.Text = "Please take your examination until 11:59pm only this day!";
                label16.Text = "Ongoing";
                label16.BackColor = Color.Yellow;
            }

            else
            {
                if (tracker.getExamDate() < TimePeriods.CurrentDate&&tracker.getStatus2()=="paid")
                {
                    MessageBox.Show("You forgot to take your examination. I'm sorry to tell you that this results to rejection of your admission");
                    autom.RejectAdmission();
                    notification.updateBit("rejected", 1);
                    notification.updateBit("rejectedapplication", 1);
                    notification.updateBit("exammissed", 1);
                    
                    UserSession.ApplicationId = 0;
                    UserSession.NAME = "";
                    UserSession.ROLE = "";
                    UserSession.ID = 0;
                    this.Close();
                    homepage.Show();
                }
            }
           

        }
        public void loadStatus4()
        {
            if (tracker.isDoneExam())
            {
                lblnotif.Text = "Please wait for your Notice on Admission!";
                label16.Text = "Done";
                label16.BackColor = Color.Green;
                label17.Text = "Waiting";
                label17.BackColor = Color.Yellow;

            }
          if (tracker.displayNOA() == "Admitted")
            {
                lblnotif.Text = "You have been admitted, Please wait for announcement regarding enrollment and other steps.!";
                label17.Text = "Approved";
                label17.BackColor = Color.Green;
               


            }
          else if (tracker.displayNOA() == "Rejected")
            {
                label17.Text = "Rejected";
                label17.BackColor = Color.Red;
            }
            if (notification.isadmitShown())
            {
                linkLabel1.Visible=true;
            }
         

        }

        private void Stu_Status_Shown(object sender, EventArgs e)
        {
            
            loadStatus();
            loadStatus0();
            loadStatus1();
            loadStatus2();
            loadStatus3();
            loadStatus4();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            noa.getStudentNOA();
        }
    }
}

using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Student;
using entrypoint.PROCESSES.Student_application;
using entrypoint.PROCESSES.System_Processes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Stu_Status : Form
    {
        private ProcessTracker tracker;
        private AutomaticRejectAppStudent autom;
        public Stu_Status()
        {
            InitializeComponent();
            tracker = new ProcessTracker();
            autom= new AutomaticRejectAppStudent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadStatus();
            loadStatus1();
            loadStatus2();
            loadStatus3();
            loadStatus4();
            lblwelcomestudent.Text = $"Welcome, {UserSession.NAME}";
        }
        public void loadStatus()
        {

            if (tracker.getStatus())
            {
                label13.Text = "Done";
                label13.BackColor = Color.Green;
            }
            else
            {
                label13.Text = "Not Done";
                label13.BackColor = Color.Gray;
            }
        }

        public void loadStatus1()
        {
            if (tracker.getStatus1())
            {
                label14.Text = "Done";
                label14.BackColor = Color.Green;
            }
            else if (tracker.getStatus() && !tracker.getStatus1()){ 
                label14.Text = "Not yet";
                label14.BackColor = Color.Gray;
            }
        }

        public void loadStatus2()
        {
            String status = tracker.getStatus2();
            if (status=="pending")
            {
                label15.Text = "Pending";
                label15.BackColor = Color.Gray;

            }
            else if (status == "rejected")
            {
                label15.Text = "Rejected";
                label15.BackColor = Color.Red;
            }
            else if (status == "paid")
            {

                label15.Text = "Paid";
                label15.BackColor = Color.Green;
                label16.Text = "Ongoing";
                label16.BackColor = Color.Gray;

            }
        }
        public void loadStatus3()
        {
            if (tracker.isDoneExam())
            {
                label16.Text = "Done";
                label16.BackColor = Color.Green;
                label17.Text = "Waiting";
                label17.BackColor = Color.Gray;

            }

        }
        public void loadStatus4()
        {
            if (tracker.displayNOA())
            {
                label17.Text = "Approved";
                label17.BackColor = Color.Green;

            }

        }

    }
}

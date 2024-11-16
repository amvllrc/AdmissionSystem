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
    public partial class Stu_AdmissionStatus: Form
    {
        public Stu_AdmissionStatus()
        {
            InitializeComponent();
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAdmissionStatus.FlatStyle = FlatStyle.Flat;
            btnAdmissionStatus.FlatAppearance.BorderSize = 0;
            btnApplication.FlatStyle = FlatStyle.Flat;
            btnApplication.FlatAppearance.BorderSize = 0;
            btnPaymentExam.FlatStyle = FlatStyle.Flat;
            btnPaymentExam.FlatAppearance.BorderSize = 0;
            btnExamination.FlatStyle = FlatStyle.Flat;
            btnExamination.FlatAppearance.BorderSize = 0;

        }


        private void btnAdmissionStatus_Click(object sender, EventArgs e)
        {
            Stu_AdmissionStatus AdmissionForm = new Stu_AdmissionStatus();
            AdmissionForm.Show();
            this.Hide();
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            Stu_ApplicationForm StudentApplicationForm = new Stu_ApplicationForm();
            StudentApplicationForm.Show();
            this.Hide();
        }

        private void btnPaymentExam_Click(object sender, EventArgs e)
        {
            Stu_PaymentForm PaymentForm = new Stu_PaymentForm();
            PaymentForm.Show();
            this.Hide();
        }

        private void btnExamination_Click(object sender, EventArgs e)
        {
            Stu_Examination Examination = new Stu_Examination();
            Examination.Show();
            this.Hide();
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            Homepage Homepage = new Homepage();
            Homepage.Show();
            this.Hide();
        }
    }
}

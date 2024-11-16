using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Stu_ApplicationForm : Form
    {
        private Dictionary<string, string> filePaths = new Dictionary<string, string>(); //For the Files

        public Stu_ApplicationForm()
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

    //Navigation Bar
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

        //Submission of Files (Need to modify for database connection)
        private void AttachFile(string documentType)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePaths[documentType] = openFileDialog.FileName;
                    MessageBox.Show($"{documentType} attached successfully!");
                }
            }
        }

        private void btnBirthCert_Click(object sender, EventArgs e)
        {
            AttachFile("Birth Certificate");
        }

        private void btnForm137_Click(object sender, EventArgs e)
        {
            AttachFile("Form137");
        }

        private void btn2by2Pic_Click(object sender, EventArgs e)
        {
            AttachFile("2x2 Picture");
        }

        private void btnESig_Click(object sender, EventArgs e)
        {
            AttachFile("E-Signature");
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            Homepage Homepage = new Homepage();
            Homepage.Show();
            this.Hide();
        }

        /*private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check if all files are attached
            if (!filePaths.ContainsKey("Birth Certificate") ||
                !filePaths.ContainsKey("Form137") ||
                !filePaths.ContainsKey("2x2 Picture") ||
                !filePaths.ContainsKey("E-Signature"))
            {
                MessageBox.Show("Please attach all required documents!");
                return;
            }
        }*/
    }
}

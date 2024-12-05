using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Student;
using entrypoint.PROCESSES.Student_application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Stu_PaymentForm: Form
    {
        private Payment p;
        private String Filepath;
        private String FileName;
        public Stu_PaymentForm()
        {

            InitializeComponent();
            p= new Payment();
        }


        public void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p.generateExamDates(cbDateOfExam);
            p.validateStep2(panel3);
          
        }

       
        private void btnProofOfPayment_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set filters for image file types
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the selected image into the PictureBox
                    try
                    {
                        Filepath= openFileDialog.FileName;
                        FileName = Path.GetFileName(Filepath);

                        Image selectedImage = Image.FromFile(openFileDialog.FileName);
                        picPreviewImg.Image = selectedImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
            }
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            Homepage Homepage = new Homepage();
            Homepage.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectedDateStr = cbDateOfExam.SelectedItem.ToString();
            DateTime selectedDate;
            if (DateTime.TryParse(selectedDateStr, out selectedDate))
            {
                string formattedDate = selectedDate.ToString("MM-dd-yyyy");
                
            }
            else
            {
                MessageBox.Show("Invalid date selected.");
            }
            if (p.validatePayment(txtAccountHolderName, txtCellphoneNum, txtReferenceNum, cbDateOfExam, picPreviewImg))
            {
                DialogResult result = MessageBox.Show(
                    "Please make sure to check all your payment details before clicking OK to submit.",
                    "Confirmation",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                   

                    p.insertPayment(txtAccountHolderName.Text, txtCellphoneNum.Text, txtReferenceNum.Text, selectedDate, Filepath, FileName);
                    foreach (Control control in panel3.Controls)
                    {
                        control.Enabled = false;
                    }
                }
            }

            else
            {
                MessageBox.Show("Please fill all necessary fields");
            }

        }
    }
}

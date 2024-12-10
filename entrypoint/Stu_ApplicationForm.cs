using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Student;
using entrypoint.PROCESSES.Student_application;

namespace entrypoint
{
    public partial class Stu_ApplicationForm : Form
    {
        private Dictionary<string, string> filePaths = new Dictionary<string, string>();
        public static string Gender;
        private Stu_AdmissionStatus adstat;
        private ProcessTracker tracker;
        private Student_Application stu;
        private InsertStudentData insertStudent;

        public Stu_ApplicationForm(Stu_AdmissionStatus mainform)
        {
            InitializeComponent();
            adstat = mainform;
            stu = new Student_Application();
            tracker = new ProcessTracker();
            insertStudent = new InsertStudentData();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            stu.validateStep1(panel3);
            dtpBirthdate.CalendarTitleBackColor = Color.Aqua;
            loadCourse();

        }

        private void loadCourse()
        {
            cbFirstCourse.DataSource = stu.GenerateCourse();
            cbSecondChoice.DataSource = stu.GenerateCourse();
        }




        private void ShowNewForm(Form form)
        {
            form.Show();
            this.Hide();
        }

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
            OpenFileAndSetTextBox(txtPSA, "Select a Birth Certificate PDF");
        }

        private void btnForm137_Click(object sender, EventArgs e)
        {
            OpenFileAndSetTextBox(txtForm137, "Select a Form 137 PDF");
        }

        private void btn2by2Pic_Click(object sender, EventArgs e)
        {
            OpenFileAndSetTextBox(txt2by2, "Select an image", "Image Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp|TIFF Files (*.tif;*.tiff)|*.tif;*.tiff|All Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff");
        }

        private void btnESig_Click(object sender, EventArgs e)
        {
            OpenFileAndSetTextBox(txtEsig, "Select a Birth Certificate PDF");
        }

        private void OpenFileAndSetTextBox(TextBox textBox, string title, string filter = "PDF Files (*.pdf)|*.pdf")
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = filter,
                Title = title
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;

                textBox.Text = fullPath;
            }
            else
            {
                MessageBox.Show("No file selected.");
            }
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            ShowNewForm(new Homepage());
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (stu.ValidateInput(panel3))
            {
                if (cbFirstCourse.SelectedItem != null && cbSecondChoice.SelectedItem != null)
                {
                    if (cbFirstCourse.SelectedItem.ToString() != cbSecondChoice.SelectedItem.ToString())
                    {
                        if (!(txtElemYear.Text.Length > 4 && txtHighschoolYear.Text.Length > 4 && txtSeniorYear.Text.Length > 4))
                        {
                            DialogResult result = MessageBox.Show(
                                "Please make sure to check all your details before clicking OK to submit.",
                                "Confirmation",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {
                                insertToDatabase();

                                foreach (Control control in panel3.Controls)
                                {
                                    control.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter valid graduated year");
                        }





                    }
                    else
                    {
                        MessageBox.Show("Please choose different courses.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select both courses.");
                }
            }
            else
            {
                MessageBox.Show("Error: Please fill in all required fields.");
            }
        }

        private void insertToDatabase()
        {
            String PSaname = Path.GetFileName(txtPSA.Text);
            String F137name = Path.GetFileName(txtForm137.Text);
            String picname = Path.GetFileName(txt2by2.Text);
            String esigname = Path.GetFileName(txtEsig.Text);
            try
            {
                insertStudent.InsertStudentApplication(
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtMiddleName.Text,
                      dtpBirthdate.Value,
                    txtPlaceBirth.Text,
                   Gender,
                   txtNationality.Text,
                   txtCivilStat.Text,
                   txtContactNum.Text,
                   txtAddress.Text,
                   txtElem.Text,
                   txtElemYear.Text,
                   txtHighschool.Text,
                   txtHighschoolYear.Text,
                   txtSenior.Text,
                   txtSeniorYear.Text,
                    cbFirstCourse.SelectedItem.ToString(),
                    cbSecondChoice.SelectedItem.ToString(),
                   txtMother.Text,
                   txtOccupationMother.Text,
                   txtContactMother.Text,
                   txtFather.Text,
                   txtOccupationFather.Text,
                   txtContactFather.Text,
                   txtGuardian.Text,
                   txtOccupationGuardian.Text,
                   txtContactGuardian.Text,
                    txtPSA.Text,
                    PSaname,
                    txtForm137.Text,
                    F137name,
                    txt2by2.Text,
                    picname,
                    txtEsig.Text,
                    esigname
                );
               


                tracker.validatethisbutton();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting application: " + ex.Message);
            }


        }

       
    }
}

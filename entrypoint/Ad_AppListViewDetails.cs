using entrypoint.PROCESSES.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class viewDetails : Form
    {
        public int appli_id { get; set; }
        private DetailsView view;
        private ToolTip toolTip = new ToolTip();
        private ControlValidator ctrlval;
        private ApplicationList parentForm;

        public viewDetails(ApplicationList parent)
        {
            InitializeComponent();
            view = new DetailsView();
            ctrlval = new ControlValidator();
            parentForm = parent;
        }

        private void exitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewDetails_Load(object sender, EventArgs e)
        {
            Validatethis();
            view.appl_id = appli_id;
            view.LoadDetails();
            DisplayImage(view.pic);
           

            label3.Text = view.fullname;
            label4.Text = view.add;
            label5.Text = view.birthdate;
            label6.Text = view.birthplace;
            label7.Text = view.gender;
            label8.Text = view.national;
            label9.Text = view.civilstat;
            label10.Text = view.contactnum;

            label12.Text = view.choice1;
            label14.Text = view.choice2;

            label15.Text = view.math;
            label17.Text = view.english;
            label18.Text = view.science;

            label19.Text = view.elem;
            label20.Text = view.elemyear;
            label21.Text = view.hs;
            label22.Text = view.hsyear;
            label23.Text = view.shs;
            label24.Text = view.shsyear;

            label26.Text = view.father;
            label27.Text = view.focc;
            label28.Text = view.fnum;
            label29.Text = view.mother;
            label30.Text = view.mocc;
            label31.Text = view.mnum;
        }

        private void Validatethis()
        {
            if (ctrlval.finalstatus(appli_id).Equals("Admitted"))
            {
                MessageBox.Show("This student is already approved");
                pay_btnApprove.Visible = false;
                pay_btnReject.Visible = false;
            }
            else if (ctrlval.finalstatus(appli_id).Equals("Rejcted"))
            {
                MessageBox.Show("This payment is already rejected");
                pay_btnApprove.Visible = false;
                pay_btnReject.Visible = false;
            }
        }

        private void viewDetails_Shown(object sender, EventArgs e)
        {
            panel2.AutoScrollPosition = new Point(0, 0);
        }

      
        private void DisplayPdf(byte[] pdfData)
        {
            if (pdfData != null)
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), "application.pdf");
                File.WriteAllBytes(tempFilePath, pdfData);
                Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("PDF data is empty.");
            }
        }
        private void DisplayImage(byte[] imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                // Convert byte array to image
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = image;

                }
            }
            else
            {
                MessageBox.Show("Image data is empty or invalid.");
            }
        }

      
      

        private void pay_btnApprove_Click_1(object sender, EventArgs e)
        {
            if (ctrlval.isExistExam(appli_id))
            {
                DialogResult result = MessageBox.Show(
                        "Confirm approval?", // Message text
                        "Confirm Admission",  // Title of the message box
                        MessageBoxButtons.OKCancel, // Buttons for the user to choose from
                        MessageBoxIcon.Question // Icon to show in the message box
                    );
                if (result == DialogResult.OK)
                {
                    ctrlval.approverejectAdmission(appli_id, "Admitted");
                    parentForm.LoadLis();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("This student is not ready for reviewing");
                pay_btnApprove.Enabled = false;
                pay_btnReject.Enabled = false;
            }



        }

        private void pay_btnReject_Click_1(object sender, EventArgs e)
        {

            if (ctrlval.isExistExam(appli_id))
            {
                DialogResult result = MessageBox.Show(
                        "Confirm rejection?", // Message text
                        "Confirm Rejection",  // Title of the message box
                        MessageBoxButtons.OKCancel, // Buttons for the user to choose from
                        MessageBoxIcon.Question // Icon to show in the message box
                    );
                if (result == DialogResult.OK)
                {
                    ctrlval.approverejectAdmission(appli_id, "Rejected");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("This student is not ready for reviewing");
                pay_btnApprove.Enabled = false;
                pay_btnReject.Enabled = false;
            }

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayPdf(view.psa);
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayPdf(view.form137);
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayPdf(view.esig);
            this.WindowState = FormWindowState.Minimized;
        }
    }
    }

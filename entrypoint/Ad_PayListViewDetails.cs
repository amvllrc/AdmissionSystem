using entrypoint.PROCESSES.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Ad_PayListViewDetails : Form
    {
        public int applic_id {get; set;}
        private PDetailsView detailsView;
        private ControlValidator validator;
        private ApproveReject aop;
        private QueryPayment qp;
        private Ad_PaymentList parentForm;
        public Ad_PayListViewDetails(Ad_PaymentList parent)
        {
            InitializeComponent();
            detailsView= new PDetailsView();
            validator = new ControlValidator();
            aop=new ApproveReject();
            qp=new QueryPayment();
            parentForm = parent;
        }

        private void PayListViewDetails_Load(object sender, EventArgs e)
        {
            ValidateThis();
            detailsView.ap_id= applic_id;
            detailsView.PloadDetails();
            label3.Text = detailsView.payid;
            label4.Text = applic_id.ToString();
            label5.Text = detailsView.name;
            label6.Text = detailsView.gcashnum;
            label7.Text = detailsView.status;
            label8.Text = detailsView.refnum;
            label9.Text = detailsView.paydate; 
            label10.Text = detailsView.examdate;
            DisplayImage(detailsView.proof);

        }

        private void ValidateThis()
        {
            if (validator.isExistPay(applic_id).Equals("paid"))
            {
                MessageBox.Show("This payment is already approved");
                pay_btnApprove.Visible = false;
                pay_btnReject.Visible = false;
            }
            else if (validator.isExistPay(applic_id).Equals("rejected"))
            {
                MessageBox.Show("This payment is already rejected");
                pay_btnApprove.Visible = false;
                pay_btnReject.Visible = false;
            }
          
        }

            private void DisplayImage(byte[] imageData)
        {

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    picProofOfPayment.SizeMode = PictureBoxSizeMode.StretchImage;
                    picProofOfPayment.Image = image;

                }
            }
            else
            {
                MessageBox.Show("Image data is empty or invalid.");
            }
        }

        private void exitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pay_btnApprove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to approve this payment?",
                "Confirm Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                aop.ApproveRejectPayment(applic_id, "paid");
                pay_btnApprove.Visible = false;
                pay_btnReject.Visible = false;
                this.Close();
                parentForm.loadpay();

            }
            else
            {
                MessageBox.Show("Approval cancelled.");
            }
        }

        private void pay_btnReject_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reject this payment?",
                "Confirm Rejection",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                aop.ApproveRejectPayment(applic_id, "rejected");
                pay_btnApprove.Visible = false;
                pay_btnReject.Visible = false;
                this.Close();
                parentForm.loadpay();

            }
            else
            {
                MessageBox.Show("Rejection cancelled.");
               
            }
        }
    }
}

namespace entrypoint
{
    partial class Stu_PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stu_PaymentForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpPaymentdetails = new System.Windows.Forms.GroupBox();
            this.cbDateOfExam = new System.Windows.Forms.ComboBox();
            this.lblDateOfExam = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnProofOfPayment = new System.Windows.Forms.Button();
            this.picPreviewImg = new System.Windows.Forms.PictureBox();
            this.txtReferenceNum = new System.Windows.Forms.TextBox();
            this.lblReferenceNum = new System.Windows.Forms.Label();
            this.txtAccountHolderName = new System.Windows.Forms.TextBox();
            this.lblAccountHolderName = new System.Windows.Forms.Label();
            this.txtCellphoneNum = new System.Windows.Forms.TextBox();
            this.lblCellphoneNum = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.lblScanToPay = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3.SuspendLayout();
            this.grpPaymentdetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panel3.Controls.Add(this.grpPaymentdetails);
            this.panel3.Controls.Add(this.picQR);
            this.panel3.Controls.Add(this.lblScanToPay);
            this.panel3.Location = new System.Drawing.Point(2, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 569);
            this.panel3.TabIndex = 26;
            // 
            // grpPaymentdetails
            // 
            this.grpPaymentdetails.Controls.Add(this.cbDateOfExam);
            this.grpPaymentdetails.Controls.Add(this.lblDateOfExam);
            this.grpPaymentdetails.Controls.Add(this.btnSubmit);
            this.grpPaymentdetails.Controls.Add(this.btnProofOfPayment);
            this.grpPaymentdetails.Controls.Add(this.picPreviewImg);
            this.grpPaymentdetails.Controls.Add(this.txtReferenceNum);
            this.grpPaymentdetails.Controls.Add(this.lblReferenceNum);
            this.grpPaymentdetails.Controls.Add(this.txtAccountHolderName);
            this.grpPaymentdetails.Controls.Add(this.lblAccountHolderName);
            this.grpPaymentdetails.Controls.Add(this.txtCellphoneNum);
            this.grpPaymentdetails.Controls.Add(this.lblCellphoneNum);
            this.grpPaymentdetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPaymentdetails.Location = new System.Drawing.Point(34, 209);
            this.grpPaymentdetails.Name = "grpPaymentdetails";
            this.grpPaymentdetails.Size = new System.Drawing.Size(659, 331);
            this.grpPaymentdetails.TabIndex = 30;
            this.grpPaymentdetails.TabStop = false;
            this.grpPaymentdetails.Text = "Payment Details";
            // 
            // cbDateOfExam
            // 
            this.cbDateOfExam.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDateOfExam.FormattingEnabled = true;
            this.cbDateOfExam.Location = new System.Drawing.Point(123, 192);
            this.cbDateOfExam.Margin = new System.Windows.Forms.Padding(2);
            this.cbDateOfExam.Name = "cbDateOfExam";
            this.cbDateOfExam.Size = new System.Drawing.Size(237, 27);
            this.cbDateOfExam.TabIndex = 41;
            // 
            // lblDateOfExam
            // 
            this.lblDateOfExam.AutoSize = true;
            this.lblDateOfExam.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfExam.Location = new System.Drawing.Point(24, 195);
            this.lblDateOfExam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateOfExam.Name = "lblDateOfExam";
            this.lblDateOfExam.Size = new System.Drawing.Size(95, 19);
            this.lblDateOfExam.TabIndex = 40;
            this.lblDateOfExam.Text = "Data of Exam:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(27, 241);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(144, 56);
            this.btnSubmit.TabIndex = 39;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnProofOfPayment
            // 
            this.btnProofOfPayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProofOfPayment.Location = new System.Drawing.Point(216, 241);
            this.btnProofOfPayment.Name = "btnProofOfPayment";
            this.btnProofOfPayment.Size = new System.Drawing.Size(144, 56);
            this.btnProofOfPayment.TabIndex = 38;
            this.btnProofOfPayment.Text = "PROOF OF PAYMENT";
            this.btnProofOfPayment.UseVisualStyleBackColor = true;
            this.btnProofOfPayment.Click += new System.EventHandler(this.btnProofOfPayment_Click_1);
            // 
            // picPreviewImg
            // 
            this.picPreviewImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreviewImg.Location = new System.Drawing.Point(411, 26);
            this.picPreviewImg.Name = "picPreviewImg";
            this.picPreviewImg.Size = new System.Drawing.Size(220, 288);
            this.picPreviewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreviewImg.TabIndex = 37;
            this.picPreviewImg.TabStop = false;
            // 
            // txtReferenceNum
            // 
            this.txtReferenceNum.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceNum.Location = new System.Drawing.Point(186, 145);
            this.txtReferenceNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtReferenceNum.Name = "txtReferenceNum";
            this.txtReferenceNum.Size = new System.Drawing.Size(174, 26);
            this.txtReferenceNum.TabIndex = 36;
            // 
            // lblReferenceNum
            // 
            this.lblReferenceNum.AutoSize = true;
            this.lblReferenceNum.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceNum.Location = new System.Drawing.Point(23, 148);
            this.lblReferenceNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReferenceNum.Name = "lblReferenceNum";
            this.lblReferenceNum.Size = new System.Drawing.Size(130, 19);
            this.lblReferenceNum.TabIndex = 35;
            this.lblReferenceNum.Text = "Reference Number:";
            // 
            // txtAccountHolderName
            // 
            this.txtAccountHolderName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountHolderName.Location = new System.Drawing.Point(186, 101);
            this.txtAccountHolderName.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccountHolderName.Name = "txtAccountHolderName";
            this.txtAccountHolderName.Size = new System.Drawing.Size(174, 26);
            this.txtAccountHolderName.TabIndex = 34;
            // 
            // lblAccountHolderName
            // 
            this.lblAccountHolderName.AutoSize = true;
            this.lblAccountHolderName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountHolderName.Location = new System.Drawing.Point(23, 104);
            this.lblAccountHolderName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountHolderName.Name = "lblAccountHolderName";
            this.lblAccountHolderName.Size = new System.Drawing.Size(151, 19);
            this.lblAccountHolderName.TabIndex = 33;
            this.lblAccountHolderName.Text = "Account Holder Name:";
            // 
            // txtCellphoneNum
            // 
            this.txtCellphoneNum.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCellphoneNum.Location = new System.Drawing.Point(186, 58);
            this.txtCellphoneNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtCellphoneNum.Name = "txtCellphoneNum";
            this.txtCellphoneNum.Size = new System.Drawing.Size(174, 26);
            this.txtCellphoneNum.TabIndex = 32;
            // 
            // lblCellphoneNum
            // 
            this.lblCellphoneNum.AutoSize = true;
            this.lblCellphoneNum.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellphoneNum.Location = new System.Drawing.Point(23, 61);
            this.lblCellphoneNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCellphoneNum.Name = "lblCellphoneNum";
            this.lblCellphoneNum.Size = new System.Drawing.Size(131, 19);
            this.lblCellphoneNum.TabIndex = 31;
            this.lblCellphoneNum.Text = "Cellphone Number:";
            // 
            // picQR
            // 
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picQR.Image = ((System.Drawing.Image)(resources.GetObject("picQR.Image")));
            this.picQR.Location = new System.Drawing.Point(306, 51);
            this.picQR.Margin = new System.Windows.Forms.Padding(2);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(140, 140);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // lblScanToPay
            // 
            this.lblScanToPay.AutoSize = true;
            this.lblScanToPay.BackColor = System.Drawing.Color.Transparent;
            this.lblScanToPay.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanToPay.Location = new System.Drawing.Point(313, 20);
            this.lblScanToPay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScanToPay.Name = "lblScanToPay";
            this.lblScanToPay.Size = new System.Drawing.Size(132, 25);
            this.lblScanToPay.TabIndex = 29;
            this.lblScanToPay.Text = "SCAN TO PAY";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Stu_PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(731, 611);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stu_PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grpPaymentdetails.ResumeLayout(false);
            this.grpPaymentdetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblScanToPay;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.GroupBox grpPaymentdetails;
        private System.Windows.Forms.TextBox txtReferenceNum;
        private System.Windows.Forms.Label lblReferenceNum;
        private System.Windows.Forms.TextBox txtAccountHolderName;
        private System.Windows.Forms.Label lblAccountHolderName;
        private System.Windows.Forms.TextBox txtCellphoneNum;
        private System.Windows.Forms.Label lblCellphoneNum;
        private System.Windows.Forms.PictureBox picPreviewImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnProofOfPayment;
        private System.Windows.Forms.Label lblDateOfExam;
        private System.Windows.Forms.ComboBox cbDateOfExam;
    }
}


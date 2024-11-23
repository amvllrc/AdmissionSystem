using entrypoint.PROCESSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Acc_ForgotPassword : Form
    {
        public Acc_ForgotPassword()
        {
            InitializeComponent();
        }

        private void exitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Acc_Login loginForm = new Acc_Login();
            loginForm.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNum.Text) ||
                string.IsNullOrWhiteSpace(txtNewPass.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmNewpass.Text))
            {
                MessageBox.Show("Please fill all fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPass.Text != txtConfirmNewpass.Text)
            {
                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // DATABASE CONNECTION TU
            using (SqlConnection connect = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    connect.Open();

                    string checkUser = "SELECT * FROM users WHERE email_address = @Email AND phone_number = @PhoneNumber";
                    using (SqlCommand cmd = new SqlCommand(checkUser, connect))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNum.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show("No user found with this email and phone number", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // FOR UPDATING PASSWORD
                    string updatePassword = "UPDATE users SET password = @Password WHERE email_address = @Email";
                    using (SqlCommand cmd = new SqlCommand(updatePassword, connect))
                    {
                        cmd.Parameters.AddWithValue("@Password", txtNewPass.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password updated successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Acc_Login loginForm = new Acc_Login();
                        loginForm.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

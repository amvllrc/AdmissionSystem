using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Student;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Acc_Register : Form
    {
        SqlConnection connect = new SqlConnection(DBConnection.connectionString);

        public Acc_Register()
        {
            InitializeComponent();
        }

        private void exitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(signup_email.Text) ||
                string.IsNullOrWhiteSpace(signup_lastname.Text) ||
                string.IsNullOrWhiteSpace(signup_firstname.Text) ||
                string.IsNullOrWhiteSpace(signup_password.Text) ||
                string.IsNullOrWhiteSpace(signup_confirmpassword.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!signup_email.Text.Contains("@"))
            {
                MessageBox.Show("Email must contain '@'", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (signup_password.Text != signup_confirmpassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string checkEmail = "SELECT * FROM users WHERE email_address = @Email";

                    using (SqlCommand checkUser = new SqlCommand(checkEmail, connect))
                    {
                        checkUser.Parameters.AddWithValue("@Email", signup_email.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            MessageBox.Show(signup_email.Text + " already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData = "INSERT INTO users (email_address, last_name, first_name, phone_number, password, created_at) " +
                                                "VALUES (@Email, @LastName, @FirstName, @PhoneNum, @Password, @CreatedAt)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@Email", signup_email.Text.Trim());
                                cmd.Parameters.AddWithValue("@LastName", signup_lastname.Text.Trim());
                                cmd.Parameters.AddWithValue("@FirstName", signup_firstname.Text.Trim());
                                cmd.Parameters.AddWithValue("@PhoneNum", signup_phoneNum.Text.Trim());
                                cmd.Parameters.AddWithValue("@Password", signup_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@CreatedAt", TimePeriods.CurrentDate);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Acc_Login loginForm = new Acc_Login();
                                loginForm.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void signup_showpass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showpass.Checked ? '\0' : '*';
        }

        private void signup_showconfirmpass_CheckedChanged(object sender, EventArgs e)
        {
            signup_confirmpassword.PasswordChar = signup_showconfirmpass.Checked ? '\0' : '*';
        }

        private void loginhere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Acc_Login loginForm = new Acc_Login();
            loginForm.Show();
            this.Hide();
        }

        private void Acc_Register_Load(object sender, EventArgs e)
        {
            signup_password.PasswordChar = '*';
            signup_confirmpassword.PasswordChar= '*';
        }
    }
}
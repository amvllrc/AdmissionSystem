using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Acc_Login : Form
    {

     
        SqlConnection connect = new SqlConnection(DBConnection.connectionString);
        public Acc_Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            login_password.PasswordChar = '*';
        }

        private void registerhere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (TimePeriods.CurrentDate >= TimePeriods.ApplicationPeriodStart && TimePeriods.CurrentDate <= TimePeriods.ApplicationPeriodEnd)
            {
                Acc_Register registerForm = new Acc_Register();
                registerForm.Show();
                this.Hide();
            }

            else if (TimePeriods.CurrentDate > TimePeriods.ApplicationPeriodEnd)
            {
                MessageBox.Show("The application period ended, You cannot proceed with this action");

            }
            else if (TimePeriods.CurrentDate < TimePeriods.ApplicationPeriodStart)
            {
                MessageBox.Show("The application is not yet started, You cannot proceed with this action");

            }
        }

        private void forgotpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Acc_ForgotPassword forgotpasswordForm = new Acc_ForgotPassword();
            forgotpasswordForm.Show();
            this.Hide();
        }

        private void login_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showpassword.Checked)
            {
                login_password.PasswordChar = '\0';
            }
            else
            {
                login_password.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (login_email.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fil all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        String selectData = "SELECT id,role,first_name FROM users WHERE email_address = @email AND password = @pass";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@email", login_email.Text);
                            cmd.Parameters.AddWithValue("@pass", login_password.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                int userId = Convert.ToInt32(table.Rows[0]["id"]);
                                string userRole = table.Rows[0]["role"].ToString();
                                string userName = table.Rows[0]["first_name"].ToString();
                                UserSession.ID = userId;
                                UserSession.ROLE = userRole;
                                UserSession.NAME = userName;
                                getUser(UserSession.ID, UserSession.ROLE);
                               
                                
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Connecting: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void getUser(int userId, String userRole)
        {
            if (userRole == "student")
            {
                Stu_AdmissionStatus status = new Stu_AdmissionStatus();
                status.Show();
                this.Hide();
            }
            else if (userRole == "admin"){
                Ad_Dashboard dashboard = new Ad_Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void exitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

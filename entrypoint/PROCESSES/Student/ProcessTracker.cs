using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace entrypoint.PROCESSES.Student_application
{
    public class ProcessTracker
    {

        public void validatethisbutton()
        {
            string query = "SELECT application_id FROM application where user_id = @user_id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", UserSession.ID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {


                            if (reader.Read())
                            {


                                UserSession.ApplicationId = reader.GetInt32(reader.GetOrdinal("application_id"));


                            }
                            else
                            {

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }


        }


        public DateTime? getExamDate()
        {
            DateTime? examDate = null;  // Use nullable DateTime to handle cases where no date is found
            string query = "SELECT date_of_exam FROM payment WHERE application_id = @id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", UserSession.ApplicationId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            examDate = Convert.ToDateTime(result);  // Convert the result to DateTime
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving exam date: " + ex.Message);
                }
            }

            return examDate;  // Return DateTime? (nullable DateTime)
        }



        public string getStatus()
        {
            string status = "";

            string query = "SELECT * FROM application WHERE user_id = @Id";

            using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", UserSession.ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        status = reader.GetString(reader.GetOrdinal("application_status"));
                    }
                    else
                    {
                        status = "";
                    }



                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., SQL errors)
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");

                }
            }


            return status;
        }

        public bool getStatus1()
        {
            bool isdone = false;
            string query = "SELECT * FROM payment WHERE application_id = @Id";
            using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", UserSession.ApplicationId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        isdone = true;



                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., SQL errors)
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");

                }
            }


            return isdone;
        }
        public String getStatus2()
        {
            string status = "";
            string query = "SELECT status FROM payment WHERE application_id = @Id";
            using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", UserSession.ApplicationId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        status = reader["status"].ToString();



                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., SQL errors)
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");

                }
            }


            return status;
        }

        public bool notifshown()
        {
            string query = "SELECT paymentrejected, rejectedapplication FROM notification WHERE application_id = @application_id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@application_id", UserSession.ApplicationId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            bool paymentRejected = reader.GetBoolean(0);
                            bool applicationRejected = reader.GetBoolean(1);

                            if (!paymentRejected && !applicationRejected)
                            {

                                UpdateNotificationStatus();
                                return true;

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while checking notification status: " + ex.Message);
                }
            }
            return false;
        }

        private void UpdateNotificationStatus()
        {
            string query = "UPDATE notification SET paymentrejected = 1, rejectedapplication = 1 WHERE application_id = @application_id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@application_id", UserSession.ApplicationId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating notification status: " + ex.Message);
                }
            }
        }

        public bool isDoneExam()
        {
            bool isdone = false;
            string query = "SELECT * FROM exam WHERE application_id = @Id";
            using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", UserSession.ApplicationId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {

                        isdone = true;



                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");

                }
            }


            return isdone;
        }


        public string displayNOA()
        {
            string query = "SELECT admission_status FROM application WHERE user_id = @Id";
            string admissionStatus = string.Empty; 

            using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", UserSession.ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        admissionStatus = reader["admission_status"].ToString(); 
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                    admissionStatus = "Error";  
                }
            }

            return admissionStatus;
        }
    }



    }



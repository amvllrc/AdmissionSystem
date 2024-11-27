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


                            if (reader.Read()) { 
                                

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

    

        //public void UpdateStatus(String columnname,String status)
        //{

        //    string query = "UPDATE application " +
        //          "SET " + columnname + " = '" + status + "' " +
        //          "WHERE user_id = " + UserSession.ID;
        //    using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);

        //        try
        //        {
        //            connection.Open();

        //            // Execute the update query
        //            int rowsAffected = command.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {

        //            }
        //            else
        //            {
        //                MessageBox.Show("No records were updated. Please check the application ID.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
                   
        //            MessageBox.Show("An error occurred: " + ex.Message, "Error");
        //        }
        //    }
        //}
       
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


        public bool displayNOA()
        {

            string query = "SELECT * FROM application WHERE user_id = @Id AND admission_status='Admitted'";
            bool isStatusDone = false;
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
                        isStatusDone = true;
                    }
                    else
                    {

                        isStatusDone = false;
                    }


                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                    isStatusDone = false; 
                }
            }


            return isStatusDone;
        }

    }



}
    

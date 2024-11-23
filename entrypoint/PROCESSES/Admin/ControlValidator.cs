using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.Admin
{
    public class ControlValidator
    {
      

       
        public void approverejectAdmission(int id,String status)
        {
            string query = "UPDATE application SET admission_status = @stats WHERE application_id = @id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@stats", status);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Application has been "+status);
                        }
                        else
                        {
                            MessageBox.Show("No matching application found to update.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., SQL errors)
                    MessageBox.Show("Error: " + ex.Message, "Error");
                }
            }
        }
        
        public string isExistPay(int applid)
        {
            string query = "SELECT status FROM payment WHERE application_id = @id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", applid);
                        var status = cmd.ExecuteScalar();
                        if (status == null)
                        {
                            return "No payment record found for this application.";
                        }
                        else
                        {
                            return status.ToString();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {

                return "Database error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }


        public bool isExistExam(int applid)
        {
            string query = "SELECT COUNT(*) FROM application WHERE application_id = @id AND admission_status = @status;";
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", applid);
                    cmd.Parameters.AddWithValue("@status", "Ready for Review");
                    int count = (int)cmd.ExecuteScalar();
                   
                 
                
                  
                    return count > 0;
                }
            }
        }

        public String finalstatus(int id)
        {
            string query = "SELECT admission_status FROM application WHERE application_id = @id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        var status = cmd.ExecuteScalar();
                        if (status == null)
                        {
                            return "No application record found for this application.";
                        }
                        else
                        {
                            return status.ToString();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {

                return "Database error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }
       


    }
}

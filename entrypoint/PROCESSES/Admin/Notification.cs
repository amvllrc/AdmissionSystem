using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrypoint.PROCESSES.Admin
{
    public class Notification
    {
        public bool isApprovedShown()
        {
            string query = "SELECT approvedapplication FROM Notifications WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToBoolean(result);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking approval status: " + ex.Message);
                }
            }
        }

        public bool isRejectedShown()
        {
            string query = "SELECT rejectedapplication FROM Notifications WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToBoolean(result);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking rejection status: " + ex.Message);
                }
            }
        }

        public bool isRejPaymentShown()
        {
            string query = "SELECT rejectedpayment FROM Notifications WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToBoolean(result);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking rejection status: " + ex.Message);
                }
            }
        }

        public bool isApPaymentShown()
        {
            string query = "SELECT approvedpayment FROM Notifications WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToBoolean(result);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking rejection status: " + ex.Message);
                }
            }
        }
        public bool isexamShown()
        {
            string query = "SELECT examdate FROM Notifications WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToBoolean(result);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking status: " + ex.Message);
                }
            }
        }

        public bool isexammShown()
        {
            string query = "SELECT exammissed FROM Notifications WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToBoolean(result);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking status: " + ex.Message);
                }
            }
        }


        public bool isadmitShown()
        {
            string query = "SELECT admitted FROM Notifications WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToBoolean(result);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking status: " + ex.Message);
                }
            }
        }
        public bool isrejectedShown()
        {
            string query = "SELECT rejected FROM Notifications WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToBoolean(result);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking status: " + ex.Message);
                }
            }
        }

        public void updateBit(string columnName, int value)
        {
            if (string.IsNullOrEmpty(columnName) || (value != 0 && value != 1))
            {
                throw new ArgumentException("Invalid column name or value.");
            }
            string query = $"UPDATE Notifications SET {columnName} = @Value WHERE application_id = @ApplicationId";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Value", value);
                        cmd.Parameters.AddWithValue("@ApplicationId", UserSession.ApplicationId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                      
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating the column: " + ex.Message);
                }
            }
        }
    }
}

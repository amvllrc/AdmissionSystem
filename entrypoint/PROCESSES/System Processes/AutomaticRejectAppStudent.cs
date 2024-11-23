using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.System_Processes
{
    public class AutomaticRejectAppStudent
    {
        public void AutomaticReject(String reason)
        {
            string query = "UPDATE application " +
                  "SET admission_status = 'Rejected' " +
                  "WHERE user_id = @userid;";
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", UserSession.ID);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("You have been automatically Rejected due to failure "+reason);
                        }
                        else
                        {
                            MessageBox.Show("No records found for the specified user.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the database operation
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

    }
}

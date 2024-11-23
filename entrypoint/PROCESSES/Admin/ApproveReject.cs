using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.Admin
{
    public class ApproveReject
    {
        public void ApproveRejectPayment(int id,String status)
        {
            string query = "UPDATE payment SET STATUS = @status WHERE application_id = @id;";
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@status", status);
                        int num = cmd.ExecuteNonQuery(); 
                        if (num > 0)
                        {
                            MessageBox.Show("Successfully "+status.ToUpper()+" Payment");
                        }
                        else
                        {
                            MessageBox.Show("No matching payment found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace entrypoint.PROCESSES.System_Processes
{
    public class AutomaticRejectAppStudent
    {
        public void RejectAll()
        {
            string query3 = "UPDATE application SET admission_status = 'Rejected'  WHERE application_id=@Id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                          
                            using (SqlCommand cmd3 = new SqlCommand(query3, conn, transaction))
                            {
                                cmd3.Parameters.AddWithValue("@Id", UserSession.ApplicationId);

                                cmd3.ExecuteNonQuery();
                            }

                            transaction.Commit();

                 
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error rejecting applications and payments: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }
        public void RejectAdmission()
        {
            string query3 = "UPDATE application SET admission_status = 'Rejected'  WHERE application_id=@Id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {

                            using (SqlCommand cmd3 = new SqlCommand(query3, conn, transaction))
                            {
                                cmd3.Parameters.AddWithValue("@Id", UserSession.ApplicationId);

                                cmd3.ExecuteNonQuery();
                            }

                            transaction.Commit();


                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error rejecting application automatically: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to the database: " + ex.Message);
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.Admin
{
    public class PDetailsView
    {
        public int ap_id { get; set; }
        public string payid = null;
        public string name=null;
        public string gcashnum = null;
        public string status = null;
        public string refnum = null;
        public string paydate = null;
        public string examdate = null;
        public byte[] proof = null;

        public void PloadDetails() {

            string queryPayment = "SELECT * FROM payment WHERE application_id = @appl_id";
            string queryName = "SELECT last_name,first_name,middle_name FROM application WHERE application_id = @appl_id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(queryPayment, conn))
                {
                    cmd.Parameters.AddWithValue("@appl_id",ap_id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            payid = reader["paymentid"].ToString();
                            gcashnum = reader["cellphone_number"].ToString();
                            status = reader["status"].ToString();
                            refnum = reader["reference_number"].ToString();
                            paydate = reader["pay_at"].ToString();
                            DateTime formattedDate = Convert.ToDateTime(reader["date_of_exam"]);
                           examdate= formattedDate.ToString("MMMM d, yyyy");
                            proof = reader["filepath"] as byte[];
                        }
    
                    }
                }

                using (SqlCommand cmd1 = new SqlCommand(queryName,conn))
                {
                    cmd1.Parameters.AddWithValue("@appl_id", ap_id);
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            name = reader["last_name"].ToString() + ", " + reader["first_name"].ToString() + ", " + reader["last_name"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("No data found");
                        }
                    }
                }
            }

        }


    }
}

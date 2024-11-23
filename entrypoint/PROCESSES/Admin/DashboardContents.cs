using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.Admin
{
    public class DashboardContents
 {
        //valueApprovedApplicants.Text = dc.GetApprovedApp();
        //    valueNumCourses.Text = dc.GetNumCourse();
        //    valuePendingApplicants.Text = dc.GetPendingApp(); 
        //    valueRejectedApplicants.Text = dc.GetRejectApp();
        //    valueTotalApplicants.Text = dc.GetTotalApp();
        //    valueTotalUsers.Text = dc.GetTotalUse();

        public int GetApprovedApp()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM application WHERE admission_status = 'Admitted'";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        count = (int)cmd.ExecuteScalar(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        public int GetNumCourse()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM course";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }
        public int GetPendingApp()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM application WHERE admission_status = 'Ready for Review'";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }
        public int GetRejectApp()
        {

            int count = 0;
            string query = "SELECT COUNT(*) FROM application WHERE admission_status = 'Rejected'";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }
        public int GetTotalApp()
        {

            int count = 0;
            string query = "SELECT COUNT(*) FROM application";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }
        public int GetTotalUse()
        {

            int count = 0;
            string query = "SELECT COUNT(*) FROM users;";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }


    }
}

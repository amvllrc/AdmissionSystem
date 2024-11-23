using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.Admin
{
    public class AddEdiTDeleteCourse
    {
        private int course_id;
        public int retrieveCellRow(DataGridView dgv)
        {

            if (dgv.CurrentCell != null)
            {
                int rowInd = dgv.CurrentCell.RowIndex;
                course_id = Convert.ToInt32(dgv.Rows[rowInd].Cells[0].Value);
                MessageBox.Show(course_id.ToString());
            }
            else
            {
                MessageBox.Show("No selected cell");
            }
            return course_id;
        }

        public void EditCourse(int course_id,String coursename)
        {
            string query = "UPDATE course SET name = @course WHERE course_id = @courseId";

            using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@course", coursename);
                    command.Parameters.AddWithValue("@courseId", course_id);
                    int rowsAffected = command.ExecuteNonQuery();  // ExecuteNonQuery is used for UPDATE, INSERT, DELETE

                    // Check how many rows were affected (i.e., updated)
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Course updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No rows were updated.");
                    }
                }
            }

        }

        public String retrieveCourseName(int course_id)
        {
            string coursename="";
            string query = "SELECT name FROM course WHERE course_id=@course";

            using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
            { 
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@course",course_id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          coursename = reader["name"].ToString();
                        }
                    }
                }
            }
            return coursename;
        }

        public bool isExist(string coursename)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM course WHERE name = @coursename COLLATE SQL_Latin1_General_CP1_CI_AS";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@coursename", coursename);

                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            exists = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return exists;
        }

        public void insertToCourse(string name)
        {
       
            string query = "INSERT INTO course (name) VALUES (@name)";
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Course added successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the insert
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void delCourse(int course_id)
        {
            string query = "DELETE FROM course WHERE course_id = @course_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@course_id", course_id);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Course deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Course not found.");
                        }
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
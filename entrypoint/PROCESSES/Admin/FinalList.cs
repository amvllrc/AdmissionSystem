using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.Layout.Element;

namespace entrypoint.PROCESSES.Admin
{
    public class FinalList
    {
        public DataGridView Dgv { get; set; }=new DataGridView();
        public void addApproveButton()
        {
            DataGridViewButtonColumn approveButtonColumn = new DataGridViewButtonColumn();
            approveButtonColumn.HeaderText = "Approve Admission";
            approveButtonColumn.Name = "approveButton";
            approveButtonColumn.Text = "Approve";
            approveButtonColumn.UseColumnTextForButtonValue = true;
            approveButtonColumn.FlatStyle = FlatStyle.Flat;
            approveButtonColumn.DefaultCellStyle.BackColor = Color.Green;
            approveButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            Dgv.Columns.Add(approveButtonColumn);
        }

        public void addRejectButton()
        {
            DataGridViewButtonColumn rejectButtonColumn = new DataGridViewButtonColumn();
            rejectButtonColumn.HeaderText = "Reject Admission";
            rejectButtonColumn.Name = "rejectButton";
            rejectButtonColumn.Text = "Reject";
            rejectButtonColumn.UseColumnTextForButtonValue = true;

            rejectButtonColumn.FlatStyle = FlatStyle.Flat;
            rejectButtonColumn.DefaultCellStyle.BackColor = Color.Red;
            rejectButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            Dgv.Columns.Add(rejectButtonColumn);
        }
        public void loaditem()
        {
            string query = "SELECT e.application_id as 'ID',(a.last_name + ' ' + a.first_name) AS Name, e.scoremath as Math, e.scoreenglish as English, e.scorescience as Science,a.program_choice_1 as 'Program 1',a.program_choice_2 as 'Program 2',a.admission_status as Status " +
                 "FROM exam e " +
                 "JOIN application a ON a.application_id = e.application_id";
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        Dgv.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public void UpdateApplicationStatus(int applicationId, string status)
        {
            string query = "UPDATE application SET admission_status = @status WHERE application_id = @application_id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@application_id", applicationId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Application {status} successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Error updating application status.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void executequeries(string sort, List<string>status, string search)
        {
            string query = "SELECT e.application_id as 'ID',(a.last_name + ' ' + a.first_name) AS Name, e.scoremath as Math, e.scoreenglish as English, e.scorescience as Science,a.program_choice_1 as 'Program 1',a.program_choice_2 as 'Program 2',a.admission_status as Status " +
                  "FROM exam e " +
                  "JOIN application a ON a.application_id = e.application_id";

            List<string> conditions = new List<string>();
            if (!string.IsNullOrEmpty(search))
            {
                conditions.Add($"(last_name LIKE '%{search}%' OR first_name LIKE '%{search}%')");
            }
            List<string> filterConditions = new List<string>();
            if (status.Contains("Ready for Review")) filterConditions.Add("admission_status = 'Ready for Review'");
            if (status.Contains("Admitted")) filterConditions.Add("admission_status = 'Admitted'");
            if (status.Contains("Rejected")) filterConditions.Add("admission_status = 'Rejected'");


            if (filterConditions.Count > 0)
            {
                conditions.Add("(" + string.Join(" OR ", filterConditions) + ")");
            }

            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }
            List<string> validSortColumns = new List<string> { "taken_at", "last_name", "AverageScore" };
            if (!string.IsNullOrEmpty(sort) && validSortColumns.Contains(sort))
            {
                query += $" ORDER BY {sort}";
            }
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Dgv.DataSource = dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

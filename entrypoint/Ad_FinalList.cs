using entrypoint.PROCESSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Ad_FinalList : Form
    {
        public Ad_FinalList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadlist();
            addApproveButton();
            addRejectButton();
        }
        private void addApproveButton()
        {
            DataGridViewButtonColumn approveButtonColumn = new DataGridViewButtonColumn();
            approveButtonColumn.HeaderText = "Approve Admission";
            approveButtonColumn.Name = "approveButton";
            approveButtonColumn.Text = "Approve";
            approveButtonColumn.UseColumnTextForButtonValue = true;
            approveButtonColumn.FlatStyle = FlatStyle.Flat;
            approveButtonColumn.DefaultCellStyle.BackColor = Color.Green;
            approveButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            appListDataGrid.Columns.Add(approveButtonColumn);
        }

        private void addRejectButton()
        {
            // Create a button column for 'Reject'
            DataGridViewButtonColumn rejectButtonColumn = new DataGridViewButtonColumn();
            rejectButtonColumn.HeaderText = "Reject Admission";
            rejectButtonColumn.Name = "rejectButton";
            rejectButtonColumn.Text = "Reject";
            rejectButtonColumn.UseColumnTextForButtonValue = true;

            // Set the button style to red for 'Reject'
            rejectButtonColumn.FlatStyle = FlatStyle.Flat;
            rejectButtonColumn.DefaultCellStyle.BackColor = Color.Red;
            rejectButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            appListDataGrid.Columns.Add(rejectButtonColumn);
        }

        private void loadlist()
        {
            string query = "SELECT e.application_id as 'Application ID',(a.last_name + ' ' + a.first_name) AS Name, e.scoremath, e.scoreenglish, e.scorescience,a.application_status " +
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
                        appListDataGrid.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Handle the button click in the DataGridView (Approve/Reject)
        private void appListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure we're not clicking the header row
            if (e.RowIndex >= 0)
            {
                // Get the text of the clicked cell
                string cellText = appListDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Check if the clicked cell is "Approve" or "Reject"
                if (cellText == "Approve")
                {
                    // Get the application_id from the first column (application_id column)
                    var applicationIdValue = appListDataGrid.Rows[e.RowIndex].Cells[2].Value;
                 
                    if (applicationIdValue != null && int.TryParse(applicationIdValue.ToString(), out int applicationId))
                    {
                        // Ask for confirmation before approving
                        DialogResult result = MessageBox.Show("Are you sure you want to approve this application?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            // Call method to update application status to "Admitted"
                            UpdateApplicationStatus(applicationId, "Admitted");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid application ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cellText == "Reject")
                {
                    // Get the application_id from the first column (application_id column)
                    var applicationIdValue = appListDataGrid.Rows[e.RowIndex].Cells[2].Value;

                    if (applicationIdValue != null && int.TryParse(applicationIdValue.ToString(), out int applicationId))
                    {
                        // Ask for confirmation before rejecting
                        DialogResult result = MessageBox.Show("Are you sure you want to reject this application?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            // Call method to update application status to "Rejected"
                            UpdateApplicationStatus(applicationId, "Rejected");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid application ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please click a valid button (Approve/Reject).", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void UpdateApplicationStatus(int applicationId, string status)
        {
            // SQL query to update the admission status based on the application_id
            string query = "UPDATE application SET admission_status = @status WHERE application_id = @application_id";

            // Using the connection string to connect to the database
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // Create the SQL command to execute
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@application_id", applicationId);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Application {status} successfully.");
                            loadlist();
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
        private void appListDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(appListDataGrid.Columns[e.ColumnIndex].Name == "approveButton" ||appListDataGrid.Columns[e.ColumnIndex].Name == "rejectButton")
    {
                if (appListDataGrid.Columns[e.ColumnIndex].Name == "approveButton")
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (appListDataGrid.Columns[e.ColumnIndex].Name == "rejectButton")
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
    else
            {
                e.CellStyle.BackColor = appListDataGrid.Rows[e.RowIndex].Selected ?
                    appListDataGrid.DefaultCellStyle.SelectionBackColor :
                    appListDataGrid.DefaultCellStyle.BackColor;
            }
        }
    }
}

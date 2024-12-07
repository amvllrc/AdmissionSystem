using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
namespace entrypoint.PROCESSES.Admin
{
    public class QueryPayment
    {
        public DataGridView dgv { get; set; } = new DataGridView();

        public void LoadList()
        {

            string query = @"
    SELECT 
        p.paymentid AS PaymentID,
        p.application_id as ApplicationId,
        (COALESCE(a.last_name, '') + ', ' + COALESCE(a.first_name, '') + ' ' + COALESCE(a.middle_name, '')) AS Name,
        p.pay_at AS Payment_Date,
        p.reference_number AS 'Reference_Number',
        p.status AS Status
    FROM 
        payment p
    JOIN 
        application a ON p.application_id = a.application_id";


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
                        dgv.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public void AddViewMoreButtonColumn(DataGridView dg)
        {
            DataGridViewButtonColumn viewMoreButton = new DataGridViewButtonColumn();
            viewMoreButton.HeaderText = "Action";
            viewMoreButton.Name = "viewMoreButton";
            viewMoreButton.Text = "View More";
            viewMoreButton.UseColumnTextForButtonValue = true;

            viewMoreButton.FlatStyle = FlatStyle.Flat;
            viewMoreButton.DefaultCellStyle.BackColor = Color.Red;
            viewMoreButton.DefaultCellStyle.ForeColor = Color.White;

            dg.Columns.Add(viewMoreButton);

        }

        public String getItemCbo(ComboBox cbo)
        {

            string psortby = "";
            int selectedSortIndex = cbo.SelectedIndex;
            switch (selectedSortIndex)
            {
                case 0:
                    psortby = "last_name";
                    break;
                case 1:
                    psortby = "pay_at";
                    break;
                case 2:
                    psortby = "date_of_exam";
                    break;
                default:
                    psortby = "pay_at";
                    break;
            }

            return psortby;



        }

        
        public void executequeries(string sort, List<string> status, string search)
        {
            string query = @"
    SELECT 
        p.paymentid AS PaymentID,
        p.application_id as ApplicationId,
        (COALESCE(a.last_name, '') + ', ' + COALESCE(a.first_name, '') + ' ' + COALESCE(a.middle_name, '')) AS Name,
        p.pay_at AS Payment_Date,
        p.reference_number AS 'Reference_Number',
        p.status AS Status
    FROM 
        payment p
    JOIN 
        application a ON p.application_id = a.application_id";

            List<string> conditions = new List<string>();
            if (!string.IsNullOrEmpty(search))
            {
                conditions.Add($"(last_name LIKE '%{search}%' OR first_name LIKE '%{search}%')");
            }
            List<string> filterConditions = new List<string>();
            if (status.Contains("pending")) filterConditions.Add("p.status = 'pending'");
            if (status.Contains("paid")) filterConditions.Add("p.status = 'paid'");
            if (status.Contains("rejected")) filterConditions.Add("p.status = 'rejected'");


            if (filterConditions.Count > 0)
            {
                conditions.Add("(" + string.Join(" OR ", filterConditions) + ")");
            }

            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }
            List<string> validSortColumns = new List<string> { "pay_at", "last_name", "date_of_exam" };
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
                            dgv.DataSource = dataTable;
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


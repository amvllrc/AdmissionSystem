﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Text;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.Layout.Element;

namespace entrypoint.PROCESSES.Admin
{
    public class QueryButtons
    {
       
        public DataGridView dg {  get; set; } = new DataGridView();
      
        
       
        public void LoadList()
        {
            
            string query = "SELECT application_id as ID, last_name as 'Last Name', first_name as 'First Name', middle_name as 'Middle Name', submitted_at as 'Application Date',application_status as STATUS FROM application";

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
                        dg.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public void AddViewMoreButtonColumn(DataGridView dgv)
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

        public String getItemCbo(System.Windows.Forms.ComboBox cbo)
        {

            string sortby = "";
            int selectedSortIndex = cbo.SelectedIndex;
            switch (selectedSortIndex)
            {
                case 0:
                    sortby = "submitted_at";
                    break;
                case 1:
                    sortby = "last_name";
                    break;
                case 2:
                    sortby = "first_name";
                    break;
                default:
                    sortby = "submitted_at";
                    break;
            }

            return sortby;
   }

        
public void executequeries(string sort, List<string> status, String search)
        {
            string query = "SELECT application_id as ID, last_name as 'Last Name', first_name as 'First Name', middle_name as 'Middle Name', submitted_at as 'Application Date',application_status as STATUS FROM application";

            List<string> conditions = new List<string>();
            if (!string.IsNullOrEmpty(search))
            {
                conditions.Add($"(last_name LIKE '%{search}%' OR first_name LIKE '%{search}%')");
            }
            List<string> filterConditions = new List<string>();
            if (status.Contains("approved")) filterConditions.Add("application_status = 'approved'");
            if (status.Contains("rejected")) filterConditions.Add("application_status = 'rejected'");
            if (status.Contains("pending")) filterConditions.Add("application_status = 'pending'");
      
            if (filterConditions.Count > 0)
            {
                conditions.Add("(" + string.Join(" OR ", filterConditions) + ")");
            }

            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }
            List<string> validSortColumns = new List<string> { "submitted_at", "last_name", "first_name" };
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
                            dg.DataSource = dataTable;
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

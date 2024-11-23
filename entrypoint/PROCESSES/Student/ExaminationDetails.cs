﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace entrypoint.PROCESSES.Student_application
{
    public class ExaminationDetails
    {
        public string lastName = string.Empty;
        public string firstName = string.Empty;
        public string middleName = string.Empty;
        public void retrieveNameandOthers()
        {
            string query = "SELECT last_name, first_name, middle_name FROM application WHERE application_id=@id";

           
          

            try
            {
                using (SqlConnection connection = new SqlConnection(DBConnection.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", UserSession.ApplicationId);

   
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lastName = reader["last_name"].ToString();
                                firstName = reader["first_name"].ToString();
                                middleName = reader["middle_name"].ToString();
                            }
                        }
                    }
                }

   
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"An error occurred while retrieving data from the database: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

        public void insertExaminfo(int mathScore, int scienceScore, int englishScore)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    try
                    {
                    conn.Open();
                        string query = "INSERT INTO exam (application_id, scoremath, scoreenglish, scorescience) " +
                                       "VALUES (@application_id, @scoremath, @scoreenglish, @scorescience)";


                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@application_id", UserSession.ApplicationId);
                            cmd.Parameters.AddWithValue("@scoremath", mathScore);
                            cmd.Parameters.AddWithValue("@scoreenglish", englishScore);
                        cmd.Parameters.AddWithValue("@scorescience", scienceScore);

                            int num=cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            MessageBox.Show("Congratulations! You have Completed the exam!\nJust wait for your approval");
                            updateappstatus();
                            

                        }
                        else
                        {
                            MessageBox.Show("Failed to insert exam data.");
                        }
                    }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

        private void updateappstatus()
        {
            string query = "UPDATE application SET admission_status = @status WHERE application_id = @application_id;";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "Ready for Review");
                        cmd.Parameters.AddWithValue("@application_id",UserSession.ApplicationId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("No record found to update.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur
                    MessageBox.Show("Error: " + ex.Message, "Error");
                }
            }
        }

        public void validatethis(Panel panel)
        {
            string query = "SELECT * FROM exam where application_id = @id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", UserSession.ApplicationId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            ;
                            if (reader.Read())
                            {
                                foreach (Control control in panel.Controls)
                                {
                                    control.Enabled = false;
                                }
                                MessageBox.Show("You have already taken this examination. Wait for Approval", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }

        }
    }
            
    }
    

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using entrypoint.PROCESSES.Student;

namespace entrypoint.PROCESSES.Student_application
{
    public class Payment
    {
        public bool validatePayment(TextBox t1, TextBox t2,TextBox t3,ComboBox cbo,PictureBox pic)
        {
            // Validate Account Holder Name
            if (string.IsNullOrWhiteSpace(t1.Text))
            {
                return false;
            }

            // Validate Cellphone Number (Assuming it's a valid 10-digit number)
            if (!Regex.IsMatch(t2.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Please enter a valid 11-digit cellphone number.");
                return false;
            }

            // Validate Reference Number
            if (string.IsNullOrWhiteSpace(t3.Text))
            {
                return false;
            }

            // Validate Date Selection (Check if a valid date is selected)
            if (cbo.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid exam date.");
                return false;
            }

            DateTime selectedDate;
            bool isValidDate = DateTime.TryParse(cbo.SelectedItem.ToString(), out selectedDate);

            if (!isValidDate)
            {
                MessageBox.Show("Invalid exam date selected.");
                return false;
            }

            // Optionally, check if the selected date is not in the past
            if (selectedDate < DateTime.Today)
            {
                MessageBox.Show("The selected exam date cannot be in the past.");
                return false;
            }

            if (pic.Image == null)
            {
                MessageBox.Show("Please upload an image.");
                return false;
            }


            // If all validations pass, return true
            return true;
        }
        public void generateExamDates(ComboBox cbo)
        {
            if (TimePeriods.ExamPeriodStart != null && TimePeriods.ExamPeriodEnd != null)
            {
                DateTime startDate = TimePeriods.ExamPeriodStart;
                DateTime endDate = TimePeriods.ExamPeriodEnd;

                List<string> formattedDateList = new List<string>();
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    string formattedDate = date.ToString("MMMM dd, yyyy"); // Format as "November 20, 2024"
                    formattedDateList.Add(formattedDate);
                }
                cbo.DataSource = formattedDateList;
            }
            else
            {
                MessageBox.Show("Examination start or end date is not set.");
            }
        }
       

        public void insertPayment(string accountHolderName, string cellphoneNumber, string referenceNumber, DateTime dateOfExam, string filepath,string filename)
        {
            
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                conn.Open();

                string query = @"
            INSERT INTO payment (application_id,filepath, account_holder_name, cellphone_number, reference_number, date_of_exam,file_name,pay_at)
            VALUES (@application_id, @filepath, @account_holder_name, @cellphone_number, @reference_number, @date_of_exam,@file_name,@date);
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters for application_id, status, pay_at, account_holder_name, etc.
                    cmd.Parameters.AddWithValue("@application_id", UserSession.ApplicationId);
              

                    // Read the file and convert it to a byte array
                    byte[] fileData = File.ReadAllBytes(filepath);
                    cmd.Parameters.AddWithValue("@filepath", fileData); // Add the file data as a parameter

                    // Add the other parameters
                    cmd.Parameters.AddWithValue("@account_holder_name", accountHolderName);
                    cmd.Parameters.AddWithValue("@cellphone_number", cellphoneNumber);
                    cmd.Parameters.AddWithValue("@reference_number", referenceNumber);
                    cmd.Parameters.AddWithValue("@date_of_exam", dateOfExam);
                    cmd.Parameters.AddWithValue("@file_name", filename);
                    cmd.Parameters.AddWithValue("@date", TimePeriods.CurrentDate);

                    // Execute the command
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Success, Wait for the evaluation of your payment");
                            Stu_AdmissionStatus status1 = new Stu_AdmissionStatus();
                            status1.Show();
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Handle duplicate entry error if the application_id is not unique
                        if (ex.Number == 2627) // Error code for unique constraint violation (duplicate key error)
                        {
                            MessageBox.Show("This application already has a payment record.");
                        }
                        else
                        {
                            MessageBox.Show("Error inserting payment: " + ex.Message);
                        }
                    }
                }
            }
        }

  

        public void validateStep2(Panel panel)
        {
            string query = "SELECT application_id FROM payment where application_id = @app_id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@app_id", UserSession.ApplicationId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            ;
                            if (reader.Read())  // If a record is found, the user has already made an application
                            {
                                // Disable all controls on the form (you can customize which ones to disable)
                                foreach (Control control in panel.Controls)
                                {
                                    control.Enabled = false;  // Disable all controls
                                }

                                // Show a message indicating the user is restricted from proceeding
                                MessageBox.Show("You have already submitted payment.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else
                            {
                                // No application found, allow user to proceed (no changes needed)
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

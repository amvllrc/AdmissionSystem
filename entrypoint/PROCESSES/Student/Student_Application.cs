using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace entrypoint.PROCESSES
{
    public class Student_Application
    {
        
        public bool ValidateInput(Panel panel)
        {
            try
            {
                bool isValid = true;
                bool radioButtonChecked = false;
                bool messageBoxShown = false;

                // Loop through all controls in the panel
                foreach (Control control in panel.Controls)
                {
                    if (control is System.Windows.Forms.GroupBox groupbox)
                    {
                        foreach (Control ctrl in groupbox.Controls)
                        {
                            if (ctrl is TextBox textbox)
                            {
                                if (textbox.Name == "txtContactNum" || textbox.Name == "txtContactMother"|| textbox.Name == "txtContactFather" || textbox.Name == "txtContactGuardian")
                                {
                                    if (!decimal.TryParse(textbox.Text, out _))
                                    {

                                        isValid = false;
                                        if (!messageBoxShown)
                                        {
                                            MessageBox.Show("Please enter a valid contact number.");
                                            textbox.Focus();
                                            messageBoxShown = true;
                                        }
                                    }
                                    else
                                    {
                                        
                                        textbox.BackColor = Color.White;
                                    }

                                }
                                if (string.IsNullOrWhiteSpace(textbox.Text))
                                {
                                    textbox.BackColor = Color.LightPink;
                                    isValid = false; 
                                }
                                else
                                {
                                    textbox.BackColor = Color.White;
                                }
                            }

                            if (ctrl is DateTimePicker dateTimePicker)
                            {
                                if (dateTimePicker.Value.Date == dateTimePicker.MinDate.Date ||
                                    dateTimePicker.Value.Date == DateTime.Now.Date)
                                {
                                    dateTimePicker.BackColor = Color.LightPink;
                                    isValid = false; 
                                    dateTimePicker.Focus();
                                }
                                else
                                {
                                    dateTimePicker.BackColor = Color.White;
                                }
                            }

                            if (ctrl is System.Windows.Forms.RadioButton radioButton)
                            {
                                if (radioButton.Checked)
                                {
                                    radioButtonChecked = true;
                                    Stu_ApplicationForm.Gender=radioButton.Text;


                                }
                                else
                                {
                                    radioButton.BackColor = Color.White;
                                }
                            }

                            if (ctrl is ComboBox cbo)
                            {
                                if (cbo.SelectedItem == null || string.IsNullOrWhiteSpace(cbo.SelectedItem.ToString()))
                                {
                                    cbo.BackColor = Color.LightPink;
                                    isValid = false; 
                                }
                                else
                                {
                                    cbo.BackColor = Color.White;
                                }
                            }
                        }
                    }
                }
                if (!radioButtonChecked)
                {
                    isValid = false; 
                }

                return isValid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
    

        public List<String> GenerateCourse()
        {
            List<string> courses = new List<string>();


            string query = "SELECT name FROM course";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                   
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(reader["name"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error loading courses: " + ex.Message);
                }
            }

            return courses;
        }

        public void validateStep1(Panel panel)
        {
            string query = "SELECT application_id FROM application where user_id = @user_id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", UserSession.ID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            ;
                            if (reader.Read())  
                            {
                                foreach (Control control in panel.Controls)
                                {
                                    control.Enabled = false;  
                                }
                                MessageBox.Show("You have already submitted an application. You cannot proceed with this form.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                
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

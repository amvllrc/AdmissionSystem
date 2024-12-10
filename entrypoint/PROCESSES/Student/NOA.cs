using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace entrypoint.PROCESSES.Student
{
    public class NOA
    {
        public void getStudentNOA()
        {
            string firstName = "", lastName = "", middleName = "",programchoice1="",programchoice2="";
            string query = "SELECT first_name, last_name, middle_name,program_choice_1,program_choice_2 FROM application WHERE application_id = @applicationId";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@applicationId", UserSession.ApplicationId); 

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        firstName = reader["first_name"].ToString();
                        lastName = reader["last_name"].ToString();
                        middleName = reader["middle_name"].ToString();
                        //programchoice1 = reader["program_choice_1"].ToString();
                        //programchoice2 = reader["program_choice_2"].ToString();
                    }
                    reader.Close();
                }

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                {
                    MessageBox.Show("Student details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{lastName}_{firstName}_Admission_Notice.pdf");

                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    using (Document document = new Document())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(document, fs);

                        document.Open();
                        string startupPath = Application.StartupPath;
                        string projectRootPath = Path.GetFullPath(Path.Combine(startupPath, @"..\..\.."));

                        string logoPathLeft = Path.Combine(projectRootPath, "Images", "logoContainer.png"); 
                        string logoPathRight = Path.Combine(projectRootPath, "Images", "makati_logo.png");

                        Image logoLeft = Image.GetInstance(logoPathLeft);
                        logoLeft.ScaleToFit(80f, 80f); // Scale the logo to a smaller size
                        logoLeft.SetAbsolutePosition(70f, document.PageSize.Height - 120f); // Position the left logo at the top left corner
                        document.Add(logoLeft);

                        Image logoRight = Image.GetInstance(logoPathRight);
                        logoRight.ScaleToFit(80f, 80f); // Scale the logo to a smaller size
                        logoRight.SetAbsolutePosition(document.PageSize.Width - 140f, document.PageSize.Height - 120f); // Position the right logo at the top right corner
                        document.Add(logoRight);

                        Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                        Font fontNorma = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                        Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                        Font fontUnderline = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, Font.UNDERLINE);
                        string fullName = $"{firstName.ToUpper()} {middleName.ToUpper()} {lastName.ToUpper()}";

                        Paragraph title = new Paragraph("SWIFT UNIVERSITY", fontBold)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        document.Add(title);
                        Paragraph subtitle = new Paragraph("ADMISSION DEPARTMENT", fontNormal)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        document.Add(subtitle);
                        Paragraph content0 = new Paragraph("NOTICE OF ADMISSION", fontNorma)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        document.Add(content0);
                        Paragraph content = new Paragraph("Academic Year 2024-2025", fontNormal)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        document.Add(content);
                        Paragraph greeting = new Paragraph($"\n\nDear {fullName},", fontUnderline)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(greeting);

                        // Heartwarming message and enrollment announcement
                        Paragraph message = new Paragraph("\nCongratulations! We are pleased to inform you that you have been successfully admitted to our University.", fontNormal)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(message);

                        // Add wait for enrollment announcement message
                        Paragraph waitMessage = new Paragraph("\nPlease wait for the official announcement regarding enrollment and further instructions.", fontNormal)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(waitMessage);

                        // Add more heartwarming messages
                        Paragraph warmMessage = new Paragraph("\nWe are excited to welcome you to our community. Your hard work and dedication have paid off, and we look forward to seeing you on campus soon!", fontNormal)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(warmMessage);

                        Paragraph instructions = new Paragraph("\nPlease visit the campus for further instructions. We look forward to having you with us.", fontNormal)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(instructions);

                        Paragraph closing = new Paragraph("\nBest Regards,", fontNormal)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(closing);

                        Paragraph signature = new Paragraph("\nAdmission Department", fontNormal)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(signature);

                        document.Close();
                    }

                    MessageBox.Show($"Admission notice generated successfully! Check the file at: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    // Handle any PDF generation errors
                    MessageBox.Show($"An error occurred while generating the PDF: {ex.Message}", "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle any database related errors
                MessageBox.Show($"Database error occurred: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any other unforeseen errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

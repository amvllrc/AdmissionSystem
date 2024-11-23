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
            string firstName = "", lastName = "", middleName = "";
            string query = "SELECT first_name, last_name, middle_name FROM application WHERE application_id = @applicationId";

            try
            {
                // Fetching student details from the database
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@applicationId", 11); // Adjust this to fetch the correct application ID

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        firstName = reader["first_name"].ToString();
                        lastName = reader["last_name"].ToString();
                        middleName = reader["middle_name"].ToString();
                    }
                    reader.Close();
                }

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                {
                    MessageBox.Show("Student details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{lastName}_{firstName}_Admission_Notice.pdf");

                // Creating the PDF document with iTextSharp
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    using (Document document = new Document())
                    {
                        PdfWriter.GetInstance(document, fs);

                        document.Open();

                        // Set fonts
                        Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                        Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                        // Set font for underlined name
                        Font fontUnderline = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, Font.UNDERLINE);

                        // Capitalize initials and make name underlined
                        string fullName = $"{firstName.ToUpper()} {middleName.ToUpper()} {lastName.ToUpper()}";

                        // Add the Title
                        Paragraph title = new Paragraph("Notice of Admission", fontBold)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        document.Add(title);

                        // Add the congratulatory message with underlined name
                        Paragraph greeting = new Paragraph($"Dear {fullName},", fontUnderline)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(greeting);

                        // Add the congratulatory message
                        Paragraph message = new Paragraph("\nCongratulations! We are pleased to inform you that you have been successfully admitted to our University.", fontNormal)
                        {
                            Alignment = Element.ALIGN_LEFT
                        };
                        document.Add(message);

                        // Add further instructions
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

                    // Inform the user that the PDF was created successfully
                    MessageBox.Show($"Admission notice generated successfully! Check the file at: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the PDF automatically in the default viewer (browser or PDF reader)
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

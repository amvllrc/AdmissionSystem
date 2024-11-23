using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.Admin
{
    public class DetailsView
    {
        public int appl_id;
        public string fullname = null;
        public string add = null;
        public string birthdate = null;
        public string birthplace = null;
        public string gender = null;
        public string national = null;
        public string civilstat = null;
        public string contactnum = null;
        public string choice1 = null;
        public string choice2 = null;
        public string math = null;
        public string science = null;
        public string english = null;
        public string elem = null;
        public string elemyear = null;
        public string hs = null;
        public string hsyear = null;
        public string shs = null;
        public string shsyear = null;
        public string father = null;
        public string fnum = null;
        public string focc = null;
        public string mother = null;
        public string mnum = null;
        public string mocc = null;
        public string guardian = null;
        public string gnum = null;
        public string gocc = null;

        public byte[] psa = null;
        public byte[] form137 = null;
        public byte[] esig = null;
        public byte[] pic = null;
        public void LoadDetails()
        {
            string queryApplication = "SELECT * FROM application WHERE application_id = @appl_id";
            string queryExam = "SELECT * FROM exam WHERE application_id = @appl_id";

            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                conn.Open();

                // Load data from the application table
                using (SqlCommand cmdApplication = new SqlCommand(queryApplication, conn))
                {
                    cmdApplication.Parameters.AddWithValue("@appl_id", appl_id);
                    using (SqlDataReader reader = cmdApplication.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fullname = reader["last_name"].ToString() + " " + reader["first_name"].ToString() + " " + reader["middle_name"].ToString();
                            add = reader["address"].ToString();
                            DateTime birthDateValue = Convert.ToDateTime(reader["birthdate"]);
                            birthdate = birthDateValue.ToString("yyyy-MM-dd");
                            birthplace = reader["birthplace"].ToString();
                            gender = reader["gender"].ToString();
                            national = reader["nationality"].ToString();
                            civilstat = reader["civil_status"].ToString();
                            contactnum = reader["contact_number"].ToString();
                            choice1 = reader["program_choice_1"].ToString();
                            choice2 = reader["program_choice_2"].ToString();
                            elem = reader["elementary_school"].ToString();
                            elemyear = reader["elementary_graduation_year"].ToString();
                            hs = reader["highschool"].ToString();
                            hsyear = reader["highschool_graduation_year"].ToString();
                            shs = reader["college"].ToString();
                            shsyear = reader["shs_graduation_year"].ToString();
                            father = reader["father_name"].ToString();
                            fnum = reader["contact_father"].ToString();
                            focc = reader["occupation_father"].ToString();
                            mother = reader["mother_name"].ToString();
                            mnum = reader["contact_mother"].ToString();
                            mocc = reader["occupation_mother"].ToString();
                            guardian = reader["guardian_name"].ToString();
                            gnum = reader["contact_guardian"].ToString();
                            gocc = reader["occupation_guardian"].ToString();
                            psa = reader["psa_pdf"] as byte[];
                            esig = reader["esignature_image"] as byte[];
                            pic = reader["image_2x2"] as byte[];
                            form137 = reader["form_137_pdf"] as byte[];
                        }
                        else
                        {
                            MessageBox.Show("Application not found with ID: " + appl_id);
                        }
                    }
                }

                using (SqlCommand cmdExam = new SqlCommand(queryExam, conn))
                {
                    cmdExam.Parameters.AddWithValue("@appl_id", appl_id);
                    using (SqlDataReader reader = cmdExam.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            math = reader["scoremath"].ToString();
                            science = reader["scorescience"].ToString();
                            english = reader["scoreenglish"].ToString();
                        }
                        else
                        {
                            math = "Didn't take the examination yet";
                            science = "Didn't take the examination yet";
                            english = "Didn't take the examination yet";
                        }
                    }
                }
            }



        }
    }
}

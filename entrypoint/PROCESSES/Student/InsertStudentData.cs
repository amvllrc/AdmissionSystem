using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace entrypoint.PROCESSES.Student_application
{
    
    public class InsertStudentData
       

    {
        private Stu_AdmissionStatus adstat=new Stu_AdmissionStatus();
        private ProcessTracker tracker=new ProcessTracker();
        public void InsertStudentApplication(string firstName,
    string lastName,
    string middleName,
    DateTime birthDate,
    string placeOfBirth,
    string gender,
    string nationality,
    string civilStatus,
    string contactNumber,
    string address,
    string elementarySchool,
    string elementaryYear,
    string highSchool,
    string highSchoolYear,
    string seniorHighSchool,
    string seniorHighYear,
    string firstCourseChoice,
    string secondCourseChoice,
    string motherName,
    string motherOccupation,
    string motherContact,
    string fatherName,
    string fatherOccupation,
    string fatherContact,
    string guardianName,
    string guardianOccupation,
    string guardianContact,
    string psaFile,
    string psaName,
    string form137File,
    string form138name,
    string photo2by2,
    string photoname,
    string eSignatureFile,
    string esigname)
        {
            byte[] birthCertData = File.ReadAllBytes(psaFile);
            byte[] form137Data = File.ReadAllBytes(form137File);
            byte[] pictureData = File.ReadAllBytes(photo2by2);
            byte[] eSignatureData = File.ReadAllBytes(eSignatureFile);
            
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO application (" +
                   "first_name, last_name, middle_name, birthdate, birthplace, gender, nationality, civil_status, " +
                   "contact_number, address, elementary_school, elementary_graduation_year, highschool, " +
                   "highschool_graduation_year, college, shs_graduation_year, program_choice_1, program_choice_2, " +
                   "mother_name, father_name, guardian_name, occupation_father, occupation_mother, occupation_guardian, " +
                   "contact_mother, contact_father, contact_guardian, psa_pdf, psa_pdf_filename, form_137_pdf, " +
                   "form_137_pdf_filename, image_2x2, image_2x2_filename, esignature_image, esignature_image_filename,application_status,user_id) " +
                   "VALUES (" +
                   "@FirstName, @LastName, @MiddleName, @BirthDate, @PlaceOfBirth, @Gender, @Nationality, @CivilStatus, " +
                   "@ContactNumber, @Address, @ElementarySchool, @ElementaryYear, @HighSchool, @HighSchoolYear, " +
                   "@College, @ShsGraduationYear, @FirstCourseChoice, @SecondCourseChoice, @MotherName, @FatherName, " +
                   "@GuardianName, @OccupationFather, @OccupationMother, @OccupationGuardian, @ContactMother, @ContactFather, " +
                   "@ContactGuardian, @PsaPdfData, @PsaPdfFileName, @Form137PdfData, @Form137PdfFileName, @Image2x2Data, " +
                   "@Image2x2FileName, @ESignatureImageData, @ESignatureFileName,@status,@id)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@MiddleName", middleName);
                        cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                        cmd.Parameters.AddWithValue("@PlaceOfBirth", placeOfBirth);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Nationality", nationality);
                        cmd.Parameters.AddWithValue("@CivilStatus", civilStatus);
                        cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@ElementarySchool", elementarySchool);
                        cmd.Parameters.AddWithValue("@ElementaryYear", elementaryYear);
                        cmd.Parameters.AddWithValue("@HighSchool", highSchool);
                        cmd.Parameters.AddWithValue("@HighSchoolYear", highSchoolYear);
                        cmd.Parameters.AddWithValue("@College", seniorHighSchool);
                        cmd.Parameters.AddWithValue("@ShsGraduationYear", seniorHighYear);
                        cmd.Parameters.AddWithValue("@FirstCourseChoice", firstCourseChoice);
                        cmd.Parameters.AddWithValue("@SecondCourseChoice", secondCourseChoice);
                        cmd.Parameters.AddWithValue("@MotherName", motherName);
                        cmd.Parameters.AddWithValue("@OccupationMother", motherOccupation);
                        cmd.Parameters.AddWithValue("@ContactMother", motherContact);
                        cmd.Parameters.AddWithValue("@FatherName", fatherName);
                        cmd.Parameters.AddWithValue("@OccupationFather", fatherOccupation);
                        cmd.Parameters.AddWithValue("@ContactFather", fatherContact);
                        cmd.Parameters.AddWithValue("@GuardianName", guardianName);
                        cmd.Parameters.AddWithValue("@OccupationGuardian", guardianOccupation);
                        cmd.Parameters.AddWithValue("@ContactGuardian", guardianContact);

                        
                        cmd.Parameters.AddWithValue("@PsaPdfData", birthCertData);
                        cmd.Parameters.AddWithValue("@PsaPdfFileName", psaName);
                        cmd.Parameters.AddWithValue("@Form137PdfData", form137Data);
                        cmd.Parameters.AddWithValue("@Form137PdfFileName", form138name);// Form 137 file
                        cmd.Parameters.AddWithValue("@Image2x2Data", pictureData);
                        cmd.Parameters.AddWithValue("@Image2x2FileName", photoname); // 2x2 Picture file
                        cmd.Parameters.AddWithValue("@ESignatureImageData", eSignatureData);
                        cmd.Parameters.AddWithValue("@ESignatureFileName", esigname);
                        cmd.Parameters.AddWithValue("@status", "pending");// E-Signature file
                        cmd.Parameters.AddWithValue("@id", UserSession.ID);// E-Signature file


                        int num=cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            adstat.enableControls();
                        }
                    }

                  
                }
                catch (Exception ex)
                {
                    throw new Exception("Error submitting application: " + ex.Message);
                }
            }
        }
        }
    }

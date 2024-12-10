using entrypoint.PROCESSES.Student_application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Stu_Examination : Form
    {
        private QuizChecker quizHelper;
        private ExaminationDetails r;
        public Stu_Examination()
        {
            InitializeComponent();
            quizHelper = new QuizChecker(panel3);
            AnswerKeys();
            r = new ExaminationDetails();
        }
        private void AnswerKeys()
        {

            rbQuestionOneMathB.Tag = "correct";
            rbQuestionTwoMathA.Tag = "correct";
            rbQuestionThreeMathB.Tag = "correct";
            rbQuestionFourMathB.Tag = "correct";
            rbQuestionFiveMathB.Tag = "correct";

            rbQuestionOneEnglishC.Tag = "correct";
            rbQuestionTwoEnglishB.Tag = "correct";
            rbQuestionThreeEnglishD.Tag = "correct";
            rbQuestionFourEnglishB.Tag = "correct";
            rbQuestionFiveEnglishC.Tag = "correct";

            rbQuestionOneScienceB.Tag = "correct";
            rbQuestionTwoScienceA.Tag = "correct";
            rbQuestionThreeScienceB.Tag = "correct";
            rbQuestionFourScienceD.Tag = "correct";
            rbQuestionFiveScienceB.Tag = "correct";

        }
        public void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r.validatethis(panel3);
            r.retrieveNameandOthers();
            txtFirstName.Text = r.firstName;
            txtLastName.Text = r.lastName;
            txtMiddleName.Text = r.middleName;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int mathScore = 0;
            int englishScore = 0;
            int scienceScore = 0;

            if (quizHelper.AllQuestionsAnswered())
            {
                DialogResult result = MessageBox.Show(
                    "Please make sure to check all your answers before clicking OK to submit your scores.",
                    "Confirmation",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    var subjectScores = quizHelper.CalculateScoresBySubject();
                    int totalScore = subjectScores.Values.Sum();

                    if (subjectScores.ContainsKey("MATHEMATICS:"))
                    {
                        mathScore = subjectScores["MATHEMATICS:"];
                    }
                    if (subjectScores.ContainsKey("ENGLISH:"))
                    {
                        englishScore = subjectScores["ENGLISH:"];
                    }
                    if (subjectScores.ContainsKey("SCIENCE:"))
                    {
                        scienceScore = subjectScores["SCIENCE:"];
                    }

                    MessageBox.Show(mathScore+" "+englishScore+" "+scienceScore);

                    bool isInsertSuccessful = r.insertExaminfo(mathScore, scienceScore, englishScore);
                    if (isInsertSuccessful)
                    {
                        Stu_AdmissionStatus status = new Stu_AdmissionStatus();
                        status.Show();
                    }
                    else
                    {
                        MessageBox.Show("There was an issue with inserting the exam data. Please try again.");
                    }
                    foreach (Control control in panel3.Controls)
                    {
                        control.Enabled = false;
                    }
                }
            }
        }

    }
}


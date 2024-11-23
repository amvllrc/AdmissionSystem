using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.Student_application
{
    public class QuizChecker
    {
        private Panel panel1;

        public QuizChecker(Panel panel)
        {
            panel1 = panel;
        }

        // Step 1: Check if all questions are answered
        public bool AllQuestionsAnswered()
        {
            foreach (GroupBox subjectGroup in panel1.Controls.OfType<GroupBox>())
            {
                foreach (GroupBox questionGroup in subjectGroup.Controls.OfType<GroupBox>())
                {
                    bool isAnswered = questionGroup.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
                    if (!isAnswered)
                    {
                        MessageBox.Show("Please answer all questions before submitting.");
                        return false;
                    }
                }
            }
            return true;
        }

        
        public Dictionary<string, int> CalculateScoresBySubject()
        {
            var subjectScores = new Dictionary<string, int>();

            foreach (GroupBox subjectGroup in panel1.Controls.OfType<GroupBox>())
            {
                int subjectScore = 0;

                foreach (GroupBox questionGroup in subjectGroup.Controls.OfType<GroupBox>())
                {
                    var selectedButton = questionGroup.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
                    if (selectedButton != null && selectedButton.Tag?.ToString() == "correct")
                    {
                        subjectScore++;
                    }
                }

                subjectScores[subjectGroup.Text] = subjectScore; // Use the subject GroupBox's Text as the key

               
            }


            return subjectScores;
        }
    }
}

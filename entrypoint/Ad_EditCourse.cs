using entrypoint.PROCESSES.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Ad_EditCourse : Form
    {
        private int c_id;
        private AddEdiTDeleteCourse aedcourse;
        private Ad_CourseManagement parentForm;

        public Ad_EditCourse(int course_id, Ad_CourseManagement parent)
        {
            InitializeComponent();
            c_id = course_id;
            aedcourse=new AddEdiTDeleteCourse();
            parentForm = parent;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Confirm Changes?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (result == DialogResult.OK)
            {

                if (!string.IsNullOrEmpty(textBox2.Text))
                {

                    aedcourse.EditCourse(c_id, textBox2.Text);
                    MessageBox.Show("Course updated successfully.");
                    parentForm.loadTable();
                    this.Close();

                }
                else if (textBox1.Text == textBox2.Text || string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please input New Course Name");
                }

            }
            else
            {
                MessageBox.Show("Changes not saved.");
            }
        }

        private void Ad_EditCourse_Load_1(object sender, EventArgs e)
        {

            textBox1.Text = aedcourse.retrieveCourseName(c_id);
        }
    }
}

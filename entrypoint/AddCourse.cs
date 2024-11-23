using entrypoint.PROCESSES.Admin;
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
    public partial class AddCourse : Form
    {
        private AddEdiTDeleteCourse aed;
        private Ad_CourseManagement parentForm;
        public AddCourse(Ad_CourseManagement parent)
        {
            InitializeComponent();
            aed= new AddEdiTDeleteCourse();
            parentForm = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !(aed.isExist(textBox1.Text)))
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to add this course?", 
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aed.insertToCourse(textBox1.Text);
                    parentForm.loadTable();
                    this.Close();
                }
            }
            else if (aed.isExist(textBox1.Text))
            {
                MessageBox.Show("The course is already in the curriculum");
            }
            else 
            {
                MessageBox.Show("Course name cannot be empty");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

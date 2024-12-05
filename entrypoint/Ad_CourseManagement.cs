using entrypoint;
using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace entrypoint
{
    public partial class Ad_CourseManagement : Form
    {
        private Course course;
        private AddEdiTDeleteCourse aedcourse;
       
        public Ad_CourseManagement()
        {
            InitializeComponent();
            course= new Course();
            aedcourse=new AddEdiTDeleteCourse();
            
        }

        private void exitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CourseManagement_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        public void loadTable()
        {
            string query = "SELECT course_id as ID,name as 'COURSE NAME' FROM course";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    dataAdapter.Fill(dataTable);
                }   
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        
        }

     

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Ad_Dashboard dashboardForm = new Ad_Dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void btnAppList_Click(object sender, EventArgs e)
        {
            ApplicationList applicationListForm = new ApplicationList();
            applicationListForm.Show();
            this.Hide();
        }

        private void btnPaymentList_Click(object sender, EventArgs e)
        {
            Ad_PaymentList paymentListForm = new Ad_PaymentList();
            paymentListForm.Show();
            this.Hide();
        }

      

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            AddCourse ad = new AddCourse(this);
            ad.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            int course_id=aedcourse.retrieveCellRow(dataGridView1);
            Ad_EditCourse editForm = new Ad_EditCourse(course_id, this);
            editForm.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int course_id = aedcourse.retrieveCellRow(dataGridView1);
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this course? This action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                aedcourse.delCourse(course_id);
                loadTable();
            }
        }
    }
}

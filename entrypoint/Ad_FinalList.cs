using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace entrypoint
{
    public partial class Ad_FinalList : Form
    {
        private ControlValidator validator;
        public string search = "";
        public string sortby = "";
        public FinalList Final;
        public bool chkone { get; set; }
        public bool chktwo { get; set; }
        public bool chkthree { get; set; }
        public List<string> filters { get; set; } = new List<string>();
        public ControlValidator Validator { get => validator; set => validator = value; }

        public Ad_FinalList()
        {
            InitializeComponent();
            Final = new FinalList();
            Final.Dgv = appListDataGrid;
            Validator = new ControlValidator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadlist();
            Final.addApproveButton();
            Final.addRejectButton();
            button1.Visible = false;

            appListDataGrid.EnableHeadersVisualStyles = false;
            appListDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;

        }
        

       

        private void loadlist()
        {
            Final.loaditem();
           
        }
        private bool ValidateThis(int applic_id,int rowIndex)
        {
            if (Validator.Decision(applic_id).Equals("Admitted"))
            {
                MessageBox.Show("This student is already Admitted");
                DisableButtons(rowIndex);
                return true;
            }
            else if (Validator.Decision(applic_id).Equals("Rejected"))
            {
                MessageBox.Show("This student is already Rejected");
                DisableButtons(rowIndex);
                return true;
            }
            return false;

        }
        private void appListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                string cellText = appListDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (cellText == "Approve")
                {
                    int applicationIdValue = Convert.ToInt32(appListDataGrid.Rows[e.RowIndex].Cells[2].Value);

                    if (!ValidateThis(applicationIdValue, e.RowIndex))
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to approve this application?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Final.UpdateApplicationStatus(applicationIdValue, "Admitted");
                            DisableButtons(e.RowIndex); 
                            loadlist();
                        }
                    }
                    else
                    {
                        DisableButtons(e.RowIndex);
                    }
                }
                else if (cellText == "Reject")
                {
                    int applicationIdValue = Convert.ToInt32(appListDataGrid.Rows[e.RowIndex].Cells[2].Value);

                    if (!ValidateThis(applicationIdValue, e.RowIndex))
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to reject this application?", "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Final.UpdateApplicationStatus(applicationIdValue, "Rejected");
                            DisableButtons(e.RowIndex);
                            loadlist();
                        }
                    }
                    else
                    {
                        DisableButtons(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("Please click a valid button (Approve/Reject).", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        
        }

        private void appListDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (appListDataGrid.Columns[e.ColumnIndex].Name == "approveButton" || appListDataGrid.Columns[e.ColumnIndex].Name == "rejectButton")
            {
                int applicationIdValue = Convert.ToInt32(appListDataGrid.Rows[e.RowIndex].Cells[2].Value);

                if (Validator.Decision(applicationIdValue).Equals("Admitted") || Validator.Decision(applicationIdValue).Equals("Rejected"))
                {
                    e.CellStyle.BackColor = Color.White; 
                    e.CellStyle.ForeColor = Color.Gray; 
                    e.CellStyle.SelectionBackColor = Color.Gray; 
                    e.CellStyle.SelectionForeColor = Color.Gray; 
                }
                else
                {
                    if (appListDataGrid.Columns[e.ColumnIndex].Name == "approveButton")
                    {
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else if (appListDataGrid.Columns[e.ColumnIndex].Name == "rejectButton")
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                e.CellStyle.BackColor = appListDataGrid.Rows[e.RowIndex].Selected ?
                    appListDataGrid.DefaultCellStyle.SelectionBackColor :
                    appListDataGrid.DefaultCellStyle.BackColor;
            }
        }
        private void DisableButtons(int rowIndex)
        {
            appListDataGrid.Rows[rowIndex].Cells["approveButton"].ReadOnly = true;
            appListDataGrid.Rows[rowIndex].Cells["approveButton"].Style.BackColor = Color.Gray;
            appListDataGrid.Rows[rowIndex].Cells["approveButton"].Style.ForeColor = Color.Gray;
            appListDataGrid.Rows[rowIndex].Cells["rejectButton"].ReadOnly = true;
            appListDataGrid.Rows[rowIndex].Cells["rejectButton"].Style.BackColor = Color.Gray;
            appListDataGrid.Rows[rowIndex].Cells["rejectButton"].Style.ForeColor = Color.Gray;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                button1.Visible = true;
            }
            else button1.Visible = false;
        }

        private void btnAppListSearch_Click(object sender, EventArgs e)
        {
            search = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(search))
            {
                FetchData(sortby, filters, search);
            }
            else
            {
                MessageBox.Show("Invalid Search");
            }
        }

        private void appListSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSortIndex = appListSort.SelectedIndex;
            switch (selectedSortIndex)
            {
                case 0:
                    sortby = "taken_at";
                    break;
                case 1:
                    sortby = "last_name";
                    break;
                case 2:
                    sortby = "AverageScore DESC";
                    break;
                default:
                    sortby = "taken_at";
                    break;
            }
            FetchData(sortby, filters, search);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Ad_FinalListFilter nn = new Ad_FinalListFilter(this);
            nn.ShowDialog();
        }

        public void FetchData(string sort, List<string> status, String search)
        {

            Final.executequeries(sort, status, search);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            search = "";
            FetchData(sortby, filters, search);
        }
    }
}

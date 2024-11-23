using entrypoint.PROCESSES;
using entrypoint.PROCESSES.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace entrypoint
{
    public partial class ApplicationList : Form
    {

        public bool chkone { get; set; }
        public bool chktwo { get; set; }
        public bool chkthree { get; set; }
        public List<string> filters { get; set; } = new List<string>();
        public string search = "";
        public string sort = "";

        private QueryButtons qb;
        public ApplicationList()
        {
            InitializeComponent();
            qb= new QueryButtons();
            qb.dg = appListDataGrid;

            
            
        }
        private void ApplicationList_Load(object sender, EventArgs e)
        {
            LoadLis();
            qb.AddViewMoreButtonColumn(appListDataGrid);
            button1.Visible = false;
           btnAppListSearch.FlatAppearance.BorderSize = 0;

            appListDataGrid.EnableHeadersVisualStyles = false;
            appListDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
        }

        public void LoadLis()
        {
            qb.LoadList();
        }

        private void btnAppListSearch_Click(object sender, EventArgs e)
        {
            search = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(search))
            {
                FetchData(sort,filters,search);
            }
            else
            {
                MessageBox.Show("Invalid Search");
            }

        }

        public void FetchData(string sort, List<string> status, String search)
        {

            qb.executequeries(sort,status,search);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(textBox1.Text)){
                button1.Visible = true;
            }
            else button1.Visible = false;
        }

        private void appListSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort=qb.getItemCbo(appListSort);
            FetchData(sort, filters, search);


        }
        private void btnAppListFilter_Click_1(object sender, EventArgs e)
        {
            Ad_AppListFilter app=new Ad_AppListFilter(this);
            app.ShowDialog();
        }
        private void appListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string cellText = appListDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            if (cellText == "View More")
            {
                viewDetails vie = new viewDetails(this);
                vie.appli_id = Convert.ToInt32(appListDataGrid.Rows[e.RowIndex].Cells[1].Value);

               
                vie.ShowDialog();

            }
            else MessageBox.Show("PLease Click Valid Cell!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            search = "";
            FetchData(sort, filters, search);

        }
    }
}

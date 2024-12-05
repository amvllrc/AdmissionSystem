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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace entrypoint
{
    public partial class Ad_PaymentList : Form
    {
        private QueryPayment qp;
        public bool chkone{ get; set; }
        public bool chktwo { get; set; }
        public bool chkthree { get; set; }
        public List<string> filters { get; set; } = new List<string>();
        public string search = "";
        public string sort = "";
        public Ad_PaymentList()
        {
            InitializeComponent();
            qp= new QueryPayment();
            qp.dgv = payListDataGrid;

        }

        private void PaymentList_Load(object sender, EventArgs e)
        {
            
            loadpay();
            qp.AddViewMoreButtonColumn(payListDataGrid);
            button1.Visible = false;
            btnAppListSearch.FlatAppearance.BorderSize = 0;

            payListDataGrid.EnableHeadersVisualStyles = false;
            payListDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;




        }
        public void loadpay()
        {
            qp.LoadList();
        }


        private void btnAppListSearch_Click(object sender, EventArgs e)
        {
            search = textBox2.Text.Trim();

            if (!string.IsNullOrEmpty(search))
            {
                FetchData(sort, filters, search);
            }
            else
            {
                MessageBox.Show("Invalid Search");
            }
        }

        private void btnPayListFilter_Click_1(object sender, EventArgs e)
        {
            Ad_PayListFilter nn=new Ad_PayListFilter(this);
            nn.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            sort=qp.getItemCbo(comboBox1);
            FetchData(sort, filters, search);
        }

        private void payListDataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            string cellText = payListDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            if (cellText == "View More")
            {
                Ad_PayListViewDetails vie = new Ad_PayListViewDetails(this);
                vie.applic_id = Convert.ToInt32(payListDataGrid.Rows[e.RowIndex].Cells[2].Value);


                vie.ShowDialog();

            }
            else MessageBox.Show("PLease Clicked Valid Cell!");
        }

        public void FetchData(string sort, List<string> status, String search)
        {

            qp.executequeries(sort, status, search);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            search = "";
            FetchData(sort, filters, search);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                button1.Visible = true;
            }
            else button1.Visible = false;
        }

        private void payListDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (payListDataGrid.Columns[e.ColumnIndex].Name == "viewMoreButton")
            {
                e.CellStyle.BackColor = Color.Yellow;
                e.CellStyle.ForeColor = Color.Black;
            }
        }
    }
}

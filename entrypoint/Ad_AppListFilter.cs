﻿using entrypoint.PROCESSES.Admin;
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
    public partial class Ad_AppListFilter : Form
    {
        private ApplicationList form;
        private QueryButtons quer;
        public Ad_AppListFilter(ApplicationList exform)
        {
            InitializeComponent();
            form = exform;
            quer=new QueryButtons();
        }

        private void AppListFilter_Load(object sender, EventArgs e)
        {
            checkBox4.Checked = form.chkone;
            checkBox2.Checked = form.chktwo;
            checkBox3.Checked = form.chkthree;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         

            form.chkone = checkBox4.Checked;
            form.chktwo = checkBox2.Checked;
            form.chkthree = checkBox3.Checked;
            form.filters = UpdateFilter();

            form.FetchData(form.sort, form.filters, form.search);

            this.Close();
        }
        private List<string> UpdateFilter()
        {
            List<string> filterby = new List<string>();


            if (checkBox2.Checked)
            {

                filterby.Add("pending");
               
            }

            if (checkBox3.Checked)
            {

                filterby.Add("approved");
             
            }
            if (checkBox4.Checked)
            {

                filterby.Add("rejected");
                
            }

            return filterby;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            checkBox4.Checked = checkBox2.Checked = checkBox3.Checked = false;
            form.chkone = form.chktwo = form.chkthree = false;

            form.filters = new List<string>();
            form.FetchData(form.sort, form.filters, form.search);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrypoint.PROCESSES.Student
{
    public partial class Stu_NOA : Form
    {
        public Stu_NOA()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NOA noa = new NOA();
            noa.getStudentNOA();
            this.Hide();
        }
    }
}

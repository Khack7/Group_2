using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace M.C.K.Inventory_Management_Software
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //CrystalReports.crptProducts products = new CrystalReports.crptProducts();
            //products.SetDatabaseLogon("group2fa202330", "1867186");
            //Form3 f3 = new Form3();
            ////f3.crystalReportViewer1.ReportSource = null;
            ////f3.crystalReportViewer1.ReportSource = products;
            //f3.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ProgOps.OpenDatabase();
            ProgOps.DatabaseDGVCommand(dataGridView1);
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgOps.CloseDatabase();
        }
    }
}

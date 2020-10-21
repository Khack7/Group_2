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
using System.Media;

namespace M.C.K.Inventory_Management_Software
{
    public partial class Form6 : Form
    {
        string myState;
        int myBookmark;

        public Form6()
        {
            InitializeComponent();
        }

        CurrencyManager ordersManager;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ProgOps.OpenDatabase();
            ProgOps.DatabaseOrdersTBXCommand(textBox1, textBox2, textBox3, textBox4, textBox5);
            ordersManager = (CurrencyManager)BindingContext[ProgOps.DTOrdersTable];
            SetState("Veiw");
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myState.Equals("Edit") || myState.Equals("Add"))
            {
                MessageBox.Show("You must finish the current edit before stopping the application.", "Finish Edit!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            else
            {
                try
                {
                    ProgOps.UpdateOrdersTBXOnClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving database to file: \r\n" + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ProgOps.CloseDisposeOrdersTBXData();
            }
        }

        private void SetState(string appState)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            ordersManager.Position = 0;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ordersManager.Position--;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ordersManager.Position++;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            ordersManager.Position = ordersManager.Count - 1;
        }
    }
}

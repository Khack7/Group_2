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
    public partial class Form5 : Form
    {
        string myState;
        int myBookmark;

        public Form5()
        {
            InitializeComponent();
        }

        CurrencyManager productsManager;

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

        private void Form5_Load(object sender, EventArgs e)
        {
            ProgOps.OpenDatabase();
            ProgOps.DatabaseProductsTBXCommand(textBox1, textBox2, textBox3, textBox4);
            productsManager = (CurrencyManager)BindingContext[ProgOps.DTProductsTable];
            SetState("Veiw");
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
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
                    ProgOps.UpdateProductsTBXOnClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving database to file: \r\n" + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ProgOps.CloseDisposeProductsTBXData();
            }
        }

        private void SetState(string appState)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            productsManager.Position = 0;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            productsManager.Position--;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            productsManager.Position++;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            productsManager.Position = productsManager.Count - 1;
        }
    }
}

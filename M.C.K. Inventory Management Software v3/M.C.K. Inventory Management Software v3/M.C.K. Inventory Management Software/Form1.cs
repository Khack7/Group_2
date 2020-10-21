using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M.C.K.Inventory_Management_Software
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hlpUser.HelpNamespace = Application.StartupPath + "\\Help.chm";
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your password is your employee ID number", "Hint", MessageBoxButtons.OK);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtLogin.Focus();
        }

        private void TxtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            txtLogin.MaxLength = 8; //SUBJECT TO CHANGE
        }

        private void BtnPassShow_Click(object sender, EventArgs e)
        {
            string TextOnButton = btnPassShow.Text;

            switch(TextOnButton)
            {
                case "Show":
                    txtLogin.PasswordChar = '\0';
                    btnPassShow.Text = "Hide";
                    break;
                case "Hide":
                    txtLogin.PasswordChar = '•';
                    btnPassShow.Text = "Show";
                    break;
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();

            //MessageBox.Show("This program's function is to keep track of and edit your current inventory", "About",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, hlpUser.HelpNamespace);
            //MessageBox.Show("Enter password in the texbox and click login to continue.\n" +
            //    "If your password is incorrect, try again", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool AcceptedPassword = false;

            List<string> passwords = new List<string>();
            passwords.Add("0012345678");
            passwords.Add("0087654321"); //PLACEHOLDERS!!
            passwords.Add("0024681012"); //WILL BE REPLACED WITH THE PASSWORDS FROM THE DATABASE
            passwords.Add("0013579113");
            passwords.Add("0091375642");

            Form3 f3 = new Form3();

            if (passwords.Contains(txtLogin.Text))
            {
                txtLogin.Text = "";
                txtLogin.Focus();
                string TextOnButton = btnPassShow.Text;

                switch (TextOnButton)
                {
                    case "Hide":
                        txtLogin.PasswordChar = '•';
                        btnPassShow.Text = "Show";
                        break;
                }
                //this.Hide();//FIND A WAY TO UNDO THIS. OR JUST LEAVE VISIBLE
                f3.ShowDialog();
                AcceptedPassword = true;

            }
            if (AcceptedPassword == false)
            {
                MessageBox.Show("INVALID PASSWORD", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Text = "";
                txtLogin.Focus();
            }
        }
    }
}

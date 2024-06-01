using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formForgotPassword1 : Form
    {
        public formForgotPassword1()
        {
            InitializeComponent();
        }
        DataTable dtUsername = new DataTable();
        Methods methods = new Methods();
        private void formForgotPassword1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            dtUsername = new DataTable();
            string query = $"select username\r\nfrom akun\r\nwhere jabatan = '{Methods.jabatan}';";
            methods.command(query, dtUsername);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            
            bool ada = false;
           if (txtBoxUsername.Text != "Answer")
            {
                foreach (DataRow dt in dtUsername.Rows)
                {
                    if (dt["username"].ToString() == txtBoxUsername.Text)
                    {
                        ada = true;
                        break;
                    }
                }
                if (ada)
                {
                    // forgot pass 2
                    formForgotPassword2 f2 = new formForgotPassword2(txtBoxUsername.Text);
                    methods.NewForm(this, f2);
                    labelIncorrect.Visible = false;
                }
                else
                {
                    labelIncorrect.Text = "Sorry, we could not find your account.";
                    labelIncorrect.Visible = true;
                }
            }
           else
            {
                labelIncorrect.Text = "Please input username to continue.";
                labelIncorrect.Visible = true;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            // BALIK KE FORM SIGNIN
            FormSignin signin = new FormSignin(Methods.jabatan);
            methods.NewForm(this, signin);
        }

        private void txtBoxUsername_Enter(object sender, EventArgs e)
        {
            if (txtBoxUsername.Text == "Username")
            {
                txtBoxUsername.ForeColor = SystemColors.WindowText;
                txtBoxUsername.Text = "";
            }
        }

        private void txtBoxUsername_Leave(object sender, EventArgs e)
        {
            if (txtBoxUsername.Text == "")
            {
                txtBoxUsername.ForeColor = SystemColors.WindowText;
                txtBoxUsername.Text = "Username";
            }
        }
    }
}

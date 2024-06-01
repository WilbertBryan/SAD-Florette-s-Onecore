using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formEditPassword : Form
    {
        public formEditPassword()
        {
            InitializeComponent();
        }

        DataTable dtAkun = new DataTable();
        Methods methods = new Methods();
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formEditPassword_Load(object sender, EventArgs e)
        {
            dtAkun = new DataTable();
            string query = "select username,password,jabatan from Akun;";
            methods.command(query, dtAkun);
        }

        private void VisibleOn1_Click_1(object sender, EventArgs e)
        {
            txtBoxCurrentPas.UseSystemPasswordChar = false;
            VisibleOn1.Visible = false;
            VisibleOff1.Visible = true;
        }

        private void VisibleOn2_Click(object sender, EventArgs e)
        {
            txtBoxNewPas.UseSystemPasswordChar = false;
            VisibleOn2.Visible = false;
            VisibleOff2.Visible = true;
        }

        private void VisibleOn3_Click(object sender, EventArgs e)
        {
            txtBoxConfirmPas.UseSystemPasswordChar = false;
            VisibleOn3.Visible = false;
            VisibleOff3.Visible = true;
        }

        private void VisibleOff1_Click(object sender, EventArgs e)
        {
            VisibleOff1.Visible = false;
            VisibleOn1.Visible = true;
            txtBoxCurrentPas.UseSystemPasswordChar = true;

            if (txtBoxCurrentPas.Text != null)
            {
                txtBoxCurrentPas.UseSystemPasswordChar = true;
            }
            else if (txtBoxCurrentPas.Text == null)
            {
                txtBoxCurrentPas.UseSystemPasswordChar = false;
            }
        }

        private void VisibleOff2_Click(object sender, EventArgs e)
        {
            VisibleOff2.Visible = false;
            VisibleOn2.Visible = true;
            txtBoxNewPas.UseSystemPasswordChar = true;

            if (txtBoxNewPas.Text != null)
            {
                txtBoxNewPas.UseSystemPasswordChar = true;
            }
            else if (txtBoxNewPas.Text == null)
            {
                txtBoxNewPas.UseSystemPasswordChar = false;
            }
        }

        private void VisibleOff3_Click(object sender, EventArgs e)
        {
            VisibleOff3.Visible = false;
            VisibleOn3.Visible = true;
            txtBoxConfirmPas.UseSystemPasswordChar = true;

            if (txtBoxConfirmPas.Text != null)
            {
                txtBoxConfirmPas.UseSystemPasswordChar = true;
            }
            else if (txtBoxConfirmPas.Text == null)
            {
                txtBoxConfirmPas.UseSystemPasswordChar = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // CONVERT MD5
            string newPass = convertPass(txtBoxNewPas.Text);
            string currentPass = convertPass(txtBoxCurrentPas.Text);

            // checking
            bool match = false;
            bool currentPasswordMatch = false;
            
            foreach (DataRow dt in dtAkun.Rows)
            {
                
                if (dt["username"].ToString() == Methods.username && dt["password"].ToString() == currentPass && dt["jabatan"].ToString() == Methods.jabatan)
                {
                    currentPasswordMatch = true;
                    break;
                }
            }

            // checkMatch
            if (txtBoxNewPas.Text == txtBoxConfirmPas.Text)
            {
                match = true;
            }

            // checkError
            if (txtBoxCurrentPas.Text == "" || txtBoxCurrentPas.Text == "" || txtBoxConfirmPas.Text == "")
            {
                labelIncorrect.Text = "Please fill all the required fields.";
                labelIncorrect.Visible = true;
            }
            else if (currentPasswordMatch && match) // UPDATE PASSWORD
            {
                labelIncorrect.Visible = false; 
                string q = $"update akun set password = '{newPass}' where username = '{Methods.username}'";
                methods.commandIUD(q);
                this.Close();
                formSuccess f = new formSuccess("Your Account Has Been Successfully Changed");
                f.ShowDialog();
            } else if (currentPasswordMatch == false)
            {
                labelIncorrect.Text = "Current password is wrong.";
                labelIncorrect.Visible = true;
                
            } else if (match == false)
            {
                labelIncorrect.Text = "Password do not match.";
                labelIncorrect.Visible = true;
            }

        }

        private static string convertPass(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass));
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            pass = stringBuilder.ToString();
            return pass;
        }

        private void txtBoxCurrentPas_Leave_1(object sender, EventArgs e)
        {
            if (txtBoxCurrentPas.Text != null && VisibleOff1.Visible == true)
            {
                txtBoxCurrentPas.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxCurrentPas.UseSystemPasswordChar = true;
            }
        }

        private void txtBoxNewPas_Leave(object sender, EventArgs e)
        {
            if (txtBoxNewPas.Text != null && VisibleOff2.Visible == true)
            {
                txtBoxNewPas.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxNewPas.UseSystemPasswordChar = true;
            }
        }

        private void txtBoxConfirmPas_Leave(object sender, EventArgs e)
        {
            if (txtBoxConfirmPas.Text != null && VisibleOff3.Visible == true)
            {
                txtBoxConfirmPas.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxConfirmPas.UseSystemPasswordChar = true;
            }
        }
    }
}

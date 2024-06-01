using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formForgotPassword3 : Form
    {
        Methods methods = new Methods();
        string username;
        public formForgotPassword3(string namaPengguna)
        {
            InitializeComponent();
            username = namaPengguna;
        }

        private void formForgotPassword3_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label4;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            FormSignin signin = new FormSignin(Methods.jabatan);
            methods.NewForm(this, signin);
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            if(txtBoxNewPassword.Text != "New Password" && txtBoxConfirmPassword.Text != "Confirm Password")
            {
                if (txtBoxNewPassword.Text == txtBoxConfirmPassword.Text)
                {
                    // insert ke database
                    string input = txtBoxConfirmPassword.Text;

                    MD5 md5 = new MD5CryptoServiceProvider();
                    md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
                    byte[] result = md5.Hash;

                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 0; i < result.Length; i++)
                    {
                        stringBuilder.Append(result[i].ToString("x2"));
                    }
                    input = stringBuilder.ToString();
                    string query = $"update akun set password = '{input}' where username = '{username}';";
                    methods.commandIUD(query);

                    labelIncorrect.Visible = false;
                    formSuccess f = new formSuccess("New password has been saved.");
                    f.ShowDialog();

                    FormSignin signin = new FormSignin(Methods.jabatan);
                    methods.NewForm(this, signin);
                }
                else
                {
                    labelIncorrect.Text = "Password don’t match.";
                    labelIncorrect.Visible = true;
                }              
            } else
            {
                labelIncorrect.Text = "Please fill all the requirements." ;
                labelIncorrect.Visible = true;
            }
        }

        private void VisibleOff1_Click(object sender, EventArgs e)
        {
            VisibleOff1.Visible = false;
            VisibleOn1.Visible = true;
            txtBoxNewPassword.UseSystemPasswordChar = true;

            if (txtBoxNewPassword.Text != null)
            {
                txtBoxNewPassword.UseSystemPasswordChar = true;
            }
            else if (txtBoxNewPassword.Text == null)
            {
                txtBoxNewPassword.UseSystemPasswordChar = false;
            }
        }

        private void VisibleOn1_Click(object sender, EventArgs e)
        {
            txtBoxNewPassword.UseSystemPasswordChar = false;
            VisibleOn1.Visible = false;
            VisibleOff1.Visible = true;
        }

        private void VisibleOn2_Click(object sender, EventArgs e)
        {
            txtBoxConfirmPassword.UseSystemPasswordChar = false;
            VisibleOn2.Visible = false;
            VisibleOff2.Visible = true;
        }

        private void VisibleOff2_Click(object sender, EventArgs e)
        {
            VisibleOff2.Visible = false;
            VisibleOn2.Visible = true;
            txtBoxConfirmPassword.UseSystemPasswordChar = true;

            if (txtBoxConfirmPassword.Text != null)
            {
                txtBoxConfirmPassword.UseSystemPasswordChar = true;
            }
            else if (txtBoxConfirmPassword.Text == null)
            {
                txtBoxConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtBoxNewPassword_Enter(object sender, EventArgs e)
        {
            if (txtBoxNewPassword.Text == "New Password")
            {
                txtBoxNewPassword.ForeColor = SystemColors.WindowText;
                txtBoxNewPassword.Text = "";
            }
        }

        private void txtBoxNewPassword_Leave(object sender, EventArgs e)
        {
            if (txtBoxNewPassword.Text == "")
            {
                txtBoxNewPassword.ForeColor = Color.Gray;
                txtBoxNewPassword.Text = "New Password";
                txtBoxNewPassword.UseSystemPasswordChar = false;
            }
            else if (VisibleOff1.Visible == true && txtBoxNewPassword.Text != "")
            {
                txtBoxNewPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (txtBoxConfirmPassword.Text == "Confirm Password")
            {
                txtBoxConfirmPassword.ForeColor = SystemColors.WindowText;
                txtBoxConfirmPassword.Text = "";
            }
        }

        private void txtBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtBoxConfirmPassword.Text == "")
            {
                txtBoxConfirmPassword.ForeColor = Color.Gray;
                txtBoxConfirmPassword.Text = "Confirm Password";
                txtBoxConfirmPassword.UseSystemPasswordChar = false;
            }
            else if (VisibleOff2.Visible == true && txtBoxConfirmPassword.Text != "")
            {
                txtBoxConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        
    }
}

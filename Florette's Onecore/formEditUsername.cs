using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
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
    public partial class formEditUsername : Form
    {
        public formEditUsername()
        {
            InitializeComponent();
        }

        DataTable dtAkun= new DataTable();
        Methods methods = new Methods();
        private void formEditUsername_Load(object sender, EventArgs e)
        {
            dtAkun = new DataTable();
            string query = "select username,password,jabatan from Akun;";
            methods.command(query, dtAkun);
        }
        private void VisibleOff_Click(object sender, EventArgs e)
        {
            VisibleOff.Visible = false;
            VisibleOn.Visible = true;
            txtBoxPassword.UseSystemPasswordChar = true;

            if (txtBoxPassword.Text != null)
            {
                txtBoxPassword.UseSystemPasswordChar = true;
            }
            else if (txtBoxPassword.Text == null)
            {
                txtBoxPassword.UseSystemPasswordChar = false;
            }
        }

        private void VisibleOn_Click(object sender, EventArgs e)
        {
            txtBoxPassword.UseSystemPasswordChar = false;
            VisibleOn.Visible = false;
            VisibleOff.Visible = true;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // CONVERT MD5
            string input = txtBoxPassword.Text;

            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            input = stringBuilder.ToString();

            // checking
            bool found = false;
            bool kembar = false;
            foreach (DataRow dt in dtAkun.Rows)
            {
                if (dt["username"].ToString() == txtBoxUsername.Text)
                {
                    found = false;
                    kembar = true;
                    break;
                }
                else if (dt["username"].ToString() == Methods.username && dt["password"].ToString() == input && dt["jabatan"].ToString() == Methods.jabatan)
                {
                    found = true;
                    break;
                }
            }

            if (found == true)
            {
                labelIncorrect.Visible = false;
                string query = $"update akun\r\nset username = '{txtBoxUsername.Text}' \r\nwhere username = '{Methods.username}';";
                methods.commandIUD(query);

                methods.simpanUsername(txtBoxUsername.Text);

                dtAkun = new DataTable();
                string q = "select username,password,jabatan from Akun;";
                methods.command(q, dtAkun);

                povOwner.Owner.btnAdmin.Text = Methods.username;

                formSuccess f = new formSuccess("Your Account Has Been Successfully Changed");
                this.Close();
                f.ShowDialog();

            }
            else if (txtBoxUsername.Text == "" || txtBoxPassword.Text == "")
            {
                labelIncorrect.Text = "Please fill all the required fields.";
                labelIncorrect.Visible = true;
            }
            else if (kembar)
            {
                labelIncorrect.Text = "Username already exist.";
                labelIncorrect.Visible = true;
            } else
            {
                labelIncorrect.Text = "Incorrect Password.";
                labelIncorrect.Visible = true;
            }
        }

        private void txtBoxPassword_Leave(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text != null && VisibleOff.Visible == true)
            {
                txtBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}

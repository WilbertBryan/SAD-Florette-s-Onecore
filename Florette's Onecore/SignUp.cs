using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Florette_s_Onecore
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        DataTable dtAkun = new DataTable();
        Methods methods = new Methods();
        List<string> questions = new List<string>()
        {
            "What is your favorite movie?",
            "What is your eldest cousin name?",
            "What is your mother name?",
            "What is your dream job?",
            "In what city was your father born?",
            "What is your mother language?"
        };

        string simpanKalimat1, simpanKalimat2;

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(167, 215, 197);


            txtBoxUsername.Text = "Username";
            txtBoxUsername.ForeColor = Color.Gray;
            txtBoxPassword.Text = "Password";
            txtBoxPassword.ForeColor = Color.Gray;

           
            ComboBoxQuestion1.SelectedText = "Question 1";
            ComboBoxQuestion1.ForeColor = Color.Gray;
            ComboBoxQuestion2.SelectedText = "Question 2";
            ComboBoxQuestion2.ForeColor = Color.Gray;

            txtBoxAnswer1.SelectedText = "Answer";
            txtBoxAnswer1.ForeColor = Color.Gray;
            txtBoxAnswer2.SelectedText = "Answer";
            txtBoxAnswer2.ForeColor = Color.Gray;

            // isi Question
            foreach (string q in questions)
            {
                ComboBoxQuestion1.Items.Add(q);
                ComboBoxQuestion2.Items.Add(q);
            }
            ComboBoxQuestion1.SelectedIndex = 0;
            ComboBoxQuestion1_SelectionChangeCommitted(ComboBoxQuestion1, e);
            ComboBoxQuestion2.SelectedIndex = 0;
            ComboBoxQuestion2_SelectionChangeCommitted(ComboBoxQuestion2, e);

            // Simpan smua data akun ke dtAkun
            dtAkun = new DataTable();
            string query = "select username,password from Akun;";
            methods.command(query, dtAkun);
        }

     
        private void ComboBoxQuestion1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (simpanKalimat1 != ComboBoxQuestion1.SelectedItem.ToString())
            {
                if (simpanKalimat1 != null && !ComboBoxQuestion2.Items.Contains(simpanKalimat1))
                {
                    ComboBoxQuestion2.Items.Add(simpanKalimat1);
                }
                simpanKalimat1 = ComboBoxQuestion1.SelectedItem.ToString();
            }

            if (ComboBoxQuestion1.SelectedItem != null)
            {
                string selectedName = ComboBoxQuestion1.SelectedItem.ToString();

                if (ComboBoxQuestion2.Items.Contains(selectedName))
                {
                    ComboBoxQuestion2.Items.Remove(selectedName);
                }
            }
        }
        private void ComboBoxQuestion2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (simpanKalimat2 != ComboBoxQuestion2.SelectedItem.ToString())
            {
                if (simpanKalimat2 != null && !ComboBoxQuestion1.Items.Contains(simpanKalimat2))
                {
                    ComboBoxQuestion1.Items.Add(simpanKalimat2);
                }
                simpanKalimat2 = ComboBoxQuestion2.SelectedItem.ToString();
            }

            if (ComboBoxQuestion2.SelectedItem != null)
            {
                string selectedName = ComboBoxQuestion2.SelectedItem.ToString();

                if (ComboBoxQuestion1.Items.Contains(selectedName))
                {
                    ComboBoxQuestion1.Items.Remove(selectedName);
                }
            }
        }

        private void VisibleOff_Click(object sender, EventArgs e)
        {
            VisibleOff.Visible = false;
            VisibleOn.Visible = true;
            txtBoxPassword.UseSystemPasswordChar = true;

            if (txtBoxPassword.Text != "Password")
            {
                txtBoxPassword.UseSystemPasswordChar = true;
            }
            else if (txtBoxPassword.Text == "Password")
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
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            bool found = false;
            //CONVERT MD5
         //   string PASS = txtBoxPassword.Text;

         /*   MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(PASS));
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            PASS = stringBuilder.ToString();*/

            //CHECKING
            foreach (DataRow dt in dtAkun.Rows)
            {
                if (dt["username"].ToString() == txtBoxUsername.Text)
                {
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                label_Username.Text = "Username already used.";
                label_Username.Visible = true;
            } else if (txtBoxUsername.Text == "Username" || txtBoxPassword.Text == "Password" || txtBoxAnswer1.Text == "Answer" || txtBoxAnswer2.Text == "Answer")
            {
                label_Username.Text = "Please, fill all the requirements";
                label_Username.Visible = true;  
            }
            else
            {
                methods.commandIUD($"INSERT INTO Akun (username,password,jabatan,pertanyaan1,jawaban1,pertanyaan2,jawaban2) values('{txtBoxUsername.Text}', '{txtBoxPassword.Text}', '{Methods.jabatan}', '{ComboBoxQuestion1.SelectedItem.ToString()}', '{txtBoxAnswer1.Text}', '{ComboBoxQuestion2.SelectedItem.ToString()}', '{txtBoxAnswer2.Text}');");
                label_Username.Visible = false;
                formSuccess formSuccess = new formSuccess("Account Succesfully Created.");
                formSuccess.ShowDialog();

                dtAkun = new DataTable();
                string aa = "select username,password from Akun;";
                methods.command(aa, dtAkun);

                FormSignin signIn = new FormSignin(Methods.jabatan);
                methods.NewForm(this, signIn);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            FormSignin formSignin = new FormSignin(Methods.jabatan);
            methods.NewForm(this, formSignin);
        }

        private void label_Click(object sender, EventArgs e)
        {
            FormSignin formSignin = new FormSignin(Methods.jabatan);
            methods.NewForm(this, formSignin);
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
                txtBoxUsername.ForeColor = Color.Gray;
                txtBoxUsername.Text = "Username";
            }
        }
        private void txtBoxPassword_Enter(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text == "Password")
            {
                txtBoxPassword.ForeColor = SystemColors.WindowText;
                txtBoxPassword.Text = "";
            }
        }
        private void txtBoxPassword_Leave(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text == "")
            {
                txtBoxPassword.ForeColor = Color.Gray;
                txtBoxPassword.Text = "Password";
                txtBoxPassword.UseSystemPasswordChar = false;
            }
            else if (VisibleOff.Visible == true && txtBoxPassword.Text != "")
            {
                txtBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxPassword.UseSystemPasswordChar = true;
            }
        }
       
        private void txtBoxAnswer1_Enter(object sender, EventArgs e)
        {
            if (txtBoxAnswer1.Text == "Answer")
            {
                txtBoxAnswer1.ForeColor = SystemColors.WindowText;
                txtBoxAnswer1.Text = "";
            }
        }

        private void txtBoxAnswer1_Leave(object sender, EventArgs e)
        {
            if (txtBoxAnswer1.Text == "")
            {
                txtBoxAnswer1.ForeColor = Color.Gray;
                txtBoxAnswer1.Text = "Answer";
            }
        }

        private void txtBoxAnswer2_Enter(object sender, EventArgs e)
        {
            if (txtBoxAnswer2.Text == "Answer")
            {
                txtBoxAnswer2.ForeColor = SystemColors.WindowText;
                txtBoxAnswer2.Text = "";
            }
        }

        private void txtBoxAnswer2_Leave(object sender, EventArgs e)
        {
            if (txtBoxAnswer2.Text == "")
            {
                txtBoxAnswer2.ForeColor = Color.Gray;
                txtBoxAnswer2.Text = "Answer";
            }
        }

    }
}


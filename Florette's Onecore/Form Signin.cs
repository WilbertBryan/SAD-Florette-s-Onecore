using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class FormSignin : Form
    {
        public FormSignin(string role)
        {
            DataTable dtRole = new DataTable();
            this.ActiveControl = null;
            InitializeComponent();
            if (role == "Owner")
            {
                //  !!!!!!!!! QUERY CEK OWNER KLO ADA 1 FALSE           
                string query = $"select count(username)\r\nfrom akun\r\nwhere jabatan = '{role}';";
                methods.command(query, dtRole);
                if (Convert.ToInt32(dtRole.Rows[0][0].ToString())>0)
                {
                    btnSignUp.Enabled = false;
                }
            }
        }

        string query;
        DataTable dtAkun = new DataTable();
        Methods methods = new Methods();


        private void FormSignin_Load(object sender, EventArgs e)
        {
            

            this.BackColor = Color.FromArgb(167, 215, 197);
            txtBoxUsername.Text = "Username";
            txtBoxUsername.ForeColor = Color.Gray;
            txtBoxPassword.Text = "Password";
            txtBoxPassword.ForeColor = Color.Gray;

            // Simpan smua data akun ke dtAkun
            dtAkun = new DataTable();
            query = "select username,password,jabatan from Akun;";
            methods.command(query, dtAkun);

            //ActiveControl = guna2PictureBox2;
            

        }


        private void btnSignIn_Click(object sender, EventArgs e)
        {
            bool found = false;
            
            //CONVERT MD5
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
            
            //CHECKING
            string inputUsername = txtBoxUsername.Text;
            string inputPass = txtBoxPassword.Text;

            foreach (DataRow dt in dtAkun.Rows)
            {
                if (dt["username"].ToString() == txtBoxUsername.Text && dt["password"].ToString() == input && dt["jabatan"].ToString() == Methods.jabatan)
                {
                    found = true;
                    break;
                }
            }
            


            if (found == true)
            {
                label_Incorrect.Visible = false;
                methods.simpanUsername(txtBoxUsername.Text);
                // lanjut ke HOME (DASHBOARD)
                if (Methods.jabatan == "Owner")
                {
                    povOwner pov = new povOwner();
                    methods.NewForm(this, pov);
                    
                    // lanjut kePOV Owner
                }
                else
                {
                    // lanjut kePOV Staff
                    povStaff pov = new povStaff();
                    methods.NewForm(this, pov);
                }
            }
            else if (txtBoxUsername.Text == "Username" || txtBoxPassword.Text == "Password")
            {
                label_Incorrect.Text = "Please, fill all the requirements";
                label_Incorrect.Visible = true;
            }
            else
            {
                label_Incorrect.Text = "Incorrect username or password";
                label_Incorrect.Visible = true;
            }


        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            SignUp signUp = new SignUp();
            methods.NewForm(this, signUp);
        }

        private void label_ForgotPassword_Click(object sender, EventArgs e)
        {
            // form forgot pass
            formForgotPassword1 forgotPassword1 = new formForgotPassword1();
            methods.NewForm(this, forgotPassword1);
        }

        private void Back_Click(object sender, EventArgs e)
        { 
            Methods methods = new Methods();
            ChooseRole chooseRole = new ChooseRole();
            methods.NewForm(this, chooseRole);
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

        private void VisibleOn_Click(object sender, EventArgs e)
        {
            txtBoxPassword.UseSystemPasswordChar = false;
            VisibleOn.Visible = false;
            VisibleOff.Visible = true;
           
        }

        private void VisibleOff_Click(object sender, EventArgs e)
        {
            VisibleOff.Visible = false;
            VisibleOn.Visible = true;
            txtBoxPassword.UseSystemPasswordChar = true;

            if (txtBoxPassword.Text != "Password")
            {
                txtBoxPassword.UseSystemPasswordChar = true;
            } else if (txtBoxPassword.Text == "Password")
            {
                txtBoxPassword.UseSystemPasswordChar = false;
            }
        
        }
    }
}

using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formForgotPassword2 : Form
    {
        Methods methods = new Methods();
        DataTable dtSimpanData = new DataTable();
        string username;
        public formForgotPassword2(string namaPengguna)
        {
            InitializeComponent();
            username = namaPengguna;
           
        }   
        private void Back_Click(object sender, EventArgs e)
        {
            formForgotPassword1 f1 = new formForgotPassword1();
            methods.NewForm(this, f1);
        }

        private void formForgotPassword2_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label4;
            dtSimpanData = new DataTable();
            string query = $"select pertanyaan1, jawaban1, pertanyaan2 ,jawaban2 from akun where username = '{username}'";
            methods.command(query, dtSimpanData);

            txtBoxQuestion1.Text =  dtSimpanData.Rows[0]["pertanyaan1"].ToString();
            txtBoxQuestion2.Text = dtSimpanData.Rows[0]["pertanyaan2"].ToString();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (txtBoxAnswer1.Text != "Answer" && txtBoxAnswer2.Text != "Answer")
            {
                if (dtSimpanData.Rows[0]["jawaban1"].ToString().ToLower() == txtBoxAnswer1.Text.ToLower() && dtSimpanData.Rows[0]["jawaban2"].ToString().ToLower() == txtBoxAnswer2.Text.ToLower())
                {
                    labelIncorrect.Visible = false;
                    formForgotPassword3 f3 = new formForgotPassword3(username);
                    methods.NewForm(this, f3);
                }
                else
                {
                    
                    labelIncorrect.Text = "Wrong Answer. Please Try Again";
                    labelIncorrect.Visible = true;
                }
            } else
            {
                labelIncorrect.Text = "Please fill all the requirements.";
                labelIncorrect.Visible = true;
            }

        }


        private void txtBoxAnswer1_Enter(object sender, EventArgs e)
        {
            Guna2TextBox txtbox = (Guna2TextBox)sender;
            if (txtbox.Text == "Answer")
            {
                txtbox.ForeColor = SystemColors.WindowText;
                txtbox.Text = "";
            }
        }

        private void txtBoxAnswer1_Leave(object sender, EventArgs e)
        {
            Guna2TextBox txtbox = (Guna2TextBox)sender;
            if (txtbox.Text == "")
            {
                txtbox.ForeColor = SystemColors.WindowText;
                txtbox.Text = "Answer";
            }
        }

        
    }
}

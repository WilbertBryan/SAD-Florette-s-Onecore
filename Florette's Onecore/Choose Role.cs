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
    public partial class ChooseRole : Form
    {
        public ChooseRole()
        {
            InitializeComponent();
        }
        Methods methods = new Methods();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(167, 215, 197);
            
        }

        private void Staff_Click(object sender, EventArgs e)
        {
            string role = "Staff";
            FormSignin signin = new FormSignin(role);
            methods.simpanRole(role);
            methods.NewForm(this,signin);
        }

        private void Owner_Click(object sender, EventArgs e)
        {
            string role = "Owner";
            FormSignin signin = new FormSignin(role);
            methods.simpanRole(role);
            methods.NewForm(this,signin);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

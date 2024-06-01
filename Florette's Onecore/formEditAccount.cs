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
    public partial class formEditAccount : Form
    {
        public formEditAccount()
        {
            InitializeComponent();
        }

        private void labelEditUsername_Click(object sender, EventArgs e)
        {
            formEditUsername f = new formEditUsername();
            f.ShowDialog();
        }

        private void labelEditPassword_Click(object sender, EventArgs e)
        {
            formEditPassword f = new formEditPassword();
            f.ShowDialog();
        }
    }
}

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
    public partial class formLogOut : Form
    {
        public formLogOut()
        {
            InitializeComponent();
        }
        Methods methods = new Methods();
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Methods.jabatan == "Owner")
            {
                ChooseRole choose = new ChooseRole();
                methods.NewForm(povOwner.Owner, choose);
            }
            else
            {
                ChooseRole choose = new ChooseRole();
                methods.NewForm(povStaff.Staff, choose);
            }
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

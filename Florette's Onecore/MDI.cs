using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Florette_s_Onecore;



namespace Florette_s_Onecore
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }
        public static MDI instance;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(167, 215, 197);
             Methods methods = new Methods();
              ChooseRole formChooseRole = new ChooseRole();
              methods.NewForm(this,formChooseRole);
         /*   ChooseRole formChooseRole = new ChooseRole();
            formChooseRole.MdiParent = this;
            formChooseRole.WindowState = FormWindowState.Maximized;
            formChooseRole.Show();*/
        }

       
    }
}

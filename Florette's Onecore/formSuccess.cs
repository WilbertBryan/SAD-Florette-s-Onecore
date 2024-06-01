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
    public partial class formSuccess : Form
    {
        public formSuccess(string text)
        {
            InitializeComponent();
            label.Text = text;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void formSuccess_Load(object sender, EventArgs e)
        {

        }
    }
}

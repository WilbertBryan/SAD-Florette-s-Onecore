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
    public partial class formNotes : Form
    {
        bool able = false;
        public formNotes(string text, string edit)
        {
            InitializeComponent();
            txtBoxNotes.Text = text;
            if (edit == "view only")
            {
                txtBoxNotes.ReadOnly = true;
            }
            else if (edit == "write")
            {
                txtBoxNotes.ReadOnly = false;
                able = true;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formNotes_Load(object sender, EventArgs e)
        {
        }

        private void txtBoxNotes_TextChanged(object sender, EventArgs e)
        {
            if (able == true)
            {
                

                if (txtBoxNotes.Text == "")
                {
                    formOrder.Instance.txtBoxNotes.Text = "Click to Add Notes";
                } else
                {
                    formOrder.Instance.txtBoxNotes.Text = txtBoxNotes.Text;
                }
            }
            
        }
    }
}

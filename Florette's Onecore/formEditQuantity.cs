using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formEditQuantity : Form
    {
        int index = 0;
        DataTable dtGambar = new DataTable();
        Methods methods = new Methods();
        public formEditQuantity(int keberapa, int quantity, string menu)
        {
            InitializeComponent();
            labelQty.Text = quantity.ToString();
            index = keberapa;
            dtGambar = new DataTable();
            string query = $"select gambar_menu from menu where nama_menu = '{menu}' and deleted_at_menu is null";
            methods.command(query, dtGambar);
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string imagepath = projectDirectory + dtGambar.Rows[0][0];
            //  foto[i].Tag = i;
            gambar.ImageLocation = imagepath;

        }

        private void formEditQuantity_Load(object sender, EventArgs e)
        {
           
          /*  string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string imagepath = projectDirectory + ssss;
            foto[i].Tag = i;
            foto[i].ImageLocation = imagepath;*/
        }

        private void minus_Click(object sender, EventArgs e)
        {
            Guna2PictureBox icon = (Guna2PictureBox)sender;
            int qty = Convert.ToInt32(labelQty.Text);
            if (icon.Name == "minus")
            {
                if (qty!=0)
                {
                    qty -= 1;                  
                }           
            } else if (icon.Name == "plus")
            {
                qty += 1;
            }
            labelQty.Text = qty.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            formOrder.Instance.dtOrder.Rows.RemoveAt(index);
            formOrder.Instance.dgvOrder.Update();
            formOrder.Instance.totalPrice();
            this.Close();
            formSuccess f = new formSuccess("Removed.");
            f.ShowDialog();

            //
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (labelQty.Text == "0")
            {
                formOrder.Instance.dtOrder.Rows.RemoveAt(index);
                formOrder.Instance.dgvOrder.Update();
                formOrder.Instance.totalPrice();
                this.Close();
                formSuccess f = new formSuccess("Removed.");
                f.ShowDialog();
            }
            else
            {
                formOrder.Instance.dtOrder.Rows[index]["Quantity"] = labelQty.Text;
                formOrder.Instance.dgvOrder.Update();
                formOrder.Instance.totalPrice();
                this.Close();
                formSuccess f = new formSuccess("Saved.");
                f.ShowDialog();
            }

            

            //
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

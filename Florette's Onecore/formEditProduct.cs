using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formEditProduct : Form
    {
        string comboBox, id;
        Methods methods = new Methods();
        DataTable dtCategory = new DataTable();
        string pathFoto;
        public formEditProduct(string idmenu, string category, string nama, string nominal, string path)
        {
            InitializeComponent();
            id = idmenu;
            comboBox = category;
            txtBoxName.Text = nama;
            txtBoxNominal.Text = nominal;

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            gambar.ImageLocation = projectDirectory + path;
        }
        private void formEditProduct_Load(object sender, EventArgs e)
        {
            dtCategory = new DataTable();
            string query = "select * from kategori;";
            methods.command(query, dtCategory);
            cmbBoxCategory.DataSource = dtCategory;
            cmbBoxCategory.ValueMember = "id_kategori";
            cmbBoxCategory.DisplayMember = "nama_kategori";

            cmbBoxCategory.SelectedIndex = cmbBoxCategory.FindString(comboBox);
        }

        private void txtBoxNominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            /// !!!!! REMOVE dari database
            string query = $"update menu set deleted_at_menu = current_timestamp where id_menu = '{id}';";
            methods.commandIUD(query);
            formManagementProduct.Instance.btnAll.PerformClick();

            this.Close();
            formSuccess f = new formSuccess("Product succesfully removed.");
            f.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //////// !!! SAVE, UPDATE DI DATABASE
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            double cekHarga = Convert.ToDouble(txtBoxNominal.Text);

            if (cekHarga < 1000)
            {
                labelIncorrect.Visible = true;
            }
            else
            {
                if (Path.GetFileName(pathFoto) == null && cekHarga >= 1000)
                {
                    string query = $"update menu set id_kategori = '{cmbBoxCategory.SelectedValue.ToString()}', nama_menu ='{txtBoxName.Text}',harga_menu = '{txtBoxNominal.Text}' where id_menu = '{id}';";
                    methods.commandIUD(query);
                }
                else
                {
                    string gambarDatabase = "\\images\\" + Path.GetFileName(pathFoto);
                    File.Copy(pathFoto, Path.Combine(projectDirectory + gambarDatabase), true);
                    gambarDatabase = "\\\\images\\\\" + Path.GetFileName(pathFoto);
                    string query = $"update menu set id_kategori = '{cmbBoxCategory.SelectedValue.ToString()}', nama_menu ='{txtBoxName.Text}',harga_menu = '{txtBoxNominal.Text}', gambar_menu = '{gambarDatabase}' where id_menu = '{id}';";
                    methods.commandIUD(query);
                }

                formManagementProduct.Instance.btnAll.PerformClick();
                this.Close();
                formSuccess f = new formSuccess("Product updated.");
                f.ShowDialog();
            }

        }
        private void gambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                gambar.Image = Image.FromFile(open.FileName);
                pathFoto = open.FileName.ToString();
            }
            open.Dispose();
        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxName_Enter(object sender, EventArgs e)
        {
            if (txtBoxName.Text == "Write product's name")
            {
                txtBoxName.Text = "";
            }
        }

        private void txtBoxName_Leave(object sender, EventArgs e)
        {
            if (txtBoxName.Text == "")
            {
                txtBoxName.Text = "Write product's name";
            }
        }

        private void txtBoxNominal_Enter(object sender, EventArgs e)
        {
            if (txtBoxNominal.Text == "0")
            {
                txtBoxNominal.Text = "";
            }
        }

        private void txtBoxNominal_Leave(object sender, EventArgs e)
        {
            if (txtBoxNominal.Text == "")
            {
                txtBoxNominal.Text = "0";
            }
        }


    }
}

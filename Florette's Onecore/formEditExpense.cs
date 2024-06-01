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
    public partial class formEditExpense : Form
    {
        string id, comboBox;
        public formEditExpense(string idBiaya, string category, string nominal)
        {
            InitializeComponent();
            id = idBiaya;
            comboBox = category;
            txtBoxNominal.Text = nominal;

        }
        Methods methods = new Methods();
        DataTable dtCategory = new DataTable();
        DataTable dt = new DataTable();
        private void formEditExpense_Load(object sender, EventArgs e)
        {
            dtCategory = new DataTable();
            string query = "select * from kategori_biaya;";
            methods.command(query, dtCategory);
            cmbBoxCategory.DataSource = dtCategory;
            cmbBoxCategory.ValueMember = "id_kategori_biaya";
            cmbBoxCategory.DisplayMember = "nama_biaya";

            cmbBoxCategory.SelectedIndex = cmbBoxCategory.FindString(comboBox);

            query = $"select detail_biaya from biaya where id_biaya = '{id}' and deleted_at_biaya is null";
            methods.command(query, dt);
            txtBoxDetail.Text = dt.Rows[0][0].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBoxNominal.Text != "0")
            {
                labelIncorrect.Visible = false;
                string q = $"update biaya\r\nset id_kategori_biaya = '{cmbBoxCategory.SelectedValue.ToString()}',\r\nbiaya = '{txtBoxNominal.Text}',\r\ndetail_biaya = '{txtBoxDetail.Text}'\r\nwhere id_biaya = '{id}';";
                methods.commandIUD(q);


                this.Close();
                formSuccess f = new formSuccess("Expense Succesfully Updated");
                f.ShowDialog();
                formExpense.Instance.updateDGV();
            } else
            {
                labelIncorrect.Visible = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string q = $"update biaya\r\nset deleted_at_biaya = current_timestamp\r\nwhere id_biaya = '{id}';";
            methods.commandIUD(q);


            this.Close();
            formSuccess f = new formSuccess("Expense Deleted");
            f.ShowDialog();
            formExpense.Instance.updateDGV();
        }



        private void txtBoxNominal_Enter(object sender, EventArgs e)
        {
            if (txtBoxNominal.Text == "0")
            {
                txtBoxNominal.Text = "";
            }
        }

        private void txtBoxDetail_Leave(object sender, EventArgs e)
        {
            if (txtBoxDetail.Text == "")
            {
                txtBoxDetail.Text = "Write detail";

            }
        }

        private void txtBoxDetail_Enter(object sender, EventArgs e)
        {
            if (txtBoxDetail.Text == "Write detail")
            {
                txtBoxDetail.Text = "";
            }
        }

        private void txtBoxNominal_Leave(object sender, EventArgs e)
        {
            if (txtBoxNominal.Text == "")
            {
                txtBoxNominal.Text = "0";
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void txtBoxNominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formExpense : Form
    {
        public static formExpense Instance;
        public formExpense()
        {
            InitializeComponent();
            Instance = this;
        }
        Methods methods = new Methods();
        DataTable dtCategory = new DataTable();
        DataTable dtExpense = new DataTable();
        List<string> category = new List<string>();

        private void formExpense_Load(object sender, EventArgs e)
        {

            dtCategory = new DataTable();
            string query = "select * from kategori_biaya;";
            methods.command(query, dtCategory);
            cmbBoxCategory.DataSource = dtCategory;

            dtCategory = new DataTable();
            methods.command(query, dtCategory);
            foreach (DataRow a in dtCategory.Rows)
            {
                category.Add(a["nama_biaya"].ToString());
            }

            cmbCategory.Items.Add("All");
            for (int i = 0; i < category.Count; i++)
            {
                cmbCategory.Items.Add(category[i].ToString());
            }

            cmbBoxCategory.ValueMember = "id_kategori_biaya";
            cmbBoxCategory.DisplayMember = "nama_biaya";
            
            cmbCategory.Text = "All";
            updateDGV();

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBoxDetail.Text != null && (txtBoxNominal.Text != "0"))
            {
                string detail;
                if (txtBoxDetail.Text == "Write detail")
                {
                    detail = "";
                } else
                {
                    detail = txtBoxDetail.Text;
                }

                string q = $"insert into biaya(id_kategori_biaya,biaya,detail_biaya)\r\nvalues ('{cmbBoxCategory.SelectedValue.ToString()}','{txtBoxNominal.Text}','{detail}');";
                methods.commandIUD(q);
                labelIncorrect.Visible = false;

                formSuccess f = new formSuccess("Expense Has Been Created");
                f.ShowDialog();
                updateDGV();

                txtBoxDetail.Text = "Write detail";
                txtBoxNominal.Text = "0";
                cmbBoxCategory.SelectedIndex = 0;

            }
            else
            {
                labelIncorrect.Visible = true;
            }

        }

        public void updateDGV()
        {
            dtExpense.Clear(); dgvDetail.DataSource = null;
            dtExpense = new DataTable();
            string query = $"call pGetExpense('all')";
            methods.command(query, dtExpense);
            dtExpense.Columns.Add("Edit", typeof(Image));
            for (int i = 0; i < dtExpense.Rows.Count; i++)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                string imagepath = Path.Combine(projectDirectory, "images", "edit.png");
                Image image = Image.FromFile(imagepath);
                dtExpense.Rows[i]["Edit"] = image;
            }
            dgvDetail.DataSource = dtExpense;
        }

        private void dgvDetail_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = dgvDetail.HitTest(e.X, e.Y);

                if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == 3)
                {
                    string id = dgvDetail.CurrentRow.Cells["Expense ID"].Value.ToString();
                    string category = dgvDetail.CurrentRow.Cells["Expense"].Value.ToString();
                    string nominal = dgvDetail.CurrentRow.Cells["Nominal"].Value.ToString();

                    formEditExpense f = new formEditExpense(id, category, nominal);
                    f.ShowDialog();
                }
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

        private void txtBoxDetail_Enter(object sender, EventArgs e)
        {
            if (txtBoxDetail.Text == "Write detail")
            {
                txtBoxDetail.Text = "";
            }
        }

        private void txtBoxDetail_Leave(object sender, EventArgs e)
        {
            if (txtBoxDetail.Text == "")
            {
                txtBoxDetail.Text = "Write detail";
            }
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filterDgv();
        }

        void filterDgv()
        {
            if (cmbCategory.Text != "All")
            {
                dtExpense.Clear(); dgvDetail.DataSource = null;
                dtExpense = new DataTable();
                string query = $"call pGetExpense('{cmbCategory.Text}')";
                methods.command(query, dtExpense);
                dtExpense.Columns.Add("Edit", typeof(Image));
                for (int i = 0; i < dtExpense.Rows.Count; i++)
                {
                    string workingDirectory = Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                    string imagepath = Path.Combine(projectDirectory, "images", "edit.png");
                    Image image = Image.FromFile(imagepath);
                    dtExpense.Rows[i]["Edit"] = image;
                }
                dgvDetail.DataSource = dtExpense;
            }
            else
            {
                updateDGV();
            }

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

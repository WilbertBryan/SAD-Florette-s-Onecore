using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formAllOrders : Form
    {
        public formAllOrders()
        {
            InitializeComponent();
        }

        DataTable dtHistory = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dtDetailOrder = new DataTable();
        Methods methods = new Methods();
        private void formAllOrders_Load(object sender, EventArgs e)
        {
            // btnOrderHistory.FillColor = Color.FromArgb(248, 248, 248);
            cmbBoxCategory.Items.AddRange(new string[] { "Today", "Last 7 Days", "This Month", "Last 30 Days", "All" });
            cmbBoxCategory.Text = "Today";
            /*     string query = "select * from vPenjualanHariIni;";
                 methods.command(query, dtHistory);
                 dgvHistory.DataSource = dtHistory;*/
            btnOrderHistory.PerformClick();
            btnOrderHistory.FillColor = Color.Gainsboro; // berubah
        }


        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text != null)
            {
                dtHistory.Clear(); dgvHistory.DataSource = null;
                string namasearch = txtBoxSearch.Text.ToUpper();
                dtHistory = new DataTable();
                string query = $"CALL pSearchTransaksi('{namasearch}');";
                methods.command(query, dtHistory);
                dgvHistory.DataSource = dtHistory;
            }

        }

        private void txtBoxSearch_Enter(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "Search Order ID / Name")
            {
                txtBoxSearch.Text = "";
                
            }
            btnActiveOrder.FillColor = Color.FromArgb(255, 251, 251); // balik putih
            btnOrderHistory.FillColor = Color.Gainsboro; // berubah
            cmbBoxCategory.Enabled = true;
        }

        private void txtBoxSearch_Leave(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "")
            {
                txtBoxSearch.Text = "Search Order ID / Name";
                btnOrderHistory.PerformClick();
            }
        }

        private void dgvHistory_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // ini untuk menampilkan detail yang di kanan
            string id = dgvHistory.CurrentRow.Cells["Transaction ID"].Value.ToString() ;
            dtDetail.Clear(); dtDetailOrder.Clear(); dgvDetail.DataSource = null;

            dtDetail = new DataTable();
            string query = $"CALL pDetailOrder1('{id}');";
            methods.command(query, dtDetail);

            dtDetailOrder = new DataTable();
            string q = $"CALL pDetailOrder2('{id}');";
            methods.command(q, dtDetailOrder);
            dgvDetail.DataSource = dtDetailOrder;

            labelNama.Text = dtDetail.Rows[0]["nama"].ToString();
            labelNama.Visible = true;

            if (dtDetail.Rows[0]["email"].ToString() != null)
            {
                labelEmail.Text = dtDetail.Rows[0]["email"].ToString();
                labelEmail.Visible = true;
            }

            if (dtDetail.Rows[0]["catatan"].ToString() != null)
            {
                txtBoxNotes.Text = dtDetail.Rows[0]["catatan"].ToString();
                txtBoxNotes.Enabled = true;
            }

           labelidTransaksi.Text = id;
            labelidTransaksi.Visible = true;
            labelCashier.Text = dtDetail.Rows[0]["cashier"].ToString();
            labelCashier.Visible = true;


            int total = Convert.ToInt32(dtDetail.Rows[0]["total"].ToString());
            labelTotal.Text = "Rp "+string.Format("{0:N0}", total);
            labelTotal.Visible = true;
            labelMetode.Text = dtDetail.Rows[0]["metodePembayaran"].ToString();
            labelMetode.Visible = true;

        }

        private void cmbBoxCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbBoxFilter(cmbBoxCategory);
        }

        private void btnActiveOrder_Click(object sender, EventArgs e)
        {
            btnOrderHistory.FillColor = Color.FromArgb(255, 251, 251); // balik putih
            btnActiveOrder.FillColor = Color.Gainsboro; // berubah
            cmbBoxCategory.Enabled = false;
            dtHistory.Clear(); dgvHistory.DataSource = null;

            string query = "select * from vTransaksiAktif;";
            methods.command(query, dtHistory);
            dgvHistory.DataSource = dtHistory;
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            btnActiveOrder.FillColor = Color.FromArgb(255, 251, 251); // balik putih
            btnOrderHistory.FillColor = Color.Gainsboro; // berubah
            cmbBoxCategory.Enabled = true;
            cmbBoxFilter(cmbBoxCategory);
        }

        private void cmbBoxFilter(Guna2ComboBox cmb)
        {

            string query;
            dtHistory.Clear(); dgvHistory.DataSource = null;
            switch (cmb.Text)
            {
                case "Today":
                    //query = "select * from vPenjualanHariIni;";
                    query = "CALL pGetLapPenjualan('today')";
                    methods.command(query, dtHistory);
                    dgvHistory.DataSource = dtHistory;
                    break;
                case "Last 7 Days":
                    //query = "select * from vPenjualan7;";
                    query = "CALL pGetLapPenjualan('week')";
                    methods.command(query, dtHistory);
                    dgvHistory.DataSource = dtHistory;
                    break;
                case "This Month":
                    //query = "select * from vPenjualanBulan;";
                    query = "CALL pGetLapPenjualan('month')";
                    methods.command(query, dtHistory);
                    dgvHistory.DataSource = dtHistory;
                    break;
                case "Last 30 Days":
                    //query = "select * from vPenjualan30;";
                    query = "CALL pGetLapPenjualan('30')";
                    methods.command(query, dtHistory);
                    dgvHistory.DataSource = dtHistory;
                    break;
                case "All":
                    //query = "select * from vPenjualan;";
                    query = "CALL pGetLapPenjualan('all')";
                    methods.command(query, dtHistory);
                    dgvHistory.DataSource = dtHistory;
                    break;
            }
        }

        private void txtBoxNotes_Click(object sender, EventArgs e)
        {
            if (txtBoxNotes.Text != "")
            {
                string view = "view only";
                formNotes notes = new formNotes(txtBoxNotes.Text, view);
                notes.ShowDialog();
            }
        }


    }
}

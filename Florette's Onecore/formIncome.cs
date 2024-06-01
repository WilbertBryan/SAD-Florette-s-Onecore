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
    public partial class formIncome : Form
    {
        public formIncome()
        {
            InitializeComponent();
        }
        Methods methods = new Methods();
        DataTable dtSales, dtExpenses,dtFilter;
        List<string> category = new List<string>();

        string query;
        private void formIncome_Load(object sender, EventArgs e)
        {
            DataTable isiCmb = new DataTable();
            query = "SELECT CONCAT(MONTHNAME(created_at_transaksi),' ', YEAR(created_at_transaksi)) 'isi'\r\nFROM transaksi\r\nGROUP BY 1;";
            methods.command(query, isiCmb);
            cmbBoxSelling.DataSource = isiCmb;
            cmbBoxSelling.DisplayMember = "isi";
            cmbBoxSelling.SelectedIndex = 0;
            UpdateData();
            Sales_Click(Sales, e);
        }

        private void cmbBoxSelling_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateData();
            Sales_Click(Sales, e);
        }

        private void Sales_Click(object sender, EventArgs e)
        {
            category.Clear();
            cmbFilter.Items.Clear();
            dtFilter = new DataTable();
            string query = "select * from Metode_Pembayaran;";
            methods.command(query, dtFilter);          

            foreach (DataRow a in dtFilter.Rows)
            {
                category.Add(a["nama_metode"].ToString());
            }
            cmbFilter.Items.Add("All Sales");
            for (int i = 0; i < category.Count; i++)
            {
                cmbFilter.Items.Add(category[i].ToString());
            }
            
            cmbFilter.Text = "All Sales";

            labelTotalName.Text = "Total Sales";
            cmbFilter_SelectionChangeCommitted(cmbFilter, e);
        }

        private void cmbFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtTotal = new DataTable();
            string blnThn = cmbBoxSelling.Text;
            switch (cmbFilter.Text)
            {
                case "All Sales":
                    query = "CALL pGetLapPenjualan('month')";
                    methods.command(query, dt);
                    dgvDetail.DataSource = dt;
                    query = $"SELECT sum(t.total_harga)\r\n    FROM Transaksi t\r\n    WHERE DATE_FORMAT(t.created_at_transaksi, '%M %Y') = '{blnThn}' and t.status_transaksi = 1;";
                    methods.command(query, dtTotal);

                    if (dtTotal.Rows[0][0].ToString() != "")
                    {
                        int sales = Convert.ToInt32(dtTotal.Rows[0][0].ToString());
                        labelTotal.Text = "Rp " + string.Format("{0:N0}", sales);
                    } else
                    {
                        labelTotal.Text = "Rp 0";
                    }
                    break;
                case "Cash":
                    query = $"SELECT t.id_transaksi 'Transaction ID', t.created_at_transaksi 'Date', t.nama_pelanggan 'Name',  t.total_harga 'Sales', a.username\r\n    FROM Transaksi t, akun a\r\n    WHERE DATE_FORMAT(t.created_at_transaksi, '%M %Y') = '{blnThn}' and t.id_admin = a.id_admin and t.status_transaksi = 1 and t.id_metode_pembayaran = 'MP0001';";
                    methods.command(query, dt);
                    dgvDetail.DataSource = dt;
                    query = $"SELECT sum(t.total_harga)\r\n    FROM Transaksi t\r\n    WHERE DATE_FORMAT(t.created_at_transaksi, '%M %Y') = '{blnThn}' and t.status_transaksi = 1 and t.id_metode_pembayaran = 'MP0001';";
                    methods.command(query, dtTotal);

                    if (dtTotal.Rows[0][0].ToString() != "")
                    {
                        int cash = Convert.ToInt32(dtTotal.Rows[0][0].ToString());
                        labelTotal.Text = "Rp " + string.Format("{0:N0}", cash);
                    }
                    else
                    {
                        labelTotal.Text = "Rp 0";
                    }
                    break;
                case "Transfer BCA":
                    query = $"SELECT t.id_transaksi 'Transaction ID', t.created_at_transaksi 'Date', t.nama_pelanggan 'Name',  t.total_harga 'Sales', a.username\r\n    FROM Transaksi t, akun a\r\n    WHERE DATE_FORMAT(t.created_at_transaksi, '%M %Y') = '{blnThn}' and t.id_admin = a.id_admin and t.status_transaksi = 1 and t.id_metode_pembayaran = 'MP0002';";
                    methods.command(query, dt);
                    dgvDetail.DataSource = dt;
                    query = $"SELECT sum(t.total_harga)\r\n    FROM Transaksi t\r\n    WHERE DATE_FORMAT(t.created_at_transaksi, '%M %Y') = '{blnThn}' and t.status_transaksi = 1 and t.id_metode_pembayaran = 'MP0002';";
                    methods.command(query, dtTotal);

                    if (dtTotal.Rows[0][0].ToString() != "")
                    {
                        int bca = Convert.ToInt32(dtTotal.Rows[0][0].ToString());
                        labelTotal.Text = "Rp " + string.Format("{0:N0}", bca);
                    } else
                    {
                        labelTotal.Text = "Rp 0";
                    }    
                    break;
                case "All Expenses":
                    query = $"select b.id_biaya 'Expense ID', kb.nama_biaya 'Expense', b.biaya 'Nominal'\r\nfrom biaya b,  kategori_biaya kb\r\nwhere b.id_kategori_biaya = kb.id_kategori_biaya and b.deleted_at_biaya is null and DATE_FORMAT(b.created_at_biaya, '%M %Y') = '{blnThn}';";
                    methods.command(query, dt);
                    dgvDetail.DataSource = dt;
                    query = $"SELECT sum(biaya)\r\n    FROM biaya\r\n    WHERE DATE_FORMAT(created_at_biaya, '%M %Y') = '{blnThn}' and deleted_at_biaya is null;";
                    methods.command(query, dtTotal);

                    if (dtTotal.Rows[0][0].ToString() != "")
                    {
                        int expenses = Convert.ToInt32(dtTotal.Rows[0][0].ToString());
                        labelTotal.Text = "Rp " + string.Format("{0:N0}", expenses);
                    }
                    break;
                default :
                    query = $"select b.id_biaya 'Expense ID', kb.nama_biaya 'Expense', b.biaya 'Nominal'\r\nfrom biaya b,  kategori_biaya kb\r\nwhere b.id_kategori_biaya = kb.id_kategori_biaya and b.deleted_at_biaya is null and kb.nama_biaya = '{cmbFilter.Text}' and DATE_FORMAT(b.created_at_biaya, '%M %Y') = '{blnThn}';";
                    methods.command(query, dt);
                    dgvDetail.DataSource = dt;
                    dtTotal = new DataTable();
                    query = $"SELECT sum(b.biaya)\r\n    FROM biaya b, kategori_biaya kb\r\n    WHERE DATE_FORMAT(b.created_at_biaya, '%M %Y') = '{blnThn}' and b.deleted_at_biaya is null and kb.nama_biaya = '{cmbFilter.Text}' and b.id_kategori_biaya = kb.id_kategori_biaya;";
                    methods.command(query, dtTotal);

                    if (dtTotal.Rows[0][0].ToString() != "")
                    {
                        int total = Convert.ToInt32(dtTotal.Rows[0][0].ToString());
                        labelTotal.Text = "Rp " + string.Format("{0:N0}", total);
                    }
                    else
                    {
                        labelTotal.Text = "Rp 0";
                    }
                    break;
                    
            }
        }

        private void Expenses_Click(object sender, EventArgs e)
        {
            category.Clear();
            cmbFilter.Items.Clear();
            dtFilter = new DataTable();
            string query = "select * from kategori_biaya;";
            methods.command(query, dtFilter);

            foreach (DataRow a in dtFilter.Rows)
            {
                category.Add(a["nama_biaya"].ToString());
            }
            cmbFilter.Items.Add("All Expenses");
            for (int i = 0; i < category.Count; i++)
            {
                cmbFilter.Items.Add(category[i].ToString());
            }
            
            cmbFilter.Text = "All Expenses";

            labelTotalName.Text = "Total Expenses";
            cmbFilter_SelectionChangeCommitted(cmbFilter, e);
        }

        private void UpdateData()
        {

            string blnThn = cmbBoxSelling.Text;
            dtSales = new DataTable();
            query = $"select sum(total_harga)\r\nfrom transaksi\r\nwhere status_transaksi = 1 and DATE_FORMAT(created_at_transaksi, '%M %Y') = '{blnThn}' ;";
            methods.command(query, dtSales);

            dtExpenses = new DataTable();
            query = $"SELECT sum(biaya) \r\nFROM biaya\r\nWHERE deleted_at_biaya is null and DATE_FORMAT(created_at_biaya, '%M %Y') = '{blnThn}' ;";
            methods.command(query, dtExpenses);

            int exp = 0;
            int sales = 0;
            int profit = 0;
            if (dtSales.Rows[0][0].ToString() != "")
            {
                sales = Convert.ToInt32(dtSales.Rows[0][0].ToString());
                labelSales.Text = "Rp " + string.Format("{0:N0}", sales);
                           
            }
            else
            {
                labelSales.Text = "Rp 0";
            }

            if (dtExpenses.Rows[0][0].ToString() != "")
            {
                exp = Convert.ToInt32(dtExpenses.Rows[0][0].ToString());
                labelExpenses.Text = "Rp " + string.Format("{0:N0}", exp);
            } else
            {
                labelExpenses.Text = "Rp 0";
            }
            profit = sales - exp;
            labelProfit.Text = "Rp " + string.Format("{0:N0}", (profit));
        }

    }
}

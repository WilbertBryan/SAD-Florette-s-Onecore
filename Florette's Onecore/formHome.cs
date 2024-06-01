using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formHome : Form
    {
        public static formHome Instance;
        public formHome()
        {
            InitializeComponent();
            cmbBoxSelling.Items.AddRange(new string[] { "Best Selling", "Least Selling" });
            Instance = this;

        }

        Methods methods = new Methods();
        DataTable dtSimpan = new DataTable();
        DataTable dtSelling = new DataTable();
        DataTable dtsimpanTransaksi = new DataTable();
        DataTable dtsimpanDetail = new DataTable();
        Label[] labelnama;
        Label[] labelidTransaksi;
        Label[] labelAntrian;
        Label[] labelOrder;
        Label[] labelQty;
        PictureBox[] centang;
        Label[] garis;
        private void formHome_Load(object sender, EventArgs e)
        {
            cmbBoxSelling.Text = "Best Selling";
            string q = "select * from vTotalTransaksiStatus;";
            methods.command(q, dtSimpan);

            if (dtSimpan.Rows[0][0].ToString() != "")
            {
                labelCurrentOrder.Text = dtSimpan.Rows[0]["Active"].ToString();

            }
            if (dtSimpan.Rows[0][1].ToString() != "")
            {
                labelCompletedOrder.Text = dtSimpan.Rows[0]["Completed"].ToString();

            }



            dtsimpanTransaksi = new DataTable();
            methods.command("select id_transaksi from transaksi where status_transaksi = 0 and DATE(created_at_transaksi) = DATE(now()) and deleted_at_transaksi is null;", dtsimpanTransaksi);


            if (dtsimpanTransaksi.Rows.Count > 0)
            {

                dtsimpanDetail = new DataTable();
                string id = "'" + dtsimpanTransaksi.Rows[0][0].ToString() + "'";
                string query = $"CALL pDetailTransaksi({id});";
                methods.command(query, dtsimpanDetail);
                Design();
            }

            DateTime currentDateTime = DateTime.Now;
            labelDate.Text = currentDateTime.ToString("dddd, dd MMMM yyyy");

            int cash = 0;
            int bank = 0;

            DataTable dt = new DataTable();
            string q1 = "SELECT sum(t.total_harga)\r\nFROM Transaksi t\r\nWHERE  DATE(t.created_at_transaksi) = DATE(now()) and t.status_transaksi = 1 and t.id_metode_pembayaran = 'MP0001';";
            methods.command(q1,dt);
            if (dt.Rows[0][0].ToString() != "")
            {
                cash = Convert.ToInt32(dt.Rows[0][0].ToString());
                labelCash.Text = "Rp " + string.Format("{0:N0}", cash);
            }
              
            dt = new DataTable();
            q1 = "SELECT sum(t.total_harga)\r\nFROM Transaksi t\r\nWHERE  DATE(t.created_at_transaksi) = DATE(now()) and t.status_transaksi = 1 and t.id_metode_pembayaran = 'MP0002';";
            methods.command(q1, dt);
            if (dt.Rows[0][0].ToString() != "")
            {
                bank = Convert.ToInt32(dt.Rows[0][0].ToString());
                labelTransfer.Text = "Rp " + string.Format("{0:N0}", bank);
            }

            int total = cash + bank;
            labelTotalSales.Text = "Rp " + string.Format("{0:N0}", total);
        }

        public void Design()
        {

            labelnama = new Label[dtsimpanTransaksi.Rows.Count];
            labelidTransaksi = new Label[dtsimpanTransaksi.Rows.Count];
            labelAntrian = new Label[dtsimpanTransaksi.Rows.Count];

            centang = new PictureBox[dtsimpanTransaksi.Rows.Count]; // click
            garis = new Label[dtsimpanTransaksi.Rows.Count];

            int x = 11;
            int y = 120;

            int labelnamaY = 105;
            int garisY = 260;
            int labelOrderY = labelnamaY + 70;


            panelOrder.AutoScroll = true;         // Disable horizontal scrolling
            panelOrder.HorizontalScroll.Enabled = false; // Enable vertical scrolling
            panelOrder.HorizontalScroll.Visible = false; // Make vertical scrollbar visible


            // baris kiri nama, id transaksi
            for (int i = 0; i < dtsimpanTransaksi.Rows.Count; i++)
            {
                dtsimpanDetail = new DataTable();
                string id = "'" + dtsimpanTransaksi.Rows[i][0].ToString() + "'";
                string query = $"CALL pDetailTransaksi({id});";
                methods.command(query, dtsimpanDetail);

                labelOrder = new Label[dtsimpanDetail.Rows.Count];
                labelQty = new Label[dtsimpanDetail.Rows.Count];

                for (int j = 0; j < dtsimpanDetail.Rows.Count; j++)
                {

                    labelnama[i] = new Label();
                    labelnama[i].Location = new Point(x, labelnamaY);
                    labelnama[i].Size = new Size(170, 25);
                    labelnama[i].Font = new Font("Leelawadee UI", 14, FontStyle.Bold);
                    labelnama[i].Text = dtsimpanDetail.Rows[0][0].ToString();
                    labelnama[i].ForeColor = Color.FromArgb(114, 134, 127);
                    this.panelOrder.Controls.Add(labelnama[i]);

                    labelAntrian[i] = new Label();
                    labelAntrian[i].Location = new Point(180, labelnamaY);
                    labelAntrian[i].Size = new Size(170, 25);
                    labelAntrian[i].Font = new Font("Leelawadee UI", 14, FontStyle.Bold);
                    labelAntrian[i].Text = "Que No. " + dtsimpanDetail.Rows[0][2].ToString();
                    labelAntrian[i].ForeColor = Color.FromArgb(114, 134, 127);
                    this.panelOrder.Controls.Add(labelAntrian[i]);

                    labelidTransaksi[i] = new Label();
                    labelidTransaksi[i].Location = new Point(x, (labelnamaY + 20));
                    labelidTransaksi[i].Size = new Size(170, 30);
                    labelidTransaksi[i].Font = new Font("Leelawadee UI", 14, FontStyle.Regular);
                    labelidTransaksi[i].Text = dtsimpanTransaksi.Rows[i][0].ToString();
                    labelidTransaksi[i].ForeColor = Color.FromArgb(114, 134, 127);
                    this.panelOrder.Controls.Add(labelidTransaksi[i]);


                    labelOrder[j] = new Label();
                    labelOrder[j].Location = new Point(x, (labelOrderY));
                    labelOrder[j].Size = new Size(170, 25);
                    labelOrder[j].Font = new Font("Leelawadee UI", 14, FontStyle.Regular);
                    labelOrder[j].Text = dtsimpanDetail.Rows[j][3].ToString();
                    labelOrder[j].ForeColor = Color.FromArgb(114, 134, 127);
                    this.panelOrder.Controls.Add(labelOrder[j]);

                    labelQty[j] = new Label();
                    labelQty[j].Location = new Point(195, (labelOrderY));
                    labelQty[j].Size = new Size(30, 25);
                    labelQty[j].Font = new Font("Leelawadee UI", 14, FontStyle.Regular);
                    labelQty[j].Text = dtsimpanDetail.Rows[j][4].ToString();
                    labelQty[j].ForeColor = Color.FromArgb(114, 134, 127);
                    this.panelOrder.Controls.Add(labelQty[j]);


                    if (j != dtsimpanDetail.Rows.Count - 1)
                    {
                        labelOrderY += 20;
                    }

                }
                centang[i] = new PictureBox();
                centang[i].Location = new Point(250, labelOrderY + 5);
                centang[i].SizeMode = PictureBoxSizeMode.StretchImage;
                centang[i].Size = new Size(20, 20);
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                string imagepath = projectDirectory + "\\images\\checked.png";
                centang[i].Tag = i;
                centang[i].ImageLocation = imagepath;
                centang[i].Click += centang_Click;
                this.panelOrder.Controls.Add(centang[i]);

                garis[i] = new Label();
                garis[i].Location = new Point(-3, (labelOrderY + 40));
                garis[i].Size = new Size(500, 25);
                garis[i].Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                garis[i].Text = "_________________________________________________________";
                garis[i].ForeColor = SystemColors.ControlDark;
                this.panelOrder.Controls.Add(garis[i]);



                garisY = labelOrderY + 40;
                labelnamaY = garisY + 30;
                labelOrderY = labelnamaY + 70;
            }
        }

        private void centang_Click(object sender, EventArgs e)
        {
            PictureBox pct = (PictureBox)sender;
            int angka = Convert.ToInt32(pct.Tag);
            string id = labelidTransaksi[angka].Text;
            formOrderCheck f = new formOrderCheck(id);
            f.ShowDialog();
        }

        private void cmbBoxSelling_SelectedValueChanged(object sender, EventArgs e)
        {
            dtSelling.Clear();
            if (cmbBoxSelling.SelectedItem.ToString() == "Best Selling")
            {
                string qBestSelling = "select * from vBestSelling;";
                methods.command(qBestSelling, dtSelling);
                labelThisMonth.Text = "Best Selling Menu in This Month";

            }
            else
            {
                string qLeastSelling = "select * from vLeastSelling;";
                methods.command(qLeastSelling, dtSelling);
                labelThisMonth.Text = "Least Selling Menu in This Month";
            }

            dgvSelling.DataSource = dtSelling;
        }
        public void Update()
        {

            panelOrder.Controls.Clear();

            dtSimpan = new DataTable();
            dtsimpanDetail = new DataTable();
            dtsimpanTransaksi = new DataTable();
            string q = "select * from vTotalTransaksiStatus;";
            methods.command(q, dtSimpan);
            labelCurrentOrder.Text = dtSimpan.Rows[0]["Active"].ToString();
            labelCompletedOrder.Text = dtSimpan.Rows[0]["Completed"].ToString();

            //update today's sales
            int cash = 0;
            int bank = 0;

            DataTable dt = new DataTable();
            string q1 = "SELECT sum(t.total_harga)\r\nFROM Transaksi t\r\nWHERE  DATE(t.created_at_transaksi) = DATE(now()) and t.status_transaksi = 1 and t.id_metode_pembayaran = 'MP0001';";
            methods.command(q1, dt);
            if (dt.Rows[0][0].ToString() != "")
            {
                cash = Convert.ToInt32(dt.Rows[0][0].ToString());
                labelCash.Text = "Rp " + string.Format("{0:N0}", cash);
            }

            dt = new DataTable();
            q1 = "SELECT sum(t.total_harga)\r\nFROM Transaksi t\r\nWHERE  DATE(t.created_at_transaksi) = DATE(now()) and t.status_transaksi = 1 and t.id_metode_pembayaran = 'MP0002';";
            methods.command(q1, dt);
           
            if (dt.Rows[0][0].ToString() != "")
            {
                bank = Convert.ToInt32(dt.Rows[0][0].ToString());
                labelTransfer.Text = "Rp " + string.Format("{0:N0}", bank);
            }

            int total = cash + bank;
            labelTotalSales.Text = "Rp " + string.Format("{0:N0}", total);
            dtsimpanTransaksi = new DataTable();
            methods.command("select id_transaksi from transaksi where status_transaksi = 0 and DATE(created_at_transaksi) = DATE(now()) and deleted_at_transaksi is null;", dtsimpanTransaksi);

            Label label1 = new Label();
            label1.Location = new Point(18, 30);
            label1.Size = new Size(196, 41);
            label1.Font = new Font("Leelawadee UI", 18, FontStyle.Bold);
            label1.Text = "Active Order";
            label1.ForeColor = Color.FromArgb(114, 134, 127);
            this.panelOrder.Controls.Add(label1);

            Label label2 = new Label();
            label2.Location = new Point(-3, 72);
            label2.Size = new Size(500, 25);
            label2.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            label2.Text = "_________________________________________________________";
            label2.ForeColor = SystemColors.ControlDark;
            this.panelOrder.Controls.Add(label2);


            if (dtsimpanTransaksi.Rows.Count > 0)
            {
                dtsimpanDetail = new DataTable();
                string id = "'" + dtsimpanTransaksi.Rows[0][0].ToString() + "'";
                string query = $"CALL pDetailTransaksi({id});";
                methods.command(query, dtsimpanDetail);
                Design();
            }

           
        }
    }
}

using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formOrder : Form
    {
        public static formOrder Instance;
        public formOrder()
        {
            InitializeComponent();
            Instance = this;
        }
        Methods methods = new Methods();
        DataTable dtMenu = new DataTable();
        public DataTable dtOrder = new DataTable();
        DataTable dtDetail = new DataTable();
        Label[] labelnama;
        Label[] labelHarga;
        Guna2Button[] btnAdd;
        Guna2TextBox[] background;
        Guna2PictureBox[] foto;
        string id_metode_pembayaran = "";
        string totalHarga;

        private void formOrder_Load(object sender, EventArgs e)
        {

            btnAll.FillColor = Color.Gainsboro; // berubah
            btnAll.PerformClick();
            dtOrder = new DataTable();
            dtOrder.Columns.Add("Product");
            dtOrder.Columns.Add("Quantity");
            dtOrder.Columns.Add("Price");
            dtOrder.Columns.Add("Edit", typeof(Image));
            totalPrice();

            dgvOrder.DataSource = dtOrder;

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text != "Search Menu")
            {
                txtBoxSearch.Text = "Search Menu";
            }
            Guna2Button btn = (Guna2Button)sender;
            string query = "";
            switch (btn.Name)
            {
                case "btnAll":

                    btnAll.FillColor = Color.Gainsboro;
                    btnFood.FillColor = Color.FromArgb(255, 251, 251);
                    btnDrink.FillColor = Color.FromArgb(255, 251, 251);
                    query = "select nama_menu, harga_menu, gambar_menu\r\nfrom menu where deleted_at_menu is null;"; // ini query all
                    UpdateKatalog(query);
                    break;
                case "btnFood":
                    btnFood.FillColor = Color.Gainsboro;
                    btnAll.FillColor = Color.FromArgb(255, 251, 251);
                    btnDrink.FillColor = Color.FromArgb(255, 251, 251);
                    query = "select m.nama_menu, m.harga_menu, m.gambar_menu\r\nfrom menu m join kategori k on k.id_kategori = m.id_kategori and k.nama_kategori = 'Makanan' where m.deleted_at_menu is null"; // ini query all
                    UpdateKatalog(query);
                    break;
                case "btnDrink":
                    btnDrink.FillColor = Color.Gainsboro;
                    btnAll.FillColor = Color.FromArgb(255, 251, 251);
                    btnFood.FillColor = Color.FromArgb(255, 251, 251);
                    query = "select m.nama_menu, m.harga_menu, m.gambar_menu\r\nfrom menu m join kategori k on k.id_kategori = m.id_kategori and k.nama_kategori = 'Minuman' where m.deleted_at_menu is null;"; // ini query all
                    UpdateKatalog(query);
                    break;
            }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string imagepath = Path.Combine(projectDirectory, "images", "edit.png");
            Image image = Image.FromFile(imagepath);

            dtDetail.Clear();

            string query = $"select nama_menu, harga_menu\r\nfrom menu where nama_menu = '{btn.Tag}' and deleted_at_menu is null;";
            methods.command(query, dtDetail);
            dgvOrder.DataSource = null;
            bool ada = false;
            int keBerapa = 0;
            if (dtOrder.Rows.Count != 0)
            {
                for (int i = 0; i < dtOrder.Rows.Count; i++)
                {
                    if (dtOrder.Rows[i]["Product"].ToString() == btn.Tag.ToString())
                    {
                        ada = true;
                        keBerapa = i;
                        break;
                    }
                }
                if (ada)
                {
                    int quantity = Convert.ToInt32(dtOrder.Rows[keBerapa]["Quantity"]) + 1;
                    dtOrder.Rows[keBerapa]["Quantity"] = quantity;///
                }
                else
                {
                    dtOrder.Rows.Add(dtDetail.Rows[0]["nama_menu"], 1, dtDetail.Rows[0]["harga_menu"], image);
                }
            }
            else
            {
                dtOrder.Rows.Add(dtDetail.Rows[0]["nama_menu"], 1, dtDetail.Rows[0]["harga_menu"], image);
            }

            totalPrice();

            dgvOrder.DataSource = dtOrder;

        }


        private void dgvOrder_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = dgvOrder.HitTest(e.X, e.Y);

                if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == 3)
                {

                    int quantity = Convert.ToInt32(dgvOrder.CurrentRow.Cells["Quantity"].Value.ToString());
                    string menu = dgvOrder.CurrentRow.Cells["Product"].Value.ToString();
                    int keBerapa = dgvOrder.CurrentCell.RowIndex;

                    //   dtOrder.Rows[keBerapa]["Quantity"] = quantity;

                    formEditQuantity f = new formEditQuantity(keBerapa, quantity, menu);
                    f.ShowDialog();
                }
            }
            dgvOrder.DataSource = dtOrder;
        }



        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {

            string query = $"select nama_menu, harga_menu, gambar_menu\r\nfrom menu where nama_menu like \"%{txtBoxSearch.Text}%\" and deleted_at_menu is null;"; // ini query all
            UpdateKatalog(query);

        }
        private void btnPay_Click(object sender, EventArgs e)
        {

            int angka = 0;
            string payment, nama, email, notes;
            bool salah = false;
            if (txtBoxName.Text != "Input Customer's Name" && txtBoxQue.Text != "Que Number Card" && dgvOrder.Rows.Count > 0)
            {
                nama = txtBoxName.Text;
                angka = Convert.ToInt32(txtBoxQue.Text);
            }
            else
            {
                salah = true;
            }


            if (btnCash.FillColor == Color.Gainsboro)
            {
                payment = btnCash.Tag.ToString();
            }
            else if (btnTransferBank.FillColor == Color.Gainsboro)
            {
                payment = btnTransferBank.Tag.ToString();
            }
            else
            {
                salah = true;
            }

            if (txtBoxEmail.Text != "Customer's email (optional)")
            {
                if (IsValidEmail(txtBoxEmail.Text) == false)
                {
                    MessageBox.Show("Wrong input email");
                    salah = true;
                }
                else
                {
                    email = txtBoxEmail.Text;
                }
            }
            else if (txtBoxNotes.Text != "Click to Add Notes")
            {
                notes = txtBoxNotes.Text;
            }


            if (salah == true)
            {

                formError f = new formError();
                f.ShowDialog();
            }
            else
            {
                // !!!!!! masuk ke database;
                DataTable dtQuery = new DataTable();
                string query = $"select id_admin from akun where username='{Methods.username}';";
                methods.command(query, dtQuery);
                string id_admin = dtQuery.Rows[0][0].ToString();

               if (txtBoxEmail.Text.Contains(","))
                {
                    MessageBox.Show("Wrong email, please recheck");
                }
              
                else if (txtBoxEmail.Text != "Customer's email (optional)" && txtBoxNotes.Text != "Click to Add Notes") //kl notes & email terisi
                {
                    
                  
                      query = $"insert into Transaksi (id_admin, id_metode_pembayaran, nama_pelanggan, no_antrian, total_harga, catatan, email) values ('{id_admin}','{id_metode_pembayaran}', '{txtBoxName.Text}', '{txtBoxQue.Text}', '{totalHarga}', '{txtBoxNotes.Text}', '{txtBoxEmail.Text}');";
                        methods.commandIUD(query);
                        sendEmail(txtBoxEmail.Text);
                  
                    //    MessageBox.Show("Email terkirim");
                    // SEND EMAIL    
                }
                else if (txtBoxNotes.Text != "Click to Add Notes") // kl notes terisi
                {
                    query = $"insert into Transaksi (id_admin, id_metode_pembayaran, nama_pelanggan, no_antrian, total_harga, catatan) values ('{id_admin}','{id_metode_pembayaran}', '{txtBoxName.Text}', '{txtBoxQue.Text}', '{totalHarga}', '{txtBoxNotes.Text}');";
                    methods.commandIUD(query);
               //     MessageBox.Show("Notes ada");
                }
                else if (txtBoxEmail.Text != "Customer's email (optional)")// kl email terisi & notes kosong
                {
                    query = $"insert into Transaksi (id_admin, id_metode_pembayaran, nama_pelanggan, no_antrian, total_harga, email) values ('{id_admin}','{id_metode_pembayaran}', '{txtBoxName.Text}', '{txtBoxQue.Text}', '{totalHarga}', '{txtBoxEmail.Text}');";
                    methods.commandIUD(query);
                 //   MessageBox.Show("Email terkirim & notes kosong");
                    // SEND EMAIL
                    sendEmail(txtBoxEmail.Text);
                }
                else
                {
                    query = $"insert into Transaksi (id_admin, id_metode_pembayaran, nama_pelanggan, no_antrian, total_harga) values ('{id_admin}', '{id_metode_pembayaran}', '{txtBoxName.Text}', '{txtBoxQue.Text}', '{totalHarga}');";
                    methods.commandIUD(query);
                }
                query = "select max(id_transaksi)\r\nfrom transaksi;";
                DataTable dtID = new DataTable();
                methods.command(query, dtID);
                string id = dtID.Rows[0][0].ToString();
                for (int i = 0; i < dtOrder.Rows.Count; i++)
                {
                    // cek id menu
                    query = $"select id_menu, harga_menu from menu where nama_menu = '{dtOrder.Rows[i]["Product"].ToString()}'";
                    DataTable dtCekMenu = new DataTable();
                    methods.command(query, dtCekMenu);

                    string idMenu = dtCekMenu.Rows[0][0].ToString();
                    string quantity = dtOrder.Rows[i]["Quantity"].ToString();
                    string harga = dtCekMenu.Rows[0][1].ToString();


                    query = $"insert into Detail_Transaksi (id_transaksi, id_menu, jumlah, harga) values ('{id}', '{idMenu}', '{quantity}', '{harga}');";
                    methods.commandIUD(query);
                }
                txtBoxName.Text = "Input Customer's Name";
                txtBoxEmail.Text = "Customer's email (optional)";
                txtBoxNotes.Text = "Click to Add Notes";
                txtBoxQue.Text = "Que Number Card";
                dtDetail.Clear();  dtOrder.Clear();
                dgvOrder.DataSource = null;
                formSuccess f = new formSuccess("New Order Has Been Created");
                f.ShowDialog();
            }
        }




        private void txtBoxNotes_Click(object sender, EventArgs e)
        {
            string edit = "write";
            string tulisan = "";
            if (txtBoxNotes.Text != "Click to Add Notes")
            {
                tulisan = txtBoxNotes.Text;
            }
            formNotes f = new formNotes(tulisan, edit);
            f.ShowDialog();
        }

        private void btnTransferBank_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            if (btn.Name == "btnCash")
            {
                btnCash.FillColor = Color.Gainsboro;
                btnTransferBank.FillColor = Color.FromArgb(255, 251, 251);
                id_metode_pembayaran = "MP0001";
            }
            else if (btn.Name == "btnTransferBank")
            {
                btnTransferBank.FillColor = Color.Gainsboro;
                btnCash.FillColor = Color.FromArgb(255, 251, 251);
                id_metode_pembayaran = "MP0002";
            }

        }

        public void totalPrice()
        {
            double total = 0;
            for (int i = 0; i < dtOrder.Rows.Count; i++)
            {
                total += Convert.ToDouble(dtOrder.Rows[i]["Quantity"]) * Convert.ToDouble(dtOrder.Rows[i]["Price"]);
            }

            labelTotal.Text = "Rp. " + total.ToString("N0");
            dgvOrder.DataSource = dtOrder;
            totalHarga = total.ToString();
        }
        private void txtBoxSearch_Enter(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "Search Menu")
            {
                txtBoxSearch.Text = "";
            }
            btnAll.FillColor = Color.Gainsboro;
            btnFood.FillColor = Color.FromArgb(255, 251, 251);
            btnDrink.FillColor = Color.FromArgb(255, 251, 251);
        }
        public void UpdateKatalog(string query)
        {
            int counter = 1;
            int baris = 1;
            panelMenu.Controls.Clear();
            dtMenu.Clear();
            methods.command(query, dtMenu);

            labelnama = new Label[dtMenu.Rows.Count];
            labelHarga = new Label[dtMenu.Rows.Count];
            btnAdd = new Guna2Button[dtMenu.Rows.Count];
            foto = new Guna2PictureBox[dtMenu.Rows.Count];
            background = new Guna2TextBox[dtMenu.Rows.Count];

            int xBackground = 17;
            int yBackground = 14;

            int xNama = 75;
            int yNama = 166;

            int xHarga = 84;
            int yHarga = 186;

            int xButton = 68;
            int yButton = 210;

            int xFoto = 42;
            int yFoto = 42;


            for (int i = 0; i < dtMenu.Rows.Count; i++)
            {

                background[i] = new Guna2TextBox();
                background[i].Location = new Point(xBackground, yBackground);
                background[i].Size = new Size(180, 240);
                background[i].BorderRadius = 20;
                background[i].FillColor = Color.White;
                background[i].ReadOnly = true;
                this.panelMenu.Controls.Add(background[i]);

                foto[i] = new Guna2PictureBox();
                foto[i].Location = new Point(xFoto, yFoto);
                foto[i].Size = new Size(130, 110);
                foto[i].BorderRadius = 15;
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                string imagepath = projectDirectory + dtMenu.Rows[i][2];
                foto[i].ImageLocation = imagepath;
                foto[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.panelMenu.Controls.Add(foto[i]);
                foto[i].BringToFront();

                labelnama[i] = new Label();
                labelnama[i].Location = new Point(xNama, yNama);
                labelnama[i].Size = new Size(80, 0);
                labelnama[i].AutoSize = true;
                labelnama[i].Font = new Font("Leelawadee UI", 9, FontStyle.Bold);
                labelnama[i].Text = dtMenu.Rows[i][0].ToString();
                labelnama[i].ForeColor = Color.FromArgb(114, 134, 127);
                labelnama[i].BackColor = Color.White;
                labelnama[i].MaximumSize = new Size(80, 0);
                labelnama[i].TextAlign = ContentAlignment.MiddleCenter;
                this.panelMenu.Controls.Add(labelnama[i]);
                labelnama[i].BringToFront();

                string[] cek = labelnama[i].Text.Split(' ');
                yHarga = labelnama[i].Location.Y + labelnama[i].Height;

                labelHarga[i] = new Label();
                labelHarga[i].Location = new Point(xHarga, yHarga);
                labelHarga[i].Size = new Size(80, 0);
                labelHarga[i].AutoSize = true;
                labelHarga[i].Font = new Font("Leelawadee UI", 9, FontStyle.Bold);
                labelHarga[i].Text = dtMenu.Rows[i][1].ToString();
                labelHarga[i].ForeColor = Color.FromArgb(114, 134, 127);
                labelHarga[i].BackColor = Color.White;
                labelHarga[i].TextAlign = ContentAlignment.MiddleCenter;
                this.panelMenu.Controls.Add(labelHarga[i]);
                labelHarga[i].BringToFront();

                btnAdd[i] = new Guna2Button();
                btnAdd[i].UseTransparentBackground = true;
                btnAdd[i].Location = new Point(xButton, yButton);
                btnAdd[i].Size = new Size(80, 30);
                btnAdd[i].BorderColor = Color.FromArgb(217, 221, 226);
                btnAdd[i].BorderRadius = 10;
                btnAdd[i].BorderThickness = 1;
                btnAdd[i].FillColor = Color.FromArgb(239, 239, 239);
                btnAdd[i].Font = new Font("Leelawadee UI", 9, FontStyle.Bold);
                btnAdd[i].ForeColor = Color.FromArgb(114, 134, 127);
                btnAdd[i].Text = "Add";
                btnAdd[i].Tag = labelnama[i].Text;
                btnAdd[i].Click += btnAdd_Click;
                this.panelMenu.Controls.Add(btnAdd[i]);
                btnAdd[i].BringToFront();

                if (cek.Length > 2)
                {
                    xNama += 15;

                }


                if (counter % 4 == 0 && counter >= 4)
                {
                    xBackground = 17;
                    yBackground += 270;

                    xFoto = 42;
                    yFoto += 270;

                    xNama = 71;
                    yNama += 270;

                    xHarga = 80;
                    yHarga += 270;

                    xButton = 68;
                    yButton += 270;
                    baris++;
                }
                else
                {
                    xBackground += 215;
                    xFoto += 215;
                    xNama += 210;
                    xHarga += 215;
                    xButton += 215;
                }

                counter++;
            }
            if (baris > 3)
            {

                panelMenu.AutoScroll = true;         // Disable horizontal scrolling
                panelMenu.HorizontalScroll.Enabled = false; // Enable vertical scrolling
                panelMenu.HorizontalScroll.Visible = false; // Make vertical scrollbar visible

            }

        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private void sendEmail(string alamatEmail)
        {

            string detailMakan = "";
            string query;
            for (int i = 0; i < dtOrder.Rows.Count; i++)
            {

                string menu = dtOrder.Rows[i]["Product"].ToString();
                double harga = Convert.ToDouble(dtOrder.Rows[i]["Price"]);
                int quantity = Convert.ToInt32(dtOrder.Rows[i]["Quantity"]);
                double ttlHarga = harga * quantity;
                detailMakan = detailMakan + string.Format("          <tbody><tr>\r\n              <td style=\"vertical-align:top\"><b>              {0}                 </b></td>\r\n              <td>{1}\r\n                  <p></p></td>\r\n              <td style=\"text-align:right;vertical-align:top\">\r\n                  @Rp{2}\r\n              </td>\r\n              <td style=\"text-align:right;vertical-align:top\">\r\n                  <b> Rp{3}</b>\r\n              </td>\r\n          </tr>", quantity.ToString(), menu, harga.ToString("N0"), ttlHarga.ToString("N0"));

            }


            query = "select max(id_transaksi)\r\nfrom transaksi;";
            DataTable dtID = new DataTable();
            methods.command(query, dtID);
            string id = dtID.Rows[0][0].ToString();

            DataTable isiOrder = new DataTable();
            query = $"select t.id_transaksi 'ID', t.nama_pelanggan 'name', t.catatan, DATE_FORMAT(t.created_at_transaksi, '%W, %e %M %Y') 'date', m.nama_metode 'metode', t.total_harga 'total' from transaksi t, metode_pembayaran m where m.id_metode_pembayaran = t.id_metode_pembayaran and t.id_transaksi = '{id}';";
            methods.command(query, isiOrder);

            string catatan = isiOrder.Rows[0]["catatan"].ToString();
            string dateandtime = isiOrder.Rows[0]["date"].ToString();
            string idtrans = isiOrder.Rows[0]["ID"].ToString();
            string name = isiOrder.Rows[0]["name"].ToString();
            string metodepembayaran = isiOrder.Rows[0]["metode"].ToString();
            double total = Convert.ToDouble(isiOrder.Rows[0]["total"]);


            string ttlharga = string.Format("<tr><td colspan=\"4\"><hr></td></tr>\r\n          \r\n      <tr>\r\n          <td colspan=\"2\" style=\"font-weight:bold\">Total pembayaran</td>\r\n          <td style=\"text-align:right;vertical-align:top\">\r\n          </td>\r\n          <td style=\"font-weight:bold;text-align:right;vertical-align:top\">\r\n              Rp{1}\r\n          </td>\r\n      </tr>\r\n      \r\n          \r\n      <tr>\r\n          <td colspan=\"2\">Metode Pembayaran</td>\r\n          <td style=\"text-align:right;vertical-align:top\">\r\n          </td>\r\n          <td style=\"text-align:right;vertical-align:top\">\r\n              {2}\r\n          </td>\r\n      </tr>", total.ToString("N0"), total.ToString("N0"), metodepembayaran);

       //     MessageBox.Show(catatan + dateandtime + idtrans + name + total);
            detailMakan = detailMakan + string.Format("<tr>\r\n              <td colspan=\"4\" style=\"vertical-align:top\">\r\n                 {0}              </td>\r\n          </tr>\r\n      \r\n      \r\n          \r\n\r\n      \r\n", catatan);
            string simpan = string.Format("<div style=\"font-size:11pt;background-color:#fafafa;font-family:Arial,sans-serif;width:50vw;min-width:600px;margin-left:auto;margin-right:auto\">\r\n  <div style=\"background-color:white;padding-bottom:0.1em;margin-bottom:1em;margin-left:auto;margin-right:auto;max-width:600px;width:600px;font-family:Arial,sans-serif;font-size:11pt\" width=\"600\">\r\n  \r\n  <table id=\"m_-7991567004525286311header\" style=\"color:white;min-width:100%;padding:1em;font-family:Arial,sans-serif;font-size:11pt;background-color:#C1E3D6\">\r\n      <tbody><tr>\r\n          <td style=\"max-width:25%\">\n <div style=\"text-align:left;font-size: 35px;\">Florette's Onecore </div> <td style=\"width:75%\">\r\n              <div style=\"text-align:right\">{0}</div>\r\n              <div style=\"text-align:right\">ID pesanan: {1}</div>\r\n          </td>\r\n      </tr>\r\n  </tbody></table>\r\n  \r\n      \r\n      <table id=\"m_-7991567004525286311thanks\" style=\"width:95%;margin-top:1em;margin-left:1em;margin-right:2em\">\r\n          <tbody><tr>\r\n              <td>\r\n                  <div style=\"margin:0;padding:0;font-size:16px;line-height:20px;margin-top:20px\">\r\n                      Hai {2},\r\n                      \r\n                  </div>\r\n                  <div style=\"font-weight:700;font-size:21px;line-height:28px;margin-top:8px;margin-bottom:24px\">\r\n                      Makasih udah pesan Florette's Onecore\r\n                  </div>\r\n              </td>\r\n          </tr>\r\n      </tbody></table>\r\n  \r\n      \r\n  <table id=\"m_-7991567004525286311header-total\" style=\"text-align:center;margin-top:0.5em;margin-bottom:0.5em;padding:0.5em;margin-left:auto;margin-right:auto;width:70%;border:1px solid #e8e8e8;background-color:#fafafa\">\r\n      <tbody><tr>\r\n          <td style=\"font-weight:bold;font-size:13pt;vertical-align:center;text-align:left;padding:0.2em;padding-left:1em\">Total dibayar</td>\r\n          <td style=\"font-weight:bold;color:green;font-size:13pt;vertical-align:center;text-align:right;padding:0.2em;padding-right:1em\">Rp{3}</td>\r\n      </tr>\r\n  </tbody></table>\r\n  \r\n  \r\n     \r\n     \r\n  \r\n  <p id=\"m_-7991567004525286311order-details-header\" style=\"margin-left:1em;margin-top:2em;font-size:12pt;font-weight:bold\">Rincian pesanan</p>\r\n  <table id=\"m_-7991567004525286311orders\" style=\"padding:1em;border:1px solid #e8e8e8;width:96%;margin-left:0.8em;margin-right:1em\">\r\n      \r\n          {4}{5}         \r\n          \r\n      \r\n      \r\n            </tbody></table>\r\n  \r\n      \r\n      \r\n          \r\n  \r\n  </tbody></table>\r\n  \r\n  \r\n  </div>\r\n  \r\n  <img width=\"1px\" height=\"1px\" alt=\"\" src=\"https://ci5.googleusercontent.com/proxy/iNYqsfJAAEctrmCF8iXoGkMahszQAUHr_5RKYCsCo9-XLFOnOu1jnMkNA9sCNQtSmAGRasff2_yvZbE7dD_MEikiUqFAdcIAMrkOM2CNCFlDLyNKZC8LbYupdk-fCEDA3pi9yXkTQF5iIeT6OArZTj8QVrFgJgOqU3j7ZBbBTHJBq5l4HwP5ke8EDvMMgW5Puo-k1Bhn3WxOusPlxwu35V4lFQd31fs0HBN9fD1ueXUbuhn8-TfKmuGBcWEmvUFwkqw5XTHro1AIWoAJQIqGScPN_yoDYykoaRFqRPPGPTtljb1g1QWNP7eeoTWhtg2Cak1GbKW-5lUuYkboevmITJhiA9kqsN3iM4ue8Dfo2TpTlpD8jydjkBC3S3459A=s0-d-e1-ft#http://email.invoicing.gojek.com/o/eJwczkFuxCAMQNHTlF0iYxwIC85Sge1QdzJEykSt5vZVuv5_8Xg3HdenSant_Xr1w0nR1bcQnRYfc1xyypHcV-G0ecqRsgJvEkJGzZskqQsHWBmdFQQMHiD64JFwhgVr0speOJAgfRDY-DmMbfS5H9_6mPl4urP82t70vNr5rgPurT-r7f_xOis_bPRbmKJkhrpMBOwnam2dGmCbcKMURCtkpL8AAAD__3_fPrY\" class=\"CToWUd\" data-bit=\"iit\"></div>", dateandtime, idtrans, name, total.ToString("N0"), detailMakan, ttlharga);


            try
            {

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mauuhehe12@gmail.com", "Florette's Onecore Receipt");
                mail.To.Add(new MailAddress(alamatEmail));
                mail.Subject = "INVOICE";
                mail.Body = simpan;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    SmtpClient client = new SmtpClient();
                    client.UseDefaultCredentials = false;
                    client.Host = "smtp.gmail.com";
                    var credentials = new System.Net.NetworkCredential("mauuhehe12@gmail.com", "kolcmoicrpbfujia");
                    client.Credentials = credentials;
                    client.Port = 587;
                    client.EnableSsl = true;

                    client.Send(mail);
                }
            }

            catch (SmtpException ex)
            {

               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                MessageBox.Show("Email has been sent");
            }
        }


        private void txtBoxSearch_Leave(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "")
            {
                txtBoxSearch.Text = "Search Menu";
            }
        }

        private void txtBoxName_Enter(object sender, EventArgs e)
        {
            if (txtBoxName.Text == "Input Customer's Name")
            {
                txtBoxName.Text = "";
            }
        }

        private void txtBoxName_Leave(object sender, EventArgs e)
        {
            if (txtBoxName.Text == "")
            {
                txtBoxName.Text = "Input Customer's Name";
            }
        }

        private void txtBoxQue_Enter(object sender, EventArgs e)
        {
            if (txtBoxQue.Text == "Que Number Card")
            {
                txtBoxQue.Text = "";
            }
        }

        private void txtBoxQue_Leave(object sender, EventArgs e)
        {
            if (txtBoxQue.Text == "")
            {
                txtBoxQue.Text = "Que Number Card";
            }
        }

        private void txtBoxQue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxEmail_Enter(object sender, EventArgs e)
        {

            if (txtBoxEmail.Text == "Customer's email (optional)")
            {
                txtBoxEmail.Text = "";
            }
        }

        private void txtBoxEmail_Leave(object sender, EventArgs e)
        {
            if (txtBoxEmail.Text == "")
            {
                txtBoxEmail.Text = "Customer's email (optional)";
            }
        }
    }
}


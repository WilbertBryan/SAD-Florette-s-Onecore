using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formManagementProduct : Form
    {
        public static formManagementProduct Instance;
        public formManagementProduct()
        {
            InitializeComponent();
            Instance = this;
        }
        Methods methods = new Methods();
        DataTable dtMenu = new DataTable();
        DataTable dtCategory = new DataTable();

        Label[] labelnama;
        Label[] labelHarga;
        Guna2Button[] btnAdd;
        Guna2TextBox[] background;
        Guna2PictureBox[] foto;
        string pathFoto;
        private void formManagementProduct_Load(object sender, EventArgs e)
        {
            btnAll.FillColor = Color.Gainsboro; // berubah
            btnAll.PerformClick();

            dtCategory = new DataTable();
            string query = "select * from kategori;";
            methods.command(query, dtCategory);
            cmbBoxCategory.DataSource = dtCategory;
            cmbBoxCategory.ValueMember = "id_kategori";
            cmbBoxCategory.DisplayMember = "nama_kategori";
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string query = $"select nama_menu, harga_menu, gambar_menu\r\nfrom menu where nama_menu like \"%{txtBoxSearch.Text}%\" and deleted_at_menu is null;"; // ini query all
            UpdateKatalog(query);
        }

        private void btn_Click(object sender, EventArgs e)
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
                    query = "select m.nama_menu, m.harga_menu, m.gambar_menu\r\nfrom menu m join kategori k on k.id_kategori = m.id_kategori and k.nama_kategori = 'Makanan' where m.deleted_at_menu is null;"; // ini query all
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            DataTable dtMenuApa = new DataTable();
            string query = $"select m.id_menu 'id', k.nama_kategori 'kategori', m.nama_menu 'nama', m.harga_menu 'harga', m.gambar_menu 'path'\r\nfrom menu m\r\njoin kategori k on k.id_kategori = m.id_kategori\r\nwhere m.nama_menu = '{btn.Tag}' and deleted_at_menu is null;";
            methods.command(query, dtMenuApa);
            string id = dtMenuApa.Rows[0]["id"].ToString();
            string kategori = dtMenuApa.Rows[0]["kategori"].ToString();
            string nama = dtMenuApa.Rows[0]["nama"].ToString();
            string harga = dtMenuApa.Rows[0]["harga"].ToString();
            string path = dtMenuApa.Rows[0]["path"].ToString();
            formEditProduct f = new formEditProduct(id, kategori, nama, harga, path);
            f.ShowDialog();
        }


        private void btnUpload_Click(object sender, EventArgs e)
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
           
            
            if(txtBoxName.Text != "Input Product's Name" && txtBoxPrice.Text != "Input Price" && cmbBoxCategory.SelectedIndex >=0 && Path.GetFileName(pathFoto) != null)
            {
                double cekHarga = Convert.ToDouble(txtBoxPrice.Text);
                if (cekHarga <1000)
                {
                    labelIncorrect.Text = "Minimum of price is Rp 1,000";
                    labelIncorrect.Visible = true;
                }
                else
                {
                    string workingDirectory = Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                    string gambarDatabase = "\\images\\" + Path.GetFileName(pathFoto);
                    File.Copy(pathFoto, Path.Combine(projectDirectory + gambarDatabase), true);
                    gambarDatabase = "\\\\images\\\\" + Path.GetFileName(pathFoto);


                    // INPUT KE DATABASE
                    DataTable cekNama = new DataTable();
                    string query = "select nama_menu from menu where deleted_at_menu is null";
                    methods.command(query, cekNama);
                    bool kembar = false;
                    foreach (DataRow dt in cekNama.Rows)
                    {
                        if (dt["nama_menu"].ToString().ToLower() == txtBoxName.Text.ToLower())
                        {
                            kembar = true;
                            break;
                        }
                    }
                    if (kembar)
                    {
                        // eror
                        labelIncorrect.Text = "Product's name already exist.";
                        labelIncorrect.Visible = true;
                    }
                    else // kalau makanan blm ada di menu
                    {
                        labelIncorrect.Visible = false;
                        cekNama = new DataTable();
                        query = "select nama_menu from menu where deleted_at_menu is not null";
                        methods.command(query, cekNama);

                        bool cekLagi = false;
                        foreach (DataRow dt in cekNama.Rows)
                        {
                            if (dt["nama_menu"].ToString().ToLower() == txtBoxName.Text.ToLower())
                            {
                                cekLagi = true;
                                break;
                            }

                        }
                        if (cekLagi)
                        {
                            query = $"update menu set id_kategori = '{cmbBoxCategory.SelectedValue.ToString()}', harga_menu = '{txtBoxPrice.Text}', gambar_menu = '{gambarDatabase}', deleted_at_menu = null where nama_menu = '{txtBoxName.Text}'";
                            methods.commandIUD(query);

                            gambar.Image = null;
                            txtBoxName.Text = "Input Product's Name";
                            txtBoxPrice.Text = "Input Price";
                            cmbBoxCategory.SelectedIndex = 0;
                        }
                        else
                        {
                            // insert ke database 
                            query = $"insert into menu(id_kategori, nama_menu, harga_menu, gambar_menu) values ('{cmbBoxCategory.SelectedValue}','{txtBoxName.Text}','{txtBoxPrice.Text}','{gambarDatabase}');";
                            methods.commandIUD(query);

                            gambar.Image = null;
                            txtBoxName.Text = "Input Product's Name";
                            txtBoxPrice.Text = "Input Price";
                            cmbBoxCategory.SelectedIndex = 0;
                        }
                        btnAll.PerformClick();
                    }
               
                }
            } else
            {
                labelIncorrect.Text = "Please fill all the requirements.";
                labelIncorrect.Visible = true;
            }
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
                btnAdd[i].Text = "Edit";
                btnAdd[i].Tag = labelnama[i].Text;
                btnAdd[i].Click += btnEdit_Click;
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

        private void txtBoxSearch_Leave(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "")
            {
                txtBoxSearch.Text = "Search Menu";
            }
        }
        private void txtBoxName_Enter(object sender, EventArgs e)
        {
            if (txtBoxName.Text == "Input Product's Name")
            {
                txtBoxName.Text = "";
            }
        }

        private void txtBoxName_Leave(object sender, EventArgs e)
        {
            if (txtBoxName.Text == "")
            {
                txtBoxName.Text = "Input Product's Name";
            }
        }

        private void txtBoxPrice_Enter(object sender, EventArgs e)
        {
            if (txtBoxPrice.Text == "Input Price")
            {
                txtBoxPrice.Text = "";
            }
        }

        private void txtBoxPrice_Leave(object sender, EventArgs e)
        {
            if (txtBoxPrice.Text == "")
            {
                txtBoxPrice.Text = "Input Price";
            }
        }

        private void txtBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

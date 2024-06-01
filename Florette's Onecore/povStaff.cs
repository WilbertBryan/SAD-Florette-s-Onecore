using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class povStaff : Form
    {
        public static povStaff Staff;
        public povStaff()
        {
            InitializeComponent();
            Staff = this;
        }

        private void povStaff_Load(object sender, EventArgs e)
        {
            btnHome.PerformClick();
            btnAdmin.Text = Methods.username;
            labelRole.Text = Methods.jabatan;
        }
        Methods methods = new Methods();
        string simpanWarna;
        private void btnHome_Click(object sender, EventArgs e)
        {

            List<Guna2Button> buttons = new List<Guna2Button>()
            {
                btnAdmin,
                btnHome,
                btnOrder,
                btnAllOrders,
                btnLogout
            };


            Guna2Button btn = (Guna2Button)sender;

            if (simpanWarna != null & simpanWarna != btn.Name)
            {
                foreach (Guna2Button b in buttons)
                {
                    if (simpanWarna == b.Name)
                    {
                        simpanWarna = b.Name;
                        b.FillColor = Color.Transparent;
                        b.UseTransparentBackground = true;
                    }
                }
            }


            if (btn.UseTransparentBackground == false && btn.Name != "btnHome")
            {
                btn.FillColor = Color.Transparent;
                btn.UseTransparentBackground = true;
                btn.Tag = "keHome";
            }
            else if (btn.UseTransparentBackground == true)
            {
                btn.FillColor = Color.FromArgb(255, 255, 251);
                btn.UseTransparentBackground = false;
                btn.Tag = "";
            }
            simpanWarna = btn.Name;


            switch (btn.Name)
            {
                case "btnAdmin":
                    if (btn.Tag.ToString() == "keHome")
                    {
                        btnHome.PerformClick();
                    }
                    else
                    {
                        loadForm(new formEditAccount());
                    }

                    break;

                case "btnHome":
                    loadForm(new formHome());
                    break;
                case "btnOrder":
                    if (btn.Tag.ToString() == "keHome")
                    {
                        btnHome.PerformClick();
                    }
                    else
                    {
                        loadForm(new formOrder());
                    }
                    break;

                case "btnAllOrders":
                    if (btn.Tag.ToString() == "keHome")
                    {
                        btnHome.PerformClick();
                    }
                    else
                    {
                        loadForm(new formAllOrders());
                    }
                    break;
                case "btnLogout":

                    formLogOut f = new formLogOut();
                    f.ShowDialog();
                    break;
            }
            
        }
        private void loadForm(object Form)
        {
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.RemoveAt(0);
            }
            Form f = Form as Form;


            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.WindowState = FormWindowState.Maximized;

            this.panel1.Controls.Add(f);
            this.panel1.Tag = "f";
            f.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Florette_s_Onecore
{
    public partial class formOrderCheck : Form
    {

        public formOrderCheck(string id)
        {
            InitializeComponent();
            idTransaksi = id;
        }
        Methods method = new Methods();
        string idTransaksi;

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (toggle.Checked == true)
            {
                string query = $"update Transaksi \r\nset status_transaksi = 1 \r\nwhere id_transaksi = '{idTransaksi}';";
                method.commandIUD(query);
                formHome.Instance.Update();
                formSuccess f = new formSuccess("Status Has Been Changed");
                this.Close();
                f.ShowDialog();
            }
            else if(toggle.Checked == false)
            {
                string query = $"update Transaksi \r\nset status_transaksi = 0\r\nwhere id_transaksi = '{idTransaksi}';";
                method.commandIUD(query);
            }
        }

        private void formOrderCheck_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Florette_s_Onecore
{
    public class Methods
    {
        public static string jabatan, username;


        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        MySqlDataReader sqlDataReader;
        string connection = "server=localhost;uid=root;pwd=root;database=db_florettes";
        public void NewForm(Form awal,Form child)
        {
            awal.Hide();
            child.MdiParent = MDI.instance;
            child.Show();
            child.WindowState = FormWindowState.Maximized;
            child.BringToFront();
        }
        
        public void simpanRole(string role)
        {
            jabatan = role;
        }

        public void simpanUsername(string usn)
        {
            username = usn;
        }

        public void command(string code, DataTable data)
        {
            try
            {
                sqlConnection = new MySqlConnection(connection);
                sqlConnection.Open();
                sqlCommand = new MySqlCommand(code, sqlConnection);
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void commandIUD(string query)
        {
            try
            {
                sqlConnection = new MySqlConnection(connection);
                sqlConnection.Open();
                sqlCommand = new MySqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string generateID(string kode,string queryID)
        {
            DataTable dt = new DataTable();
            sqlConnection = new MySqlConnection(connection);
            sqlConnection.Open();
            sqlCommand = new MySqlCommand(queryID, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt);

            int id = Convert.ToInt32(dt.Rows[0][0]) + 1;
            string ids = id.ToString();
            for (int i = 4 - ids.Length; i >= 1; i--)
            {
                kode += "0";
            }
            kode += ids;
            return kode;
        }
    }
}

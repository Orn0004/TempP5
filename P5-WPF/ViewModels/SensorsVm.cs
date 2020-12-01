using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P5_WPF.ViewModels
{
    class SensorsVm
    {
        public SensorsVm()
        {

            DataTable dt = new DataTable();
            string CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        }
        private void FindBatchID(string CS, int id)
        {
            using (MySqlConnection conn = new MySqlConnection(CS))
            { 
                    try
                    {
                        string query = $"SELECT BatchID FROM aktivesensorer WHERE ID = {id}";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                        conn.Open();
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        // write exception info to log or anything else
                        MessageBox.Show("Error occured!");
                    }
            }
        }
    }
}

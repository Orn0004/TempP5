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
        public DataView sensors { get; private set; }
        public SensorsVm()
        {
            DataTable dt = new DataTable();
            string CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SensorsInject(CS);
        }

        private void SensorsInject(string CS)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CS))
                {
                    string CmdString = $"SELECT * FROM aktivesensorer";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                    adapter.Fill(dt);
                }
                //Dataview of the selected sql table from query
                sensors = dt.DefaultView;
            }
            catch (Exception)
            {
            }
        }
    }
}

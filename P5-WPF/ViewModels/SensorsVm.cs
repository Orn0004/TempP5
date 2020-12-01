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
            //ActiveSensorsInjection(CS);
        }
        private void ActiveSensorsInjection(string CS)
        {
            using (MySqlConnection connection = new MySqlConnection(CS))
            string CmdString = $"SELECT * FROM aktivesensor;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(CmdString, connection);
            adapter.Fill(dt);

            {
                try
                {
                    da = new MySqlDataAdapter(connection);
                    da.Fill(dt);
                    Combo1.DataSource = dt;
                    Combo1.DataTextField = dtbl.Columns["ClerkId"].ToString();
                    Combo1.DataBind();
                }
                catch (Exception ex)
                {
                    connection.Close();

                }
            }
        }
    }
}


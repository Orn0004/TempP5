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
    public class SingleBatchVm
    {
        public DataView singleBatch { get; private set; }
        public string myTitle { get; private set; }
        public SingleBatchVm(int id)
        {
            myTitle = "Batch no." + id;

            //var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            //DataTable dt = new DataTable();
            //try
            //{
            //    using (MySqlConnection connection = new MySqlConnection(CS))
            //    {
            //        string CmdString = "SELECT * FROM aktivetemperaturer WHERE BatchID = ";
            //        MySqlDataAdapter adapter = new MySqlDataAdapter();
            //        adapter.SelectCommand = new MySqlCommand(CmdString, connection);
            //        adapter.Fill(dt);
            //    }
            //    singleBatch = dt.DefaultView;
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Cannot establish connection");
            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}

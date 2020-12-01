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
            string CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            //ActiveSensorsInjection(CS);
        }
        //private void ActiveSensorsInjection(string CS)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(CS))
        //    {
        //        try
        //        {
        //            string query = "SELECT ID from aktivesensorer";
        //            MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
        //            connection.Open();
        //            DataSet ds = new DataSet();
        //            da.Fill(ds, "Sensor");
        //            cmbTripName.DisplayMember = "ID";
        //            cmbTripName.ValueMember = "ID";
        //            cmbTripName.DataSource = ds.Tables["Sensor"];
        //        }
        //        catch (Exception ex)
        //        {
        //            // write exception info to log or anything else
        //            MessageBox.Show("Error occured!");
        //        }
        //    }
        //}
    }
}


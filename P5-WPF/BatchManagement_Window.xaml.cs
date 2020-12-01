using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using P5_WPF.ViewModels;
using System.Windows.Forms;
using System.Media;

namespace P5_WPF
{
    /// <summary>
    /// Interaction logic for BatchManagement_Window.xaml
    /// </summary>
    public partial class BatchManagement_Window : Window
    {
        public BatchManagement_Window()
        {
            InitializeComponent();

            string CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            sensorsInject(CS);
            //SensorCB.Items.Insert(0, "-SELECT SENSOR-");
            SensorCB.SelectedIndex = 0;
        }
        public void sensorsInject(string CS)
        {
            using (MySqlConnection conn = new MySqlConnection(CS))
            {
                string query = $"SELECT ID, BatchID FROM aktivesensorer";
                MySqlCommand sqlCmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader sqlReader = sqlCmd.ExecuteReader();
                Dictionary<string, string> sensordata = new Dictionary<string,string>();
                while (sqlReader.Read())
                {

                    SensorCB.Items.Add(sqlReader["ID"].ToString());
                    sensordata.Add(sqlReader["ID"].ToString(), sqlReader["BatchID"].ToString());

                }



                sqlReader.Close();
            }
        }

        private void addToDB(object sender, RoutedEventArgs e)
        {
            var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(CS))
                try
                {
                    {
                        MySqlCommand cmd = new MySqlCommand($"UPDATE aktivesensorer SET BatchID = (@BatchID) WHERE ID = {SensorCB.SelectedValue}", con);
                        cmd.Parameters.AddWithValue("@BatchID", New_Batch.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        System.Windows.Forms.MessageBox.Show($"Batch {New_Batch.Text} sucessfully connected to DH22 Sensor {SensorCB.SelectedValue}");
                    }
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show($"ERROR: Batch {New_Batch.Text} is connected to another DH22 Sensor");
                }
        }
        private void findBatchID(string CS, int id)
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
                    System.Windows.Forms.MessageBox.Show("Error occured!");
                }
            }
        }
    }
}

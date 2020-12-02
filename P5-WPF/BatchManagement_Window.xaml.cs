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
using System.Text.RegularExpressions;

namespace P5_WPF
{
    /// <summary>
    /// Interaction logic for BatchManagement_Window.xaml
    /// </summary>
    public partial class BatchManagement_Window : Window
    {
        public List<string> sensordata = new List<string>();
        public BatchManagement_Window()
        {
            InitializeComponent();

            string CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            sensorsInject(CS);
            //SensorCB.Items.Insert(0, "-SELECT SENSOR-");
            SensorCB.SelectedIndex = 0;
        }

        private void SensorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sensordata.Any())
            {
                CurrentBatch.Content = sensordata[SensorCB.SelectedIndex];
            }
        }
        public void sensorsInject(string CS)
        {
            SensorCB.Items.Clear();
            sensordata.Clear();
            using (MySqlConnection conn = new MySqlConnection(CS))
            {
                string query = $"SELECT ID, BatchID FROM aktivesensorer";
                MySqlCommand sqlCmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    SensorCB.Items.Add(sqlReader["ID"].ToString());
                    sensordata.Add(sqlReader["BatchID"].ToString());
                }
                sqlReader.Close();
            }
        }

        private void INTonly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void addToDB(object sender, RoutedEventArgs e)
        {
            if (New_Batch.Text.Trim() == string.Empty)
                System.Windows.MessageBox.Show("ERROR: 'New Batch'-Textbox is empty");
            else
            {
                var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(CS))
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand($"UPDATE aktivesensorer SET BatchID = (@BatchID) WHERE ID = {SensorCB.SelectedValue}", con);
                        cmd.Parameters.AddWithValue("@BatchID", New_Batch.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        System.Windows.Forms.MessageBox.Show($"Batch {New_Batch.Text} successfully connected to DH22 Sensor {SensorCB.SelectedValue}");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        //System.Windows.Forms.MessageBox.Show($"ERROR: Batch {New_Batch.Text} is connected to another DH22 Sensor");
                    }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace P5_WPF
{
    
    public partial class BatchAdd : Window
    {
        public BatchAdd()
        {
            InitializeComponent();
        }
        private void addToDB(object sender, RoutedEventArgs e)
        {


            string CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(CS))
                try
                {
                    {
                        
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO batch (BatchNr, Temp, Shelf) Values (@BatchNr, @Temp, @Shelf) ");
                        cmd.Parameters.AddWithValue("@BatchNr", BatchNr.Text);
                        cmd.Parameters.AddWithValue("@Temp", Temp.Text);
                        cmd.Parameters.AddWithValue("@Shelf", Shelf.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot establish connection");
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
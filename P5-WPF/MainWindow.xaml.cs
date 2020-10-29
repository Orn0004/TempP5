using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace P5_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BatchesModel BatchID;
        private IEnumerable<BatchesVm> Batches;

        public MainWindow()
        {

            InitializeComponent();
            FillDataGrid();

        }
        private void Batch_Click(object sender, RoutedEventArgs e)
        {

            BatchAdd batchAdd = new BatchAdd();
            batchAdd.Show();
        }

        //private void BatchInfo(object sender, RoutedEventArgs e)
        //{

        //    test_button.Visibility = welcome_text.Visibility = tables_button.Visibility = Visibility.Hidden;
        //    back_button.Visibility = Visibility.Visible;
        //}

        //private void back_button_Click(object sender, RoutedEventArgs e)
        //{
        //    test_button.Visibility = welcome_text.Visibility = tables_button.Visibility = Visibility.Visible;
        //    back_button.Visibility = Visibility.Hidden;
        //}

        private void FillDataGrid()
        {
            var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            string CmdString = string.Empty;
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                CmdString = "SELECT DISTINCT BatchID FROM aktivetemperaturer";
                MySqlCommand cmd = new MySqlCommand(CmdString, con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Batches");
                sda.Fill(dt);
                grdBatches.ItemsSource = dt.DefaultView;
            }
        }

    }

}

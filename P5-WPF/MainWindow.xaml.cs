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
using P5_WPF.ViewModels;

namespace P5_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();

        }
        private void Batch_Click(object sender, RoutedEventArgs e)
        {

            BatchAdd batchAdd = new BatchAdd();
            batchAdd.Show();
        }

        private void BatchInfo(object sender, RoutedEventArgs e)
        {

            test_button.Visibility = aktivebatches.Visibility = tables_button.Visibility = Visibility.Hidden;
            back_button.Visibility = Visibility.Visible;
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            test_button.Visibility = aktivebatches.Visibility = tables_button.Visibility = Visibility.Visible;
            back_button.Visibility = Visibility.Hidden;
        }
        private void batchesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SingleBatch_Window single = new SingleBatch_Window();
            single.Show();
        }
    }

}

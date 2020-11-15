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
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using P5_WPF.ViewModels;
using System.Collections;
using System.Data.SqlClient;
using System.Xml;
using System.Windows.Threading;

namespace P5_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer t;
        DateTime start;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BatchesVm();

            t = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Render,
            t_Tick, Dispatcher.CurrentDispatcher); t.IsEnabled = true;
            start = DateTime.Now;
        }
        private void t_Tick(object sender, EventArgs e)
        {
            TimerDisplay.Text = Convert.ToString(DateTime.Now - start);   
            CommandManager.InvalidateRequerySuggested();
        }
        private void RefreshTable(object sender, RoutedEventArgs e)
        {
            DataContext = new BatchesVm();
        }
        //private void BatchInfo(object sender, RoutedEventArgs e)
        //{

        //    test_button.Visibility = aktivebatches.Visibility = tables_button.Visibility = Visibility.Hidden;
        //    back_button.Visibility = Visibility.Visible;
        //}

        //private void back_button_Click(object sender, RoutedEventArgs e)
        //{
        //    test_button.Visibility = aktivebatches.Visibility = tables_button.Visibility = Visibility.Visible;
        //    back_button.Visibility = Visibility.Hidden;
        //}
        private void batchesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //get index of the selected row.
                int itemindex = batcheslist.Items.IndexOf(batcheslist.SelectedItems[0]);
                BatchesVm a = new BatchesVm();
                //get id of selected row.
                int batchId = a.allBatchIds[itemindex];

                SingleBatch_Window single = new SingleBatch_Window(batchId);
                single.Show();
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Venligst vælg en Batch.");
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }    
        }

      
    }

}

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
        int counter ;
        int countAmount = 5;       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BatchesVm();
            start = DateTime.Now;
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);
            

            t = new DispatcherTimer(new TimeSpan(1), DispatcherPriority.Render,
            t_Tick, Dispatcher.CurrentDispatcher); t.IsEnabled = true;


        }
        private void t_Tick(object sender, EventArgs e)
        {
             
            CommandManager.InvalidateRequerySuggested();
            
            if (counter == 0)
            {

               
                
            }
            counter--;
        }

        private void RefreshTable(object sender, RoutedEventArgs e)
        {
            TimerDisplay.Text = start.ToString("dd MMMM yyyy hh:mm:ss tt");
            DataContext = new BatchesVm();
            start = DateTime.Now;
            counter = countAmount;
        }
        private void Batch_Click(object sender, RoutedEventArgs e)
        {

            BatchManagement_Window batchAdd = new BatchManagement_Window();
            batchAdd.Show();
        }

        private void NotVisible_Click(object sender, RoutedEventArgs e)
        {

            archive_button.Visibility = activetext.Visibility = batcheslist.Visibility =  Visibility.Hidden;
            active_button.Visibility = archivedbatcheslist.Visibility = archivetext.Visibility = Visibility.Visible;
        }

        private void Visible_Click(object sender, RoutedEventArgs e)
        {
            archive_button.Visibility = activetext.Visibility = batcheslist.Visibility = Visibility.Visible;
            active_button.Visibility = archivedbatcheslist.Visibility = archivetext.Visibility = Visibility.Hidden;
        }
        private void batchesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //get index of the selected row.
                int itemindex = batcheslist.Items.IndexOf(batcheslist.SelectedItems[0]);
                BatchesVm a = new BatchesVm();
                //get id of selected row.
                int batchId = a.activeBatchIds[itemindex];

                SingleBatch_Window single = new SingleBatch_Window(batchId, true);
                single.Show();
            }

            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: You have not chosen a Batch.");
            }    
        }

        private void archivedbatchesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //get index of the selected row.
                int itemindex = archivedbatcheslist.Items.IndexOf(archivedbatcheslist.SelectedItems[0]);
                BatchesVm a = new BatchesVm();
                //get id of selected row.
                int batchId = a.archivedBatchIds[itemindex];

                SingleBatch_Window single = new SingleBatch_Window(batchId, false);
                single.Show();
            }

            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Error: You have not chosen a Batch.");
            }
        }



    }

}

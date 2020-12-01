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
          
        }
       private void Sensor_List()
        {
            SensorsVm a = new SensorsVm();
           
        }
    }
}

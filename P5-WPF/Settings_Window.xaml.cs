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
using System.Windows.Shapes;

namespace P5_WPF
{
    /// <summary>
    /// Interaction logic for Settings_Window.xaml
    /// </summary>
    public partial class Settings_Window : Window
    {
        public Settings_Window()
        {
            InitializeComponent();
        }
        private void HumValue_Click(object sender, RoutedEventArgs e)
        {
            ValueSettings_Window HumV = new ValueSettings_Window(true);
            HumV.Show();
        }
        private void TempValue_Click(object sender, RoutedEventArgs e)
        {
            ValueSettings_Window TempV = new ValueSettings_Window(false);
            TempV.Show();
        }
    }
}
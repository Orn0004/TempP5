using P5_WPF.ViewModels;
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
using System.Reactive.Linq;

namespace P5_WPF
{
    /// <summary>
    /// Interaction logic for SingleBatch_Window.xaml
    /// </summary>
    public partial class SingleBatch_Window : Window
    {
        public bool hwr { get; set; }
        public bool twr { get; set; }
        public SingleBatch_Window(int id)
        {
            InitializeComponent();
            DataContext = new SingleBatchVm(id);

            SingleBatchVm a = new SingleBatchVm(id);

            //assigning x and y axis for graphs with data from the batch
            var y1 = a.temperaturerlist;
            var y2 = a.luftfugtighedlist;
            var x = a.tidspunktlist;

            //drawing linegraph with the data
            linegraphtemp.Plot(x, y1);
            linegraphhum.Plot(x, y2);
        }

    }
}

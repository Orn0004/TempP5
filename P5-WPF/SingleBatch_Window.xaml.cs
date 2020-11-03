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
        public SingleBatch_Window(int id)
        {
            InitializeComponent();
            DataContext = new SingleBatchVm(id);

            var x = Enumerable.Range(0, 1001).Select(i => i / 10.0).ToArray();
            var y = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v).ToArray();

            linegraph.Plot(x, y); // x and y are IEnumerable<double>

        }

    }
}

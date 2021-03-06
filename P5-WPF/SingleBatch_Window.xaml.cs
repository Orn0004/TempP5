﻿using P5_WPF.ViewModels;
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
        public SingleBatch_Window(int id, bool active)
        {
            InitializeComponent();
            DataContext = new SingleBatchVm(id);

            SingleBatchVm a = new SingleBatchVm(id);
            if (active == true){
                //assigning x and y axis for graphs with data from the batch
                var y1 = a.activeTemperatureList;
                var y2 = a.activeHumidityList;
                var x = a.activeDateList;

                Visible();

                //drawing linegraph with the data
                linegraphtemp.Plot(x, y1);
                linegraphhum.Plot(x, y2);
            }
            else
            {
                var y1 = a.archivedTemperatureList;
                var y2 = a.archivedHumidityList;
                var x = a.archivedDateList;


                //drawing linegraph with the data
                linegraphtemp.Plot(x, y1);
                linegraphhum.Plot(x, y2);
            }

           
        }
        private void Visible()
        {

            archivedbatchinfo.Visibility = Visibility.Hidden;
            batchinfo.Visibility = Visibility.Visible;
        }


    }
}

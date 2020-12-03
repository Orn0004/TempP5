using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for HumidityValue_Window.xaml
    /// </summary>
    public partial class ValueSettings_Window : Window
    {
        private string ValueType { get; set; }
        private float UpperHum { get; set; }
        private float UpperTemp { get; set; }
        private float LowerTemp { get; set; }
        private float LowerHum { get; set; }
        private bool IsHumidity { get; set; }
        public ValueSettings_Window(bool Humidity)
        {
            InitializeComponent();
            UpperHum = Properties.Settings.Default.UpperHum;
            LowerHum = Properties.Settings.Default.LowerHum;
            UpperTemp = Properties.Settings.Default.UpperTemp;
            LowerTemp = Properties.Settings.Default.LowerTemp;
            IsHumidity = Humidity;
            if (IsHumidity)
            {
                ValueType = "HUMIDITY";
                CurrentRange.Content = LowerHum.ToString() + "% - " + UpperHum.ToString() + "%";
                RecommendedRange_Text.Content = "(Recommended range is 40 - 70%)";
                CurrentValue_Text.Content = "Current humidity value range:";
            }
            else
            {
                ValueType = "TEMPERATURE";
                CurrentRange.Content = LowerTemp.ToString() + "C - " + UpperTemp.ToString() + "C";
                RecommendedRange_Text.Content = "(Recommended range is 18 - 24 Celsius)";
                CurrentValue_Text.Content = "Current temperature value range:";
            }
        }
        private void INTonly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[-,0-9]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void SaveValues(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(UpperBoundNew.Text) && !string.IsNullOrEmpty(LowerBoundNew.Text))
                {
                if (IsHumidity)
                {
                    if (float.Parse(UpperBoundNew.Text) > float.Parse(LowerBoundNew.Text))
                    {
                        Properties.Settings.Default.UpperHum = float.Parse(UpperBoundNew.Text);
                        Properties.Settings.Default.LowerHum = float.Parse(LowerBoundNew.Text);
                        Properties.Settings.Default.Save();
                        System.Windows.Forms.MessageBox.Show($"New {ValueType} VALUE: '{LowerBoundNew.Text}-{UpperBoundNew.Text}'");
                        this.Close();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("ERROR: Lower bound is higher than upper bound.");
                    }
                }
                else
                {
                    if (float.Parse(UpperBoundNew.Text) > float.Parse(LowerBoundNew.Text))
                    {
                        Properties.Settings.Default.UpperTemp = float.Parse(UpperBoundNew.Text);
                        Properties.Settings.Default.LowerTemp = float.Parse(LowerBoundNew.Text);
                        Properties.Settings.Default.Save();
                        System.Windows.Forms.MessageBox.Show($"New {ValueType} VALUE: '{LowerBoundNew.Text}-{UpperBoundNew.Text}'");
                        this.Close();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("ERROR: Lower bound is higher than upper bound.");
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Both values not filled.");
            }

        }
    }
}

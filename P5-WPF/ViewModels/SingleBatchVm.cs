using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P5_WPF.ViewModels

{
    public class SingleBatchVm
    {
        public DataView singleBatch { get; private set; }
        public List<float> temperaturerlist { get; private set; }
        public List<double> tidspunktlist { get; private set; }
        public List<float> luftfugtighedlist { get; private set; }
        public bool temperaturewithinRange { get; private set; }
        public bool humiditywithinRange { get; private set; }
        public string myTitle { get; private set; }
        public SingleBatchVm(int id)
        {
            myTitle = "Batch no." + id;

            temperaturewithinRange = true;
            humiditywithinRange = true;

            var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CS))
                {
                    string CmdString = "SELECT * FROM aktivemaalinger WHERE BatchID = " + id;
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                    adapter.Fill(dt);
                }
                singleBatch = dt.DefaultView;
                
                //putting respective rows into generic lists in order to use for linegraph.
                temperaturerlist = singleBatch.ToTable().Rows.OfType<DataRow>()
                    .Select(dr => dr.Field<float>("Temperatur_Celsius")).ToList();
              
                luftfugtighedlist = singleBatch.ToTable().Rows.OfType<DataRow>()
                   .Select(dr => dr.Field<float>("Luftfugtighed_Procent")).ToList();
                
                foreach (float item in (temperaturerlist.Count > 12 ? temperaturerlist.Skip(temperaturerlist.Count - 12) : temperaturerlist))
                {
                    if (item >= 18 && item <= 24)
                    {
                        temperaturewithinRange = false;
                    }
                }

                foreach (float item in (luftfugtighedlist.Count > 12 ? luftfugtighedlist.Skip(luftfugtighedlist.Count - 12) : luftfugtighedlist))
                {
                    if (item >= 40 && item <= 70)
                    {
                        humiditywithinRange = false;
                    }
                }

                List<DateTime> _tidspunktlist = singleBatch.ToTable().Rows.OfType<DataRow>()
                    .Select(dr => dr.Field<DateTime>("Tidspunkt")).ToList();

                //converting DateTime generic list to a double list for OLE Automation date.
                List<double> __tidspunktlist = new List<double>();

                foreach (DateTime item in _tidspunktlist)
                {
                    double converteditem = item.ToOADate();
                    __tidspunktlist.Add(converteditem);
                }
                tidspunktlist = __tidspunktlist;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Cannot establish connection");
                MessageBox.Show(ex.Message);
            }

        }
    }
}

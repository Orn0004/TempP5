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
        public DataView activesinglebatch { get; private set; }
        public List<float> activeTemperatureList { get; private set; }
        public List<double> activeDateList { get; private set; }
        public List<float> activeHumidityList { get; private set; }

        public DataView archivedsinglebatch { get; private set; }
        public List<float> archivedTemperatureList { get; private set; }
        public List<double> archivedDateList { get; private set; }
        public List<float> archivedHumidityList { get; private set; }
        public bool humiditywithinRange { get; private set; }
        public bool temperaturewithinRange { get; private set; }
        public string myTitle { get; private set; }
        public SingleBatchVm(int id)
        {
            myTitle = "Batch no." + id;
            temperaturewithinRange = true;
            humiditywithinRange = true;
            var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            singleBatchInjection(CS, true, id);
            singleBatchInjection(CS, false, id);
        }

        private void singleBatchInjection(string CS, bool active, int id)
        {
            if (active == true)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(CS))
                    {
                        string CmdString = $"SELECT * FROM aktivemaalinger WHERE BatchID = {id}";
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                        adapter.Fill(dt);
                    }
                    activesinglebatch = dt.DefaultView;

                    //putting respective rows into generic lists in order to use for linegraph.
                    activeTemperatureList = activesinglebatch.ToTable().Rows.OfType<DataRow>()
                        .Select(dr => dr.Field<float>("Temperatur_Celsius")).ToList();

                    activeHumidityList = activesinglebatch.ToTable().Rows.OfType<DataRow>()
                       .Select(dr => dr.Field<float>("Luftfugtighed_Procent")).ToList();

                    foreach (float item in (activeTemperatureList.Count > 12 ? activeTemperatureList.Skip(activeTemperatureList.Count - 12) : activeTemperatureList))
                    {
                        if (item >= 18 && item <= 24)
                        {
                            temperaturewithinRange = false;
                        }
                    }

                    foreach (float item in (activeHumidityList.Count > 12 ? activeHumidityList.Skip(activeHumidityList.Count - 12) : activeHumidityList))
                    {
                        if (item >= 40 && item <= 70)
                        {
                            humiditywithinRange = false;
                        }
                    }

                    List<DateTime> _tidspunktlist = activesinglebatch.ToTable().Rows.OfType<DataRow>()
                        .Select(dr => dr.Field<DateTime>("Tidspunkt")).ToList();

                    //converting DateTime generic list to a double list for OLE Automation date.
                    List<double> __tidspunktlist = new List<double>();

                    foreach (DateTime item in _tidspunktlist)
                    {
                        double converteditem = item.ToOADate();
                        __tidspunktlist.Add(converteditem);
                    }
                    activeDateList = __tidspunktlist;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Cannot establish connection");
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                DataTable dta = new DataTable();
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(CS))
                    {
                        string CmdString = $"SELECT * FROM arkiveretmaalinger WHERE BatchID = {id}";
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                        adapter.Fill(dta);
                    }
                    archivedsinglebatch = dta.DefaultView;

                    //putting respective rows into generic lists in order to use for linegraph.
                    archivedTemperatureList = archivedsinglebatch.ToTable().Rows.OfType<DataRow>()
                        .Select(dr => dr.Field<float>("Temperatur_Celsius")).ToList();

                    archivedHumidityList = archivedsinglebatch.ToTable().Rows.OfType<DataRow>()
                       .Select(dr => dr.Field<float>("Luftfugtighed_Procent")).ToList();


                    List<DateTime> _dateList = archivedsinglebatch.ToTable().Rows.OfType<DataRow>()
                        .Select(dr => dr.Field<DateTime>("Tidspunkt")).ToList();

                    //converting DateTime generic list to a double list for OLE Automation date.
                    List<double> __dateList = new List<double>();

                    foreach (DateTime item in _dateList)
                    {
                        double converteditem = item.ToOADate();
                        __dateList.Add(converteditem);
                    }
                    archivedDateList = __dateList;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Cannot establish connection");
                    MessageBox.Show(ex.Message);
                }

            }

        }
    }
}

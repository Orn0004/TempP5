using MySql.Data.MySqlClient;
using P5_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;

namespace P5_WPF

{
    public class BatchesVm
    {
        public DataView activeBatches { get; private set; }
        public DataView archivedBatches { get; private set; }
        public List<int> activeBatchIds { get; private set; }
        public List<int> archivedBatchIds { get; private set; }
        public string myTitle { get; private set; }
        public BatchesVm()
        {
            myTitle = "Novefa RoomMonitor";
            string CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            ActiveBatchesInjection(CS);
            ArchivedBatchesInjection(CS);
        }

        private void ActiveBatchesInjection(string CS)
        {
            DataTable dtactive = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CS))
                {
                    string CmdString = "select BatchID,Temperatur_Celsius,Luftfugtighed_Procent,Tidspunkt from (select BatchID,Temperatur_Celsius,Luftfugtighed_Procent,Tidspunkt,row_number() over(partition by BatchID order by Tidspunkt desc) as rn from aktivemaalinger) t where t.rn = 1;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                    adapter.Fill(dtactive);
                }
                //Dataview of the selected sql table from query
                activeBatches = dtactive.DefaultView;

                //converting DataView allBatches BatchID's to a generic list.
                activeBatchIds = activeBatches.ToTable().Rows.OfType<DataRow>()
                    .Select(dr => dr.Field<int>("BatchID")).ToList();
            }
            catch (Exception)
            {
            }
        }
        private void ArchivedBatchesInjection(string CS)
        {
            DataTable dtarchive = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CS))
                {
                    string CmdString = "select BatchID,Temperatur_Celsius,Luftfugtighed_Procent,Tidspunkt from (select BatchID,Temperatur_Celsius,Luftfugtighed_Procent,Tidspunkt,row_number() over(partition by BatchID order by Tidspunkt desc) as rn from arkiveretmaalinger) t where t.rn = 1;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                    adapter.Fill(dtarchive);
                }
                //Dataview of the selected sql table from query
                archivedBatches = dtarchive.DefaultView;

                //converting DataView allBatches BatchID's to a generic list.
                archivedBatchIds = archivedBatches.ToTable().Rows.OfType<DataRow>()
                    .Select(dr => dr.Field<int>("BatchID")).ToList();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Cannot establish connection");
            }
        }
    }
}




using MySql.Data.MySqlClient;
using P5_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;

namespace P5_WPF

{
    public class BatchesVm
    {
        public DataView allBatches { get; private set; }
        public List<int> allBatchIds { get; private set; }
        public BatchesVm()
        {
            var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CS))
                {
                    string CmdString = "select BatchID,Temperatur_Celsius,Luftfugtighed_Procent,Tidspunkt from (select BatchID,Temperatur_Celsius,Luftfugtighed_Procent,Tidspunkt,row_number() over(partition by BatchID order by Tidspunkt desc) as rn from aktivemaalinger) t where t.rn = 1;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                    adapter.Fill(dt);
                }
                //Dataview of the selected sql table from query
                allBatches = dt.DefaultView;

                //converting DataView allBatches to a generic list.
                allBatchIds = allBatches.ToTable().Rows.OfType<DataRow>()
                    .Select(dr => dr.Field<int>("BatchID")).ToList();

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cannot establish connection");
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }
        //public CollectionView BatchesView { get; }

        //private string _filterText = "";
        //public string FilterText
        //{
        //    get => _filterText;
        //    set
        //    {
        //        if (SetValue(ref _filterText, value))
        //        {
        //            allBatches.Items.Refresh();
        //        }
        //    }
        //}


    }
}




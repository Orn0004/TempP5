using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P5_WPF

{
    public class BatchesVm
    {
        public DataView allBatches { get; private set; }
        public IEnumerable<int> BatchIds { get; private set; }
        public BatchesVm()
        {
            var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CS))
                {
                    string CmdString = "select BatchID,Temperatur_Celsius,Luftfugtighed_Procent,Tidspunkt from (select BatchID,Temperatur_Celsius,Luftfugtighed_Procent,Tidspunkt,row_number() over(partition by BatchID order by Tidspunkt desc) as rn from aktivetemperaturer) t where t.rn = 1;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                    adapter.Fill(dt);
                }
                allBatches = dt.DefaultView;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Cannot establish connection");
                MessageBox.Show(ex.Message);
            }
        }


    }
}




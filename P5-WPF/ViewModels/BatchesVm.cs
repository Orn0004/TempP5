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
    class BatchesVm
    {
        //private IList<BatchesModel> _BatchesList;
        public DataView AlleBatches { get; private set; }

        public BatchesVm()
        {
            var CS = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CS))
                {
                    string CmdString = "SELECT BatchID, Temperatur_Celsius, Luftfugtighed_Procent FROM aktivetemperaturer GROUP BY BatchID HAVING COUNT(*) > 1";
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(CmdString, connection);
                    adapter.Fill(dt);
                }
                AlleBatches = dt.DefaultView;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Cannot establish connection");
                MessageBox.Show(ex.Message);
            }
        }


    }
}

//public IList<User> Users
//{
//    get { return _UsersList; }
//    set { _UsersList = value; }
//}

//private ICommand mUpdater;
//public ICommand UpdateCommand
//{
//    get
//    {
//        if (mUpdater == null)
//            mUpdater = new Updater();
//        return mUpdater;
//    }
//    set
//    {
//        mUpdater = value;
//    }
//}

//private class Updater : ICommand
//{
//    #region ICommand Members  

//    public bool CanExecute(object parameter)
//    {
//        return true;
//    }

//    public event EventHandler CanExecuteChanged;

//    public void Execute(object parameter)
//    {

//    }

//    #endregion
//}



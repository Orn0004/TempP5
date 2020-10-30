using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_WPF
{
    public class BatchesModel : INotifyPropertyChanged
    {
        private int batchID;
        private int temperatur;
        private int luftFugtighed;
        private int tidspunkt;
        private int hyldeID;

        public int BatchID
        {
            get
            {
                return batchID;
            }
            set
            {
                BatchID = value;
                OnPropertyChanged("BatchID");
            }
        }
        public int Temperatur
        {
            get
            {
                return temperatur;
            }
            set
            {
                temperatur = value;
                OnPropertyChanged("FirstName");
            }
        }
        public int LuftFugtighed
        {
            get
            {
                return luftFugtighed;
            }
            set
            {
                luftFugtighed = value;
                OnPropertyChanged("LastName");
            }
        }
        public int Tidspunkt
        {
            get
            {
                return tidspunkt;
            }
            set
            {
                tidspunkt = value;
                OnPropertyChanged("City");
            }
        }
        public int HyldeID
        {
            get
            {
                return hyldeID;
            }
            set
            {
                hyldeID = value;
                OnPropertyChanged("State");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}

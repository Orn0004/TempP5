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
        public int batchID { get; set; }
        public float temperatur { get; set; }
        public float luftFugtighed { get; set; }
        public  int tidspunkt { get; set; }
        public int hyldeID { get; set; }


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

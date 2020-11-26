using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5_WPF
{
    public class BatchModel
    {
        public int batchID { get; set; }
        public float temperatur { get; set; }
        public float luftFugtighed { get; set; }
        public  int tidspunkt { get; set; }
        public int hyldeID { get; set; }

    }
}

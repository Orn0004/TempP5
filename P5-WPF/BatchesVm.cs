﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P5_WPF
{
    public class BatchesVm
    {
        public IEnumerable<BatchesModel> Batches { get; set; }

    }
}

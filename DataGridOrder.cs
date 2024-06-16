using InternetMagazine.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMagazine
{
    public class DataGridOrder : Order
    {
        public string UserLogin{ get; set; }
        public string CourierLogin { get; set; }
        public string ProductName { get; set; }
        public string StatusName { get; set; }
        public string DateString { get; set; }
    }
}

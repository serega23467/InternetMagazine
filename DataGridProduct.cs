using InternetMagazine.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace InternetMagazine
{
    public class DataGridProduct : Product
    {
        public string Category { get; set; }
        public string HasInGarbageString { get; set; }
        public BitmapImage ImageBitmap{ get; set; }
    }
}

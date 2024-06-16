using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMagazine.DBClasses
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public double ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public bool HasInGarbage { get; set; }
        public byte[] ProductImage { get; set; }
    }
}

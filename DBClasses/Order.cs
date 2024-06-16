using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMagazine.DBClasses
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CourierId { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }
        public string Adress { get; set; }
        public string Comment { get; set; } 
        public DateTime OrderDate { get; set; }
    }
}

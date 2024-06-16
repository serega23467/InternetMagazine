using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMagazine.DBClasses
{
    public class UserStatus
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}

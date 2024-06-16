using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMagazine.DBClasses
{
    public class MagazineUser
    {
        [Key]
        public int Id { get; set; }
        public int UserStatus { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}

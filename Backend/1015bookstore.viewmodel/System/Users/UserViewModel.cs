using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class UserViewModel
    {
        public Guid id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime? dob {  get; set; }
        public bool? sex { get; set; }
        public string? phonenumber { get; set; }
        public string email { get; set; }
    }
}

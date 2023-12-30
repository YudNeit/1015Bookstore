using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class UserViewModel
    {
        public Guid gUser_id { get; set; }
        public string sUser_firstname { get; set; }
        public string sUser_lastname { get; set; }
        public DateTime? dtUser_dob {  get; set; }
        public bool? bUser_sex { get; set; }
        public string? sUser_phonenumber { get; set; }
        public string sUser_email { get; set; }
    }
}

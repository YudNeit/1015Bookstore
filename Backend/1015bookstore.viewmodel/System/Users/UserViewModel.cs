using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        public DateTime? dtUser_dob {  get; set; }
        public bool? bUser_sex { get; set; }
        public string? sUser_phonenumber { get; set; }
        public string sUser_email { get; set; }
        public string sUser_username { get; set; }
        public string? sUser_rolename { get; set; }
    }
}

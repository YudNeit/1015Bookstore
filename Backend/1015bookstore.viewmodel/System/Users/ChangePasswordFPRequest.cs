using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class ChangePasswordFPRequest
    {
        public string token { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class RegisterRequest
    {
        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string confirmpassword { get; set; }
    }
}

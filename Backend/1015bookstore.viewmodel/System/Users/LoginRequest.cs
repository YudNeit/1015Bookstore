using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string passwrod { get; set; }
        public bool rememberme { get; set; }
    }
}

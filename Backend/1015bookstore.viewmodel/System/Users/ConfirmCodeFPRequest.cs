using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class ConfirmCodeFPRequest
    {
        public string token { get; set; }
        public string code { get; set; }
    }
}

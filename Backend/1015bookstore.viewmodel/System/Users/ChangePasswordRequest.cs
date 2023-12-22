using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class ChangePasswordRequest
    {
        public Guid user_id { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string confirmnewPassword { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.User
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Please enter your Username!")]
        public string sUser_username { get; set; }
        [Required(ErrorMessage = "Please enter your Pasword!")]
        public string sUser_password { get; set; }
    }
}

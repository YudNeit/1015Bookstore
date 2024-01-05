using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class ChangePasswordFPRequest
    {
        [Required(ErrorMessage = "Token is required.")]
        public string sUser_tokenFP { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Password is wrong format!")]
        [Compare("sUser_confirmpassword", ErrorMessage = "Confirm password is different password")]
        public string sUser_password { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Confirm password is wrong format!")]
        public string sUser_confirmpassword { get; set; }
    }
}

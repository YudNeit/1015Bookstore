using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        public string sUser_firstname { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        public string sUser_lastname { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [EmailAddress(ErrorMessage = "The E-mail is wrong format!")]
        public string sUser_email { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{5,}$",ErrorMessage = "The Username is wrong format!")]
        public string sUser_username { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Password is wrong format!")]
        [Compare("sUser_confirmpassword", ErrorMessage = "Confirm password is different password")]
        public string sUser_password { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Confirm password is wrong format!")]
        public string sUser_confirmpassword { get; set; }
    }
}

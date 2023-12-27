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
        public string firstname { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        public string lastname { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [EmailAddress(ErrorMessage = "The E-mail is wrong format!")]
        public string email { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{5,}$",ErrorMessage = "The Username is wrong format!")]
        public string username { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=]).{8,}$", ErrorMessage = "The Password is wrong format!")]
        [Compare("confirmpassword", ErrorMessage = "Confirm password is different password")]
        public string password { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=]).{8,}$", ErrorMessage = "The Confirm password is wrong format!")]
        public string confirmpassword { get; set; }
    }
}

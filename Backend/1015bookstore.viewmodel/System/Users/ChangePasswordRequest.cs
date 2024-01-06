using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class ChangePasswordRequest
    {
        [Required]
        public Guid gUser_id { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Old Password is wrong format!")]
        public string sUser_oldPassword { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Password is wrong format!")]
        [Compare("sUser_confirmnewPassword", ErrorMessage = "Confirm password is different password")]
        public string sUser_newPassword { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Confirm password is wrong format!")]
        public string sUser_confirmnewPassword { get; set; }
    }
}

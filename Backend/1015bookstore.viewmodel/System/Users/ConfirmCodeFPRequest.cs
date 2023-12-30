using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class ConfirmCodeFPRequest
    {
        [Required(ErrorMessage = "Token is required.")]
        public string sUser_tokenFP { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "The field must be exactly 6 numbers.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Please enter numeric characters.")]
        public string sUser_codeFP { get; set; }
    }
}

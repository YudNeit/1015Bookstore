using _1015bookstore.viewmodel.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class UserUpdateRequest
    {
        [Required]
        public Guid gUser_id { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        public string sUser_firstname { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        public string sUser_lastname { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [DateOfBirth(ErrorMessage = "The BirthDay is wrong format")]
        [DataType(DataType.Date)]
        public DateTime dtUser_dob { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        public bool bUser_sex { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "PhoneNumber is wrong format")]
        public string sUser_phonenumber { get; set; }
    }
}

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
        public Guid id { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [DateOfBirth(ErrorMessage = "The BirthDay is wrong format")]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        public bool sex { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "NumberPhone is wrong format")]
        public string phonenumber { get; set; }
    }
}

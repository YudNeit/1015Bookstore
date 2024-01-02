using _1015bookstore.viewmodel.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class RegisterAdminRequest
    {
        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        [Display(Name = "Họ")]
        public string sUser_firstname { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[^0-9]{1,20}$", ErrorMessage = "Name is not include number")]
        [Display(Name = "Tên")]
        public string sUser_lastname { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [DateOfBirth(ErrorMessage = "The BirthDay is wrong format")]
        [Display(Name = "Ngày tháng năm sinh")]
        [DataType(DataType.Date)]
        public DateTime dtUser_dob { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [Display(Name = "Giới tính")]
        public bool bUser_sex { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [EmailAddress(ErrorMessage = "The E-mail is wrong format!")]
        [Display(Name = "Email cá nhân")]
        public string sUser_email { get; set; }

        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "PhoneNumber is wrong format")]
        [Display(Name = "Số điện thoại")]
        public string sUser_phonenumber { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{5,}$", ErrorMessage = "The Username is wrong format!")]
        [Display(Name = "Tên đăng nhập")]
        public string sUser_username { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Password is wrong format!")]
        [Compare("sUser_confirmpassword", ErrorMessage = "Confirm password is different password")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string sUser_password { get; set; }


        [Required(ErrorMessage = "The * field is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$", ErrorMessage = "The Confirm password is wrong format!")]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        public string sUser_confirmpassword { get; set; }
    }
}

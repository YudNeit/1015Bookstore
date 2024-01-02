using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Users
{
    public class UserViewModel
    {
        [Display(Name ="Id người dùng")]
        public Guid gUser_id { get; set; }
        [Display(Name = "Họ")]
        public string sUser_firstname { get; set; }
        [Display(Name = "Tên")]
        public string sUser_lastname { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ngày tháng năm sinh")]
        public DateTime? dtUser_dob {  get; set; }
        [Display(Name = "Giới tính")]
        public bool? bUser_sex { get; set; }
        [Display(Name = "Số điện thoại")]
        public string? sUser_phonenumber { get; set; }
        [Display(Name = "Email")]
        public string sUser_email { get; set; }
        [Display(Name = "Tài khoản")]
        public string sUser_username { get; set; }
        [Display(Name = "Quyền hạn")]
        public string? sUser_rolename { get; set; }
    }
}

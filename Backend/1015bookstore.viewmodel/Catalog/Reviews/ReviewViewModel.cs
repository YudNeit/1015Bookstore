using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Reviews
{
    public class ReviewViewModel
    {
        [Display(Name = "Tài khoản người dùng")]
        public string sUser_username { get; set; }
        [Display(Name = "Số sao")]
        public int iReview_start { get; set; }
        [Display(Name = "Nội dung bình luận")]
        public string? sReview_content { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo")]
        public DateTime dtReview_date { get; set; }

    }
}

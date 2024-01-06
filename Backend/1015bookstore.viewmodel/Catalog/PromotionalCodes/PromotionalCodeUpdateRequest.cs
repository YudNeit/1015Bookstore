using _1015bookstore.data.Enums;
using _1015bookstore.viewmodel.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.PromotionalCodes
{
    public class PromotionalCodeUpdateRequest
    {
        [Required]
        public int iPromotionalCode_id { get; set; }
        [Required]
        [Display(Name = "Mã giảm giá")]
        public string sPromotionalCode_code { set; get; }
        [Required]
        [Display(Name = "Tên mã giảm giá")]
        public string sPromotionalCode_name { get; set; }
        [Required]
        [Display(Name = "Mô tả mã giảm giá")]
        public string sPromotionalCode_description { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "The rate in range (1-100)")]
        [Display(Name = "Tỉ lệ giảm giá")]
        public int iPromotionalCode_discount_rate { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The amount is bigger than 0")]
        [Display(Name = "Số lượng mã giảm giá")]
        public int iPromotionalCode_amount { get; set; }
        [Required]
        [DateOfPromotionalCodeValidation("dtPromotionalCode_todate", ErrorMessage = "Not valid")]
        [Display(Name = "Ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime dtPromotionalCode_fromdate { set; get; }
        [Required]
        [Display(Name = "Ngày kết thúc")]
        [DataType(DataType.Date)]
        public DateTime dtPromotionalCode_todate { set; get; }
        [Display(Name = "Trạng thái")]
        public PromotionalCodeStatus stPromotionalCode_status { get; set; }
    }
}

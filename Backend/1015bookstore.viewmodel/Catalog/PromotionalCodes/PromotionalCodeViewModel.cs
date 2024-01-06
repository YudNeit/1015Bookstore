using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.PromotionalCodes
{
    public class PromotionalCodeViewModel
    {
        [Display(Name = "ID")]
        public int iPromotionalCode_id {  get; set; }
        [Display(Name = "Mã giảm giá")]
        public string sPromotionalCode_code { set; get; }
        [Display(Name = "Tên mã giảm giá")]
        public string sPromotionalCode_name { get; set; }
        [Display(Name = "Mô tả mã giảm giá")]
        public string sPromotionalCode_description { get; set; }
        [Display(Name = "Tỷ lệ giảm giá")]
        public int iPromotionalCode_discount_rate { get; set; }
        [Display(Name ="Số lượng mã giảm giá")]
        public int iPromotionalCode_amount { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime dtPromotionalCode_fromdate { set; get; }
        [Display(Name = "Ngày kết thúc")]
        [DataType(DataType.Date)]
        public DateTime dtPromotionalCode_todate { set; get; }
        [Display(Name = "Trạng thái")]
        public PromotionalCodeStatus stPromotionalCode_status { get; set; }

    }
}

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
        public string sPromotionalCode_code { set; get; }
        [Required]
        public string sPromotionalCode_name { get; set; }
        [Required]
        public string sPromotionalCode_description { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "The rate in range (1-100)")]
        public int iPromotionalCode_discount_rate { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The amount is bigger than 0")]
        public int iPromotionalCode_amount { get; set; }
        [Required]
        [DateOfPromotionalCodeValidation("DTPromotionalCode_todate", ErrorMessage = "Not valid")]
        public DateTime dtPromotionalCode_fromdate { set; get; }
        [Required]
        public DateTime dtPromotionalCode_todate { set; get; }
    }
}

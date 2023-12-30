using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Orders
{
    public class OrderBuyRequest
    {
        [Required]
        public int iOrder_id {  get; set; }
        [Required]
        public string sOrder_name_receiver { get; set; }
        [Required]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "PhoneNumber is wrong format")]
        public string sOrder_phone_receiver { set; get; }
        [Required]
        public string sOrder_address_receiver { set; get; }
        
        public string? sPromotionalCode_code { set; get; }
    }
}

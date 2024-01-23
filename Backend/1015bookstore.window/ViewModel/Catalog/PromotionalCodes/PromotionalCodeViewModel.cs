using _1015bookstore.window.Emun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.Catalog.PromotionalCodes
{
    public class PromotionalCodeViewModel
    {
        public int iPromotionalCode_id { get; set; }
        public string sPromotionalCode_code { set; get; }
        public string sPromotionalCode_name { get; set; }
        public string sPromotionalCode_description { get; set; }
        public int iPromotionalCode_discount_rate { get; set; }
        public int iPromotionalCode_amount { get; set; }
        public DateTime dtPromotionalCode_fromdate { set; get; }
        public DateTime dtPromotionalCode_todate { set; get; }
        public PromotionalCodeStatus stPromotionalCode_status { get; set; }
    }
}

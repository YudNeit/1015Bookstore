using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.window.ViewModel.Catalog.Orders
{
    public class OrderBuyRequest
    {
        public int iOrder_id { get; set; }
        public string sOrder_name_receiver { get; set; }
        public string sOrder_phone_receiver { set; get; }
        public string sOrder_address_receiver { set; get; }
        public string sPromotionalCode_code { set; get; }
    }
}

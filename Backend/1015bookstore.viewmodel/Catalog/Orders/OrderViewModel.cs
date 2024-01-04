using _1015bookstore.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Orders
{
    public class OrderViewModel
    {
        public int iOrder_id { get; set; }
        public string? sOrder_name_receiver { get; set; }
        public string? sOrder_phone_receiver { set; get; }
        public string? sOrder_address_receiver { set; get; }
        public string? sPromoionalCode_code { get; set; }
        public Decimal vOrder_total {  get; set; }
        public bool bOrder_review {  get; set; }
        public DateTime dtOrrder_dateorder { get; set; }
        public List<OrderDetailViewModel> lOrder_items { get; set; }

    }
}

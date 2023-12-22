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
        public int id { get; set; }
        public string? name_reciver { get; set; }
        public string? phone_reciver { set; get; }
        public string? address_reciver { set; get; }
        public string? promoionalcode { get; set; }
        public Decimal total {  get; set; }
        public List<OrderDetailViewModel> orderdetails { get; set; }

    }
}

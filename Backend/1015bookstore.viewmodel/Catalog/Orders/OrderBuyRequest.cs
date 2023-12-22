using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Orders
{
    public class OrderBuyRequest
    {
        public int order_id {  get; set; }
        public string name_reciver { get; set; }
        public string phone_reciver { set; get; }
        public string address_reciver { set; get; }
        public string? promotionalcode { set; get; }
    }
}

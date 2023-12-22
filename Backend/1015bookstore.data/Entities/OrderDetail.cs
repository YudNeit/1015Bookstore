using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class OrderDetail
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public Decimal price { get; set; }
        public string product_name { get; set; }
        public string? imgpath { get; set; }

        public Order order { get; set; }
        public Product product { get; set; }
    }
}

using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class Cart
    {
        public int id { get; set; }
        public int product_id { set; get; }
        public string product_name { get; set; }
        public string imgpath { get; set; }
        public Guid user_id { get; set; }
        public int quantity { set; get; }
        public DateTime datecreated { get; set; }
        public Decimal price { set; get; }
        public CartStatus status { set; get; }

        public User user { set; get; }
        public Product product { set; get; }
    }
}

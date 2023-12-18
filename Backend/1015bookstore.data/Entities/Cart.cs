using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class Cart
    {
        public int product_id { set; get; }
        public Guid user_id { get; set; }
        public int quantity { set; get; }
        public decimal price { set; get; }
        public DateTime datecreated { get; set; }

        public User user { set; get; }
        public Product product { set; get; }
    }
}

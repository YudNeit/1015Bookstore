using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Carts
{
    public class CartViewModel
    {
        public int cart_id { get; set; }
        public string product_name { get; set; }
        public string pathimage { get; set; }
        public int amount { get; set; }
        public Decimal price { get; set; }
        public CartStatus status { get; set; }

    }
}

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
        public int iCart_id { get; set; }
        public string sProduct_name { get; set; }
        public string? sImage_path { get; set; }
        public int iProduct_amount { get; set; }
        public decimal vProduct_price { get; set; }
        public CartStatus stCart_status { get; set; }

    }
}

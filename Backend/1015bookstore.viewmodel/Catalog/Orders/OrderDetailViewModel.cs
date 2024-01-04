using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Orders
{
    public class OrderDetailViewModel
    {
        public int iProduct_id { get; set; }
        public string sProduct_name {  get; set; }
        public string? sImage_path {  get; set; }
        public int iProduct_amount { get; set; }
        public Decimal vProduct_price { get; set; }
    }
}

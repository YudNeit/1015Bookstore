using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Orders
{
    public class OrderDetailViewModel
    {
        public string name {  get; set; }
        public string? imgpath {  get; set; }
        public int quantity { get; set; }
        public Decimal price { get; set; }
    }
}

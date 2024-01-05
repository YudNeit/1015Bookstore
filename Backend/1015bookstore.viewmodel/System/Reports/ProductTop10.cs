using _1015bookstore.viewmodel.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Reports
{
    public class ProductTop10
    {
        public int product_id { get; set; }
        public string product_name {  get; set; }
        public int amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class ProductInCategory
    {
        public int product_id {  get; set; }
        public Product product { get; set; }
        public int category_id { get; set;}
        public Category category { get; set; }
    }
}

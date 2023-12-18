using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class ProductImage
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string imagepath { get; set; }
        public string caption { get; set; }
        public bool is_default { get; set; }
        public long sizeimage { get; set; }
        public DateTime createdate { get; set; }
        public DateTime updatedate { get; set; }
        public int sortorder { get; set; }
        public Product product { get; set; }
    }
}

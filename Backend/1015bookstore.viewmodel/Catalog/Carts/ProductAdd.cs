using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Carts
{
    public class ProductAdd
    {
        [Required]
        public int product_id {  get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Carts
{
    public class CartAddProduct
    {
        [Required]
        public int iProduct_id {  get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int iProduct_amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Orders
{
    public class OrderCreateRequest
    {
        [Required]
        public List<int> cart_ids {  get; set; }
        [Required]
        public Guid user_id { get; set; }
    }
}

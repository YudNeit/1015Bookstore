using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Catalog.Orders
{
    public class OrderCreateRequest
    {
        public List<int> cart_ids {  get; set; }
        public Guid user_id { get; set; }
    }
}

using _1015bookstore.web.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Model
{
    public class CartItemModel
    {
        public int user_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}

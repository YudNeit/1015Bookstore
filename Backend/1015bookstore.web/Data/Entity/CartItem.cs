using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("CartItems")]
    public class CartItem
    {
        public int user_id { get; set; }

        public virtual User user { get; set; }

        public int product_id { get; set; }

        public virtual Product product { get; set; }

        [Range(0, int.MaxValue)]
        public int quantity { get; set; }

        [Range(0, float.MaxValue)]
        public float price { get; set; }

    }
}

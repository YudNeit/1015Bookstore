using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public int order_id { get; set; }

        public virtual Order order { get; set; }

        public int product_id { get; set; }

        public virtual Product product { get; set; }
        
        [Range(0, int.MaxValue)]
        public int quantity { get; set; }

        [Range(0, float.MaxValue)]
        public float price { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("ProductDetails")]
    public class ProductDetail
    {
        [ForeignKey("product")]
        public int product_id { get; set; }

        public virtual Product product { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string? brand { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string? suppiler { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string? author { get; set; }
    }
}

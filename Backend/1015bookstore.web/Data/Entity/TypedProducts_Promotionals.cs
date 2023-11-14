using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("TypedProducts_Promotionals")]
    public class TypedProducts_Promotionals
    {
        public int product_id { get; set; }

        public virtual Product product { get; set; }

        public int promotional_id { get; set; }

        public virtual PromotionalCode promotionalcodes { get; set; }

        public DateTime expirationdate { get; set; }
    }
}

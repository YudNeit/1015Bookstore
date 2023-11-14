using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("TypedCategories_Promotionals")]
    public class TypedCategories_Promotionals
    {
        public int category_id { get; set; }

        public virtual Category category { get; set; }

        public int promotional_id { get; set; }

        public virtual PromotionalCode promotionalcodes { get; set; }

        public DateTime expirationdate { get; set; }
    }
}

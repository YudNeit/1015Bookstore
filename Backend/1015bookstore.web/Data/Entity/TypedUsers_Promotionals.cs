using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("TypedUsers_Promotionals")]
    public class TypedUsers_Promotionals
    {
        public int user_id { get; set; }

        public virtual User user { get; set; }

        public int promotional_id { get; set; }

        public virtual PromotionalCode promotionalcodes { get; set; }

        public DateTime expirationdate { get; set; }
    }
}

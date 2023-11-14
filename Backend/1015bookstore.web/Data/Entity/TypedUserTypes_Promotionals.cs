using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("TypedUserTypes_Promotionals")]
    public class TypedUserTypes_Promotionals
    {
        public int usertype_id { get; set; }

        public virtual UserType usertype { get; set; }

        public int promotional_id { get; set; }

        public virtual PromotionalCode promotionalcodes { get; set; }

        public DateTime expirationdate { get; set; }
    }
}

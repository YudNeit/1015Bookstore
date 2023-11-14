using _1015bookstore.web.Data.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("PromotionalCodes")]
    public class PromotionalCode : Auditable
    {
        public int id { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string name { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string alias { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        public string description { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string createdby { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string updatedby { get; set; }

        [Range(0, 100)]
        public int discount_rate { get; set; }

        // Khóa ngoại với TypedCategories_Promotionals
        public virtual ICollection<TypedCategories_Promotionals> typedcategories_promotionals { get; set; }
        // Khóa ngoại với TypedProducts_Promotionals
        public virtual ICollection<TypedProducts_Promotionals> typedproducts_promotionals { get; set; }
        // Khóa ngoại với TypedUserTypes_Promotionals
        public virtual ICollection<TypedUserTypes_Promotionals> typedusertypes_promotionals { get; set; }
        // Khóa ngoại với TypedUsers_Promotionals
        public virtual ICollection<TypedUsers_Promotionals> typedusers_promotionals { get; set; }

        public PromotionalCode()
        {
            typedcategories_promotionals = new List <TypedCategories_Promotionals>();
            typedproducts_promotionals = new List <TypedProducts_Promotionals>();
            typedusertypes_promotionals = new List <TypedUserTypes_Promotionals>();
            typedusers_promotionals = new List <TypedUsers_Promotionals>();
        }
    }
}

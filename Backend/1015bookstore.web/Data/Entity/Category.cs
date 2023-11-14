using _1015bookstore.web.Data.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("Categories")]
    public class Category : Auditable
    {
        public int id { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string name { get; set; }

        public int categoryparentid { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string createdby { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string updatedby { get; set; }

        // Khóa ngoại với Product
        public virtual ICollection<Product> products { get; set; }
        // Khóa ngoại với TypedCategories_Promotionals
        public virtual ICollection<TypedCategories_Promotionals> typedcategories_promotionals { get; set; }
        
        public Category()
        {
            products = new List<Product>();
            typedcategories_promotionals = new List<TypedCategories_Promotionals>();
        }
    }
}

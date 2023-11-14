using _1015bookstore.web.Data.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("UserTypes")]
    public class UserType : Auditable
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

        // Khóa ngoại với TypeUsers_UserTypes
        public virtual ICollection<TypedUsers_UserTypes> typedusers_usertypes { get; set; }
        // Khóa ngoại với TypedUserTypes_Promotionals
        public virtual ICollection<TypedUserTypes_Promotionals> typedusertypes_promotionals { get; set; }

        public UserType()
        {
            typedusers_usertypes = new List<TypedUsers_UserTypes>();
            typedusertypes_promotionals = new List<TypedUserTypes_Promotionals>();
        }
    }
}

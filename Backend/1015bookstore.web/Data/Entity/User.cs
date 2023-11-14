using _1015bookstore.web.Data.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("Users")]
    public class User : Auditable
    {
        public int id { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string username { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string password { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string email { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string firstname { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string lastname { get; set; }

        [Column(TypeName = "text")]
        public string phone { get; set; }

        // Khóa ngoại với UserAddress
        public virtual ICollection<UserAddress> useraddresses { get; set; }
        // Khóa ngoại với Order
        public virtual ICollection<Order> orders { get; set; }   
        // Khóa ngoại với CartItem
        public virtual ICollection<CartItem> cartitems { get; set; }
        // Khóa ngoại với Review
        public virtual ICollection<Review> reviews { get; set; }
        // Khóa ngoại với TypeUsers_UserTypes
        public virtual ICollection<TypedUsers_UserTypes> typedusers_usertypes { get; set; }
        // Khóa ngoại với TypedUsers_Promotionals
        public virtual ICollection<TypedUsers_Promotionals> typedusers_promotionals { get; set; }

        public User()
        {
            cartitems = new List<CartItem>();
            useraddresses = new List<UserAddress>();
            orders = new List<Order>();
            reviews = new List<Review>();
            typedusers_usertypes = new List<TypedUsers_UserTypes>();
            typedusers_promotionals = new List<TypedUsers_Promotionals>();
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("TypedUsers_UserTypes")]
    public class TypedUsers_UserTypes
    {
        public int user_id { get; set; }

        public virtual User user { get; set; }

        public int usertype_id { get; set; }

        public virtual UserType usertype { get; set; }

        public DateTime expirationdate { get; set; }
    }
}

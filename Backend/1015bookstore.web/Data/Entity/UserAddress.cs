using _1015bookstore.web.Data.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    [Table("UserAddresses")]
    public class UserAddress : Auditable
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public virtual User user { get; set; }

        public bool is_default { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string receiver_name { get; set; }

        [Column(TypeName = "text")]
        public string receiver_phone { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string city { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string district { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string sub_district { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        public string address_detail { get; set; }

        public float coordinates_X { get; set; }

        public float coordinates_Y { get; set; }

    }
}

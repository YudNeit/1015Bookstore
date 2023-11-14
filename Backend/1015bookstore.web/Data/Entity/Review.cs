using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    public enum status
    {
        New = 1, Normal = 2, Delete = -1
    }
    [Table("Reviews")]
    public class Review
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public virtual User user { get; set; }

        public int product_id { get; set; }

        public virtual Product product { get; set; }

        [Range(0, 5)]
        public int starts { get; set; }

        [Column(TypeName = "ntext")]
        public string contents { get; set; }

        public status is_status { get; set; }

        public DateTime createdtime { get; set; }

        public DateTime deletedtime { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string deletedby { get; set; }

        public Review ()
        {
            createdtime = DateTime.Now;
            is_status = status.Normal;
            deletedtime = new DateTime();
            deletedby = null;
        }
    }
}

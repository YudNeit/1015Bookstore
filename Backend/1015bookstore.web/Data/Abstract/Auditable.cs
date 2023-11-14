using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace _1015bookstore.web.Data.Abstract
{
    public enum status
    {
        New = 1, Normal = 2, Delete = -1
    }
    public class Auditable
    {
        [Required]
        public DateTime createdtime { get; set; }
        [Required]
        public DateTime updatedtime { get; set; }
        [Required]
        public status is_status { get; set; }

        public Auditable()
        {
            is_status = status.Normal;
            createdtime = DateTime.Now;
            updatedtime = DateTime.Now;
        }

    }
}

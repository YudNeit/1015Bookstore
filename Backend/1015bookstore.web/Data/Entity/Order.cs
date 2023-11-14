using _1015bookstore.web.Data.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.web.Data.Entity
{
    public enum status_ordered
    {
        create = 1, payment = 2, shipping = 3, complete = 4
    }    

    [Table("Orders")]
    public class Order : Auditable
    {
        public int id { get; set; }

        public DateTime? paymentdate { get; set; }

        public DateTime? deliverydate { get; set; }

        public DateTime? completedate { get; set; }

        public status_ordered status_order { get; set; }

        public int user_id { get; set; }

        public virtual User user { get; set; }

        public int address_id { get; set; }

        // Khóa ngoại với OrderDetail
        public virtual ICollection<OrderDetail> orderdetails { get; set; }

        public Order ()
        {
            paymentdate = new DateTime();
            deliverydate = new DateTime();
            completedate = new DateTime();
            status_order = status_ordered.create;
            orderdetails = new List<OrderDetail> ();
        }
    }
}

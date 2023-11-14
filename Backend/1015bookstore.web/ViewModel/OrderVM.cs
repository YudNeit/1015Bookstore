using _1015bookstore.web.Data.Entity;

namespace _1015bookstore.web.ViewModel
{
    public class OrderVM
    {
        public int id { get; set; }

        public DateTime? paymentdate { get; set; }

        public DateTime? deliverydate { get; set; }

        public DateTime? completedate { get; set; }

        public status_ordered status_order { get; set; }

        public int user_id { get; set; }

        public int address_id { get; set; }
    }
}

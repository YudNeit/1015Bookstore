using _1015bookstore.web.Data.Entity;

namespace _1015bookstore.web.Model
{
    public class OrderModel
    {
        public int id { get; set; }

        public status_ordered status_order { get; set; }

        public int user_id { get; set; }

        public int address_id { get; set; }
    }
}

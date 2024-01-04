using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class Order
    {
        public int id { set; get; }

        public DateTime orderdate { get; set; }
        public DateTime? paymentdate { get; set; }
        public DateTime? deliverydate { get; set; }
        public DateTime? completedate { get; set; }

        public string? name_reciver { get; set; }
        public string? phone_reciver {  set; get; }
        public string? address_reciver { set; get; }

        public decimal total {  get; set; }

        public bool isreview {  get; set; }

        //public int address_id { get; set; }
        public Guid user_id { set; get; }
        public User user { get; set; }

        public OrderStatus status { set; get; }

        public string? promotionalcode {  set; get; }

        public List<OrderDetail> orderdetails { get; set; }
    }
}

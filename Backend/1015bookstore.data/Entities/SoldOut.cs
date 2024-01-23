using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class SoldOut
    {
        public int id {  get; set; }
        public Guid user_id { get; set; }
        public decimal total { get; set; }
        public DateTime time { get; set; }

        public User user { get; set; }
    }
}

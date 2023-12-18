using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class UserAddress
    {
        public int id { get; set; }
        public Guid user_id { get; set; }
        public bool is_default { get; set; }
        public string receiver_name { get; set; }
        public string receiver_phone { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string sub_district { get; set; }
        public string address_detail { get; set; }
        public float coordinates_X { get; set; }
        public float coordinates_Y { get; set; }

        public User user { get; set; }
    }
}

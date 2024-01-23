using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class Message
    {
        public int id { get; set; }
        public Guid user_id { get; set; }
        public string message { get; set; }
        public DateTime time { get; set; }
        public MessageType type { get; set; }

        public User user { get; set; }
    }
}

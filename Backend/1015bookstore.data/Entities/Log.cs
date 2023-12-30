using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Entities
{
    public class Log
    {
        public long id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public LogType type { get; set; }
        public DateTime time { get; set; }

        public Guid user_id { get; set; }
        public string username { get; set; }

        public User user { get; set; }
    }
}

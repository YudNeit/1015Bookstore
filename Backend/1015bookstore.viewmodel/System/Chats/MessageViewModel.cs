using _1015bookstore.data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.System.Chats
{
    public class MessageViewModel
    {
        public Guid gUser_id { get; set; }
        public string sChat_message { get; set; }
        public DateTime sChat_time { get; set; }
        public MessageType stChat_type { get; set; }
        public string? sUser_avt {  get; set; }
    }
}

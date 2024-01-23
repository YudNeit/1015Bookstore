using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.System.Chats
{
    public interface IChatService
    {
        Task<ResponseService> Chat_Create(MessageViewModel message);
        Task<ResponseService<List<MessageViewModel>>> Chat_Get10(Guid user_id);
        Task<ResponseService<List<MessageViewModelWebAdmin>>> Chat_User();
    }
}

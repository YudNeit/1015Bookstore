using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Chats;

namespace _1015bookstore.websiteadmin.Service
{
    public interface IChatAPIClient
    {
        Task<ResponseAPI<List<MessageViewModelWebAdmin>>> GetUser(string session);
    }
}

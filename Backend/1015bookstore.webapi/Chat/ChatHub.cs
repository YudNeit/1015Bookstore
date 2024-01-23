using _1015bookstore.application.System.Chats;
using _1015bookstore.data.EF;
using _1015bookstore.viewmodel.System.Chats;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace _1015bookstore.webapi.Chat
{
    public class ChatHub : Hub
    {
        private readonly _1015DbContext _context;
        private readonly IChatService _chatService;
        private static List<Guid> ListUserConect = new List<Guid>();
        private static Dictionary<string, Guid> connectedUsers = new Dictionary<string, Guid>();
       
        public ChatHub(_1015DbContext context, IChatService chatService) 
        {
            _context = context;
            _chatService = chatService;
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (connectedUsers.TryGetValue(Context.ConnectionId, out Guid userId))
            {
                ListUserConect.Remove(userId);
                connectedUsers.Remove(Context.ConnectionId);
            }
            
            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinPublish(Guid user_id)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, user_id.ToString());
            await Clients.Group("Admin").SendAsync("UserConnect", user_id);
            connectedUsers[Context.ConnectionId] = user_id;
            ListUserConect.Add(user_id);
        }

        public async Task JoinAdmin()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Admin");
            foreach(var item in ListUserConect)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, item.ToString());
            }
        }

        public async Task ConnectAdminToUser(Guid user_id)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, user_id.ToString());
        }

        public async Task SendMessage(MessageViewModel message)
        {
            if (message.sChat_time < DateTime.Now)
            {
                message.sChat_time = DateTime.Now;
            }
            var response = await _chatService.Chat_Create(message);
            if (response.Status)
            {
                await Clients.Group(message.gUser_id.ToString()).SendAsync("ReceiveMessage", message);
            }    
            //await Clients.All.SendAsync("ReceiveMessage", user_id, message);
        }
    }
}

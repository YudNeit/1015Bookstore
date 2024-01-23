using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Chats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.System.Chats
{
    public class ChatService : IChatService
    {
        private readonly _1015DbContext _context;
        public ChatService(_1015DbContext context)
        {
            _context = context;
        }

        public async Task<ResponseService<List<MessageViewModel>>> Chat_Get10(Guid user_id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == user_id);
            var listdata = await _context.Messages
                .Where(x => x.user_id == user_id)
                .OrderByDescending(x => x.time)
                .Take(10)
                .Select(x => new MessageViewModel { 
                gUser_id = x.user_id,
                sChat_message = x.message,
                sChat_time = x.time,
                stChat_type = x.type,
                sUser_avt = user.avt == null?null: user.avt
                }).ToListAsync();

            return new ResponseService<List<MessageViewModel>>
            {
                Status = true,
                CodeStatus = 200,
                Data = listdata,
            };
        }

        public async Task<ResponseService<List<MessageViewModelWebAdmin>>> Chat_User()
        {
            var list = new List<MessageViewModelWebAdmin>();
            var listuser = await _context.Users.ToListAsync();
            foreach (var user in listuser)
            {
                var message = await _context.Messages.Where(x => x.user_id == user.Id).OrderByDescending(x => x.time).ToListAsync();
                if (message.Count > 0)
                {
                    var getmessage = message.First();
                    list.Add(new MessageViewModelWebAdmin
                    {
                        gUser_id = getmessage.user_id,
                        sChat_message = getmessage.message,
                        sChat_time = getmessage.time,
                        stChat_type = getmessage.type,
                        sUser_avt = user.avt != null ? user.avt : null,
                        sUser_username = user.UserName,
                        
                    });
                }    
            }

            return new ResponseService<List<MessageViewModelWebAdmin>>
            {
                Status = true,
                CodeStatus = 200,
                Data = list,
            };
        }

        public async Task<ResponseService> Chat_Create(MessageViewModel message)
        {
             var newmessage = new Message
            {
                user_id = message.gUser_id,
                message = message.sChat_message,
                time = message.sChat_time,
                type = message.stChat_type,
            };
            await _context.AddAsync(newmessage);
            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService
                {
                    CodeStatus = 200,
                    Status = true,
                };
            }
            return new ResponseService
            {
                CodeStatus = 500,
                Status = false,
            };
        }

    }
}

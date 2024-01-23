using _1015bookstore.window.ViewModel;
using _1015bookstore.window.ViewModel.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _1015bookstore.window.Business
{
    public class ChatAPIClient
    {
        private readonly HttpClient _client;
        public ChatAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }

        public async Task<ResponseAPI<List<MessageViewModel>>> GetTop10(string session, Guid user_id)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.GetAsync($"/api/chat/top10?gUser_id={user_id}");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var chats = JsonSerializer.Deserialize<List<MessageViewModel>>(body);
                return new ResponseAPI<List<MessageViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công",
                    Data = chats,
                };
            }
            else
            {
                return new ResponseAPI<List<MessageViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = await response.Content.ReadAsStringAsync(),
                    Data = new List<MessageViewModel>(),
                };
            }
        }
    }
}

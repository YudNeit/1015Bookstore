using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Chats;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _1015bookstore.websiteadmin.Service
{
    public class ChatAPIClient : IChatAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChatAPIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseAPI<List<MessageViewModelWebAdmin>>> GetUser(string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/chat/user");
            var body = await response.Content.ReadAsStringAsync();
            var messages = JsonSerializer.Deserialize<List<MessageViewModelWebAdmin>>(body);
            return new ResponseAPI<List<MessageViewModelWebAdmin>>
            {
                Data = messages,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }
    }
}

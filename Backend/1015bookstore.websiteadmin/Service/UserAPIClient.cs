using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _1015bookstore.websiteadmin.Service
{
    public class UserAPIClient : IUserAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserAPIClient(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseAPI<JObject>> Authenticate(LoginRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var multipartContent = new MultipartFormDataContent();
            //multipartContent.Add(new StringContent(json, Encoding.UTF8, "application/json"), "yourkey");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            var response = await client.PostAsync("/api/user/authenticate", httpContent);

            return new ResponseAPI<JObject>
            {
                Data = JObject.Parse(await response.Content.ReadAsStringAsync()),
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }
    }
}

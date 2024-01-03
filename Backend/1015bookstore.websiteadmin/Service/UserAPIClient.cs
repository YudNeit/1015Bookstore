using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

            if (response.IsSuccessStatusCode)
            {
                return new ResponseAPI<JObject>
                {
                    Data = JObject.Parse(await response.Content.ReadAsStringAsync()),
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                };
            }
            return new ResponseAPI<JObject>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync()
            };


        }
        public async Task<ResponseAPI<List<UserViewModel>>> GetUser( string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/user/admin-getall");
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<UserViewModel>>(body);
            return new ResponseAPI<List<UserViewModel>>
            {
                Data = users,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<string>> CraeteUserAdmin(RegisterAdminRequest request, string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/user/createadmin", httpContent);

            return new ResponseAPI<string>
            {
                Message = await response.Content.ReadAsStringAsync(),
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<UserViewModel>> GetUserById(string session, Guid user_id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/user/{user_id}");
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<UserViewModel>(body);
            
            return new ResponseAPI<UserViewModel>
            {
                Data = users,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }
    }
}

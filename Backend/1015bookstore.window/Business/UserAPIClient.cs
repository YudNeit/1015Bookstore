using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using _1015bookstore.window.ViewModel;
using Newtonsoft.Json.Linq;
using _1015bookstore.window.ViewModel.User;

namespace _1015bookstore.window.Business
{
    public class UserAPIClient
    {
        private readonly HttpClient _client;

        public UserAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }
        public async Task<ResponseAPI<JObject>> Authenticate(LoginRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/user/authenticate", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return new ResponseAPI<JObject>
                {
                    Data = JObject.Parse(await response.Content.ReadAsStringAsync()),
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công"
                };
            }
            return new ResponseAPI<JObject>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = new Object() as JObject,
            };


        }
        public async Task<ResponseAPI<JObject>> Register(RegisterRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/user/register", httpContent);

            return new ResponseAPI<JObject>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = new Object() as JObject,
            };

        }

        public async Task<ResponseAPI<string>> ForgotPassword(string email)
        {
            var json = JsonSerializer.Serialize(email);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/user/forgotpassword", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return new ResponseAPI<string>
                {
                    Data = await response.Content.ReadAsStringAsync(),
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công"
                };
            }
            return new ResponseAPI<string>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = "",
            };

        }

        public async Task<ResponseAPI<JObject>> CofirmCodeForgotPassword(ConfirmCodeFPRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/User/confirmCodeforgotpassword", httpContent);

            return new ResponseAPI<JObject>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = new Object() as JObject,
            };

        }

        public async Task<ResponseAPI<JObject>> ChangePasswordForgotPassword(ChangePasswordFPRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/User/ChangePasswordForgotPassword", httpContent);

            return new ResponseAPI<JObject>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = new Object() as JObject,
            };

        }
        //public async Task<ResponseAPI<List<UserViewModel>>> GetUser(string session)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri("https://localhost:7139");
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

        //    var response = await client.GetAsync($"/api/user/admin-getall");
        //    var body = await response.Content.ReadAsStringAsync();
        //    var users = JsonSerializer.Deserialize<List<UserViewModel>>(body);
        //    return new ResponseAPI<List<UserViewModel>>
        //    {
        //        Data = users,
        //        Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
        //    };
        //}

        //public async Task<ResponseAPI<string>> CraeteUserAdmin(RegisterAdminRequest request, string session)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri("https://localhost:7139");
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

        //    var json = JsonSerializer.Serialize(request);
        //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync($"/api/user/createadmin", httpContent);

        //    return new ResponseAPI<string>
        //    {
        //        Message = await response.Content.ReadAsStringAsync(),
        //        Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
        //    };
        //}

        //public async Task<ResponseAPI<UserViewModel>> GetUserById(string session, Guid user_id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri("https://localhost:7139");
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

        //    var response = await client.GetAsync($"/api/user/{user_id}");
        //    var body = await response.Content.ReadAsStringAsync();
        //    var users = JsonSerializer.Deserialize<UserViewModel>(body);

        //    return new ResponseAPI<UserViewModel>
        //    {
        //        Data = users,
        //        Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
        //    };
        //}
    }
}

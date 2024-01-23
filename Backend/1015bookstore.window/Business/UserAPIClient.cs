using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using _1015bookstore.window.ViewModel;
using Newtonsoft.Json.Linq;
using _1015bookstore.window.ViewModel.User;
using System.Windows.Forms;
using System.IO;

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
        public async Task<ResponseAPI<UserViewModel>> GetUserById(string session, Guid user_id)
        {

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

                var response = await _client.GetAsync($"/api/User/{user_id}");
                var body = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<UserViewModel>(body);

                return new ResponseAPI<UserViewModel>
                {
                    Data = users,
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                };
        }

        public async Task<ResponseAPI<string>> UpdateUser(UserUpdateRequest request, string session)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var requestContent = new MultipartFormDataContent();
            if (request.sUser_avt != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.sUser_avt.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.sUser_avt.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "sUser_avt", request.sUser_avt.FileName);
            }
            requestContent.Add(new StringContent(request.gUser_id.ToString()), "gUser_id");
            requestContent.Add(new StringContent(request.sUser_firstname.ToString()), "sUser_firstname");
            requestContent.Add(new StringContent(request.sUser_lastname.ToString()), "sUser_lastname");
            requestContent.Add(new StringContent(request.dtUser_dob.ToString()), "dtUser_dob");
            requestContent.Add(new StringContent(request.bUser_sex.ToString()), "bUser_sex");
            requestContent.Add(new StringContent(request.sUser_phonenumber.ToString()), "sUser_phonenumber");

            var response = await _client.PostAsync($"/api/User/updateinfor", requestContent);

            return new ResponseAPI<string>
            {
                Message = await response.Content.ReadAsStringAsync(),
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

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

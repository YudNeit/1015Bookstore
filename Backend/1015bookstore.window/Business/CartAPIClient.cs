using _1015bookstore.window.ViewModel;
using _1015bookstore.window.ViewModel.Catalog;
using _1015bookstore.window.ViewModel.Catalog.Carts;
using Newtonsoft.Json.Linq;
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
    public class CartAPIClient
    {
        private readonly HttpClient _client;
        public CartAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }

        public async Task<ResponseAPI<string>> AddCart(string session, CartAddProduct request, Guid user_id)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/cart/set?gUser_id={user_id}", httpContent);

            return new ResponseAPI<string>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = "",
            };
        }

        public async Task<ResponseAPI<List<CartViewModel>>> GetCart(string session, Guid user_id)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.GetAsync($"/api/cart/get/{user_id}");
            
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var carts = JsonSerializer.Deserialize<List<CartViewModel>>(body);
                return new ResponseAPI<List<CartViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công",
                    Data = carts,
                };
            }   
            else
            {
                return new ResponseAPI<List<CartViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = await response.Content.ReadAsStringAsync(),
                    Data = new List<CartViewModel>(),
                };
            }    
        }

        public async Task<ResponseAPI<JObject>> DeleteCart(string session, int id)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.DeleteAsync($"/api/cart/delete/{id}");

            return new ResponseAPI<JObject>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = new Object() as JObject,
            };
        }

        public async Task<ResponseAPI<JObject>> PlusCart(string session, int id, int amount)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"/api/cart/updateamount/{id}?amountadd={amount}");

            var response = await _client.SendAsync(request);

            return new ResponseAPI<JObject>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = new Object() as JObject,
            };
        }

        public async Task<ResponseAPI<JObject>> MinusCart(string session, int id, int amount)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"/api/cart/updateamount/{id}?amountadd={amount}");

            var response = await _client.SendAsync(request);

            return new ResponseAPI<JObject>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = new Object() as JObject,
            };
        }

    }
}

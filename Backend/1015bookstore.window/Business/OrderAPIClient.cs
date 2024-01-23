using _1015bookstore.window.ViewModel;
using _1015bookstore.window.ViewModel.Catalog.Orders;
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
    public class OrderAPIClient
    {
        private readonly HttpClient _client;
        public OrderAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }

        public async Task<ResponseAPI<OrderViewModel>> AddOrder(string session, OrderCreateRequest request)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/api/Order", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var order = JsonSerializer.Deserialize<OrderViewModel>(body);
                return new ResponseAPI<OrderViewModel>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.Created ? true : false,
                    Message = "Success",
                    Data = order,
                };
            }
            else
            {
                return new ResponseAPI<OrderViewModel>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.Created ? true : false,
                    Message = await response.Content.ReadAsStringAsync(),
                    Data = new OrderViewModel(),
                };
            }    
        }

        public async Task<ResponseAPI<string>> BuyOrder(string session, OrderBuyRequest request)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/api/Order/buy", httpContent);

            
            return new ResponseAPI<string>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = "",
            };
            
        }

        public async Task<ResponseAPI<List<OrderViewModel>>> GetHistory(string session, Guid user_id)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.GetAsync($"/api/order/history?gUser_id={user_id}");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var orders = JsonSerializer.Deserialize<List<OrderViewModel>>(body);
                return new ResponseAPI<List<OrderViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công",
                    Data = orders,
                };
            }
            else
            {
                return new ResponseAPI<List<OrderViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = await response.Content.ReadAsStringAsync(),
                    Data = new List<OrderViewModel>(),
                };
            }
        }
    }
}

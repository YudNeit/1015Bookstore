using _1015bookstore.window.ViewModel;
using _1015bookstore.window.ViewModel.Catalog.Reviews;
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
    public class ReviewAPIClient
    {
        private readonly HttpClient _client;
        public ReviewAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }

        public async Task<ResponseAPI<List<ReviewViewModel>>> GetReview(string session, int product_id)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.GetAsync($"/api/Review/getbyid?iProduct_id={product_id}");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var carts = JsonSerializer.Deserialize<List<ReviewViewModel>>(body);
                return new ResponseAPI<List<ReviewViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công",
                    Data = carts,
                };
            }
            else
            {
                return new ResponseAPI<List<ReviewViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = await response.Content.ReadAsStringAsync(),
                    Data = new List<ReviewViewModel>(),
                };
            }
        }
        public async Task<ResponseAPI<string>> AddReview(string session, ReviewRequestCreate request)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/api/review", httpContent);

            return new ResponseAPI<string>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync(),
                Data = "",
            };
        }

    }
}

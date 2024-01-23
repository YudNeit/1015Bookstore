using _1015bookstore.window.ViewModel;
using _1015bookstore.window.ViewModel.Catalog.PromotionalCodes;
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
    public class PromotionalCodeAPIClient
    {
        private readonly HttpClient _client;
        public PromotionalCodeAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }
        public async Task<ResponseAPI<PromotionalCodeViewModel>> CheckCode(string session, string code, Guid user_id)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.GetAsync($"/api/promotionalcode/checkcode?sPromotionalCode_code={code}&gUser_id={user_id}");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var carts = JsonSerializer.Deserialize<PromotionalCodeViewModel>(body);
                return new ResponseAPI<PromotionalCodeViewModel>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công",
                    Data = carts,
                };
            }
            else
            {
                return new ResponseAPI<PromotionalCodeViewModel>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = await response.Content.ReadAsStringAsync(),
                    Data = new PromotionalCodeViewModel(),
                };
            }
        }

    }
}

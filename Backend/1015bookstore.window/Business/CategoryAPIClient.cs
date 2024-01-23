using _1015bookstore.window.ViewModel;
using _1015bookstore.window.ViewModel.Catalog.Categories;
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
    public class CategoryAPIClient
    {
        private readonly HttpClient _client;
        public CategoryAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }

        public async Task<ResponseAPI<List<CategoryParentAndChildViewModel>>> GetTaskbar(string session)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.GetAsync($"/api/category/taskbar");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var carts = JsonSerializer.Deserialize<List<CategoryParentAndChildViewModel>> (body);
                return new ResponseAPI<List<CategoryParentAndChildViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công",
                    Data = carts,
                };
            }
            else
            {
                return new ResponseAPI<List<CategoryParentAndChildViewModel>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = await response.Content.ReadAsStringAsync(),
                    Data = new List<CategoryParentAndChildViewModel>(),
                };
            }
        }
    }
}

using _1015bookstore.window.ViewModel;
using _1015bookstore.window.ViewModel.Catalog.Products;
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
    public class ProductAPIClient
    {
        private readonly HttpClient _client;
        public ProductAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }

        public async Task<ResponseAPI<List<ProductViewModel>>> GetProductByCate(string session, int id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.GetAsync($"/api/Product/public-paging-cate?lCate_ids={id}&pageindex=1&pagesize=1000");
            var body = await response.Content.ReadAsStringAsync();
            if(body != "")
            {
                var product = JsonSerializer.Deserialize<List<ProductViewModel>>(body);
                return new ResponseAPI<List<ProductViewModel>>
                {
                    Data = product,
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                };
            }  
            else
            {
                return new ResponseAPI<List<ProductViewModel>>
                {
                    Data = new List<ProductViewModel>(),
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                };
            }    
        }

        public async Task<ResponseAPI<List<ProductViewModel>>> GetProductByKeyword(string session, string keyword)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await _client.GetAsync($"/api/Product/public-getbykeyword?sKeyword={keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (body != "")
            {
                var product = JsonSerializer.Deserialize<List<ProductViewModel>>(body);
                return new ResponseAPI<List<ProductViewModel>>
                {
                    Data = product,
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                };
            }
            else
            {
                return new ResponseAPI<List<ProductViewModel>>
                {
                    Data = new List<ProductViewModel>(),
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                };
            }
        }
    }
}

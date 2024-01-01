using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _1015bookstore.websiteadmin.Service
{
    public class ProductAPIClient : IProductAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductAPIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseAPI<List<ProductViewModel>>> GetProduct(string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var response = await client.GetAsync($"/api/product/admin-getall");
            var body = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<ProductViewModel>>(body);
            return new ResponseAPI<List<ProductViewModel>>
            {
                Data = products,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }
    }
}

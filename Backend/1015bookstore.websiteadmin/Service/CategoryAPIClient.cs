using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace _1015bookstore.websiteadmin.Service
{
    public class CategoryAPIClient : ICategoryAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryAPIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseAPI<List<CategoryParentAndChildViewModel>>> GetCate(string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/category");
            var body = await response.Content.ReadAsStringAsync();
            var cates = JsonSerializer.Deserialize<List<CategoryParentAndChildViewModel>> (body);
            return new ResponseAPI<List<CategoryParentAndChildViewModel>>
            {
                Data = cates,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<string>> ChangeParent(string session, int id, int parent_id, Guid updater_id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.PatchAsync($"/api/category/changeparent?iCate_id={id}&iCate_parent_id={parent_id}&gUpdater_id={updater_id}", null);
            var body = await response.Content.ReadAsStringAsync();
            return new ResponseAPI<string>
            {
                Message = body,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<List<CategoryViewModel>>> GetAddCate(string session, int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/category/GetAddCate?iCate_id={id}");
            var body = await response.Content.ReadAsStringAsync();
            var cates = JsonSerializer.Deserialize<List<CategoryViewModel>>(body);
            return new ResponseAPI<List<CategoryViewModel>>
            {
                Data = cates,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }


        public async Task<ResponseAPI<CategoryViewModel>> GetById(string session, int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/category/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var cates = JsonSerializer.Deserialize<CategoryViewModel>(body);
            return new ResponseAPI<CategoryViewModel>
            {
                Data = cates,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<List<ProductViewModel>>> GetProductByCate(string session, int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/Product/admin-paging-cate?lCate_ids={id}&pageindex=1&pagesize=10000");
            var body = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<List< ProductViewModel >> (body);
            return new ResponseAPI<List<ProductViewModel>>
            {
                Data = product,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<List<ProductViewModel>>> GetProductNotInCate(string session, int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/Product/notincate/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<List<ProductViewModel>>(body);
            return new ResponseAPI<List<ProductViewModel>>
            {
                Data = product,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<string>> DeleteProductInCate(string session, int id_cate, int id_product)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"api/ProductInCategory/delete?product_id={id_product}&category_id={id_cate}");
            var body = await response.Content.ReadAsStringAsync();
            return new ResponseAPI<string>
            {
                Message = body,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<string>> SetProductInCate(string session, int id_cate, int id_product)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"api/ProductInCategory/set?product_id={id_product}&category_id={id_cate}");
            var body = await response.Content.ReadAsStringAsync();
            return new ResponseAPI<string>
            {
                Message = body,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<List<CategoryViewModel>>> GetCateParent(string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/category/parent");
            var body = await response.Content.ReadAsStringAsync();
            var cates = JsonSerializer.Deserialize<List<CategoryViewModel>>(body);
            return new ResponseAPI<List<CategoryViewModel>>
            {
                Data = cates,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<string>> CreateCate(string session, CategoryCreateRequest request, Guid? gUser_id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/category?gCreator_id={gUser_id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return new ResponseAPI<string>
                {
                    Message = "success",
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                };
            }
            return new ResponseAPI<string>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync()
            };
        }

        public async Task<ResponseAPI<string>> UpdateCate(string session, CategoryUpdateRequest request, Guid? gUser_id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/category?gCreator_id={gUser_id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return new ResponseAPI<string>
                {
                    Message = "success",
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                };
            }
            return new ResponseAPI<string>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync()
            };
        }

    }
}

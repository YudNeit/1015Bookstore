using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
using _1015bookstore.viewmodel.Comon;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace _1015bookstore.websiteadmin.Service
{
    public class PromotionalCodeAPIClient : IPromotionalCodeAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PromotionalCodeAPIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseAPI<List<PromotionalCodeViewModel>>> GetCode(string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/promotionalcode");
            var body = await response.Content.ReadAsStringAsync();
            var codes = JsonSerializer.Deserialize< List < PromotionalCodeViewModel >> (body);
            return new ResponseAPI<List<PromotionalCodeViewModel>>
            {
                Data = codes,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<PromotionalCodeViewModel>> GetCodeById(string session, int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/PromotionalCode/{id}");
            var body = await response.Content.ReadAsStringAsync();
            var code = JsonSerializer.Deserialize<PromotionalCodeViewModel>(body);
            return new ResponseAPI<PromotionalCodeViewModel>
            {
                Data = code,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }
        public async Task<ResponseAPI<string>> CreateCode(string session, PromotionalCodeCreateRequest request, Guid? gUser_id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/promotionalcode?gCreator_id={gUser_id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return new ResponseAPI<string>
                {
                    Message = "success",
                    Status = response.StatusCode == System.Net.HttpStatusCode.Created ? true : false,
                };
            }
            return new ResponseAPI<string>
            {
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                Message = await response.Content.ReadAsStringAsync()
            };
        }

        public async Task<ResponseAPI<string>> UpdateCode(string session, PromotionalCodeUpdateRequest request, Guid? gUser_id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var json = JsonSerializer.Serialize(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/promotionalcode?gCreator_id={gUser_id}", httpContent);

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

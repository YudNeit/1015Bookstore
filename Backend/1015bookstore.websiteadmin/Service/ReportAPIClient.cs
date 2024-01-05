using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Reports;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _1015bookstore.websiteadmin.Service
{
    public class ReportAPIClient : IReportAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReportAPIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseAPI<decimal[]>>GetSoldByMonth(int month, string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/Report/getsoldmonth?iReport_month={month}");
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<decimal[]>(body);
            return new ResponseAPI<decimal[]>
            {
                Data = data,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<decimal[]>> GetImportByMonth(int month, string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/Report/getimportmonth?iReport_month={month}");
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<decimal[]>(body);
            return new ResponseAPI<decimal[]>
            {
                Data = data,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<decimal[]>> GetImportByWeek(DateTime date, string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/Report/getimportweek?dtReport_date={date.Year}-{date.Month}-{date.Day}");
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<decimal[]>(body);
            return new ResponseAPI<decimal[]>
            {
                Data = data,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<decimal[]>> GetSoldByWeek(DateTime date, string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/Report/getsoldweek?dtReport_date={date.Year}-{date.Month}-{date.Day}");
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<decimal[]>(body);
            return new ResponseAPI<decimal[]>
            {
                Data = data,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<List<ProductTop10>>> GetTop10ByMonth(int month, string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/Report/gettop10month?iReport_month={month}");
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<ProductTop10>>(body);
            return new ResponseAPI<List<ProductTop10>>
            {
                Data = data,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }

        public async Task<ResponseAPI<List<ProductTop10>>> GetTop10ByWeek(DateTime date, string session)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7139");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);

            var response = await client.GetAsync($"/api/Report/gettop10week?dtReport_date={date.Year}-{date.Month}-{date.Day}");
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<ProductTop10>>(body);
            return new ResponseAPI<List<ProductTop10>>
            {
                Data = data,
                Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
            };
        }
    }
}

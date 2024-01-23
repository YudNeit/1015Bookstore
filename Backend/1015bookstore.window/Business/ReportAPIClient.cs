using _1015bookstore.window.ViewModel;
using _1015bookstore.window.ViewModel.Report;
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
    public class ReportAPIClient
    {
        private readonly HttpClient _client;
        public ReportAPIClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7139");
        }

        public async Task<ResponseAPI<List<ReportDateMoney>>> GetSoldOutUser(string session, Guid user_id, DateTime datefrom, DateTime dateto)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", session);
            dateto = dateto.AddDays(1);
            var response = await _client.GetAsync($"/api/report/getsolduserday?gUser_id={user_id}&iReport_datefrom={datefrom.Year}-{datefrom.Month}-{datefrom.Day}&iReport_dateto={dateto.Year}-{dateto.Month}-{dateto.Day}");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var datas = JsonSerializer.Deserialize<List<ReportDateMoney>>(body);
                return new ResponseAPI<List<ReportDateMoney>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = "Thành công",
                    Data = datas,
                };
            }
            else
            {
                return new ResponseAPI<List<ReportDateMoney>>
                {
                    Status = response.StatusCode == System.Net.HttpStatusCode.OK ? true : false,
                    Message = await response.Content.ReadAsStringAsync(),
                    Data = new List<ReportDateMoney>(),
                };
            }
        }
    }
}

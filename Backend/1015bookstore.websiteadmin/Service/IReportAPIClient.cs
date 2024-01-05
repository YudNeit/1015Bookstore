using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Reports;

namespace _1015bookstore.websiteadmin.Service
{
    public interface IReportAPIClient
    {
        Task<ResponseAPI<decimal[]>> GetImportByMonth(int month, string session);
        Task<ResponseAPI<decimal[]>> GetSoldByMonth(int month, string session);
        Task<ResponseAPI<decimal[]>> GetImportByWeek(DateTime date, string session);
        Task<ResponseAPI<decimal[]>> GetSoldByWeek(DateTime date, string session);

        Task<ResponseAPI<List<ProductTop10>>> GetTop10ByMonth(int month, string session);
        Task<ResponseAPI<List<ProductTop10>>> GetTop10ByWeek(DateTime date, string session);
    }
}

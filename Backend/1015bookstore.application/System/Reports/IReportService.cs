using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.System.Reports
{
    public interface IReportService
    {
        Task<ResponseService<decimal[]>> Report_GetSoldByMonth(int month);

        Task<ResponseService<decimal[]>> Report_GetImportByMonth(int month);

        Task<ResponseService<decimal[]>> Report_GetImportByWeek(DateTime date);
        Task<ResponseService<decimal[]>> Report_GetSoldByWeek(DateTime date);
        Task<ResponseService<List<ProductTop10>>> Report_GetTop10ProductByMonth(int month);
        Task<ResponseService<List<ProductTop10>>> Report_GetTop10ProductByWeek(DateTime date);
    }
}

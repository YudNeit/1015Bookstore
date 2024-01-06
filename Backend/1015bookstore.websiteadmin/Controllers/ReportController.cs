using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.websiteadmin.Controllers
{
    [Authorize(Policy = "RequireAdmin")]
    public class ReportController : BaseController
    {
        private readonly IReportAPIClient _reportAPIClient;

        public ReportController(IReportAPIClient reportAPIClient)
        {
            _reportAPIClient = reportAPIClient;
        }
        public async Task<IActionResult> Index(DateTime paramName)
        {
            var session = HttpContext.Session.GetString("token");
            var soldmonth = await _reportAPIClient.GetSoldByMonth(paramName.Month, session);
            var importmonth = await _reportAPIClient.GetImportByMonth(paramName.Month, session);
            var soldweek = await _reportAPIClient.GetSoldByWeek(paramName, session);
            var importweek = await _reportAPIClient.GetImportByWeek(paramName, session);
            var top10month = await _reportAPIClient.GetTop10ByMonth(paramName.Month, session);
            var top10week = await _reportAPIClient.GetTop10ByWeek(paramName, session);

            ViewBag.top10week = top10week.Data;
            ViewData["top10weekname"] = top10week.Data.Select(x => x.product_name).ToList();
            ViewData["top10weekamount"] = top10week.Data.Select(x => x.amount).ToList();

            ViewBag.top10month = top10month.Data;
            ViewData["top10monthname"] = top10month.Data.Select(x => x.product_name).ToList();
            ViewData["top10monthamount"]= top10month.Data.Select(x => x.amount).ToList();

            ViewData["soldmonth"] = soldmonth.Data;
            ViewData["importmonth"] = importmonth.Data;
            ViewData["soldweek"] = soldweek.Data;
            ViewData["importweek"] = importweek.Data;
            return View();
        }
    }
}

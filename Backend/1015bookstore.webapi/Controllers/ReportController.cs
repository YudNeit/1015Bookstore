using _1015bookstore.application.Catalog.Carts;
using _1015bookstore.application.System.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("getsoldmonth")]
        public async Task<IActionResult> Report_GetSoldByMonth([Required]int iReport_month)
        {
            try
            {
                var response = await _reportService.Report_GetSoldByMonth(iReport_month);
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("getimportmonth")]
        public async Task<IActionResult> Report_GetImportByMonth([Required] int iReport_month)
        {
            try
            {
                var response = await _reportService.Report_GetImportByMonth(iReport_month);
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("getimportweek")]
        public async Task<IActionResult> Report_GetImportByWeek([Required] DateTime dtReport_date)
        {
            try
            {
                var response = await _reportService.Report_GetImportByWeek(dtReport_date);
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("getsoldweek")]
        public async Task<IActionResult> Report_GetSoldByWeek([Required] DateTime dtReport_date)
        {
            try
            {
                var response = await _reportService.Report_GetSoldByWeek(dtReport_date);
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("gettop10month")]
        public async Task<IActionResult> Report_GetTop10ByMonth([Required] int iReport_month)
        {
            try
            {
                var response = await _reportService.Report_GetTop10ProductByMonth(iReport_month);
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("gettop10week")]
        public async Task<IActionResult> Report_GetTop10ByWeek([Required] DateTime dtReport_date)
        {
            try
            {
                var response = await _reportService.Report_GetTop10ProductByWeek(dtReport_date);
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

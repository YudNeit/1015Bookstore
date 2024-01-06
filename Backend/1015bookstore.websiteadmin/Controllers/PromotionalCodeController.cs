using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.websiteadmin.Controllers
{
    [Authorize(Policy = "RequireAdmin")]
    public class PromotionalCodeController : BaseController
    {
        private readonly IPromotionalCodeAPIClient _promotionalcodeAPIClient;

        public PromotionalCodeController(IPromotionalCodeAPIClient promotionalcodeAPIClient)
        {
            _promotionalcodeAPIClient = promotionalcodeAPIClient;
        }
        public async Task<IActionResult> Index()
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _promotionalcodeAPIClient.GetCode(session);
            if (TempData["success"] != null)
                ViewBag.success = TempData["success"];
            if (TempData["error"] != null)
                ViewBag.error = TempData["error"];
            return View(response.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PromotionalCodeCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userIdClaim = User.FindFirst("id").Value;

            var session = HttpContext.Session.GetString("token");
            var response = await _promotionalcodeAPIClient.CreateCode(session, request, new Guid(userIdClaim));
            if (response.Status)
            {
                TempData["success"] = $"Tạo thành công mã giảm giá {DateTime.Now}";
                return RedirectToAction("Index");
            }
            ViewBag.error = response.Message;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _promotionalcodeAPIClient.GetCodeById(session, id);
            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _promotionalcodeAPIClient.GetCodeById(session, id);
            var updatecode = new PromotionalCodeUpdateRequest()
            {
                iPromotionalCode_id = id,
                dtPromotionalCode_fromdate = response.Data.dtPromotionalCode_fromdate,
                dtPromotionalCode_todate = response.Data.dtPromotionalCode_todate,
                iPromotionalCode_amount = response.Data.iPromotionalCode_amount,
                iPromotionalCode_discount_rate = response.Data.iPromotionalCode_discount_rate,
                sPromotionalCode_code = response.Data.sPromotionalCode_code,
                sPromotionalCode_name = response.Data.sPromotionalCode_name,
                sPromotionalCode_description = response.Data.sPromotionalCode_description,
                stPromotionalCode_status = response.Data.stPromotionalCode_status,
            };
            return View(updatecode);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PromotionalCodeUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var userIdClaim = User.FindFirst("id").Value;

            var session = HttpContext.Session.GetString("token");
            var response = await _promotionalcodeAPIClient.UpdateCode(session, request, new Guid(userIdClaim));
            if (response.Status)
            {
                TempData["success"] = $"Cập nhật thành công mã giảm giá {DateTime.Now}";
                return RedirectToAction("Index");
            }
            TempData["Error"] = response.Message;
            return RedirectToAction("Edit", new {id = request.iPromotionalCode_id});
        }
    }
}

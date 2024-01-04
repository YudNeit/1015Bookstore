using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.websiteadmin.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductAPIClient _productAPIClient;

        public ProductController(IProductAPIClient productAPIClient)
        {
            _productAPIClient = productAPIClient;
        }
        
        public async Task<IActionResult> Index()
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _productAPIClient.GetProduct(session);
            if (TempData["result"] != null)
                ViewBag.success = TempData["result"];
            return View(response.Data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int product_id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _productAPIClient.GetProductById(session, product_id);
            return View(response.Data);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userIdClaim = User.FindFirst("id").Value;

            var session = HttpContext.Session.GetString("token");
            var response = await _productAPIClient.CraeteProduct(request, session, new Guid(userIdClaim));
            if (response.Status)
            {
                TempData["result"] = $"Tạo thành công sản phẩm {DateTime.Now}";
                return RedirectToAction("Index");
            }
            ViewBag.error = response.Message;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int product_id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _productAPIClient.GetProductById(session, product_id);
            if (response.Status)
            {
                var productupdate = new ProductUpdateRequest
                {
                    iProduct_id = product_id,
                    sProduct_name = response.Data.sProduct_name,
                    vProduct_price = response.Data.vProduct_price,
                    iProduct_waranty = response.Data.iProduct_waranty,
                    sProduct_description = response.Data.sProduct_description,
                    sProduct_brand = response.Data.sProduct_brand,
                    sProduct_madein = response.Data.sProduct_madein,
                    dtProduct_mfgdate = response.Data.dtProduct_mfgdate,
                    sProduct_supplier = response.Data.sProduct_supplier,
                    sProduct_author = response.Data.sProduct_author,
                    sProduct_nop = response.Data.sProduct_nop,
                    iProduct_yop = response.Data.iProduct_yop,
                };
                return View(productupdate);
                    
            }
            TempData["error"] = $"Lấy thông tin sản phẩm thất bại {DateTime.Now}";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userIdClaim = User.FindFirst("id").Value;

            var session = HttpContext.Session.GetString("token");
            var response = await _productAPIClient.UpdateProduct(request, session, new Guid(userIdClaim));
            if (response.Status)
            {
                TempData["result"] = $"Cập nhật thành công sản phẩm {DateTime.Now}";
                return RedirectToAction("Index");
            }
            ViewBag.error = response.Message;
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Receipt()
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _productAPIClient.GetProduct(session);
            if (TempData["success"] != null)
                ViewBag.success = TempData["success"];
            if (TempData["error"] != null)
                ViewBag.error = TempData["error"];
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Receipt(int amount, int product_id)
        {
            var userIdClaim = User.FindFirst("id").Value;

            var session = HttpContext.Session.GetString("token");
            var response = await _productAPIClient.UpdateQuantity(amount, product_id, session, new Guid(userIdClaim));
            var product = await _productAPIClient.GetProduct(session);
            if (response.Status)
            {
                TempData["success"] = $"Nhập kho thàng công sản phẩm {DateTime.Now}";
                return RedirectToAction("Receipt");
            }
            TempData["error"] = response.Message;
            return RedirectToAction("Receipt");
        }
    }
}

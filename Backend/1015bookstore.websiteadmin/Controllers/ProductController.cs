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
            var session = HttpContext.Session.GetString("token");
            var response = await _productAPIClient.CraeteProduct(request, session);
            if (response.Status)
                return RedirectToAction("Index");
            ViewBag.error = response.Message;
            return View();
        }
    }
}

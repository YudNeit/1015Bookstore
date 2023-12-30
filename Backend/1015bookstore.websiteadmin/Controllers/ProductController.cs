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
        
        public async Task<IActionResult> Index(string keyword,int pageIndex = 1, int pageSize = 10)
        {
            var session = HttpContext.Session.GetString("token");
            var request = new GetProductByKeyWordPagingRequest
            {
                sKeyword = keyword,
                pageindex = pageIndex,
                pagesize = pageSize
            };
            var response = await _productAPIClient.GetProductPaging(request, session);
            return View(response);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            return View();
        }
    }
}

using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _1015bookstore.websiteadmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAPIClient _categoryAPIClient;
        private readonly IConfiguration _config;

        public CategoryController(ICategoryAPIClient categoryAPIClient, IConfiguration config)
        {
            _categoryAPIClient = categoryAPIClient;
            _config = config;
        }
        public async Task<IActionResult> Index()
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.GetCate(session);
            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeParent(int id, string name)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.GetAddCate(session, id);
            ViewBag.ParentCate = response.Data.Select(x => new SelectListItem { 
                Text = x.sCate_name,
                Value = x.iCate_id.ToString(),
                
            });
            ViewBag.Name = name;
            ViewBag.Id = id;    
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeParent(int id, int parent_id)
        {
            var session = HttpContext.Session.GetString("token");
            var userIdClaim = User.FindFirst("id").Value;
            var response = await _categoryAPIClient.ChangeParent(session,parent_id ,id, new Guid(userIdClaim));
            if (response.Status)
            {
                TempData["result"] = $"Thay đổi danh mục thành công {DateTime.Now}";
                return RedirectToAction("Index");
            }
            ViewBag.error = response.Message;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductCate(int paramName)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.GetById(session, paramName);
            
            var product = await _categoryAPIClient.GetProductByCate(session, paramName);
            ViewBag.product = product.Data;
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProductCate(int cate_id, int product_id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.DeleteProductInCate(session, cate_id, product_id);
            if (response.Status)
            {
                TempData["result"] = $"Thay đổi danh mục thành công {DateTime.Now}";
                return RedirectToAction("ProductCate", "Category", new { paramName = cate_id });
            }
            ViewBag.error = response.Message;
            return RedirectToAction("ProductCate", "Category", new { paramName = cate_id });
        }

        [HttpPost]
        public async Task<IActionResult> SetProductCate(int cate_id, int product_id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.SetProductInCate(session, cate_id, product_id);
            if (response.Status)
            {
                TempData["result"] = $"Thay đổi danh mục thành công {DateTime.Now}";
                return RedirectToAction("ProductCate", "Category", new { paramName = cate_id });
            }
            ViewBag.error = response.Message;
            return RedirectToAction("ProductCate", "Category", new { paramName = cate_id });
        }

        [HttpGet]
        public async Task<IActionResult> SetProductCate(int id, string name)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.GetProductNotInCate(session, id);
            ViewBag.ParentCate = response.Data.Select(x => new SelectListItem
            {
                Text = x.sProduct_name,
                Value = x.iProduct_id.ToString(),

            });
            ViewBag.Name = name;
            ViewBag.Id = id;
            return View();
        }
    }
}

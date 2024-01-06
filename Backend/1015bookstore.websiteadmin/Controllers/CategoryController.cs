using _1015bookstore.viewmodel.Catalog.Categories;
using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _1015bookstore.websiteadmin.Controllers
{
    [Authorize(Policy = "RequireAdmin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAPIClient _categoryAPIClient;


        public CategoryController(ICategoryAPIClient categoryAPIClient)
        {
            _categoryAPIClient = categoryAPIClient;
        }
        public async Task<IActionResult> Index()
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.GetCate(session);
            if (TempData["success"] != null)
                ViewBag.success = TempData["success"];
            if (TempData["error"] != null)
                ViewBag.error = TempData["error"];
            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult>Create()
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.GetCateParent(session);
            ViewBag.ParentCate = response.Data.Select(x => new SelectListItem
            {
                Text = x.sCate_name,
                Value = x.iCate_id.ToString(),

            });
            if (TempData["error"] != null)
                ViewBag.error = TempData["error"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(CategoryCreateRequest request)
        {
            var session = HttpContext.Session.GetString("token");
            var userIdClaim = User.FindFirst("id").Value;
            var response = await _categoryAPIClient.CreateCate(session, request, new Guid(userIdClaim));

            if (response.Status)
            {
                TempData["success"] = $"Tạo thành công danh mục sản phẩm {DateTime.Now}";
                return RedirectToAction("Index");
            }
            ViewBag.error = response.Message;
            return View();
        }

        

        [HttpGet]
        public async Task<IActionResult> ChangeParent(int id, string name)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.GetAddCate(session, id);
            ViewBag.Name = name;
            ViewBag.Id = id;
            if (TempData["error"] != null)
                ViewBag.error = TempData["error"];
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeParent(int id, int parent_id)
        {
            var session = HttpContext.Session.GetString("token");
            var userIdClaim = User.FindFirst("id").Value;
            var response = await _categoryAPIClient.ChangeParent(session,parent_id ,id, new Guid(userIdClaim));
            if (response.Status)
            {
                TempData["success"] = $"Thay đổi danh mục thành công {DateTime.Now}";
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
            if (TempData["success"] != null)
                ViewBag.success = TempData["success"];
            if (TempData["error"] != null)
                ViewBag.error = TempData["error"];

            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProductCate(int cate_id, int product_id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.DeleteProductInCate(session, cate_id, product_id);
            if (response.Status)
            {
                TempData["success"] = $"Thay đổi danh mục thành công {DateTime.Now}";
                return RedirectToAction("ProductCate", "Category", new { paramName = cate_id });
            }
            TempData["success"] = response.Message;
            return RedirectToAction("ProductCate", "Category", new { paramName = cate_id });
        }

        [HttpPost]
        public async Task<IActionResult> SetProductCate(int cate_id, int product_id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.SetProductInCate(session, cate_id, product_id);
            if (response.Status)
            {
                TempData["success"] = $"Thay đổi danh mục thành công {DateTime.Now}";
                return RedirectToAction("ProductCate", "Category", new { paramName = cate_id });
            }
            TempData["error"] = response.Message;
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _categoryAPIClient.GetById(session, id);
            var updatecate = new CategoryUpdateRequest()
            {
                iCate_id = id,
                sCate_name= response.Data.sCate_name,
                stCate_status = response.Data.stCate_status,
                stCate_show = response.Data.stCate_show,
            };
            return View(updatecate);
        
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateRequest request)
        {
            var session = HttpContext.Session.GetString("token");
            var userIdClaim = User.FindFirst("id").Value;
            var response = await _categoryAPIClient.UpdateCate(session, request, new Guid(userIdClaim));

            if (response.Status)
            {
                TempData["success"] = $"Cập nhật thành công danh mục sản phẩm {DateTime.Now}";
                return RedirectToAction("ProductCate", new { paramName = request.iCate_id});
            }
            ViewBag.error = response.Message;
            return View();
        }
    }
}

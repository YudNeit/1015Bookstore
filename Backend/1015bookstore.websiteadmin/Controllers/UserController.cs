using _1015bookstore.viewmodel.System.Users;
using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace _1015bookstore.websiteadmin.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserAPIClient _userAPIClient;
        private readonly IConfiguration _config;

        public UserController(IUserAPIClient userAPIClient, IConfiguration config)
        {
            _userAPIClient = userAPIClient;
            _config = config;
        }
        public async Task<IActionResult> Index()
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _userAPIClient.GetUser(session);
            return View(response.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (RegisterAdminRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var session = HttpContext.Session.GetString("token");
            var response = await _userAPIClient.CraeteUserAdmin(request, session);
            
            if (response.Status)
                return RedirectToAction("Index");
            ViewBag.error = response.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

    }
}

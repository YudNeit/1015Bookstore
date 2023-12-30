using _1015bookstore.viewmodel.System.Users;
using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

    }
}

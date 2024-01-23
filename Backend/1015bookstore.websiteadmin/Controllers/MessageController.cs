
using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.websiteadmin.Controllers
{
    public class MessageController : Controller
    {
        private readonly IChatAPIClient _chatAPIClient;

        public MessageController(IChatAPIClient chatAPIClient) 
        {
            _chatAPIClient = chatAPIClient;
        }
        public async Task<IActionResult> Index()
        {
            var session = HttpContext.Session.GetString("token");
            var response = await _chatAPIClient.GetUser(session);
            var userIdClaim = User.FindFirst("id").Value;
            ViewBag.Session = session;
            ViewBag.MessageUser = response.Data;
            ViewBag.User_id = userIdClaim;
            return View();
        }

    }
}

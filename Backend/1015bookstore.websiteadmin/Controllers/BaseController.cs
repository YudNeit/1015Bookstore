using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _1015bookstore.websiteadmin.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString("token");
            if (session == null) {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            
            base.OnActionExecuting(context);
        }
    }
}

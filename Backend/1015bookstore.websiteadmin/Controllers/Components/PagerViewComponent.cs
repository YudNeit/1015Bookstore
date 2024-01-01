using _1015bookstore.viewmodel.Comon;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.websiteadmin.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}

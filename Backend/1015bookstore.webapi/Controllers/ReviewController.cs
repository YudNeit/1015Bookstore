using _1015bookstore.application.Catalog.Carts;
using _1015bookstore.application.Catalog.Reviews;
using _1015bookstore.viewmodel.Catalog.Reviews;
using _1015bookstore.viewmodel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> Review_Create([FromBody] ReviewRequestCreate request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _reviewService.Review_Create(request);
                return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getbyid")]
        [AllowAnonymous]
        public async Task<IActionResult> Review_GetByProductID([FromQuery] int iProduct_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _reviewService.Review_GetByProductId(iProduct_id);
                if (!result.Status)
                {
                    return StatusCode(result.CodeStatus, result.Message);
                }
                return StatusCode(result.CodeStatus, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

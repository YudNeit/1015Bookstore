using _1015bookstore.application.Catalog.ProductIsnCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductInCategoryController : ControllerBase
    {
        private readonly IProductInCategoryService _productInCategoryService;

        public ProductInCategoryController(IProductInCategoryService productInCategoryService) 
        {
            _productInCategoryService = productInCategoryService;
        }
        //http:localhost:port/api/productincategory/set
        [HttpGet("set")]
        public async Task<IActionResult> Set([FromQuery]int product_id, [FromQuery] int category_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productInCategoryService.Create(product_id, category_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/productincategory/remove
        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery]int product_id, [FromQuery] int category_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productInCategoryService.Delete(product_id, category_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

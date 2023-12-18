using _1015bookstore.application.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService) {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        //http:localhost:port/api/product
        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                var product = await _publicProductService.GetAll();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/public-paging
        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            try
            {
                var pageResult = await _publicProductService.GetAllByCategoryId(request);
                return Ok(pageResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _manageProductService.GetById(id);
                if (product == null)
                    return BadRequest("Cannot find product");
                return Ok(product);
            }    
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/product
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            try
            {
                var productId = await _manageProductService.Create(request);
                if (productId == 0)
                    return BadRequest();

                var product = await _manageProductService.GetById(productId);
                return CreatedAtAction(nameof(GetById), new { id = productId }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/product
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            try
            {
                var affectedResult = await _manageProductService.Update(request);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var affectedResult = await _manageProductService.Delete(id);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/1/12000
        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(id, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }
    }
}

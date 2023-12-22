using _1015bookstore.application.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService ProductService) {
            _productService = ProductService;
        }

        //http:localhost:port/api/product
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get() {
            try
            {
                var product = await _productService.GetAll();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/public-paging
        [HttpGet("public-paging")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] GetProductByCategoryPagingRequest request)
        {
            try
            {
                var pageResult = await _productService.GetProductByCategoryId(request);
                return Ok(pageResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/public-paging
        [HttpGet("public-paging-keyword")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByKeyWord([FromQuery] GetProductByKeyWordPagingRequest request)
        {
            try
            {
                var pageResult = await _productService.GetProductByKeyWordPaging(request);
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
                var product = await _productService.GetById(id);
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
                var productId = await _productService.Create(request);
                if (productId == 0)
                    return BadRequest();

                var product = await _productService.GetById(productId);
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
                var affectedResult = await _productService.Update(request);
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
                var affectedResult = await _productService.Delete(id);
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
            try
            {
                var isSuccessful = await _productService.UpdatePrice(id, newPrice);
                if (isSuccessful)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/addviewcount/1
        [HttpPut("addviewcount/{id}")]
        public async Task<IActionResult> AddViewCount(int id)
        {
            try
            {
                 await _productService.AddViewcount(id);
                 return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/updatequanity
        [HttpPut("updatequanity")]
        public async Task<IActionResult> UpdateQuanity([FromQuery]int id, int addedQuantity)
        {
            try
            {
                await _productService.UpdataQuanity(id, addedQuantity);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

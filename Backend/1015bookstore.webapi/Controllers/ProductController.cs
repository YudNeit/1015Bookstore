using _1015bookstore.application.Catalog.Products;
using _1015bookstore.viewmodel.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
                var result = await _productService.GetById(id);
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
        
        //http:localhost:port/api/product
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.Create(request);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Data);
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
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.Update(request);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Message);
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
        public async Task<IActionResult> UpdatePrice([Required]int id, [Required(ErrorMessage = "The * field is required")][Range(0, int.MaxValue, ErrorMessage = "The price is bigger than 0")]decimal newPrice)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.UpdatePrice(id, newPrice);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Message);
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
        public async Task<IActionResult> UpdateQuanity([Required][FromQuery]int id, [Required]int addedQuantity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.UpdataQuanity(id, addedQuantity);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

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
        [HttpGet("category")]
        [AllowAnonymous]
        public async Task<IActionResult> Product_GetCategory([Required]int iProduct_id) {
            try
            {
                var response = await _productService.Product_GetCategory(iProduct_id);
                if (response.Status)
                {
                    return StatusCode(response.CodeStatus, response.Data);
                }
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        

        //http://localhost:port/api/product/public-paging
        [HttpGet("public-paging-cate")]
        [AllowAnonymous]
        public async Task<IActionResult> Product_GetProductByCategoryPagingPublic([FromQuery] GetProductByCategoryPagingRequest request)
        {
            try
            {
                var pageResult = await _productService.Product_GetProductByCategoryPagingPublic(request);
                return Ok(pageResult.items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/product/public-paging
        [HttpGet("admin-paging-cate")]
        public async Task<IActionResult> Product_GetProductByCategoryPagingAdmin([FromQuery] GetProductByCategoryPagingRequest request)
        {
            try
            {
                var pageResult = await _productService.Product_GetProductByCategoryPagingPublic(request);
                return Ok(pageResult.items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/product/public-paging
        [HttpGet("public-paging-keyword")]
        [AllowAnonymous]
        public async Task<IActionResult> Product_GetProductByKeyWordPagingPublic([FromQuery] GetProductByKeyWordPagingRequest request)
        {
            try
            {
                var pageResult = await _productService.Product_GetProductByKeyWordPagingPublic(request);
                return Ok(pageResult.items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/product/public-paging
        [HttpGet("admin-paging-keyword")]
        public async Task<IActionResult> Product_GetProductByKeyWordPagingAdmin([FromQuery] GetProductByKeyWordPagingRequest request)
        {
            try
            {
                var pageResult = await _productService.Product_GetProductByKeyWordPagingAdmin(request);
                return Ok(pageResult.items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/product/public-paging
        [HttpGet("admin-getall")]
        public async Task<IActionResult> Product_GetAllAdmin()
        {
            try
            {
                var response = await _productService.Product_GetAllAdmin();
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/public-paging
        [HttpGet("public-getall")]
        [AllowAnonymous]
        public async Task<IActionResult> Product_GetAllPublic()
        {
            try
            {
                var response = await _productService.Product_GetAllPublic();
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/public-paging
        [HttpGet("public-getbykeyword")]
        [AllowAnonymous]
        public async Task<IActionResult> Product_GetProductByKeywordAllPublic(string? sKeyword)
        {
            try
            {
                var response = await _productService.Product_GetProductByKeywordAllPublic(sKeyword);
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/product/1
        [HttpGet("{iProduct_id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Product_GetById(int iProduct_id)
        {
            try
            {
                var result = await _productService.Product_GetById(iProduct_id);
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


        [HttpGet("notincate/{iCate_id}")]
        public async Task<IActionResult> Product_GetNotInCate(int iCate_id)
        {
            try
            {
                var result = await _productService.Product_GetProductNotInCate(iCate_id);
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
        public async Task<IActionResult> Product_Create([FromForm] ProductCreateRequest request, Guid? gCreator_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.Product_Create(request, gCreator_id);
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
        public async Task<IActionResult> Product_Update([FromForm] ProductUpdateRequest request, Guid? gCreator_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.Product_Update(request, gCreator_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        //http://localhost:port/api/product/1
        [HttpDelete("{IProduct_id}")]
        public async Task<IActionResult> Product_Delete([Required]int iProduct_id, Guid? gCreator_id)
        {
            try
            {
                var response = await _productService.Product_Delete(iProduct_id, gCreator_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        //http://localhost:port/api/product/1/12000
        [HttpPut("updateprice")]
        public async Task<IActionResult> Product_UpdatePrice([Required]int iProduct_id, [Required(ErrorMessage = "The * field is required")][Range(0, int.MaxValue, ErrorMessage = "The price is bigger than 0")]decimal newPrice, Guid? gCreator_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.Product_UpdatePrice(iProduct_id, newPrice, gCreator_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        //http://localhost:port/api/product/addviewcount/1
        [HttpPut("addviewcount/{iProduct_id}")]
        public async Task<IActionResult> Product_AddViewcount(int iProduct_id)
        {
            try
            {
                 await _productService.Product_AddViewcount(iProduct_id);
                 return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/product/updatequanity
        [HttpPut("updatequantity")]
        public async Task<IActionResult> Product_UpdateQuantity([Required][FromQuery]int iProduct_id, [Required]int addedQuantity, [Required] decimal price, Guid? gUpdater_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _productService.Product_UpdateQuantity(iProduct_id, addedQuantity, price, gUpdater_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

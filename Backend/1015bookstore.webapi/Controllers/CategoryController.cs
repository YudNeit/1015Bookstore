using _1015bookstore.application.Catalog.Categories;
using _1015bookstore.viewmodel.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //http:localhost:port/api/category
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateRequest request)
        {
            try
            {
                var productId = await _categoryService.Create(request);
                if (productId == 0)
                    return BadRequest();

                var product = await _categoryService.GetById(productId);
                return CreatedAtAction(nameof(GetById), new { id = productId }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/category
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateRequest request)
        {
            try
            {
                var affectedResult = await _categoryService.Update(request);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/category/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var affectedResult = await _categoryService.Delete(id);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cate = await _categoryService.GetAll();
                return Ok(cate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/category/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cate = await _categoryService.GetById(id);
                if (cate == null)
                    return BadRequest("Cannot find category");
                return Ok(cate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/category/parentandchild
        [HttpGet("parentandchild")]
        public async Task<IActionResult> GetParentAndChild()
        {
            try
            {
                var cate = await _categoryService.GetParentAndChildAll();
                return Ok(cate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/category/parentandchild/1
        [HttpGet("parentandchild/{id}")]
        public async Task<IActionResult> GetParentAndChildById(int id)
        {
            try
            {
                var cate = await _categoryService.GetParentAndChildById(id);
                return Ok(cate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

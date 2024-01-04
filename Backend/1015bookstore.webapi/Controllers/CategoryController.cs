using _1015bookstore.application.Catalog.Categories;
using _1015bookstore.viewmodel.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Cate_Create([FromBody] CategoryCreateRequest request, Guid? gCreator_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _categoryService.Cate_Create(request, gCreator_id);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/category
        [HttpPut]
        public async Task<IActionResult> Cate_Update([FromBody] CategoryUpdateRequest request, Guid? gUpdater_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _categoryService.Cate_Update(request, gUpdater_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/category/1
        [HttpDelete("{ICate_id}")]
        public async Task<IActionResult> Cate_Delete([Required]int iCate_id, Guid? gUpdater_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _categoryService.Cate_Delete(iCate_id, gUpdater_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/category
        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> Cate_GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _categoryService.Cate_GetAll();
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/category/taskbar
        [HttpGet("taskbar")]
        [AllowAnonymous]
        public async Task<IActionResult> Cate_GetTaskbar()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _categoryService.Cate_GetTaskbar();
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/category/parent
        [HttpGet("parent")]
        public async Task<IActionResult> Cate_GetParent()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _categoryService.Cate_GetParent();
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/changeparent
        [HttpPatch("changeparent")]
        public async Task<IActionResult> Cate_ChangeParent([Required]int iCate_id, [Required] int iCate_parent_id, Guid? gUpdater_id)
        {
            try
            {
                var response = await _categoryService.Cate_ChangeParent(iCate_id, iCate_parent_id, gUpdater_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAddCate")]
        public async Task<IActionResult> Cate_GetAddCate([FromQuery]int iCate_id)
        {

            try
            {
                var response = await _categoryService.Cate_GetAddCate(iCate_id);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{iCate_id}")]
        public async Task<IActionResult> Cate_GetById(int iCate_id)
        {

            try
            {
                var response = await _categoryService.Cate_GetById(iCate_id);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

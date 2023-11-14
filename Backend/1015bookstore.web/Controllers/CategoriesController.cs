using _1015bookstore.web.Model;
using _1015bookstore.web.Repository;
using _1015bookstore.web.Repository.IRepository;
using _1015bookstore.web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryreposity;

        public CategoriesController(ICategoryRepository _categoryreposity)
        {
            categoryreposity = _categoryreposity;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(categoryreposity.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            try
            {
                var data = categoryreposity.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(int userid, CategoryModel cate)
        {
            try
            {
                return Ok(categoryreposity.Add(userid, cate));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                categoryreposity.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, int userid, CategoryModel cate)
        {
            try
            {
                categoryreposity.Update(id, userid, cate);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetFull")]
        public IActionResult GetFull()
        {
            try
            {
                return Ok(categoryreposity.GetFull());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetFullById")]
        public IActionResult GetFullById(int id)
        {
            try
            {
                return Ok(categoryreposity.GetFullById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
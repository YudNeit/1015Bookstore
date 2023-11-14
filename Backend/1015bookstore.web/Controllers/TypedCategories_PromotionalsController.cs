using _1015bookstore.web.Model;
using _1015bookstore.web.Repository;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypedCategories_PromotionalsController : ControllerBase
    {
        private readonly ITypedCategories_PromotionalsRepository typedCategories_promotionalsrepository;
        public TypedCategories_PromotionalsController(ITypedCategories_PromotionalsRepository _typedCategories_promotionalsrepository)
        {
            typedCategories_promotionalsrepository = _typedCategories_promotionalsrepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(typedCategories_promotionalsrepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetByUserid/{id}")]
        public IActionResult GetByCategoryId(int cateid)
        {
            try
            {
                var data = typedCategories_promotionalsrepository.GetByCategoryId(cateid);
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

        [HttpGet("GetByProductid/{id}")]
        public IActionResult GetByPromotionalId(int promotionalid)
        {
            try
            {
                var data = typedCategories_promotionalsrepository.GetByPromotionalId(promotionalid);
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
        public IActionResult Add(TypedCategories_PromotionalsModel item)
        {
            try
            {
                return Ok(typedCategories_promotionalsrepository.Add(item));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int cateid, int promotionalid)
        {
            try
            {
                typedCategories_promotionalsrepository.Delete(cateid, promotionalid);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(TypedCategories_PromotionalsModel item)
        {
            try
            {
                typedCategories_promotionalsrepository.Update(item);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

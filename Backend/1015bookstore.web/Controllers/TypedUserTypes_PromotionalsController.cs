using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypedUserTypes_PromotionalsController : ControllerBase
    {
        private readonly ITypedUserTypes_PromotionalsRepository typedusertypes_promotionalsrepository;
        public TypedUserTypes_PromotionalsController(ITypedUserTypes_PromotionalsRepository _typedusertypes_promotionalsrepository)
        {
            typedusertypes_promotionalsrepository = _typedusertypes_promotionalsrepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(typedusertypes_promotionalsrepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetByUserTypeId/{id}")]
        public IActionResult GetByUserTypeId(int id)
        {
            try
            {
                var data = typedusertypes_promotionalsrepository.GetByUserTypeId(id);
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

        [HttpGet("GetByPromotionalId/{id}")]
        public IActionResult GetByPromotionalId(int id)
        {
            try
            {
                var data = typedusertypes_promotionalsrepository.GetByPromotionalId(id);
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
        public IActionResult Add(TypedUserTypes_PromotionalsModel item)
        {
            try
            {
                return Ok(typedusertypes_promotionalsrepository.Add(item));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int usertypeid, int promotionalid)
        {
            try
            {
                typedusertypes_promotionalsrepository.Delete(usertypeid, promotionalid);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(TypedUserTypes_PromotionalsModel item)
        {
            try
            {
                typedusertypes_promotionalsrepository.Update(item);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

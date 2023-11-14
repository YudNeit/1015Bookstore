using _1015bookstore.web.Model;
using _1015bookstore.web.Repository;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypedUsers_PromotionalsController : ControllerBase
    {
        private readonly ITypedUsers_PromotionalsRepository typedusers_promotionalsrepository;
        public TypedUsers_PromotionalsController(ITypedUsers_PromotionalsRepository _typedusers_promotionalsrepository)
        {
            typedusers_promotionalsrepository = _typedusers_promotionalsrepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(typedusers_promotionalsrepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetByUserId/{id}")]
        public IActionResult GetByUserId(int id)
        {
            try
            {
                var data = typedusers_promotionalsrepository.GetByUserId(id);
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
                var data = typedusers_promotionalsrepository.GetByPromotionalId(id);
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
        public IActionResult Add(TypedUsers_PromotionalsModel item)
        {
            try
            {
                return Ok(typedusers_promotionalsrepository.Add(item));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int userid, int promotionalid)
        {
            try
            {
                typedusers_promotionalsrepository.Delete(userid, promotionalid);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(TypedUsers_PromotionalsModel item)
        {
            try
            {
                typedusers_promotionalsrepository.Update(item);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

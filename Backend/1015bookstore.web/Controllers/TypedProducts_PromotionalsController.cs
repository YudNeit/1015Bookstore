using _1015bookstore.web.Model;
using _1015bookstore.web.Repository;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypedProducts_PromotionalsController : ControllerBase
    {
        private readonly ITypedProducts_PromotionalsRepository typedproducts_promotionalsrepository;
        public TypedProducts_PromotionalsController(ITypedProducts_PromotionalsRepository _typedproducts_promotionalsrepository)
        {
            typedproducts_promotionalsrepository = _typedproducts_promotionalsrepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(typedproducts_promotionalsrepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetByProductId/{id}")]
        public IActionResult GetByProductId(int id)
        {
            try
            {
                var data = typedproducts_promotionalsrepository.GetByProductId(id);
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
                var data = typedproducts_promotionalsrepository.GetByPromotionalId(id);
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
        public IActionResult Add(TypedProducts_PromotionalsModel item)
        {
            try
            {
                return Ok(typedproducts_promotionalsrepository.Add(item));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int productid, int promotionalid)
        {
            try
            {
                typedproducts_promotionalsrepository.Delete(productid, promotionalid);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(TypedProducts_PromotionalsModel item)
        {
            try
            {
                typedproducts_promotionalsrepository.Update(item);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

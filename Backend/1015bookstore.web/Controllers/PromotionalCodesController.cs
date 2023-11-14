using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionalCodesController : ControllerBase
    {
        private readonly IPromotionalCodeRepository promotionalcodeRepository;

        public PromotionalCodesController(IPromotionalCodeRepository _promotionalcodeRepository)
        {
            promotionalcodeRepository = _promotionalcodeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(promotionalcodeRepository.GetAll());
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
                var data = promotionalcodeRepository.GetById(id);
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
        public IActionResult Add(int userid, PromotionalCodeModel promotion)
        {
            try
            {
                return Ok(promotionalcodeRepository.Add(userid, promotion));
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
                promotionalcodeRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, int userid, PromotionalCodeModel promotion)
        {
            try
            {
                promotionalcodeRepository.Update(id, userid, promotion);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

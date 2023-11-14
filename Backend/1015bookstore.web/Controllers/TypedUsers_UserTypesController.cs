using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypedUsers_UserTypesController : ControllerBase
    {
        private readonly ITypedUsers_UserTypesRepository typedtypedUsers_userTypesrepository;
        public TypedUsers_UserTypesController(ITypedUsers_UserTypesRepository _typedtypedUsers_userTypesrepository)
        {
            typedtypedUsers_userTypesrepository = _typedtypedUsers_userTypesrepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(typedtypedUsers_userTypesrepository.GetAll());
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
                var data = typedtypedUsers_userTypesrepository.GetByUserTypeId(id);
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

        [HttpGet("GetByUserId/{id}")]
        public IActionResult GetByUserId(int id)
        {
            try
            {
                var data = typedtypedUsers_userTypesrepository.GetByUserId(id);
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
        public IActionResult Add(TypedUsers_UserTypesModel item)
        {
            try
            {
                return Ok(typedtypedUsers_userTypesrepository.Add(item));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int usertypeid, int userid)
        {
            try
            {
                typedtypedUsers_userTypesrepository.Delete(usertypeid, userid);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(TypedUsers_UserTypesModel item)
        {
            try
            {
                typedtypedUsers_userTypesrepository.Update(item);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

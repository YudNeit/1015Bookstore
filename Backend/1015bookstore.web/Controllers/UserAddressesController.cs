using _1015bookstore.web.Model;
using _1015bookstore.web.Repository;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressesController : ControllerBase
    {
        private readonly IUserAddressRepository useraddressrepository;

        public UserAddressesController(IUserAddressRepository _useraddressrepository) 
        {
            useraddressrepository = _useraddressrepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(useraddressrepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id) 
        {
            try
            {
                var data = useraddressrepository.GetById(id);
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

        [HttpGet("GetByUserID/{userid}")]
        public IActionResult GetByUserID(int userid)
        {
            try
            {
                var data = useraddressrepository.GetByUserId(userid);
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
        public IActionResult Add(UserAddressModel address)
        {
            try
            {
                return Ok(useraddressrepository.Add(address));
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
                useraddressrepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserAddressModel address)
        {
            try
            {
                useraddressrepository.Update(id, address);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

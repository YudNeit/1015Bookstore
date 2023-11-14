using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userropository;

        public UsersController(IUserRepository _userrepository)
        {
            userropository = _userrepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(userropository.GetAll());
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
                var data = userropository.GetById(id);
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
        public IActionResult Add(UserModel user)
        {
            try
            {
                return Ok(userropository.Add(user));
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
                userropository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserModel user)
        {
            try
            {
                userropository.Update(id, user);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

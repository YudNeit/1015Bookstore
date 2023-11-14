using _1015bookstore.web.Model;
using _1015bookstore.web.Repository;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemRepository cartitemrepository;
        public CartItemsController(ICartItemRepository _cartitemrepository) 
        {
            cartitemrepository = _cartitemrepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(cartitemrepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetByUserId/{id}")]
        public IActionResult GetByUserId(int userid)
        {
            try
            {
                var data = cartitemrepository.GetByUserId(userid);
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

        [HttpGet("GetByProductId/{id}")]
        public IActionResult GetByProductId(int productid)
        {
            try
            {
                var data = cartitemrepository.GetByProductId(productid);
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
        public IActionResult Add(CartItemModel item)
        {
            try
            {
                return Ok(cartitemrepository.Add(item));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int userid, int productid)
        {
            try
            {
                cartitemrepository.Delete(userid, productid);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(CartItemModel item)
        {
            try
            {
                cartitemrepository.Update(item);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

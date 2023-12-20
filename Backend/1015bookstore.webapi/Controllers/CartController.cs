using _1015bookstore.application.Catalog.Carts;
using _1015bookstore.viewmodel.Catalog.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartservice;

        public CartController(ICartService cartservice) 
        {
            _cartservice = cartservice;
        }
        //http:localhost:port/api/cart/setcart
        [HttpGet("setcart")]
        public async Task<IActionResult> SetCart([FromQuery]ProductAdd productadd, Guid user_id) 
        {
            try
            {
                var affectedResult = await _cartservice.SetProductInCart(productadd, user_id);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/cart/removecart
        [HttpGet("removecart/{id}")]
        public async Task<IActionResult> RemoveCart(int id)
        {
            try
            {
                var affectedResult = await _cartservice.DeleteProductInCart(id);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/cart/getcart/{user_id}
        [HttpGet("getcart/{user_id}")]
        public async Task<IActionResult> GetCart(Guid user_id)
        {
            try
            {
                var data = await _cartservice.GetCardOfUser(user_id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/cart/updateamountcart/{id}/{amountadd}
        [HttpGet("updateamountcart/{id}/{amountadd}")]
        public async Task<IActionResult> UpdateAmountCart(int id, int amountadd)
        {
            try
            {
                await _cartservice.UpdateAmountCart(id, amountadd);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

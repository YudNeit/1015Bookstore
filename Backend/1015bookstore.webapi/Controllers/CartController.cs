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
        [HttpPut("setcart")]
        public async Task<IActionResult> SetCart([FromQuery]ProductAdd productadd, Guid user_id) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _cartservice.SetProductInCart(productadd, user_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/cart/removecart
        [HttpDelete("removecart/{id}")]
        public async Task<IActionResult> RemoveCart(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _cartservice.DeleteProductInCart(id);
                return StatusCode(response.CodeStatus, response.Message);
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
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _cartservice.GetCardOfUser(user_id);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/cart/updateamountcart/{id}/{amountadd}
        [HttpPut("updateamountcart/{id}/{amountadd}")]
        public async Task<IActionResult> UpdateAmountCart(int id, int amountadd)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _cartservice.UpdateAmountCart(id, amountadd);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

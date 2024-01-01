using _1015bookstore.application.Catalog.Carts;
using _1015bookstore.viewmodel.Catalog.Carts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService) 
        {
            _cartService = cartService;
        }
        //http:localhost:port/api/cart/set
        [HttpPost("set")]
        public async Task<IActionResult> Cart_SetProduct([FromBody]CartAddProduct product, [FromQuery][Required]Guid gUser_id) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _cartService.Cart_SetProduct(product, gUser_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/cart/delete
        [HttpDelete("delete/{iCart_id}")]
        public async Task<IActionResult> Cart_DeleteProduct([Required]int iCart_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _cartService.Cart_DeleteProduct(iCart_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/cart/get/{GUser_id}
        [HttpGet("get/{gUser_id}")]
        public async Task<IActionResult> Cart_GetCart([Required]Guid gUser_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _cartService.Cart_GetCart(gUser_id);

                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/cart/updateamount/{ICart_id}
        [HttpPatch("updateamount/{iCart_id}")]
        public async Task<IActionResult> Cart_UpdateAmount([Required]int iCart_id,[FromQuery][Required] int amountadd)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _cartService.Cart_UpdateAmount(iCart_id, amountadd);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

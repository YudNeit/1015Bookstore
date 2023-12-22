using _1015bookstore.application.Catalog.Orders;
using _1015bookstore.viewmodel.Catalog.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        //http:localhost:port/api/Order/buy
        [HttpPut("buy")]
        public async Task<IActionResult> CreateOrder([FromForm]OrderBuyRequest request)
        {
            try
            {
                var affectedrow = await _orderService.Buy(request);
                if (!affectedrow)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //http:localhost:port/api/Order
        [HttpPut]
        public async Task<IActionResult> CreateOrder([FromForm]OrderCreateRequest request)
        {
            try
            {
                var orderid = await _orderService.CreateOrder(request);
                if (orderid == 0)
                    return BadRequest();

                var order = await _orderService.GetById(orderid);
                return CreatedAtAction(nameof(GetById), new { id = orderid }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/Order/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _orderService.GetById(id);
                if (order == null)
                    return BadRequest("Cannot find order");
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

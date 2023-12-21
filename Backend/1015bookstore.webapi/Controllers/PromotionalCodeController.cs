using _1015bookstore.application.Catalog.PromotionalCodes;
using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PromotionalCodeController : ControllerBase
    {
        private readonly IPromotionalCodeService _promotionalCodeService;

        public PromotionalCodeController(IPromotionalCodeService promotionalCodeService)
        {
            _promotionalCodeService = promotionalCodeService;
        }
        //http:localhost:port/api/promotionalcode
        [HttpPost]
        public async Task<IActionResult> Create(PromotionalCodeCreateRequest request)
        {
            try
            {
                var promotionalCodeId = await _promotionalCodeService.CreatePromotionalCode(request);
                if (promotionalCodeId == 0)
                    return BadRequest();

                var code = await _promotionalCodeService.GetById(promotionalCodeId);
                return CreatedAtAction(nameof(GetById), new { id = promotionalCodeId }, code);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/promotionalcode/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var code = await _promotionalCodeService.GetById(id);
                if (code == null)
                    return BadRequest("Cannot find promotional code");
                return Ok(code);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/promotionalcode
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var code = await _promotionalCodeService.GetAll();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/promotionalcode/ABCDFWE
        [HttpGet("getbycode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {
                var promotionalcode = await _promotionalCodeService.GetByCode(code);
                if (promotionalcode == null)
                    return BadRequest("Cannot find promotional code");
                return Ok(promotionalcode);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/promotionalcode/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var affectedResult = await _promotionalCodeService.DeletePromotionalCode(id);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/promotionalcode/updateamount
        [HttpPut("updateamount")]
        public async Task<IActionResult> UpdateQuanity([FromQuery] int id, int updateamount)
        {
            try
            {
                await _promotionalCodeService.UpdataAmount(id, updateamount);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http://localhost:port/api/promotionalcode/updatetodate
        [HttpPut("updatetodate")]
        public async Task<IActionResult> UpdateToDate(int id,[FromBody]DateTime updatetodate)
        {
            try
            {
                await _promotionalCodeService.UpdataToDate(id, updatetodate);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //http:localhost:port/api/updatetodate
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] PromotionalCodeUpdateRequest request)
        {
            try
            {
                var affectedResult = await _promotionalCodeService.UpdatePromotionalCode(request);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

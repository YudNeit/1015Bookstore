using _1015bookstore.application.Catalog.PromotionalCodes;
using _1015bookstore.viewmodel.Catalog.PromotionalCodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> PromotionalCode_Create([FromBody] PromotionalCodeCreateRequest request, Guid? gCreator_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _promotionalCodeService.PromotionalCode_Create(request, gCreator_id);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/promotionalcode
        [HttpGet("checkcode")]
        public async Task<IActionResult> PromotionalCode_CheckCode([FromQuery][Required] string sPromotionalCode_code, [FromQuery][Required] Guid gUser_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var response = await _promotionalCodeService.PromotionalCode_CheckCode(sPromotionalCode_code, gUser_id);
                if (!response.Status)
                    return StatusCode(response.CodeStatus, response.Message);

                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/promotionalcode
        [HttpGet]
        public async Task<IActionResult> PromotionalCode_GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _promotionalCodeService.PromotionalCode_GetAll();
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/promotionalcode
        [HttpGet("{iPromotionalCode_id}")]
        public async Task<IActionResult> PromotionalCode_GetById(int iPromotionalCode_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _promotionalCodeService.PromotionalCode_GetById(iPromotionalCode_id);
                return StatusCode(response.CodeStatus, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/promotionalcode/1
        [HttpDelete("{IPromotionalCode_id}")]
        public async Task<IActionResult> PromotionalCode_Delete([Required]int iPromotionalCode_id, Guid? gUser_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _promotionalCodeService.PromotionalCode_Delete(iPromotionalCode_id, gUser_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/promotionalcode/updateamount
        [HttpPut("updateamount")]
        public async Task<IActionResult> PromotionalCode_UpdataAmount([FromQuery][Required] int iPromotionalCode_id, [Required] int updateamount, Guid? gUpdater_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _promotionalCodeService.PromotionalCode_UpdataAmount(iPromotionalCode_id, gUpdater_id, updateamount);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/promotionalcode/updatetodate
        [HttpPut("updatetodate")]
        public async Task<IActionResult> PromotionalCode_UpdataToDate([FromQuery][Required] int iPromotionalCode_id, [FromForm][Required]DateTime updatetodate, Guid? gUpdater_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _promotionalCodeService.PromotionalCode_UpdataToDate(iPromotionalCode_id, gUpdater_id, updatetodate);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http:localhost:port/api/updatetodate
        [HttpPut]
        public async Task<IActionResult> PromotionalCode_Update([FromBody] PromotionalCodeUpdateRequest request, Guid? gUpdater_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var response = await _promotionalCodeService.PromotionalCode_Update(request , gUpdater_id);
                return StatusCode(response.CodeStatus, response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

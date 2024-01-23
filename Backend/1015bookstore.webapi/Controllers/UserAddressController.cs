using _1015bookstore.application.Catalog.Reviews;
using _1015bookstore.application.System.UserAddresses;
using _1015bookstore.viewmodel.System.UserAddresses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;
        public UserAddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }
        [HttpGet()]
        public async Task<IActionResult> Address_GetById(int iAddress_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userAddressService.Address_GetById(iAddress_id);
                return StatusCode(result.CodeStatus, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{gUser_id}")]
        public async Task<IActionResult> Address_GetByUserId(Guid gUser_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userAddressService.Address_GetByUserId(gUser_id);
                return StatusCode(result.CodeStatus, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost()]
        public async Task<IActionResult> Address_Create(UserAddressRequestCreate request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userAddressService.Address_Create(request);
                return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete()]
        public async Task<IActionResult> Address_Delete(int iAddress_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userAddressService.Address_Delete(iAddress_id);
                return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut()]
        public async Task<IActionResult> Address_Update(UserAddressRequestUpdate request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userAddressService.Address_Update(request);
                return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("setdefault")]
        public async Task<IActionResult> Address_SetDefault(int iAddress_id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userAddressService.Address_SetDefault(iAddress_id);
                return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

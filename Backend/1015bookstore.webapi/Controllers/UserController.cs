using _1015bookstore.application.System.Users;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _1015bookstore.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.Authencate(request);
                if (!result.Status)
                {
                    return StatusCode(result.CodeStatus, result.Message);
                }
                return StatusCode(result.CodeStatus, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.Register(request);
                return StatusCode(result.CodeStatus, result.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("forgotpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody][Required(ErrorMessage = "Please enter your Email!")][EmailAddress(ErrorMessage = "The E-mail is wrong format!")]string email)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.ForgotPassword(email);

                if (!result.Status)
                {
                    return StatusCode(result.CodeStatus, result.Message);
                }
                return StatusCode(result.CodeStatus, result.Data);
            }    
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("confirmCodeforgotpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> CofirmCodeForgotPassword(ConfirmCodeFPRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.CofirmCodeForgotPassword(request);
                if (!result.Status)
                    return StatusCode(result.CodeStatus, result.Message);
                else
                    return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        
        [HttpPost("ChangePasswordForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePasswordForgotPassword(ChangePasswordFPRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.ChangePasswordForgotPassword(request);
                if (!result.Status)
                    return StatusCode(result.CodeStatus, result.Message);
                else
                    return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        
        [HttpPost("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.ChangePassword(request);
                if(!result.Status)
                    return StatusCode(result.CodeStatus, result.Message);
                else
                    return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        
        [HttpGet("{gUser_id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(Guid gUser_id)
        {
            try
            {
                var result = await _userService.User_GetById(gUser_id);
                if (!result.Status)
                {
                    return StatusCode(result.CodeStatus, result.Message);
                }
                return StatusCode(result.CodeStatus, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("updateinfor")]
        [Authorize]
        public async Task<IActionResult> User_UpdateInfor([FromForm] UserUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.User_UpdateInfor(request);
                if (!result.Status)
                    return StatusCode(result.CodeStatus, result.Message);
                else
                    return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/user/public-paging
        [HttpGet("admin-paging-keyword")]
        [Authorize]
        public async Task<IActionResult> User_GetUserByKeyWordPagingAdmin([FromQuery] GetUserByKeyWordPagingRequest request)
        {
            try
            {
                var pageResult = await _userService.User_GetUserByKeyWordPagingAdmin(request);
                return Ok(pageResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //http://localhost:port/api/user/createadmin
        [HttpPost("createadmin")]
        [Authorize]
        public async Task<IActionResult> User_CreateAdmin([FromBody] RegisterAdminRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _userService.User_CreateAdmin(request);
                return StatusCode(result.CodeStatus, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("admin-getall")]
        [Authorize]
        public async Task<IActionResult> User_GetAllAdmin()
        {
            try
            {
                var result = await _userService.User_GetAllAdmin();
                return StatusCode(result.CodeStatus, result.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

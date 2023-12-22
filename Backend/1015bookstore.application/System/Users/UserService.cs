using _1015bookstore.application.Helper;
using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _1015bookstore.application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;
        private readonly _1015DbContext _context;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration config, IEmailSender emailSender, _1015DbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _emailSender = emailSender;
            _context = context;
        }
        public async Task<LoginRespone> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.username);
            if (user == null) return null;

            var result = await _signInManager.PasswordSignInAsync(user, request.password, request.rememberme, true);
            if (!result.Succeeded) return null;

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.firstname),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddHours(3),signingCredentials: creds);

            return new LoginRespone
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                user_id = user.Id,
            };
        }

        public async Task<string> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new _1015Exception($"Can not find a emai: {email}");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            string code = CreateCode();

            var save = new CodeForgotPassword
            {
                user_id = user.Id,
                code = code,
                createdate = DateTime.Now,
                dateexpire = DateTime.Now.AddMinutes(3),
                token = token,
            };
            await _context.CodesForgotPassword.AddAsync(save);
            await _context.SaveChangesAsync();

            await _emailSender.SendEmailForgotPassword(email, code);
            return token;
        }

        private string CreateCode()
        {
            string code = "";

            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                int randomNumber = random.Next(10);
                stringBuilder.Append(randomNumber);
            }

            code = stringBuilder.ToString();

            return code;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user_old = await _userManager.FindByNameAsync(request.username);
            if (user_old != null)
                throw new _1015Exception("Username is existed");
            user_old = await _userManager.FindByEmailAsync(request.email);
            if (user_old != null)
                throw new _1015Exception("Email is existed");
            if (request.password != request.confirmpassword)
                throw new _1015Exception("The password and confirmation password do not match");
            var user = new User()
            {
                Email = request.email,
                firstname = request.firstname,
                lastname = request.lastname,
                UserName = request.username,
            };
            var result = await _userManager.CreateAsync(user, request.password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CofirmCodeForgotPassword(ConfirmCodeFPRequest request)
        {
            var code_db = await _context.CodesForgotPassword.Where(x => x.token == request.token).OrderByDescending(x => x.createdate).FirstOrDefaultAsync();

            if (code_db == null)
            {
                throw new _1015Exception("Token is wrong");
            }    

            if (code_db.code != request.code)
            {
                throw new _1015Exception("Code is wrong");
            }

            code_db.check = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangePasswordForgotPassword(ChangePasswordFPRequest request)
        {
            if (request.password != request.confirmpassword)
            {
                throw new _1015Exception("The password and confirmation password do not match");
            }
            var code_db = await _context.CodesForgotPassword.Where(x => x.token == request.token).OrderByDescending(x => x.createdate).FirstOrDefaultAsync();
            if (code_db == null)
            {
                throw new _1015Exception("Token is wrong");
            }
            if (!code_db.check)
            {
                throw new _1015Exception("Process is wrong, load page ...");
            }
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == code_db.user_id);
            var resetPassResult = await _userManager.ResetPasswordAsync(user, request.token, request.password);
            return resetPassResult.Succeeded;
        }
    
        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            if (request.confirmnewPassword != request.newPassword)
            {
                throw new _1015Exception("The password and confirmation password do not match");
            }
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.user_id);
            if (user == null)
            {
                throw new _1015Exception($"Can not find a user with id: {request.user_id}");
            }
            var resetPassResult = await _userManager.ChangePasswordAsync(user,request.oldPassword, request.newPassword);
            return resetPassResult.Succeeded;


        }
    }
}

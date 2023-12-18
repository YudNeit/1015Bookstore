﻿using _1015bookstore.data.Entities;
using _1015bookstore.viewmodel.System.Users;
using Microsoft.AspNetCore.Identity;
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

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<Role> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<string> Authencate(LoginRequest request)
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

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
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
    }
}
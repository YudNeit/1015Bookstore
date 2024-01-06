using _1015bookstore.application.Helper;
using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.utility.Exceptions;
using _1015bookstore.viewmodel.Catalog.Products;
using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _1015bookstore.application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;
        private readonly _1015DbContext _context;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config, IEmailSender emailSender, _1015DbContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _emailSender = emailSender;
            _context = context;
        }
        public async Task<ResponseService<LoginRespone>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.sUser_username);
            if (user == null) 
                return new ResponseService<LoginRespone>()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Wrong Username or Password!",
                };

            var result = await _signInManager.PasswordSignInAsync(user, request.sUser_password, true, true);
            if (!result.Succeeded) 
                return new ResponseService<LoginRespone>()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Wrong Username or Password!",
                };
            
            var query = from u in _context.Users
                        join r in _context.UserRoles on u.Id equals r.UserId
                        join r_ in _context.Roles on r.RoleId equals r_.Id
                        where u.Id == user.Id
                        select new { u,r,r_ };
            var role = await query.FirstOrDefaultAsync();

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.firstname),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("id",user.Id.ToString()),
                new Claim("Role",role.r_.Name),
                
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddHours(3),signingCredentials: creds);

           var loginRespone = new LoginRespone
           {
               sUser_tokenL = new JwtSecurityTokenHandler().WriteToken(token),
               gUser_id = user.Id,
           };

            return new ResponseService<LoginRespone>()
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = loginRespone
            };
        }

        public async Task<ResponseService<string>> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new ResponseService<string>()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find a emai: {email}",
                };


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

            return new ResponseService<string>()
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = token
            };
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

        public async Task<ResponseService> Register(RegisterRequest request)
        {
            var user_old = await _userManager.FindByNameAsync(request.sUser_username);
            if (user_old != null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "The Username is used for someone",
                };


            var check_email = await _userManager.FindByEmailAsync(request.sUser_email);
            if (check_email != null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "The Email is used for someone",
                };

            var user = new User()
            {
                Email = request.sUser_email,
                firstname = request.sUser_firstname,
                lastname = request.sUser_lastname,
                UserName = request.sUser_username,
            };
            var result = await _userManager.CreateAsync(user, request.sUser_password);

            await _context.UserRoles.AddAsync(new IdentityUserRole<Guid>
            {
                RoleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DA"),
                UserId = _userManager.FindByNameAsync(request.sUser_username).Result.Id
            });
            await _context.SaveChangesAsync();
            if (result.Succeeded)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = "Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = "Can not create account",
            };
        }

        public async Task<ResponseService> CofirmCodeForgotPassword(ConfirmCodeFPRequest request)
        {
            var code_db = await _context.CodesForgotPassword.Where(x => x.token == request.sUser_tokenFP).OrderByDescending(x => x.createdate).FirstOrDefaultAsync();

            if (code_db == null)
            {
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Token is wrong",
                };
            }    

            if (code_db.code != request.sUser_codeFP)
            {
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Code is wrong",
                };
            }

            code_db.check = true;
            await _context.SaveChangesAsync();

            return new ResponseService()
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
            };
        }

        public async Task<ResponseService> ChangePasswordForgotPassword(ChangePasswordFPRequest request)
        {
            var code_db = await _context.CodesForgotPassword.Where(x => x.token == request.sUser_tokenFP).OrderByDescending(x => x.createdate).FirstOrDefaultAsync();
            if (code_db == null)
            {
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Token is wrong",
                };
            }
            if (!code_db.check)
            {
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "Process is wrong",
                };
            }
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == code_db.user_id);
            var resetPassResult = await _userManager.ResetPasswordAsync(user, request.sUser_tokenFP, request.sUser_password);
            if (resetPassResult.Succeeded)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = "Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = "Can not change password",
            };
        }
    
        public async Task<ResponseService> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.gUser_id);
            if (user == null)
            {
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find a user with id: {request.gUser_id}",
                };
            }
            var resetPassResult = await _userManager.ChangePasswordAsync(user, request.sUser_oldPassword, request.sUser_newPassword);
            if (resetPassResult.Succeeded)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = "Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 400,
                Status = false,
                Message = "The old password is wrong!",
            };
        }

        public async Task<ResponseService<UserViewModel>> User_GetById(Guid id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return new ResponseService<UserViewModel>()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find a user with id: {id}",
                };
            }

            var query = from p in _context.UserRoles
                        join pa in _context.Roles on p.RoleId equals pa.Id
                        select new { p, pa};

            var data = await query.FirstOrDefaultAsync(x => x.p.UserId == user.Id);


            return new ResponseService<UserViewModel>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = new UserViewModel
                {
                    gUser_id = id,
                    sUser_firstname = user.firstname,
                    sUser_lastname = user.lastname,
                    dtUser_dob = user.dob,
                    bUser_sex = user.sex,
                    sUser_phonenumber = user.PhoneNumber,
                    sUser_email = user.Email,
                    sUser_username = user.UserName,
                    sUser_rolename = data == null ? null : data.pa.Name,
                }
            };
        }

        public async Task<ResponseService> User_UpdateInfor(UserUpdateRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.gUser_id);
            if (user == null)
            {
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = $"Can not find a user with id: {request.gUser_id}",
                };
            }

            user.firstname = request.sUser_firstname;
            user.lastname = request.sUser_lastname;
            user.dob = request.dtUser_dob;
            user.sex = request.bUser_sex;
            user.PhoneNumber = request.sUser_phonenumber;

            if (await _context.SaveChangesAsync() > 0)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = "Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = "Can not change information",
            };
        }

        public async Task<PagedResult<UserViewModel>> User_GetUserByKeyWordPagingAdmin(GetUserByKeyWordPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.sKeyword))
            {
                query = query.Where(x => x.UserName.Contains(request.sKeyword) || x.PhoneNumber.Contains(request.sKeyword));
            }
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageindex - 1) * request.pagesize).Take(request.pagesize)
            .Select(x => new UserViewModel()
            {
                gUser_id = x.Id,
                sUser_firstname = x.firstname,
                sUser_lastname = x.lastname,
                dtUser_dob = x.dob,
                bUser_sex = x.sex,
                sUser_phonenumber = x.PhoneNumber,
                sUser_email = x.Email,
                sUser_username = x.UserName
            }).ToListAsync();

            var pagedResult = new PagedResult<UserViewModel>()
            {
                totalRecords = totalRow,
                pageIndex = request.pageindex,
                pageSize = request.pagesize,
                items = data
            };
            return pagedResult;
        }

        public async Task<ResponseService> User_CreateAdmin(RegisterAdminRequest request)
        {
            var user_old = await _userManager.FindByNameAsync(request.sUser_username);
            if (user_old != null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "The Username is used for someone",
                };


            var check_email = await _userManager.FindByEmailAsync(request.sUser_email);
            if (check_email != null)
                return new ResponseService()
                {
                    CodeStatus = 400,
                    Status = false,
                    Message = "The Email is used for someone",
                };

            var user = new User()
            {
                Email = request.sUser_email,
                firstname = request.sUser_firstname,
                lastname = request.sUser_lastname,
                UserName = request.sUser_username,
                dob = request.dtUser_dob,
                sex = request.bUser_sex,
                PhoneNumber = request.sUser_phonenumber,
            };
            var result = await _userManager.CreateAsync(user, request.sUser_password);
            
            await _context.UserRoles.AddAsync(new IdentityUserRole<Guid>
            {
                RoleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                UserId = _userManager.FindByNameAsync(request.sUser_username).Result.Id
            });

            await _context.SaveChangesAsync();

            if (result.Succeeded)
            {
                return new ResponseService()
                {
                    CodeStatus = 200,
                    Status = true,
                    Message = "Success",
                };
            }
            return new ResponseService()
            {
                CodeStatus = 500,
                Status = false,
                Message = "Can not create account",
            };
        }

        public async Task<ResponseService<List<UserViewModel>>> User_GetAllAdmin()
        {
            var query = from p in _context.UserRoles
                        join pa in _context.Roles on p.RoleId equals pa.Id
                        select new { p, pa };

            var data = await _context.Users.Select(x => new UserViewModel
            {
                gUser_id = x.Id,
                sUser_firstname = x.firstname,
                sUser_lastname = x.lastname,
                dtUser_dob = x.dob,
                bUser_sex = x.sex,
                sUser_phonenumber = x.PhoneNumber,
                sUser_email = x.Email,
                sUser_username = x.UserName,
                sUser_rolename =  query.FirstOrDefault(a => a.p.UserId == x.Id).pa.Name
            }).ToListAsync();


            return new ResponseService<List<UserViewModel>>
            {
                CodeStatus = 200,
                Status = true,
                Message = "Success",
                Data = data
            };
        }
    }
}

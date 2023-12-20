using _1015bookstore.viewmodel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.application.System.Users
{
    public interface IUserService
    {
        Task<LoginRespone> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}

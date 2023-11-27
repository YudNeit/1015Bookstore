using _1015bookstore.web.Model;
using Microsoft.AspNetCore.Identity;

namespace _1015bookstore.web.Repository.IRepository
{
    public interface IAccountRepository
    {
        public Task<string> LoginAsync(LoginModel model);
        public Task<IdentityResult> RegisterAsync(RegisterModel model);
    }
}

using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Model;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace _1015bookstore.web.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public Task<string> LoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel model)
        {
            
        }
    }
}

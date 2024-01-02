using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using Newtonsoft.Json.Linq;

namespace _1015bookstore.websiteadmin.Service
{
    public interface IUserAPIClient
    {
        Task<ResponseAPI<JObject>> Authenticate(LoginRequest request);
        Task<ResponseAPI<List<UserViewModel>>> GetUser( string session);
        Task<ResponseAPI<string>> CraeteUserAdmin(RegisterAdminRequest request, string session);
        Task<ResponseAPI<UserViewModel>> GetUserById(string session, Guid user_id);
    }
}

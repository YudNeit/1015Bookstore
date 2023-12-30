using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;
using Newtonsoft.Json.Linq;

namespace _1015bookstore.websiteadmin.Service
{
    public interface IUserAPIClient
    {
        Task<ResponseAPI<JObject>> Authenticate(LoginRequest request);
    }
}

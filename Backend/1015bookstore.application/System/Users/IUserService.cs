using _1015bookstore.viewmodel.Comon;
using _1015bookstore.viewmodel.System.Users;

namespace _1015bookstore.application.System.Users
{
    public interface IUserService
    {
        Task<ResponseService<LoginRespone>> Authencate(LoginRequest request);
        Task<ResponseService> Register(RegisterRequest request);
        Task<ResponseService<string>> ForgotPassword(string email);
        Task<ResponseService> CofirmCodeForgotPassword(ConfirmCodeFPRequest request);
        Task<ResponseService> ChangePasswordForgotPassword(ChangePasswordFPRequest request);
        Task<ResponseService> ChangePassword(ChangePasswordRequest request);
        Task<ResponseService<UserViewModel>> GetUserById(Guid id);
        Task<ResponseService> UpdateInforUser(UserUpdateRequest request);
    }
}

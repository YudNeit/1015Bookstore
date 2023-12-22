using _1015bookstore.viewmodel.System.Users;

namespace _1015bookstore.application.System.Users
{
    public interface IUserService
    {
        Task<LoginRespone> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        Task<string> ForgotPassword(string email);
        Task<bool> CofirmCodeForgotPassword(ConfirmCodeFPRequest request);
        Task<bool> ChangePasswordForgotPassword(ChangePasswordFPRequest request);
    }
}

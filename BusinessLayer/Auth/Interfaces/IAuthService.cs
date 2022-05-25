using BusinessLayer.Auth.Models;
using BusinessLayer.Utilities.Results;

namespace BusinessLayer.Auth.Interfaces
{
    public interface IAuthService
    {
        Result Register(NewAccountForm accountForm);
        Result Login(LoginForm loginForm);
    }
}

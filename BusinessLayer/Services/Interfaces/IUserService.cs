using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Result AddUser(User user);
        Result DeleteUser(int userId);
        Result UpdateUser(User user);
        Result IsUserEmailExist(string email);
        DataResult<int> GetUserIdByEmail(string email);
        DataResult<List<User>> GetAllUserType();
        DataResult<User> GetUserById(int userId);
        Result IsPasswordCorrect(string email, string password);
    }
}

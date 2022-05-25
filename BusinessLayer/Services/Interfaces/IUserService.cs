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
        DataResult<int> GetUserIdByEmail(string Email);
        DataResult<List<User>> GetAllUserType();
        DataResult<User> GetUserTypeById(int userId);
    }
}

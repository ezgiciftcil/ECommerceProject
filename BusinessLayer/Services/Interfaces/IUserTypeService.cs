using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserTypeService
    {
        Result AddUserType(UserType userType);
        Result DeleteUserTpye(UserType userType);
        Result UpdateUserType(UserType userType);
        DataResult<List<UserType>> GetAllUserType();
        DataResult<UserType> GetUserTypeById(int userTypeId);
    }
}

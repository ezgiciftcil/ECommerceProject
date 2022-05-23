using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class UserTypeService:IUserTypeService
    {
        private readonly IUserTypeRepository userTypeRepository;
        public UserTypeService(IUserTypeRepository _userTypeRepository)
        {
            userTypeRepository = _userTypeRepository;
        }

        public Result AddUserType(UserType userType)
        {
            if(string.IsNullOrWhiteSpace(userType.TypeName))
                return new Result(false, "User Type Name must be filled !") ;
            if (userType.TypeName.Length > 20)
                return new Result(false, " User Type Name can not be longer than 20 characters.");
            userTypeRepository.Add(userType);
            return new Result(true, "User Type is saved.");
           
        }

        public Result DeleteUserTpye(UserType userType)
        {
            userTypeRepository.Delete(userType);
            return new Result(true, "User Type is deleted.");

        }

        public DataResult<List<UserType>> GetAllUserType()
        {
            return new DataResult<List<UserType>>(userTypeRepository.GetAll(), true, "All User Types are listed.");
        }

        public DataResult<UserType> GetUserTypeById(int userTypeId)
        {
            return new DataResult<UserType>(userTypeRepository.GetById(userTypeId), true, "User Type is listed.");
        }

        public Result UpdateUserType(UserType userType)
        {
            userTypeRepository.Update(userType);
            return new Result(true, "User Type is updated.");
        }
    }
}

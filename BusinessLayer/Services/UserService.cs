using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public Result AddUser(User user)
        {
            user.CreatedDate = DateTime.Now;
            if (String.IsNullOrEmpty(user.Email))
                return new Result(false, "Please enter your email");
            if(String.IsNullOrEmpty(user.FirstName)||String.IsNullOrEmpty(user.LastName))
                return new Result(false, "Please enter your first or last name");
            if (user.Password.Length > 12 || user.Password.Length < 8)
                return new Result(false, "Your password must be at least 8 , at most 12 characters.");
            if (user.PhoneNumber.Length != 11)
                return new Result(false, "Please enter your phone number correctly.");
            userRepository.Add(user);
            return new Result(true, "User added.");
        }

        public Result DeleteUser(int userId)
        {
            var userToDelete = userRepository.GetById(userId);
            userRepository.Delete(userToDelete);
            return new Result(true, "User is deleted.");
        }

        public DataResult<List<User>> GetAllUserType()
        {
            return new DataResult<List<User>>(userRepository.GetAll(), true,"All users are listed.");
        }

        public DataResult<User> GetUserTypeById(int userId)
        {
            return new DataResult<User>(userRepository.GetById(userId), true, "User is listed.");
        }

        public Result UpdateUser(User user)
        {
            userRepository.Update(user);
            return new Result(true, "User is updated.");
        }
    }
}

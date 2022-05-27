using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IWishingListService wishingListService;
        private readonly ICartService cartService;
        public UserService(IUserRepository _userRepository, IWishingListService _wishingListService, ICartService _cartService)
        {
            userRepository = _userRepository;
            wishingListService = _wishingListService;
            cartService = _cartService;
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

        public DataResult<User> GetUserById(int userId)
        {
            return new DataResult<User>(userRepository.GetById(userId), true, "User is listed.");
        }

        public Result UpdateUser(User user)
        {
            userRepository.Update(user);
            return new Result(true, "User is updated.");
        }

        public Result IsUserEmailExist(string email)
        {
            var existResult= userRepository.GetAll().Any(user => user.Email==email);
            if (existResult)
            {
                return new Result(true, "An account already created with this email.");
            }
            return new Result(false, "There is no any account created with this email.");
        }

        public DataResult<int> GetUserIdByEmail(string email)
        {
            var userId = userRepository.GetUserIdByEmail(email);
            return new DataResult<int>(userId, !(userId==0));
        }

        public Result IsPasswordCorrect(string email, string password)
        {
            var isCorrect = userRepository.GetAll().Any(user => user.Email == email && user.Password== password);
            if (isCorrect)
                return new Result(true, "Password and Email address is correct.");
            return new Result(false, "The email or password is incorrect.");
        }

        public Result AddUserCartAndWishList(int userId)
        {
            var resultOfWishList = wishingListService.AddWishListForUser(userId);
            var resultOfCart = cartService.AddCartForUser(userId);
            if (resultOfWishList.Success && resultOfCart.Success)
                return new Result(true, "User Cart and Wishing Lists are created");
            return new Result(true, "Error Occured");
        }
    }
}

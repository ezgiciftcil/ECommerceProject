using BusinessLayer.Auth.Interfaces;
using BusinessLayer.Auth.Models;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using EntityLayer;

namespace BusinessLayer.Auth
{
    public class AuthService : IAuthService
    {
        IUserService userService;
        IAddressService addressService;
        public AuthService(IUserService _userService, IAddressService _addressService)
        {
            userService = _userService;
            addressService = _addressService;
        }
        public Result Login(LoginForm loginForm)
        {
            throw new System.NotImplementedException();
        }

        public Result Register(NewAccountForm accountForm)
        {
            if (string.IsNullOrEmpty(accountForm.Email))
                return new Result(false, "Email must be filled !");

            var isEmailExist = userService.IsUserEmailExist(accountForm.Email);
            if (isEmailExist.Success)
                return isEmailExist;

            if (accountForm.Password != accountForm.PasswordRepeat)
                return new Result(false, "Passwords are not matching !");

            var newUser = new User()
            {
                Email = accountForm.Email,
                FirstName = accountForm.FirstName,
                LastName = accountForm.LastName,
                Password = accountForm.Password,
                PhoneNumber = accountForm.PhoneNumber,
                UserTypeId = 1
            };

            var addUserResult = userService.AddUser(newUser);

            if(addUserResult.Success && accountForm.IsAddressWanted)
            {
                var findUserId = userService.GetUserIdByEmail(accountForm.Email);
                if (!findUserId.Success)
                    return new Result(false,"Error");

                var newAddress = new Address() {
                    AddressDescription = accountForm.AddressDesc,
                    CityId = accountForm.CityId,
                    Country = accountForm.Country,
                    PostCode = accountForm.PostalCode,
                    Street = accountForm.Street,
                    UserId = findUserId.Data,
                };
                var addAddressResult= addressService.AddAddress(newAddress);
                if (!addAddressResult.Success)
                    return addAddressResult;
            }
            return addUserResult;
        }
    }
}

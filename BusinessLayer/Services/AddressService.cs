using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        public AddressService(IAddressRepository _addressRepository)
        {
            addressRepository = _addressRepository;
        }
        public Result AddAddress(Address address)
        {
            address.Country = "Turkey";
            if (string.IsNullOrEmpty(address.AddressDescription))
                return new Result(false, "Please fill the description section.");
            if (string.IsNullOrEmpty(address.Street))
                return new Result(false, "Please enter your street information.");
            if (address.PostCode==0)
                return new Result(false, "Please enter your postal code.");
            if (address.CityId==0)
                return new Result(false, "Please select your city.");
            addressRepository.Add(address);
            return new Result(true, "Address is saved.");
        }

        public Result DeleteAddress(int addressId)
        {
            var addressToDelete=addressRepository.GetById(addressId);
            addressRepository.Delete(addressToDelete);
            return new Result(true, "Address is deleted.");
        }

        public DataResult<Address> GetAddressById(int addressId)
        {
            return new DataResult<Address>(addressRepository.GetById(addressId), true, "Address are listed.");
        }

        public DataResult<List<Address>> GetAllAddress()
        {
            return new DataResult<List<Address>>(addressRepository.GetAll(), true, "Addresses are listed.");
        }

        public DataResult<Address> GetUserDefaultAddress(int userId)
        {
            var isUserHasDefaultAddress = IsUserHasDefaultAddress(userId);
            if (isUserHasDefaultAddress.Data)
            {
                var address = addressRepository.GetAll().Where(e => e.UserId == userId).FirstOrDefault();
                return new DataResult<Address>(address, true, "Default address is founded.");
            }
            return new DataResult<Address>(null, false, "Default address can not be founded.");
        }

        public DataResult<bool> IsUserHasDefaultAddress(int userId)
        {
            var address = addressRepository.GetAll().Count(e => e.UserId == userId);
            var result = address > 0;
            return new DataResult<bool>(result, true);
        }

        public Result UpdateAddress(Address address)
        {
            addressRepository.Update(address);
            return new Result(true, "Address is updated.");
        }
    }
}

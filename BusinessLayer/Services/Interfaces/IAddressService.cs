using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IAddressService
    {
        Result AddAddress(Address address);
        Result DeleteAddress(int addressId);
        Result UpdateAddress(Address address);
        DataResult<List<Address>> GetAllAddress();
        DataResult<Address> GetAddressById(int addressId);
        DataResult<bool> IsUserHasDefaultAddress(int userId);
        DataResult<Address> GetUserDefaultAddress(int userId);
    }
}

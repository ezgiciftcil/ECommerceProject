using BusinessLayer.Utilities.Results;
using EntityLayer;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICartService
    {
        Result AddCartForUser(int userId);
        DataResult<Cart> GetCartByUserId(int userId);
    }
}

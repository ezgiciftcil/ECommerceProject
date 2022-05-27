using BusinessLayer.Utilities.Results;
using EntityLayer;

namespace BusinessLayer.Services.Interfaces
{
    public interface IWishingListService
    {
        Result AddWishListForUser(int userId);
        DataResult<WishingList> GetWishListByUserId(int userId);
        Result AddProductToWishList(int userId, int productId);
        Result DeleteProductFromWishList(int userId, int productId);
    }
}

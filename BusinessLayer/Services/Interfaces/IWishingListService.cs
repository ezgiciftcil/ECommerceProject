using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface IWishingListService
    {
        Result AddWishListForUser(int userId);
        DataResult<WishingList> GetWishListByUserId(int userId);
        Result AddProductToWishList(int userId, int productId);
        Result DeleteProductFromWishList(int userId, int productId);
        DataResult<List<Product>> GetAvailableWishListProducts(int userId);
        DataResult<bool> IsProductAlreadyAdded(int userId,int productId);
        Result AddProductToCart(int userId, int productId);
    }
}

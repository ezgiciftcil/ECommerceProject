using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICartService
    {
        Result AddCartForUser(int userId);
        DataResult<Cart> GetCartByUserId(int userId);
        Result AddProductToCart(int userId, int productId);
        Result RemoveProductFromCart(int userId, int productId);
        DataResult<List<Product>> GetAvailableCartProducts(int userId);
        DataResult<IDictionary<int, int>> GetProductQuantityInCart(List<Product> products);
        DataResult<decimal> ProductTotalPrice(int quantity, decimal price);
        DataResult<decimal> TotalPriceOfCart(List<decimal> productsPrice);
        DataResult<List<CartProduct>> GetCartProductsProductsToPage(int userId);
    }
}

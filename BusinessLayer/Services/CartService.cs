using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Linq;

namespace BusinessLayer.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        public CartService(ICartRepository _cartRepository)
        {
            cartRepository = _cartRepository;
        }
        public Result AddCartForUser(int userId)
        {
            var newCart = new Cart()
            {
                UserId = userId
            };
            cartRepository.Add(newCart);
            return new Result(true, "New cart is created for user.");
        }

        public DataResult<Cart> GetCartByUserId(int userId)
        {
            var cart = cartRepository.GetAll().Where(m => m.UserId == userId).FirstOrDefault();
            return new DataResult<Cart>(cart, true, "Cart is listed for userId");
        }
    }
}

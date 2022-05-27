using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class WishingListService : IWishingListService
    {
        private readonly IWishingListRepository wishingListRepository;
        private readonly IWishingListItemRepository listItemRepository;
        private readonly IProductService productService;
        private readonly ICartService cartService;
        public WishingListService(IWishingListRepository _wishingListRepository, IWishingListItemRepository _listItemRepository, IProductService _productService, ICartService _cartService)
        {
            wishingListRepository = _wishingListRepository;
            listItemRepository = _listItemRepository;
            productService = _productService;
            cartService = _cartService;
        }

        public Result AddProductToWishList(int userId, int productId)
        {
            var isProductAlreadyAdded = IsProductAlreadyAdded(userId, productId);
            if (isProductAlreadyAdded.Data)
                return new Result(false, isProductAlreadyAdded.Message);

            var isProductAvailable = productService.CheckProductAvailable(productId).Data;
            if (!isProductAvailable)
                return new Result(false, "Product is out of stock.");

            var wishList = GetWishListByUserId(userId).Data;
            var productToAdd = new WishingListItem()
            {
                ProductId = productId,
                WishingListId = wishList.WishingListId
            };
            listItemRepository.Add(productToAdd);
            return new Result(true, "Product added to your wishing list.");
        }

        public Result DeleteProductFromWishList(int userId, int productId)
        {
            var wishList = GetWishListByUserId(userId).Data;
            var itemToDelete= listItemRepository.GetAll().Where(m => m.ProductId==productId && m.WishingListId==wishList.WishingListId).FirstOrDefault();
            listItemRepository.Delete(itemToDelete);
            return new Result(true, "Product removed from your wishing list.");
        }


        public Result AddWishListForUser(int userId)
        {
            var newWishList = new WishingList()
            {
                UserId = userId
            };
            wishingListRepository.Add(newWishList);
            return new Result(true, "Wishing List created for user");
        }

        public DataResult<WishingList> GetWishListByUserId(int userId)
        {
            var wishingList = wishingListRepository.GetAll().Where(m => m.UserId == userId).FirstOrDefault();
            return new DataResult<WishingList>(wishingList, true, "Wishing List is listed for userId");
        }

        public DataResult<List<Product>> GetAvailableWishListProducts(int userId)
        {
            var wishList = GetWishListByUserId(userId).Data;
            var listItemsOfUser = listItemRepository.GetAll().Where(e => e.WishingListId == wishList.WishingListId);
            var products = new List<Product>();
            foreach (var item in listItemsOfUser)
            {
                var productId = item.ProductId;
                var isProductHaveStock = productService.CheckProductAvailable(productId).Data;
                
                if (isProductHaveStock)
                {
                    var productToAdd = productService.GetProductById(productId).Data;
                    products.Add(productToAdd);
                }
            }
            return new DataResult<List<Product>>(products, true, "Available Products of Wishing List are Listed");
        }

        public DataResult<bool> IsProductAlreadyAdded(int userId,int productId)
        {
            var wishList = GetWishListByUserId(userId).Data;
            var listItemsOfUser = listItemRepository.GetAll().Where(e => e.WishingListId == wishList.WishingListId);
            foreach (var item in listItemsOfUser)
            {
                if (item.ProductId == productId)
                {
                    return new DataResult<bool>(true, true, "Product is already in your wishing list.");
                }
            }
            return new DataResult<bool>(false, true, "Product is not in your wishing list.");
        }

        public Result AddProductToCart(int userId, int productId)
        {
            var isProductAvailable = productService.CheckProductAvailable(productId);
            if (!isProductAvailable.Success)
                return new Result(false, "Product is out of stock.");
            var addResult=cartService.AddProductToCart(userId, productId);
            return addResult;
        }
    }
}

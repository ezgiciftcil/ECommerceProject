using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Linq;

namespace BusinessLayer.Services
{
    public class WishingListService : IWishingListService
    {
        private readonly IWishingListRepository wishingListRepository;
        private readonly IWishingListItemRepository listItemRepository;
        private readonly IProductService productService;
        public WishingListService(IWishingListRepository _wishingListRepository, IWishingListItemRepository _listItemRepository, IProductService _productService)
        {
            wishingListRepository = _wishingListRepository;
            listItemRepository = _listItemRepository;
            productService = _productService;
        }

        public Result AddProductToWishList(int userId, int productId)
        {
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
    }
}

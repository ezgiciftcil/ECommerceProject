using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishingListService wishListService;
        private readonly ICategoryService categoryService;
        public WishListController(IWishingListService _wishListService, ICategoryService _categoryService)
        {
            wishListService = _wishListService;
            categoryService = _categoryService;
        }
        public IActionResult Index(bool isSucceed=true, string message=null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
                ViewBag.IsSucceed = isSucceed;
            }
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if(userId==0)
                return RedirectToAction("Index", "Login",new { Message="You need to login before looking your wish list."});
            var model = new WishListModel();
            model.Products = wishListService.GetAvailableWishListProducts(userId).Data;
            return View(model);
        }
        public IActionResult RemoveItemFromList(int productId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = $"You need to login before view this wish list page." });
            var result = wishListService.DeleteProductFromWishList(userId, productId);
            return RedirectToAction("Index", "WishList", new { isSucceed = result.Success, message = result.Message });
        }

        public IActionResult AddItemFromCategory(int productId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = $"You need to login before adding item your wish list." });
            var result = wishListService.AddProductToWishList(userId, productId);
            var category = categoryService.GetCategoryByProductId(productId).Data;
            return RedirectToAction("Index", "Product", new { categoryId = category.CategoryId, categoryName = category.CategoryName, isSucceed = result.Success, message = result.Message });
        }

        public IActionResult AddItemFromProductDetail(int productId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = $"You need to login before adding item your wish list." });
            var result = wishListService.AddProductToWishList(userId, productId);
            return RedirectToAction("Detail", "Product", new { productId=productId, isSucceed = result.Success, message = result.Message });
        }
    }
}

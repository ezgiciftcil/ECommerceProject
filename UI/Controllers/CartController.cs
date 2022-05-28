using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UI.Models;

namespace UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly ICategoryService categoryService;
        public CartController(ICartService _cartService, ICategoryService _categoryService)
        {
            cartService = _cartService;
            categoryService = _categoryService;
        }
        public IActionResult Index(bool isSucceed = true, string message = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
                ViewBag.IsSucceed = isSucceed;
            }
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = "You need to login before to look your cart." });

            var model = new CartModel();
            model.Products= cartService.GetCartProductsProductsToPage(userId).Data;
            var priceList = new List<decimal>();
            foreach (var product in model.Products)
            {
                priceList.Add(product.TotalPrice);
            }
            model.ShipmentPrice = 0;
            model.TotalAmount = cartService.TotalPriceOfCart(priceList).Data + model.ShipmentPrice;
            model.CartModelJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return View(model);
        }

        public IActionResult RemoveItemFromList(int productId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = $"You need to login before the see your shopping card." });
            var result = cartService.RemoveProductFromCart(userId, productId);
            return RedirectToAction("Index", "Cart", new { isSucceed = result.Success, message = result.Message });
        }

        public IActionResult AddItemFromCategory(int productId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = "You need to login before adding item to your shopping card." });
            var result = cartService.AddProductToCart(userId, productId);
            var category = categoryService.GetCategoryByProductId(productId).Data;
            return RedirectToAction("Index", "Product", new { categoryId = category.CategoryId, categoryName = category.CategoryName, isSucceed = result.Success, message = result.Message });
        }

        public IActionResult AddItemFromProductDetail(int productId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionService.SessionUserId));
            if (userId == 0)
                return RedirectToAction("Index", "Login", new { Message = "You need to login before adding item to your shopping card." });
            var result = cartService.AddProductToCart(userId, productId);
            return RedirectToAction("Detail", "Product", new { productId = productId, isSucceed = result.Success, message = result.Message });
        }
    }
}

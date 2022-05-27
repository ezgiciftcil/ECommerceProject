using BusinessLayer.Services.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ICategoryService categoryService;
        IProductService productService;
        IWishingListService wishingListService;
        public ProductController(ICategoryService _categoryService, IProductService _productService, IWishingListService _wishingListService)
        {
            categoryService = _categoryService;
            productService = _productService;
            wishingListService = _wishingListService;
        }
        public IActionResult Index(int categoryId, string categoryName, bool isSucceed=true, string message=null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
                ViewBag.IsSucceed = isSucceed;
            }
            var productsOfCategory = new ProductsOfCategoryModel();
            productsOfCategory.Categories = categoryService.GetAllCategories().Data;
            productsOfCategory.CategoryId = categoryId;
            productsOfCategory.CategoryName = categoryName;
            productsOfCategory.Products = productService.GetAvailableProductsByCategoryId(categoryId).Data;
            return View(productsOfCategory);
        }

        public IActionResult Detail(int productId, bool isSucceed = true, string message = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
                ViewBag.IsSucceed = isSucceed;
            }
            var productDetail = new ProductDetailModel();
            productDetail.Product=productService.GetProductById(productId).Data;
            return View(productDetail);
        }

    }
}

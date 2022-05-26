using BusinessLayer.Services.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ICategoryService categoryService;
        IProductService productService;
        public ProductController(ICategoryService _categoryService, IProductService _productService)
        {
            categoryService = _categoryService;
            productService = _productService;
        }
        public IActionResult Index(int categoryId, string categoryName)
        {
            var productsOfCategory = new ProductsOfCategoryModel();
            productsOfCategory.Categories = categoryService.GetAllCategories().Data;
            productsOfCategory.CategoryId = categoryId;
            productsOfCategory.CategoryName = categoryName;
            productsOfCategory.Products = productService.GetAvailableProductsByCategoryId(categoryId).Data;
            return View(productsOfCategory);
        }

        public IActionResult Detail(int productId)
        {
            var productDetail = new ProductDetailModel();
            productDetail.Product=productService.GetProductById(productId).Data;
            return View(productDetail);
        }
    }
}

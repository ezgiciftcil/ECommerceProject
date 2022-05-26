using BusinessLayer.Services.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ICategoryService categoryService;
        public ProductController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index(int categoryId, string categoryName)
        {
            var productsOfCategory = new ProductsOfCategoryModel();
            productsOfCategory.Categories = categoryService.GetAllCategories().Data;
            productsOfCategory.CategoryId = categoryId;
            productsOfCategory.CategoryName = categoryName;
            return View(productsOfCategory);
        }
    }
}

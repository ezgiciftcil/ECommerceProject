using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IProductService productService;
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository _categoryRepository, IProductService _productService)
        {
            categoryRepository = _categoryRepository;
            productService = _productService;
        }
        public DataResult<List<Category>> GetAllCategories()
        {
            return new DataResult<List<Category>>(categoryRepository.GetAll(), true, "All Categories are listed.");
        }

        public DataResult<IDictionary<int, int>> GetAllCategoriesTotalProductNumber()
        {
            var categories = GetAllCategories().Data;
            var categoryProductNumber= new Dictionary<int, int>();
            foreach (var category in categories)
            {
                var totalProductsOfCategory = productService.GetAllProductsByCategoryId(category.CategoryId).Data;
                var counter = 0;
                foreach (var product in totalProductsOfCategory)
                {
                    if (product.Stock != 0)
                        counter++;
                }
                categoryProductNumber.Add(category.CategoryId, counter);
            }
            return new DataResult<IDictionary<int, int>>(categoryProductNumber, true, "Products number of each category is listed.");
        }

       public DataResult<Category> GetCategoryByProductId(int productId)
        {
            var categoryId = productService.GetProductById(productId).Data.CategoryId;
            var category = categoryRepository.GetById(categoryId);
            return new DataResult<Category>(category, true, "Category is finded by product id");
        }
    }
}

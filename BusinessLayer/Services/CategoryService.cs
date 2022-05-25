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
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public DataResult<List<Category>> GetAllCategories()
        {
            return new DataResult<List<Category>>(categoryRepository.GetAll(), true, "All Categories are listed.");
        }

        public DataResult<IDictionary<string, int>> GetAllCategoriesTotalProductNumber()
        {
            throw new NotImplementedException();
        }
    }
}

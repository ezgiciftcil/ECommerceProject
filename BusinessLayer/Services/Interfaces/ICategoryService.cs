using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        DataResult<List<Category>> GetAllCategories();
        DataResult<IDictionary<int,int>> GetAllCategoriesTotalProductNumber();
    }
}

using BusinessLayer.Utilities.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProductService
    {
        DataResult<List<Product>> GetAllProducts();
        DataResult<List<Product>> GetAllProductsByCategoryId(int CategoryId);
        DataResult<int> GetProductStockById(int ProductId);
        DataResult<List<Product>> GetAvailableProductsByCategoryId(int CategoryId);
    }
}

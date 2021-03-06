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
        DataResult<Product> GetProductById(int ProductId);
        DataResult<bool> CheckProductAvailable(int ProductId);
        DataResult<bool> CheckProductQuantityIsOkForSale(int ProductId,int quantity);
        Result DecreaseProductStock(int stock, int productId);
    }
}

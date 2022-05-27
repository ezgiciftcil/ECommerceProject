using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;

        }
        public DataResult<List<Product>> GetAllProducts()
        {
            return new DataResult<List<Product>>(productRepository.GetAll(), true, "All products are listed.");
        }

        public DataResult<List<Product>> GetAllProductsByCategoryId(int CategoryId)
        {
            var productsOfCategory = productRepository.GetAll().Where(m => m.CategoryId == CategoryId).ToList();
            return new DataResult<List<Product>>(productsOfCategory, true, "All products of the category are listed");
        }

        public DataResult<List<Product>> GetAvailableProductsByCategoryId(int CategoryId)
        {
            var products = GetAllProductsByCategoryId(CategoryId).Data;
            var availableProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.Stock != 0)
                    availableProducts.Add(product);
            }
            return new DataResult<List<Product>>(availableProducts, true, "Available Products of Category are listed.");
        }

        public DataResult<int> GetProductStockById(int ProductId)
        {
            var stock = productRepository.GetById(ProductId);
            return new DataResult<int>(stock.Stock, true, "Stock number of this products are finded");
        }

        public DataResult<Product> GetProductById(int ProductId)
        {
            var product = productRepository.GetById(ProductId);
            return new DataResult<Product>(product, true, "Product is listed by product id.");
        }

        public DataResult<bool> CheckProductAvailable(int ProductId)
        {
            var stock = GetProductStockById(ProductId).Data;
            var result = stock == 0 ? false : true;
            return new DataResult<bool>(result, true);
        }

        public DataResult<bool> CheckProductQuantityIsOkForSale(int ProductId, int quantity)
        {
            var product = productRepository.GetById(ProductId);
            var result = product.Stock >= quantity ? true : false;
            return new DataResult<bool>(result, true, "Availabilty for sale is determined");
        }
    }
}

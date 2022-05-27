using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductService productService;
        private readonly ICartItemRepository cartItemRepository;
        public CartService(ICartRepository _cartRepository, IProductService _productService, ICartItemRepository _cartItemRepository)
        {
            cartRepository = _cartRepository;
            productService = _productService;
            cartItemRepository = _cartItemRepository;
        }
        public Result AddCartForUser(int userId)
        {
            var newCart = new Cart()
            {
                UserId = userId
            };
            cartRepository.Add(newCart);
            return new Result(true, "New cart is created for user.");
        }
        public DataResult<Cart> GetCartByUserId(int userId)
        {
            var cart = cartRepository.GetAll().Where(m => m.UserId == userId).FirstOrDefault();
            return new DataResult<Cart>(cart, true, "Cart is listed for userId");
        }
        public Result AddProductToCart(int userId, int productId)
        {
            var cart = GetCartByUserId(userId).Data;
            var itemToAdd = new CartItem()
            {
                AddedDate = DateTime.Now,
                CartId = cart.CartId,
                ProductId = productId
            };
            cartItemRepository.Add(itemToAdd);
            return new Result(true, "Product added to the card.");
        }

        public DataResult<List<Product>> GetAvailableCartProducts(int userId)
        {
            var cart = GetCartByUserId(userId).Data;
            var cartItems = cartItemRepository.GetAll().Where(e => e.CartId == cart.CartId);
            var products = new List<Product>();
            foreach (var item in cartItems)
            {
                var isAvailable = productService.CheckProductAvailable(item.ProductId).Data;
                if (!isAvailable)
                {
                    var deleteOutOfStockItem = RemoveProductFromCart(userId, item.ProductId);
                }
                else
                {
                    var product = productService.GetProductById(item.ProductId).Data;
                    products.Add(product);
                }
            }
            return new DataResult<List<Product>>(products,true,"Available products are listed.");
        }

        public DataResult<IDictionary<int, int>> GetProductQuantityInCart(List<Product> products)
        {
            var productQuantity = new Dictionary<int, int>();
            foreach (var product in products)
            {
                var quantity = products.Count(e => e.ProductId == product.ProductId);
                if (productQuantity.ContainsKey(product.ProductId))
                    continue;
                productQuantity.Add(product.ProductId, quantity);
            }
            return new DataResult<IDictionary<int, int>>(productQuantity, true, "Each products quantity are listed");
        }

       

        public DataResult<decimal> ProductTotalPrice(int quantity, decimal price)
        {
            var productTotalPrice = quantity * price;
            return new DataResult<decimal>(productTotalPrice, true);
        }

        public Result RemoveProductFromCart(int userId, int productId)
        {
            var cart = GetCartByUserId(userId).Data;
            var cartItem = cartItemRepository.GetAll().Where(e => e.CartId == e.CartId && e.ProductId == productId).FirstOrDefault();
            cartItemRepository.Delete(cartItem);
            return new Result(true, "Product is removed from the card.");
        }

        public DataResult<List<CartProduct>> GetCartProductsProductsToPage(int userId)
        {
            var availableProducts = GetAvailableCartProducts(userId).Data;
            var productQuantities = GetProductQuantityInCart(availableProducts).Data;
            var cartProducts = new List<CartProduct>();
            foreach (var entry in productQuantities)
            {
                var availableToSale = productService.CheckProductQuantityIsOkForSale(entry.Key, entry.Value).Data;
                if (!availableToSale)
                {
                    var removeProduct = RemoveProductFromCart(userId, entry.Key);
                    continue;
                }
                var product = productService.GetProductById(entry.Key).Data;
                var cartProduct = new CartProduct()
                {
                    ProductId = product.ProductId,
                    ProductName= product.ProductName,
                    ProductImgUrl = product.ImageUrl,
                    Quantity = entry.Value,
                    UnitPrice = productService.GetProductById(entry.Key).Data.Price,
                    TotalPrice = ProductTotalPrice(entry.Value, productService.GetProductById(entry.Key).Data.Price).Data
                };
                cartProducts.Add(cartProduct);
            }
            return new DataResult<List<CartProduct>>(cartProducts, true, "Cart Items are listed");
        }

        
        public DataResult<decimal> TotalPriceOfCart(List<decimal> productsPrice)
        {
            decimal sum = 0;
            foreach (var price in productsPrice)
            {
                sum += price;
            }
            return new DataResult<decimal>(sum, true);
        }
    }
}

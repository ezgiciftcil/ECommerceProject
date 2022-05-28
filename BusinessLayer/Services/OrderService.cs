using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderAddressRepository addressRepository;
        private readonly IOrderItemRepository itemRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICartService cartService;
        private readonly IStatusRepository statusRepository;
        public OrderService(IOrderAddressRepository _addressRepository, IOrderItemRepository _itemRepository, IOrderRepository _orderRepository, ICartService _cartService, IStatusRepository _statusRepository)
        {
            addressRepository = _addressRepository;
            itemRepository = _itemRepository;
            orderRepository = _orderRepository;
            cartService = _cartService;
            statusRepository = _statusRepository;
        }

        public DataResult<string> CreateGuidForOrder()
        {
            var orderGuid = Guid.NewGuid().ToString();
            return new DataResult<string>(orderGuid, true, "Guid are created for order.");
        }
        public Result CreateOrderAddress(string orderGuid, Address address)
        {
            if (string.IsNullOrEmpty(address.AddressDescription))
                return new Result(false, "Please enter address description.");
            if (string.IsNullOrEmpty(address.Country))
                return new Result(false, "Please enter country.");
            if (string.IsNullOrEmpty(address.Street))
                return new Result(false, "Please enter street.");
            if (address.CityId == 0)
                return new Result(false, "Please select city.");
            if (address.PostCode == 0)
                return new Result(false, "Please enter postal code.");

            var newAddress = new OrderAddress()
            {
                AddressDescription = address.AddressDescription,
                CityId = address.CityId,
                Country = address.Country,
                Street = address.Street,
                OrderGuid = orderGuid,
                PostCode = address.PostCode
            };
            addressRepository.Add(newAddress);
            return new Result(true, "Address is created for order");
        }
        public DataResult<OrderAddress> GetOrderAddressByOrderGuid(string orderGuid)
        {
            var guid = addressRepository.GetAll().Where(e => e.OrderGuid == orderGuid).FirstOrDefault();
            return new DataResult<OrderAddress>(guid, true);
        }
        public Result CreateNewOrderForUser(int userId, string guid, decimal totalAmount)
        {
            var orderAddress = GetOrderAddressByOrderGuid(guid).Data;
            var newOrder = new Order()
            {
                StatusId = 1,
                CreateDate = DateTime.Now,
                isPaymentSuceed = false,
                OrderGuid = guid,
                OrderAddressId = orderAddress.AddressId,
                TotalAmount = totalAmount,
                UpdatedDate = DateTime.Now,
                UserId = userId
            };
            orderRepository.Add(newOrder);
            return new Result(false, "New Order is created for user.");
        }
        public DataResult<Order> GetOrderByOrderGuid(string orderGuid)
        {
            var order = orderRepository.GetAll().Where(e => e.OrderGuid == orderGuid).FirstOrDefault();
            return new DataResult<Order>(order, true);
        }
        public Result CompleteOrder(int userId, List<CartProduct> products, Address address, decimal totalAmount)
        {
            var orderGuid = CreateGuidForOrder().Data;
            var createOrderAddress = CreateOrderAddress(orderGuid, address);
            if (!createOrderAddress.Success)
                return createOrderAddress;
            var createNewOrder = CreateNewOrderForUser(userId, orderGuid, totalAmount);
            var createdOrder = GetOrderByOrderGuid(orderGuid);
            var addProductsToOrder = AddProductToOrder(products, createdOrder.Data.OrderId);
            //Purchase is successfull.
            var deleteProductsFromCard = cartService.RemovePurchasedProductsFromCart(products,userId);
            return new Result(true, "Order is successfully created.");
        }
        public Result AddProductToOrder(List<CartProduct> products, int orderId)
        {
            foreach (var product in products)
            {
                var item = new OrderItem()
                {
                    Amount = product.TotalPrice,
                    Quantity = product.Quantity,
                    OrderId = orderId,
                };
                itemRepository.Add(item);
            }
            return new Result(true, "Products added to the order.");
        }

        public DataResult<List<UserOrder>> GetAllUserOrderToPage(int userId)
        {
            var orders = GetAllUserOrder(userId).Data;
            var pageList = new List<UserOrder>();
            foreach (var order in orders)
            {
                var status= statusRepository.GetById(order.StatusId);
                var pageItem = new UserOrder(order, status);
                pageList.Add(pageItem);
            }
            return new DataResult<List<UserOrder>>(pageList, true);
        }

        public DataResult<List<Order>> GetAllUserOrder(int userId)
        {
            var orders = orderRepository.GetAll().Where(e => e.UserId == userId).ToList();
            return new DataResult<List<Order>>(orders, true);
        }
    }
}

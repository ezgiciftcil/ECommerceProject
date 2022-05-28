using BusinessLayer.Utilities.Results;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IOrderService
    {
        DataResult<string> CreateGuidForOrder();
        Result CreateOrderAddress(string orderGuid, Address address);
        DataResult<OrderAddress> GetOrderAddressByOrderGuid(string orderGuid);
        Result CompleteOrder(int userId, List<CartProduct> products, Address address, decimal totalAmount);
        Result CreateNewOrderForUser(int userId, string guid,decimal totalAmount);
        DataResult<Order> GetOrderByOrderGuid(string orderGuid);
        Result AddProductToOrder(List<CartProduct> products,int orderId);
        DataResult<List<UserOrder>> GetAllUserOrderToPage(int userId);
        DataResult<List<Order>> GetAllUserOrder(int userId);
    }
}

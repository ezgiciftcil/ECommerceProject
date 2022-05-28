using System;
using System.Collections.Generic;

namespace EntityLayer
{
    public class Order : IEntity
    {
        public Order()
        {
            if (OrderItems == null)
                OrderItems = new List<OrderItem>();
        }
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool isPaymentSuceed { get; set; }
        public string OrderGuid { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int StatusId { get; set; }
        public OrderStatus Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrderAddressId { get; set; }
        public OrderAddress OrderAddress { get; set; }
        
    }
}

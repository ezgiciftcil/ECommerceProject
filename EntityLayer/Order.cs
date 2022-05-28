﻿using System;
using System.Collections.Generic;

namespace EntityLayer
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
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

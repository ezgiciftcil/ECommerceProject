using System.Collections.Generic;

namespace EntityLayer
{
    public class OrderStatus:IEntity
    {
        public OrderStatus()
        {
            if (Orders == null)
                Orders = new List<Order>();
        }
        public int StatusId { get; set; }
        public string StatusDesc { get; set; }
        public List<Order> Orders { get; set; }
    }
}

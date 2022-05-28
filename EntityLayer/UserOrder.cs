using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserOrder
    {
        public UserOrder(Order order,OrderStatus status)
        {
            Order = order;
            Status = status;
        }
        public Order Order { get; set; }
        public OrderStatus Status { get; set; }

    }
}

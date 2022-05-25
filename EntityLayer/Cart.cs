using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Cart : IEntity
    {
        public Cart()
        {
            if (CartItems == null)
                CartItems = new List<CartItem>();
        }
        public int CartId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems {get; set;}
    }
}

using EntityLayer;
using System.Collections.Generic;

namespace UI.Models
{
    public class CartModel
    {
        public List<CartProduct> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ShipmentPrice {get; set;}
    }
}

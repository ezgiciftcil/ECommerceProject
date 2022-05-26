using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Product:IEntity
    {
        public Product()
        {
            if (Discounts == null)
                Discounts = new List<Discount>();
            if (CartItems == null)
                CartItems = new List<CartItem>();
        }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}

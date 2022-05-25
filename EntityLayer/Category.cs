using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Category:IEntity
    {
        public Category()
        {
            if (Products == null)
                Products = new List<Product>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}

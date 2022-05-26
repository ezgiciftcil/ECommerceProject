using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ProductsOfCategoryModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

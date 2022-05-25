using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Context context = new Context();
        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}

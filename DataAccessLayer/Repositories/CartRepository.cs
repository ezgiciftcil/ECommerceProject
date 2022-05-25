using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CartRepository : ICartRepository
    {
        private Context context= new Context();
        public void Add(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        public void Delete(Cart cart)
        {
            context.Carts.Remove(cart);
            context.SaveChanges();
        }

        public List<Cart> GetAll()
        {
            return context.Carts.ToList();
        }

        public Cart GetById(int id)
        {
            return context.Carts.Find(id);
        }

        public void Update(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }
    }
}

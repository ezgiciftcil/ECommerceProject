using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private Context context = new Context();
        public void Add(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
            context.SaveChanges();
        }

        public void Delete(CartItem cartItem)
        {
            context.CartItems.Remove(cartItem);
            context.SaveChanges();
        }

        public List<CartItem> GetAll()
        {
            return context.CartItems.ToList();
        }

        public CartItem GetById(int id)
        {
            return context.CartItems.Find(id);
        }

        public void Update(CartItem cartItem)
        {
            context.CartItems.Update(cartItem);
            context.SaveChanges();
        }
    }
}

using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private Context context = new Context();
        public void Add(Order entity)
        {
            context.Orders.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            context.Orders.Remove(entity);
            context.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return context.Orders.Find(id);
        }

        public void Update(Order entity)
        {
            context.Orders.Update(entity);
            context.SaveChanges();
        }
    }
}

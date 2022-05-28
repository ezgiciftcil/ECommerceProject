using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private Context context = new Context();
        public void Add(OrderItem entity)
        {
            context.OrderItems.Add(entity);
            context.SaveChanges();
        }

        public void Delete(OrderItem entity)
        {
            context.OrderItems.Remove(entity);
            context.SaveChanges();
        }

        public List<OrderItem> GetAll()
        {
            return context.OrderItems.ToList();
        }

        public OrderItem GetById(int id)
        {
            return context.OrderItems.Find(id);
        }

        public void Update(OrderItem entity)
        {
            context.OrderItems.Update(entity);
            context.SaveChanges();
        }
    }
}

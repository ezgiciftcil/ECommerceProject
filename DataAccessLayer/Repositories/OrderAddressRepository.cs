using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class OrderAddressRepository : IOrderAddressRepository
    {
        private Context context = new Context();
        public void Add(OrderAddress entity)
        {
            context.OrderAddresses.Add(entity);
            context.SaveChanges();
        }

        public void Delete(OrderAddress entity)
        {
            context.OrderAddresses.Remove(entity);
            context.SaveChanges();
        }

        public List<OrderAddress> GetAll()
        {
            return context.OrderAddresses.ToList();
        }

        public OrderAddress GetById(int id)
        {
            return context.OrderAddresses.Find(id);
        }

        public void Update(OrderAddress entity)
        {
            context.OrderAddresses.Update(entity);
            context.SaveChanges();
        }
    }
}

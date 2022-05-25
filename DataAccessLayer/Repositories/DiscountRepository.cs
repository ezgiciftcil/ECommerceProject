using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private Context context = new Context();
        public void Add(Discount discount)
        {
            context.Discounts.Add(discount);
            context.SaveChanges();
        }

        public void Delete(Discount discount)
        {
            context.Discounts.Remove(discount);
            context.SaveChanges();
        }

        public List<Discount> GetAll()
        {
            return context.Discounts.ToList();
        }

        public Discount GetById(int id)
        {
            return context.Discounts.Find(id);
        }

        public void Update(Discount discount)
        {
            context.Discounts.Add(discount);
            context.SaveChanges();
        }
    }
}

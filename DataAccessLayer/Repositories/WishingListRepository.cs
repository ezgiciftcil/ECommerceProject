using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WishingListRepository : IWishingListRepository
    {
        private Context context = new Context();
        public void Add(WishingList wishingList)
        {
            context.WishingLists.Add(wishingList);
            context.SaveChanges();
        }

        public void Delete(WishingList wishingList)
        {
            context.WishingLists.Remove(wishingList);
            context.SaveChanges();
        }

        public List<WishingList> GetAll()
        {
            return context.WishingLists.ToList();
        }

        public WishingList GetById(int id)
        {
            return context.WishingLists.Find(id);
        }

        public void Update(WishingList wishingList)
        {
            context.WishingLists.Update(wishingList);
            context.SaveChanges();
        }
    }
}

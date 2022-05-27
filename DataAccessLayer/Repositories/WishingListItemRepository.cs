using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WishingListItemRepository : IWishingListItemRepository
    {
        private Context context = new Context();
        public void Add(WishingListItem wishingListItem)
        {
            context.WishingListItems.Add(wishingListItem);
            context.SaveChanges();
        }

        public void Delete(WishingListItem wishingListItem)
        {
            context.WishingListItems.Remove(wishingListItem);
            context.SaveChanges();
        }

        public List<WishingListItem> GetAll()
        {
            return context.WishingListItems.ToList();
        }

        public WishingListItem GetById(int id)
        {
            return context.WishingListItems.Find(id);
        }

        public void Update(WishingListItem wishingListItem)
        {
            context.WishingListItems.Update(wishingListItem);
            context.SaveChanges();
        }
    }
}

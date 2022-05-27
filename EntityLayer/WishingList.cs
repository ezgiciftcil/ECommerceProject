using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class WishingList:IEntity
    {
        public WishingList()
        {
            if (WishingListItems == null)
                WishingListItems = new List<WishingListItem>();
        }
        public int WishingListId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<WishingListItem> WishingListItems { get; set; }

    }
}

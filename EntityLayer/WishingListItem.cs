namespace EntityLayer
{
    public class WishingListItem : IEntity
    {
        public int WishingListItemId {get; set;}
        public int WishingListId { get; set; }
        public WishingList WishingList { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

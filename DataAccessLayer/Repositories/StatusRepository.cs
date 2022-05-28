using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;

namespace DataAccessLayer.Repositories
{
    public class StatusRepository:IStatusRepository
    {
        private Context context=new Context();
        public OrderStatus GetById(int statusId)
        {
            return context.OrderStatuses.Find(statusId);
        }
    }
}

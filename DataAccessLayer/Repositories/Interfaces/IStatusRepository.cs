using EntityLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        OrderStatus GetById(int statusId);
    }
}

using EntityLayer;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        int GetUserIdByEmail(string Email);
    }
}

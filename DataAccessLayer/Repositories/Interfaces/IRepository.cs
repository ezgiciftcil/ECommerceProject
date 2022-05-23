using EntityLayer;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRepository<T> where T:IEntity
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}

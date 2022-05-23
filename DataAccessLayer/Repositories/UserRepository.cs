using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Context context = new Context();
        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public void Update(User user)
        {
            context.Update(user);
            context.SaveChanges();
        }
    }
}

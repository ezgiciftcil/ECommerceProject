using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private Context context = new Context();
        public void Add(UserType userType)
        {
            context.UserTypes.Add(userType);
            context.SaveChanges();
        }

        public void Delete(UserType userType)
        {
            context.UserTypes.Remove(userType);
            context.SaveChanges();
        }

        public List<UserType> GetAll()
        {
            return context.UserTypes.ToList();
        }

        public UserType GetById(int id)
        {
            return context.UserTypes.Find(id);
        }

        public void Update(UserType userType)
        {
            context.UserTypes.Update(userType);
            context.SaveChanges();
        }
    }
}

using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private Context context = new Context();
        public void Add(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
        }

        public void Delete(Address address)
        {
            context.Addresses.Remove(address);
            context.SaveChanges();
        }

        public List<Address> GetAll()
        {
            return context.Addresses.ToList();
        }

        public Address GetById(int id)
        {
            return context.Addresses.Find(id);
        }

        public void Update(Address address)
        {
            context.Addresses.Update(address);
            context.SaveChanges();
        }
    }
}

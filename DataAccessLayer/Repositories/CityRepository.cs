using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class CityRepository:ICityRepository
    {
        private Context context = new Context();

        public List<City> GetAllCities()
        {
            return context.Cities.ToList();
        }
    }
}

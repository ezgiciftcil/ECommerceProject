using EntityLayer;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ICityRepository
    {
        List<City> GetAllCities();
    }
}

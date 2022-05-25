using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities.Results;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;
        public CityService(ICityRepository _cityRepository)
        {
            cityRepository = _cityRepository;
        }
        public DataResult<List<City>> GetAllCities()
        {
            return new DataResult<List<City>>(cityRepository.GetAllCities(), true, "Cities are listed");
        }
    }
}

using BusinessLayer.Utilities.Results;
using EntityLayer;
using System.Collections.Generic;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICityService
    {
        DataResult<List<City>> GetAllCities();
    }
}

using Domain.Entities;
using System.Collections.Generic;

namespace Infra.Repository.Interface
{
    public interface ILocationRepository
    {
        List<Country> GetCountries();
        List<State> GetStates(int IdCountry);
        List<City> GetCities(int IdState);
    }
}

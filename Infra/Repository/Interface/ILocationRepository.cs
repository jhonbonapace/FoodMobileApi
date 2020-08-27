using Domain.Entities;
using System.Collections.Generic;

namespace Infra.Repository.Interface
{
    public interface ILocationRepository
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<State> GetStates(int IdCountry);
        IEnumerable<City> GetCities(int IdState);
    }
}

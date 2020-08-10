using Domain.Entities.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Interface
{
    public interface ILocationRepository
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<State> GetStates(int IdCountry);
        IEnumerable<City> GetCities(int IdState);
    }
}

using Domain.Entities.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface ILocationService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<State> GetStates(int IdCountry);
        IEnumerable<City> GetCities(int IdState);
    }
}

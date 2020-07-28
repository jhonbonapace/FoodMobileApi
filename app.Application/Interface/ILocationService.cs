using Application.DTO;
using Domain.Entities.Location;
using System.Collections.Generic;

namespace Application.Interface
{
    public interface ILocationService
    {
        ResponseModel<IEnumerable<Country>> GetCountries();
        ResponseModel<IEnumerable<State>> GetStates(int IdCountry);
        ResponseModel<IEnumerable<City>> GetCities(int IdState);
    }
}

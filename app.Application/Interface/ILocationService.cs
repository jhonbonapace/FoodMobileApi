using Application.DTO;
using Application.DTO.Mapbox;
using Domain.Entities.Location;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILocationService
    {
        Task<ResponseModel<MapboxPlacesDTO>> SearchLocation(string location);
        ResponseModel<IEnumerable<Country>> GetCountries();
        ResponseModel<IEnumerable<State>> GetStates(int IdCountry);
        ResponseModel<IEnumerable<City>> GetCities(int IdState);
    }
}

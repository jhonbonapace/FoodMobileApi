using Application.DTO;
using Application.DTO.Mapbox;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILocationService
    {
        Task<ResponseModel<MapboxPlacesDTO>> SearchLocation(string location);
        ResponseModel<List<Country>> GetCountries();
        ResponseModel<List<State>> GetStates(int IdCountry);
        ResponseModel<List<City>> GetCities(int IdState);
    }
}

using Application.Interface;
using Domain.Entities.Location;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class LocationService: ILocationService
    {
        private ILocationRepository _locationRepository;

        public LocationService(DatabaseContext context)
        {
            _locationRepository = new LocationRespository(context);
        }

        public IEnumerable<Country> GetCountries()
        {
            try
            {
                return _locationRepository.GetCountries();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<State> GetStates(int IdCountry)
        {
            try
            {
                return _locationRepository.GetStates(IdCountry);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IEnumerable<City> GetCities(int IdState)
        {
            try
            {
                return _locationRepository.GetCities(IdState);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

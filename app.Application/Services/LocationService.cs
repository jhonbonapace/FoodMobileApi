using Application.DTO;
using Application.Interface;
using Domain.Entities.Location;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class LocationService : ILocationService
    {
        private ILocationRepository _locationRepository;

        public LocationService(DatabaseContext context)
        {
            _locationRepository = new LocationRespository(context);
        }

        public ResponseModel<IEnumerable<Country>> GetCountries()
        {
            ResponseModel<IEnumerable<Country>> model = new ResponseModel<IEnumerable<Country>>();

            try
            {
                model.Response.Data = _locationRepository.GetCountries();

                model.Response.Success = true;

            }
            catch (Exception)
            {
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<IEnumerable<State>> GetStates(int IdCountry)
        {
            ResponseModel<IEnumerable<State>> model = new ResponseModel<IEnumerable<State>>();

            try
            {
                model.Response.Data = _locationRepository.GetStates(IdCountry);

                model.Response.Success = true;

            }
            catch (Exception)
            {
                model.Response.Success = false;
            }

            return model;
        }
        public ResponseModel<IEnumerable<City>> GetCities(int IdState)
        {
            ResponseModel<IEnumerable<City>> model = new ResponseModel<IEnumerable<City>>();

            try
            {
                model.Response.Data = _locationRepository.GetCities(IdState);

                model.Response.Success = true;

            }
            catch (Exception)
            {
                model.Response.Success = false;
            }

            return model;
        }
    }
}

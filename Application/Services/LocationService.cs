using Application.DTO;
using Application.DTO.Mapbox;
using Application.Interface;
using CrossCutting.Extensions;
using CrossCutting.Util;
using Domain.Entities;
using Domain.Helpers;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LocationService : ILocationService
    {
        Serilog.Core.Logger _logger;

        private ILocationRepository _locationRepository;
        private readonly MapBoxSettings _mapboxSettings;
        private static HttpClient Client = new HttpClient();


        public LocationService(DatabaseContext context, MapBoxSettings mapBoxSettings)
        {
            LoggerExtension logger = new LoggerExtension();
            _logger = logger.CreateLogger();
            _mapboxSettings = mapBoxSettings;
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
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<IEnumerable<State>> GetStates([FromQuery] int IdCountry)
        {
            ResponseModel<IEnumerable<State>> model = new ResponseModel<IEnumerable<State>>();

            try
            {
                model.Response.Data = _locationRepository.GetStates(IdCountry);

                model.Response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }
        public ResponseModel<IEnumerable<City>> GetCities([FromQuery] int IdState)
        {
            ResponseModel<IEnumerable<City>> model = new ResponseModel<IEnumerable<City>>();

            try
            {
                model.Response.Data = _locationRepository.GetCities(IdState);

                model.Response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }

        public async Task<ResponseModel<MapboxPlacesDTO>> SearchLocation(string location)
        {
            ResponseModel<MapboxPlacesDTO> model = new ResponseModel<MapboxPlacesDTO>();

            try
            {
                Uri enpoint = new Uri($"{_mapboxSettings.Endpoint}{location}.json?access_token={_mapboxSettings.Access_token}&autocomplete={_mapboxSettings.Autocomplete}&country={_mapboxSettings.Country}&limit={_mapboxSettings.Limit}");

                var result = await Client.GetAsync(enpoint);
                var response = result.Content.ReadAsStringAsync().Result;

                model.Response.Data = Serializer.Deserialize<MapboxPlacesDTO>(response);

                model.Response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }
    }
}

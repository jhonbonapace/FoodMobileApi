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

        public ResponseModel<List<Country>> GetCountries()
        {
            ResponseModel<List<Country>> model = new ResponseModel<List<Country>>();

            try
            {
                model.Data = _locationRepository.GetCountries();

                model.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
            }

            return model;
        }

        public ResponseModel<List<State>> GetStates([FromQuery] int IdCountry)
        {
            ResponseModel<List<State>> model = new ResponseModel<List<State>>();

            try
            {
                model.Data = _locationRepository.GetStates(IdCountry);

                model.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
            }

            return model;
        }
        public ResponseModel<List<City>> GetCities([FromQuery] int IdState)
        {
            ResponseModel<List<City>> model = new ResponseModel<List<City>>();

            try
            {
                model.Data = _locationRepository.GetCities(IdState);

                model.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
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

                model.Data = Serializer.Deserialize<MapboxPlacesDTO>(response);

                model.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
            }

            return model;
        }
    }
}

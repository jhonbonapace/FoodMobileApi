using Application.DTO;
using Application.DTO.Mapbox;
using CrossCutting.Util;
using Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace AppTest
{
    class Location
    {
        private static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:44368/Location/") };

        [Test]
        public async Task GetCountries()
        {

            const string route = "Countries/List";

            var json = await GetResponse(route);

            var response = Serializer.Deserialize<ResponseModel<List<Country>>>(json);

            Assert.IsTrue(response.Success);

            Assert.NotNull(response.Data);
            Assert.IsTrue(response.Data.Count > 0);
        }

        [Test]
        public async Task GetStates()
        {
            const string route = "State/List";

            var json = await GetResponse(route);

            var response = Serializer.Deserialize<ResponseModel<List<State>>>(json);

            Assert.IsTrue(response.Success);

            Assert.NotNull(response.Data);
            Assert.IsTrue(response.Data.Count > 0);
        }

        [Test]
        public async Task GetCities()
        {

            int IdState = 23; // RS

            const string route = "City/List/";

            var json = await GetResponse(route + IdState);

            var response = Serializer.Deserialize<ResponseModel<List<City>>>(json);

            Assert.IsTrue(response.Success);

            Assert.NotNull(response.Data);
            Assert.IsTrue(response.Data.Count > 0);
        }

        [Test]
        public async Task GetLocation()
        {
            string location = "Porto Alegre";

            string route = $"Search?location={location}";

            var json = await GetResponse(route);

            var response = Serializer.Deserialize<ResponseModel<MapboxPlacesDTO>>(json);

            Assert.IsTrue(response.Success);

            Assert.NotNull(response.Data);
            Assert.IsTrue(response.Data.features.Count > 0);
        }

        public async Task<string> GetResponse(string route)
        {
            var result = await client.GetAsync(route);

            return result.Content.ReadAsStringAsync().Result;
        }
    }
}

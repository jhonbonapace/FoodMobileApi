using Domain.Entities.Location;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repository.Implementation
{
    public class LocationRespository: ILocationRepository
    {
        private DatabaseContext _context;

        public LocationRespository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _context.Country
                .OrderBy(p => p.Id).ToList();
        }

        public IEnumerable<State> GetStates(int IdCountry)
        {
            return _context.State.Where(e => e.IdCountry == IdCountry)
                .OrderBy(p => p.Id).ToList();
        }

        public IEnumerable<City> GetCities(int IdState)
        {
            return _context.City.Where(e => e.IdState == IdState)
                .OrderBy(p => p.Id).ToList();
        }
    }
}

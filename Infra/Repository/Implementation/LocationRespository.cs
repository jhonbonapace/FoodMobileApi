using Domain.Entities;
using Infra.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository.Implementation
{
    public class LocationRespository : ILocationRepository
    {
        private DatabaseContext _context;

        public LocationRespository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Country> GetCountries()
        {
             return _context.Country
                 .OrderBy(p => p.Id).ToList();
        }

        public List<State> GetStates(int CountryId)
        {
            return _context.State.Where(e => e.CountryId == CountryId)
                    .OrderBy(p => p.Id).ToList();
        }

        public List<City> GetCities(int StateId)
        {
            return _context.City.Where(e => e.StateId == StateId)
                .OrderBy(p => p.Id).ToList();
        }
    }
}

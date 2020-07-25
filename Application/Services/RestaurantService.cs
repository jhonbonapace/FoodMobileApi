using System.Linq;
using System.Collections.Generic;
using System.IO;
using Application.DTO;
using Domain.Entities;
using Infra.Repository.Interface;

namespace Application.Services
{
    public class RestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository) => _restaurantRepository = restaurantRepository;

        public void Add(RestaurantDTO restaurantDto)
        {
            byte[] thumbnail = null;
            if (restaurantDto.Thumbnail.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    restaurantDto.Thumbnail.CopyTo(stream);
                    thumbnail = stream.ToArray();
                }
            }

            _restaurantRepository.Create(
                new Restaurant(
                    restaurantDto.Name, 
                    thumbnail, 
                    restaurantDto.Latitude, 
                    restaurantDto.Longitude,
                    restaurantDto.TimeOpen,
                    restaurantDto.TimeClose,
                    restaurantDto.Tags));
        }

        public IEnumerable<RestaurantListResultDTO> List(RestaurantListFilterDTO restaurantListFilter)
        {
            IEnumerable<Restaurant> restaurants = _restaurantRepository.List(
                restaurantListFilter.Tags, 
                restaurantListFilter.Longitude, 
                restaurantListFilter.Latitude, 
                restaurantListFilter.Distance);

            IEnumerable<RestaurantListResultDTO> result =
                restaurants.Select(x => new RestaurantListResultDTO
                {
                    Name = x.Name,
                    Rating = x.Rating,
                    Tags = x.Tags?.Select(y => y.Name),
                    Thumbnail = x.Thumbnail,
                    TimeOpen = x.TimeOpen,
                    TimeClose = x.TimeClose
                });

            return result;
        }
    }
}
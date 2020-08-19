using System.Collections.Generic;
using System.IO;
using System.Linq;
using Application.DTO;
using Domain.Entities;
using Infra.Repository.Interface;
using Serilog;

namespace Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(CustomerDto customerDto)
        {
            byte[] thumbnail = null;
            if (customerDto.Thumbnail.Length > 0)
            {
                using(var stream = new MemoryStream())
                {
                    customerDto.Thumbnail.CopyTo(stream);
                    thumbnail = stream.ToArray();
                }
            }

            _customerRepository.Add(new Customer(
                customerDto.Name, customerDto.Description, thumbnail, customerDto.Rating, customerDto.Latitude, customerDto.Longitude,
                customerDto.TimeOpen, customerDto.TimeClose, customerDto.Tags, customerDto.WorkDays, customerDto.DaysOff,
                customerDto.PaymentMethods, customerDto.Facilities));
        }

        // public IEnumerable<RestaurantListResultDTO> List(RestaurantListFilterDTO restaurantListFilter)
        // {
        //     IEnumerable<Restaurant> restaurants = _restaurantRepository.List(
        //         restaurantListFilter.Tags,
        //         restaurantListFilter.Longitude,
        //         restaurantListFilter.Latitude,
        //         restaurantListFilter.Distance);

        //     IEnumerable<RestaurantListResultDTO> result =
        //         restaurants.Select(x => new RestaurantListResultDTO
        //         {
        //             Name = x.Name,
        //                 Rating = x.Rating,
        //                 Tags = x.Tags?.Select(y => y.Name),
        //                 Thumbnail = x.Thumbnail,
        //                 TimeOpen = x.TimeOpen,
        //                 TimeClose = x.TimeClose
        //         });

        //     return result;
        // }
    }
}

using Application.DTO;
using Domain.Entities;
using Domain.Models;
using Infra.Repository.Interface;

namespace Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(Customer customer)
        {
            // byte[] thumbnail = null;
            // if (customer.Thumbnail.Length > 0)
            // {
            //     using (var stream = new MemoryStream())
            //     {
            //         customer.Thumbnail.CopyTo(stream);
            //         thumbnail = stream.ToArray();
            //     }
            // }

            _customerRepository.Add(customer);
        }

        public CustomerList List(CustomerListFilterDto customerListFilterDto)
        {
            return _customerRepository.List(new CustomerFilter
            {
                Latitude = customerListFilterDto.Latitude,
                Longitude = customerListFilterDto.Longitude,
                PageSize = customerListFilterDto.PageSize,
                CurrentPage = customerListFilterDto.CurrentPage,
                Tags = customerListFilterDto.Tags
            });
        }

        //public IEnumerable<restaurantlistresultdto> list(restaurantlistfilterdto restaurantlistfilter)
        //{
        //    IEnumerable<Customer> restaurants = _customerrepository.List(
        //        restaurantlistfilter.tags,
        //        restaurantlistfilter.longitude,
        //        restaurantlistfilter.latitude,
        //        restaurantlistfilter.distance);

        //    ienumerable<restaurantlistresultdto> result =
        //        restaurants.Select(x => new CustomerDto
        //        {
        //            Name = x.Name,
        //            rating = x.rating,
        //            tags = x.tags?.select(y => y.name),
        //            thumbnail = x.thumbnail,
        //            timeopen = x.timeopen,
        //            timeclose = x.timeclose
        //        });

        //    return result;
        //}
    }
}
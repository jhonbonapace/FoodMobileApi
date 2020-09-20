using Application.DTO;
using Domain.Entities;
using Domain.Models;
using Infra.Repository.Interface;
using NetTopologySuite;
using NetTopologySuite.Geometries;

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

            //4326 refere-se a WGS 84, um padrão usado em GPS e outros sistemas geográficos.
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var currentLocation = geometryFactory.CreatePoint(new Coordinate(customer.Address.Longitude, customer.Address.Latitude));
            customer.Address.Location = currentLocation;

            _customerRepository.Add(customer);
        }

        public CustomerList List(CustomerListFilterDto customerListFilterDto)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var currentLocation = geometryFactory.CreatePoint(new Coordinate(customerListFilterDto.Longitude, customerListFilterDto.Latitude));

            return _customerRepository.List(new CustomerFilter
            {
                Location = currentLocation,
                    PageSize = customerListFilterDto.PageSize,
                    CurrentPage = customerListFilterDto.CurrentPage,
                    Tags = customerListFilterDto.Tags,
                    Distance = customerListFilterDto.Distance
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
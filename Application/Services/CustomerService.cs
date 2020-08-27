
using Application.DTO;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Models;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;
using System.IO;

namespace application.services
{
    public class customerservice
    {
        private readonly ICustomerRepository _customerrepository;

        public customerservice(CustomerRepository customerrepository)
        {
            _customerrepository = customerrepository;
        }

        public void Add(CustomerDto customerDto)
        {
            byte[] thumbnail = null;
            if (customerDto.Thumbnail.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    customerDto.Thumbnail.CopyTo(stream);
                    thumbnail = stream.ToArray();
                }
            }

            //_customerrepository.Add(new Customer(
            //    customerDto.Name, customerDto.Description, thumbnail, customerDto.Rating, customerDto.Latitude, customerDto.Longitude,
            //    customerDto.TimeOpen, customerDto.TimeClose, customerDto.Tags, customerDto.WorkDays, customerDto.DaysOff,
            //    customerDto.PaymentMethods, customerDto.Facilities));
        }

        public CustomerList List(CustomerListFilterDto customerListFilterDto)
        {
            return _customerrepository.List(new CustomerFilter
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
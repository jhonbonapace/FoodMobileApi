using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infra.Repository.Interface;

namespace Infra.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private DatabaseContext _context;

        public CustomerRepository(DatabaseContext context)
        {
            _context = context;
        }

        public CustomerList List(CustomerFilter customerFilter)
        {
            // var query = _context.Customer.OrderByDescending(x => x.Rating);

            // var (pageCount, results) =
            //                 _context.Customer
            //                     .OrderByDescending(x => x.Rating)
            //                     .GetPaged(customerFilter.CurrentPage, customerFilter.PageSize);

            // var customerList = new CustomerList
            // {
            //     Customers = results,
            //     PageCount = pageCount
            // };

            var result = _context.Customer.OrderByDescending(x => x.Rating).ToList();
            var customerList = new CustomerList
            {
                Customers = result,
                PageCount = 1
            };

            return customerList;
        }

        public bool Add(Customer customer)
        {
            try
            {
                _context.Customer.Add(customer);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
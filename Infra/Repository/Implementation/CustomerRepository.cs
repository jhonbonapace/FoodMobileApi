using System;
using System.Linq;
using Domain.Entities;
using Domain.Models;
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
            //var query = _context.Customer.OrderByDescending(x => x.Name);

            // var (pageCount, results) =
            //                 _context.Customer
            //                     .OrderBy(c => c.Address.Location.Distance(customerFilter.Location))
            //                     .OrderByDescending(x => x.Name)
            //                     .GetPaged(customerFilter.CurrentPage, customerFilter.PageSize);

            //var customerList = new CustomerList
            //{
            //    Customers = results,
            //    PageCount = pageCount
            //};

            //var result = _context.Customer.OrderBy(c => c.Address.Location.Distance(customerFilter.Location)).OrderBy(x => x.Name).ToList();
            var result = _context.Customer
                .Where(c => c.Address.Location.Distance(customerFilter.Location) < customerFilter.Distance)
                .OrderBy(c => c.Address.Location.Distance(customerFilter.Location))
                .OrderBy(x => x.Name)
                .Select(x => new Customer { Distance = x.Address.Location.Distance(customerFilter.Location), Name = x.Name })
                .ToList();

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
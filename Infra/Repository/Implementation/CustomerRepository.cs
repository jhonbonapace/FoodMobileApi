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

        public IEnumerable<Customer> List()
        {
            return _context.Customer
                .OrderBy(p => p.Id).ToList();
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
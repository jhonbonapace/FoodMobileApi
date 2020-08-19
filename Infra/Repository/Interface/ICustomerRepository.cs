using System.Collections.Generic;
using Domain.Entities;

namespace Infra.Repository.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> List();
        bool Add(Customer customer);
    }
}
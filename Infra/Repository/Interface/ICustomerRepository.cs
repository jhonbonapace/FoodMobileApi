using System.Collections.Generic;
using Domain.Entities;

namespace Infra.Repository.Interface
{
    public interface ICustomerRepository
    {
        CustomerList List(CustomerFilter customerFilter);
        bool Add(Customer customer);
    }
}
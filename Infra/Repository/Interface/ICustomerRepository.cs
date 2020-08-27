using Domain.Entities;
using Domain.Models;

namespace Infra.Repository.Interface
{
    public interface ICustomerRepository
    {
        CustomerList List(CustomerFilter customerFilter);
        bool Add(Customer customer);
    }
}
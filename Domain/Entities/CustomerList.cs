using System.Collections.Generic;

namespace Domain.Entities
{
    public class CustomerList
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int PageCount { get; set; }
    }
}
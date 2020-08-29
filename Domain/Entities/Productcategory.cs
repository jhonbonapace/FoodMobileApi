using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Productcategory: Base
    {
        public Productcategory()
        {
            Product = new HashSet<Product>();
        }

        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ulong? IsExcluded { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}

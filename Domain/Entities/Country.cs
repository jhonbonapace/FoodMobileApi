using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
            Customer = new HashSet<Customer>();
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NamePt { get; set; }
        public string Initials { get; set; }
        public string Bacen { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}

using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class State: Base
    {
        public State()
        {
            Address = new HashSet<Address>();
            City = new HashSet<City>();
        }
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public string Ibgecode { get; set; }
        public string Initials { get; set; }
        public string NumberCode { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}

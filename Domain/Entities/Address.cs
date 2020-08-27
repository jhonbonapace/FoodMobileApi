using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? IdCountry { get; set; }
        public int? IdState { get; set; }
        public int? IdCity { get; set; }

        public virtual City IdCityNavigation { get; set; }
        public virtual Country IdCountryNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}

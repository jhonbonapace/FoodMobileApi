using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdState { get; set; }
        public string Ibgecode { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}

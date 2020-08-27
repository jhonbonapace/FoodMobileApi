using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Facility
    {
        public Facility()
        {
            Customerfacilities = new HashSet<Customerfacilities>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Customerfacilities> Customerfacilities { get; set; }
    }
}

using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Facility: Base
    {
        public Facility()
        {
            Customerfacilities = new HashSet<Customerfacilities>();
        }
        public string Description { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Customerfacilities> Customerfacilities { get; set; }
    }
}

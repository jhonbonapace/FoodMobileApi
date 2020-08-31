using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Facility : Base
    {
        // public Facility()
        // {
        //     CustomerFacilities = new HashSet<CustomerFacilities>();
        // }
        public string Description { get; set; }
        public int Code { get; set; }

        public ICollection<CustomerFacilities> CustomerFacilities { get; set; }
    }
}

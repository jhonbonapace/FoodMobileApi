using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class CustomerFacilities : Base
    {
        public ulong IsActive { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}

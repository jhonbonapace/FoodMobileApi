namespace Domain.Entities
{
    public partial class CustomerFacilities : Base
    {
        public ulong IsActive { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}

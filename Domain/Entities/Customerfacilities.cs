namespace Domain.Entities
{
    public partial class Customerfacilities: Base
    {
        public int IdFacility { get; set; }
        public int IdCustomer { get; set; }
        public ulong IsActive { get; set; }
        public string Description { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Facility IdFacilityNavigation { get; set; }
    }
}

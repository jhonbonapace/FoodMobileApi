namespace Domain.Entities
{
    public partial class Customertags: Base
    {
        public int IdTag { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Tags IdTagNavigation { get; set; }
    }
}

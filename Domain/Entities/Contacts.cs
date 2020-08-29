namespace Domain.Entities
{
    public partial class Contacts: Base
    {
        public int IdCustomer { get; set; }
        public int ContactyType { get; set; }
        public string Description { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
    }
}

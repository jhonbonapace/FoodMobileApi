namespace Domain.Entities
{
    public partial class Contacts
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int ContactyType { get; set; }
        public string Description { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
    }
}

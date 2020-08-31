namespace Domain.Entities
{
    public partial class UserFavoriteCustomers : Base
    {
        public int IdCustomer { get; set; }
        public int IdUser { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}

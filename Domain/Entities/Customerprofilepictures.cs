namespace Domain.Entities
{
    public partial class CustomerProfilePictures : Base
    {
        public string Name { get; set; }
        public decimal? Size { get; set; }
        public string ImagePath { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
    }
}

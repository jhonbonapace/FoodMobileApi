namespace Domain.Entities
{
    public partial class Customerprofilepictures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Size { get; set; }
        public string ImagePath { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
    }
}

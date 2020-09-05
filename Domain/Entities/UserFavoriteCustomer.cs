namespace Domain.Entities
{
    public  class UserFavoriteCustomer : Base
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

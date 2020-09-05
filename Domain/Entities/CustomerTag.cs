namespace Domain.Entities
{
    public class CustomerTag : Base
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}

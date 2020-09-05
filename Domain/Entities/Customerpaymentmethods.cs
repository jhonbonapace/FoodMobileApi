namespace Domain.Entities
{
    public class CustomerPaymentMethods : Base
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}

namespace Domain.Entities
{
    public partial class Customerpaymentmethods : Base
    {
        public int IdPaymentMethod { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Paymentmethod IdPaymentMethodNavigation { get; set; }
    }
}

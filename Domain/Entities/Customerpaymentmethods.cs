namespace Domain.Entities
{
    public partial class Customerpaymentmethods
    {
        public int Id { get; set; }
        public int IdPaymentMethod { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Paymentmethod IdPaymentMethodNavigation { get; set; }
    }
}

using System.Collections.Generic;
using static Domain.Enumerators.Enumerator;

namespace Domain.Entities
{
    public partial class Paymentmethod : Base
    {
        public Paymentmethod()
        {
            CustomerPaymentMethods = new HashSet<CustomerPaymentMethods>();
        }
        public string Description { get; set; }
        public int Code { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }

        public virtual ICollection<CustomerPaymentMethods> CustomerPaymentMethods { get; set; }
    }
}

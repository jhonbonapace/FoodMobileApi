using System.Collections.Generic;
using static Domain.Enumerators.Enumerator;

namespace Domain.Entities
{
    public partial class Paymentmethod: Base
    {
        public Paymentmethod()
        {
            Customerpaymentmethods = new HashSet<Customerpaymentmethods>();
        }
        public string Description { get; set; }
        public int Code { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }

        public virtual ICollection<Customerpaymentmethods> Customerpaymentmethods { get; set; }
    }
}

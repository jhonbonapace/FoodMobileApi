﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Enumerators.Enumerator;

namespace Domain.Entities
{
    public class PaymentMethod : Base
    {
        [Column(TypeName = "varchar(20)")]
        public string Description { get; set; }
        public int Code { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }

        public ICollection<CustomerPaymentMethods> CustomerPaymentMethods { get; set; }
    }
}

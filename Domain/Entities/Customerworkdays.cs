using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Customerworkdays: Base
    {
        public Customerworkdays()
        {
            Customerworkdaystimeoff = new HashSet<Customerworkdaystimeoff>();
        }
        public int WeekDay { get; set; }
        public DateTime? TimeOpen { get; set; }
        public DateTime? TimeClose { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<Customerworkdaystimeoff> Customerworkdaystimeoff { get; set; }
    }
}

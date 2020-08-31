using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class CustomerWorkDays : Base
    {
        public CustomerWorkDays()
        {
            CustomerWorkDaysTimeOff = new HashSet<CustomerWorkDaysTimeOff>();
        }
        public int WeekDay { get; set; }
        public DateTime? TimeOpen { get; set; }
        public DateTime? TimeClose { get; set; }
        public int IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<CustomerWorkDaysTimeOff> CustomerWorkDaysTimeOff { get; set; }
    }
}

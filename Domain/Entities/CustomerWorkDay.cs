using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CustomerWorkDay : Base
    {
        public int WeekDay { get; set; }
        public DateTime? TimeOpen { get; set; }
        public DateTime? TimeClose { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<CustomerWorkDayTimeOff> CustomerWorkDaysTimeOff { get; set; }
    }
}

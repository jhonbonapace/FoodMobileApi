using System;

namespace Domain.Entities
{
    public partial class CustomerWorkDaysTimeOff : Base
    {
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public int IdCustomerWorkDays { get; set; }

        public virtual CustomerWorkDays IdCustomerWorkDaysNavigation { get; set; }
    }
}

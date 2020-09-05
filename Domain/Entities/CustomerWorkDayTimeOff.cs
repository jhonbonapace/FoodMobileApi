using System;

namespace Domain.Entities
{
    public class CustomerWorkDayTimeOff : Base
    {
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }

        public int CustomerWorkDayId { get; set; }
        public CustomerWorkDay CustomerWorkDay { get; set; }
    }
}

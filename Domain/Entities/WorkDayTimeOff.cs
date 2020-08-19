using System;

namespace Domain.Entities
{
    public class WorkDayTimeOff : Base
    {
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}
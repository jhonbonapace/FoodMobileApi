using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WorkDay : Base
    {
        public DayOfWeek WeekDay { get; set; }
        public TimeSpan TimeOpen { get; set; }
        public TimeSpan TimeClose { get; set; }
        public IEnumerable<WorkDayTimeOff> DayTimeOffs { get; set; }
    }
}
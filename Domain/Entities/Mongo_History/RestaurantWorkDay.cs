using System.Collections.Generic;
using System;

namespace Domain.Entities

{
    public class RestaurantWorkDay : Base
    {

        public int IdRestaurant { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public TimeSpan TimeOpen { get; set; }
        public TimeSpan TimeClose { get; set; }
        public IEnumerable<RestaurantWorkDayTimeOff> DayTimeOffs { get; set; }
    }
}
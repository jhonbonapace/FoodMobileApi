using System;
namespace Domain.Entities
{
    public class RestaurantWorkDayTimeOff
    {
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class RestaurantListResultDTO
    {
        public string Name { get; set; }
        public byte[] Thumbnail { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public double Rating { get; set; }
        public TimeSpan TimeOpen { get; set; }
        public TimeSpan TimeClose { get; set; }
        public bool IsOpenNow
        {
            get 
            {
                return
                    TimeClose < TimeOpen 
                    ? DateTime.Now.TimeOfDay >= TimeOpen 
                    : (DateTime.Now.TimeOfDay >= TimeOpen && DateTime.Now.TimeOfDay <= TimeClose);
            }
        }

        public bool IsOpenAllDay
        {
            get { return TimeOpen == new TimeSpan(0, 0, 0) && TimeClose == new TimeSpan(0, 0, 0); }
        }
    }
}
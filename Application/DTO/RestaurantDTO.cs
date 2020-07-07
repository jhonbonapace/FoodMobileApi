using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public class RestaurantDTO
    {
        public string Name { get; set; }
        public IFormFile Thumbnail { get; set; }
        public double Rating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public TimeSpan TimeOpen { get; set; }
        public TimeSpan TimeClose { get; set; }
    }
}
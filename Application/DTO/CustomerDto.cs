using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Thumbnail { get; set; }
        public double Rating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public TimeSpan TimeOpen { get; set; }
        public TimeSpan TimeClose { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<WorkDay> WorkDays { get; set; }
        public IEnumerable<SpecificOff> DaysOff { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
        public IEnumerable<Facilitie> Facilities { get; set; }
    }
}
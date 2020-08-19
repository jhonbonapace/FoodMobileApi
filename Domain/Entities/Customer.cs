using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Customer : Base
    {
        // [Required]
        // [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Thumbnail { get; set; }
        public double Rating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public TimeSpan TimeOpen { get; set; }
        public TimeSpan TimeClose { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<WorkDay> WorkDays { get; set; }
        public IEnumerable<SpecificOff> DaysOff { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
        public IEnumerable<Facilitie> Facilities { get; set; }

        private Customer() { }

        public Customer(string name, string description, byte[] thumbnail, double rating, double latitude, double longitude, TimeSpan timeOpen, TimeSpan timeClose,
            IEnumerable<Tag> tags, IEnumerable<WorkDay> workDays, IEnumerable<SpecificOff> daysOff, IEnumerable<PaymentMethod> paymentMethods, IEnumerable<Facilitie> facilities)
        {
            Name = name;
            Description = description;
            Thumbnail = thumbnail;
            Rating = rating;
            Latitude = latitude;
            Longitude = longitude;
            TimeOpen = timeOpen;
            TimeClose = timeClose;
            Tags = tags;
            WorkDays = workDays;
            DaysOff = daysOff;
            Comments = new List<Comment>();
            PaymentMethods = paymentMethods;
            Facilities = facilities;
        }

        // public Customer(string name)
        // {
        //     if (string.IsNullOrWhiteSpace(name))
        //         throw new ArgumentException("Nome deve ser informado");
        // }
    }
}
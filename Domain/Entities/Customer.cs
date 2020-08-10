using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Customer : Base
    {
        // [Required]
        // [StringLength(100)]
        public string Name { get; private set; }
        public byte[] Thumbnail { get; private set; }
        public double Rating { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public TimeSpan TimeOpen { get; private set; }
        public TimeSpan TimeClose { get; private set; }
        public IEnumerable<Tag> Tags { get; private set; }
        public IEnumerable<WorkDay> WorkDays { get; private set; }
        public IEnumerable<SpecificOff> DaysOff { get; private set; }
        public IEnumerable<Comment> Comments { get; private set; }
        public IEnumerable<PaymentMethod> Comments { get; private set; }
        public IEnumerable<Facilitie> Comments { get; private set; }

        private Customer() { }

        // public Customer(string name)
        // {
        //     if (string.IsNullOrWhiteSpace(name))
        //         throw new ArgumentException("Nome deve ser informado");
        // }
    }
}
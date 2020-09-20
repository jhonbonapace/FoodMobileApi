using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public class CustomerDto : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BookingNote { get; set; }
        public string Specialty { get; set; }
        public byte[] Thumbnail { get; set; }
        public int? ReservationMaxPartySize { get; set; }
        public int? ReservationMinPartySize { get; set; }
        public DateTime? LastUpdate { get; set; }

        public Address Address { get; set; }
        public User User { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public ICollection<Contacts> Contacts { get; set; }
        public ICollection<CustomerFacilities> CustomerFacilities { get; set; }
        public ICollection<CustomerPaymentMethods> CustomerPaymentMethods { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }
        public ICollection<UserCommentaries> UserCommentaries { get; set; }
        public ICollection<UserFavoriteCustomer> UserFavoriteCustomers { get; set; }
    }
}
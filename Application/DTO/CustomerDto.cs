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
        public int IdUser { get; set; }
        public int? IdAddress { get; set; }
        public int? IdNacionalitySpecialty { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
        public virtual Country IdNacionalitySpecialtyNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<CustomerFacilities> CustomerFacilities { get; set; }
        public virtual ICollection<CustomerPaymentMethods> CustomerPaymentMethods { get; set; }
        public virtual ICollection<CustomerProfilePictures> CustomerProfilePictures { get; set; }
        public virtual ICollection<CustomerTags> CustomerTags { get; set; }
        public virtual ICollection<CustomerWorkDays> CustomerWorkDays { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        public virtual ICollection<UserCommentaries> UserCommentaries { get; set; }
        public virtual ICollection<UserFavoriteCustomers> UserFavoriteCustomers { get; set; }
    }
}
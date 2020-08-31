using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Customer : Base
    {

        // public Customer()
        // {
        //     Booking = new HashSet<Booking>();
        //     Contacts = new HashSet<Contacts>();
        //     CustomerFacilities = new HashSet<CustomerFacilities>();
        //     // CustomerPaymentMethods = new HashSet<CustomerPaymentMethods>();
        //     // CustomerProfilePictures = new HashSet<CustomerProfilePictures>();
        //     // CustomerTags = new HashSet<CustomerTags>();
        //     // CustomerWorkDays = new HashSet<CustomerWorkDays>();
        //     // ProductCategory = new HashSet<ProductCategory>();
        //     // UserCommentaries = new HashSet<UserCommentaries>();
        //     // UserFavoriteCustomers = new HashSet<UserFavoriteCustomers>();
        // }

        public string Name { get; set; }
        public string Description { get; set; }
        public string BookingNote { get; set; }
        public string Specialty { get; set; }
        public byte[] Thumbnail { get; set; }
        public int? ReservationMaxPartySize { get; set; }
        public int? ReservationMinPartySize { get; set; }
        // public int IdUser { get; set; }
        // public int? IdAddress { get; set; }
        // public int? IdNacionalitySpecialty { get; set; }
        public DateTime? LastUpdate { get; set; }

        // public virtual Address IdAddressNavigation { get; set; }
        // public virtual Country IdNacionalitySpecialtyNavigation { get; set; }
        // public virtual User IdUserNavigation { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public ICollection<Contacts> Contacts { get; set; }
        public ICollection<CustomerFacilities> CustomerFacilities { get; set; }
        // public virtual ICollection<CustomerPaymentMethods> CustomerPaymentMethods { get; set; }
        // public virtual ICollection<CustomerProfilePictures> CustomerProfilePictures { get; set; }
        // public virtual ICollection<CustomerTags> CustomerTags { get; set; }
        // public virtual ICollection<CustomerWorkDays> CustomerWorkDays { get; set; }
        // public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        // public virtual ICollection<UserCommentaries> UserCommentaries { get; set; }
        // public virtual ICollection<UserFavoriteCustomers> UserFavoriteCustomers { get; set; }
    }
}

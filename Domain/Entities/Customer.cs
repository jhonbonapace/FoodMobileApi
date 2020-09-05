using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Customer : Base
    {
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string BookingNote { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Specialty { get; set; }
        public byte[] Thumbnail { get; set; }
        public int? ReservationMaxPartySize { get; set; }
        public int? ReservationMinPartySize { get; set; }
        public Address Address { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public ICollection<Contacts> Contacts { get; set; }
        public ICollection<CustomerFacilities> CustomerFacilities { get; set; }
        public ICollection<CustomerPaymentMethods> CustomerPaymentMethods { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<CustomerTag> CustomerTags { get; set; }
        public ICollection<CustomerWorkDay> CustomerWorkDays { get; set; }
        public ICollection<UserCommentaries> UserCommentaries { get; set; }
        public ICollection<UserFavoriteCustomer> UserFavoriteCustomers { get; set; }
    }
}

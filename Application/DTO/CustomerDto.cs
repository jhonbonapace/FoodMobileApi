using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }
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
        public virtual ICollection<Customerfacilities> Customerfacilities { get; set; }
        public virtual ICollection<Customerpaymentmethods> Customerpaymentmethods { get; set; }
        public virtual ICollection<Customerprofilepictures> Customerprofilepictures { get; set; }
        public virtual ICollection<Customertags> Customertags { get; set; }
        public virtual ICollection<Customerworkdays> Customerworkdays { get; set; }
        public virtual ICollection<Productcategory> Productcategory { get; set; }
        public virtual ICollection<Usercommentaries> Usercommentaries { get; set; }
        public virtual ICollection<Userfavoritecustomers> Userfavoritecustomers { get; set; }
    }
}
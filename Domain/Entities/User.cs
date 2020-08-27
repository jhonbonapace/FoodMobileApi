using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Booking = new HashSet<Booking>();
            Customer = new HashSet<Customer>();
            Usercommentaries = new HashSet<Usercommentaries>();
            Userfavoritecustomers = new HashSet<Userfavoritecustomers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public string Telephone { get; set; }
        public DateTime? BirthDate { get; set; }

        public string Gender { get; set; }
        public byte[] Thumbnail { get; set; }
        public int UserType { get; set; }
        public int FailedAttempts { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ulong? Deleted { get; set; }
        public string Ip { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Usercommentaries> Usercommentaries { get; set; }
        public virtual ICollection<Userfavoritecustomers> Userfavoritecustomers { get; set; }
    }
}

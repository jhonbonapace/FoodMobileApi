using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Enumerators.Enumerator;

namespace Domain.Entities
{
    public class User : Base
    {
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(14)")]
        public string Identity { get; set; }

        [Column(TypeName = "varchar(11)")]
        public string Telephone { get; set; }
        public DateTime? BirthDate { get; set; }

        public Gender? Gender { get; set; }
        public byte[] Thumbnail { get; set; }

        public int FailedAttempts { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PasswordHash { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string PasswordSalt { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Ip { get; set; }
        public UserType UserType { get; set; }
        public ICollection<Booking> Booking { get; set; }
        public ICollection<UserCommentaries> UserCommentaries { get; set; }
        public ICollection<UserFavoriteCustomers> UserFavoriteCustomers { get; set; }
    }
}

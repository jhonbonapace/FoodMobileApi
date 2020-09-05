using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Booking : Base
    {
        [Column(TypeName = "varchar(20)")]
        public string ReservationCode { get; set; }
        public DateTime Date { get; set; }
        public int? GuestQuantity { get; set; }
        public ulong? Deleted { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Request { get; set; }
        public DateTime CreatedOn { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

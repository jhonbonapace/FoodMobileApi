using System;

namespace Domain.Entities
{
    public partial class Booking : Base
    {
        public string ReservationCode { get; set; }
        public DateTime Date { get; set; }
        public int? GuestQuantity { get; set; }
        public ulong? Deleted { get; set; }
        public string Request { get; set; }
        public DateTime CreatedOn { get; set; }
        // public int IdUser { get; set; }
        // public int? IdComment { get; set; }

        // public virtual UserCommentaries IdCommentNavigation { get; set; }

        // public virtual User IdUserNavigation { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

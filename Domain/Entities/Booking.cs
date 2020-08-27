using System;

namespace Domain.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string ReservationCode { get; set; }
        public DateTime Date { get; set; }
        public int? GuestQuantity { get; set; }
        public ulong? Deleted { get; set; }
        public string Request { get; set; }
        public DateTime CreatedOn { get; set; }
        public int IdCustomer { get; set; }
        public int IdUser { get; set; }
        public int? IdComment { get; set; }

        public virtual Usercommentaries IdCommentNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}

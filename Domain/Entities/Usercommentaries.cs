using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Usercommentaries
    {
        public Usercommentaries()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public decimal? Rating { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int IdCustomer { get; set; }
        public int IdUser { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}

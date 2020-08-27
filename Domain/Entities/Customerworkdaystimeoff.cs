using System;

namespace Domain.Entities
{
    public partial class Customerworkdaystimeoff
    {
        public int Id { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public int IdCustomerWorkDays { get; set; }

        public virtual Customerworkdays IdCustomerWorkDaysNavigation { get; set; }
    }
}

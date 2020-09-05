using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserCommentaries : Base
    {
        public decimal? Rating { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

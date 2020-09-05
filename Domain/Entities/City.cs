using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class City : Base
    {
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string IbgeCode { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}

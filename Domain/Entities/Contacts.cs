using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Contacts : Base
    {
        public int ContactyType { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

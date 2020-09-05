using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class City : Base
    {
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string IbgeCode { get; set; }
        public State State { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}

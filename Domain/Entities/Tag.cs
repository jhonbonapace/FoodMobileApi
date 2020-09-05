using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Tag : Base
    {
        [Column(TypeName = "varchar(20)")]
        public string Description { get; set; }
        public int Code { get; set; }

        public ICollection<CustomerTag> CustomerTags { get; set; }
    }
}

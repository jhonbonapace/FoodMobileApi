using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Facility : Base
    {
        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; }
        public int Code { get; set; }

        public ICollection<CustomerFacilities> CustomerFacilities { get; set; }
    }
}

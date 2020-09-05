using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Country : Base
    {
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string NamePt { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Initials { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Bacen { get; set; }
    }
}

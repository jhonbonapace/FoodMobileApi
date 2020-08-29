using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Country: Base
    {
        public string Name { get; set; }
        public string NamePt { get; set; }
        public string Initials { get; set; }
        public string Bacen { get; set; }

        [JsonIgnore]
        public virtual ICollection<Address> Address { get; set; }
        [JsonIgnore]
        public virtual ICollection<Customer> Customer { get; set; }
        [JsonIgnore]
        public virtual ICollection<State> State { get; set; }
    }
}

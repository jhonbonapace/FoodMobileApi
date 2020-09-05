using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Country : Base
    {
        public string Name { get; set; }
        public string NamePt { get; set; }
        public string Initials { get; set; }
        public string Bacen { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}

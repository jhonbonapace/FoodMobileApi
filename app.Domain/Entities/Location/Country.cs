using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Location
{
    public class Country : Base
    {
        public string Name { get; set; }
        public string Name_PT { get; set; }
        public string Initials { get; set; }
        public string Bacen { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}

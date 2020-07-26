using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Location
{
    public class Country : Base
    {
        public string Name { get; set; }
        public string Initials { get; set; }
    }
}

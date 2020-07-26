using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Location
{
    public class State : Base
    {
        public int IdCountry { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
    }
}

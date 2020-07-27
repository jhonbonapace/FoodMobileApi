﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Location
{
    public class State : Base
    {
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public string IBGECode { get; set; }
        public string Initials { get; set; }
        public string NumberCode { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
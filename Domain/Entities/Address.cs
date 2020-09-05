﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Address : Base
    {
        [Column(TypeName = "varchar(50)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string Number { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string District { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Complement { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string ZipCode { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public City City { get; set; }
    }
}

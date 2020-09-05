﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class State : Base
    {
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string IbgeCode { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string Initials { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NumberCode { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Profile : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Displayable { get; set; }
        public List<Contact> Contacts { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

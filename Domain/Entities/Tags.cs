using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Tags: Base
    {
        public Tags()
        {
            Customertags = new HashSet<Customertags>();
        }
        public string Description { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Customertags> Customertags { get; set; }
    }
}

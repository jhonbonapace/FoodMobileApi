using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Tags
    {
        public Tags()
        {
            Customertags = new HashSet<Customertags>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Customertags> Customertags { get; set; }
    }
}

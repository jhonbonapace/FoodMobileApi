using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Tags : Base
    {
        public Tags()
        {
            CustomerTags = new HashSet<CustomerTags>();
        }
        public string Description { get; set; }
        public int Code { get; set; }

        public virtual ICollection<CustomerTags> CustomerTags { get; set; }
    }
}

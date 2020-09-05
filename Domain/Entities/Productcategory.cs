using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ProductCategory : Base
    {
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }
        public ulong? IsExcluded { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product : Base
    {
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsPriceless { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string ImagePath { get; set; }
        public bool? IsDeleted { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}

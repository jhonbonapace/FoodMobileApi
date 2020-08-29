namespace Domain.Entities
{
    public partial class Product: Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public ulong? IsPriceless { get; set; }
        public int IdProductCategory { get; set; }
        public string ImagePath { get; set; }
        public ulong? Deleted { get; set; }

        public virtual Productcategory IdProductCategoryNavigation { get; set; }
    }
}

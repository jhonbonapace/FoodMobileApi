namespace Domain.Entities
{
    public partial class Contacts : Base
    {
        public int ContactyType { get; set; }
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

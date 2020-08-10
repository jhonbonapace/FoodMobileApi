namespace Domain.Entities.Location
{
    public class City : Base
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public string IBGECode { get; set; }
    }
}

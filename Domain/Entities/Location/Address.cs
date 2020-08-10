namespace Domain.Entities.Location
{
    public class Address : Base
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}

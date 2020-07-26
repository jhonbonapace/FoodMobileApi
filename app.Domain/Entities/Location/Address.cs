namespace Domain.Entities.Location
{
    public class Address : Base
    {
        public int IdCity { get; set; }
        public int IdCountry { get; set; }
        public int IdState { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}

namespace Domain.Entities.ValueObject
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        private Location() { }

        public Location(double latitude, double longitude)
        {

        }
    }
}
namespace Domain.Entities.ValueObject
{
    public class Location
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        private Location() { }

        public Location(double latitude, double longitude)
        {

        }
    }
}
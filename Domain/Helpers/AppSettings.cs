namespace Domain.Helpers
{
    public class AppSettings
    {
        // To generate password
        public string Secret { get; set; }
        public int DaysToExpire { get; set; }
        public int WorkFactor { get; set; }
    }
}

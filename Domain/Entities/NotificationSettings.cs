namespace Domain.Entities
{
    public class NotificationSettings: Base
    {
        public bool Email { get; set; }
        public bool Whatsapp { get; set; }
        public bool SMS { get; set; }
    }
}

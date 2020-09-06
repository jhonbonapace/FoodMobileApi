

namespace Domain.Entities
{
    public class UserSettings: Base
    {
        public NotificationSettings NotificationSettings { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
     
    }
}

using Newtonsoft.Json;

namespace Domain.Entities

{
    public class Comment : Base
    {
        public string Text { get; set; }
        public User User { get; set; }
    }
}
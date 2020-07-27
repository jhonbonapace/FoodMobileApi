using Newtonsoft.Json;

namespace Domain.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public string Telephone { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
   
        [JsonIgnore]
        public string Password { get; set; }
        public string Thumbnail { get; set; }
    }
}

using Newtonsoft.Json;
using static Domain.Enumerators.Enumerator;

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
        public string Thumbnail { get; set; }
        public UserType UserType { get; set; }
        public Profile Profile { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}

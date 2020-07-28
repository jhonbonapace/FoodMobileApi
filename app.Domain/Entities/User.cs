using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        [NotMapped]
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string PasswordSalt { get; set; }
        [JsonIgnore]
        public int WorkFactor { get; set; }
    }
}

using static Domain.Enumerators.Enumerator;

namespace Domain.Entities
{
    public class Contact : Base
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ContactType ContactType { get; set; }
    }
}

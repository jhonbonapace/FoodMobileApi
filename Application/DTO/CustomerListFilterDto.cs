using System.Collections.Generic;

namespace Application.DTO
{
    public class CustomerListFilterDto : PagedResultBase
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long Distance { get; set; }
        public double Rating { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Type { get; set; } // Um especificador mais geral do que mais representa o estabelecimento
    }
}
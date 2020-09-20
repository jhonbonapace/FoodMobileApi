using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Domain.Models
{
    public class CustomerFilter
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public double Distance { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Geometry Location { get; set; }
        public double Rating { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Type { get; set; } // Um especificador mais geral do que mais representa o estabelecimento
    }
}
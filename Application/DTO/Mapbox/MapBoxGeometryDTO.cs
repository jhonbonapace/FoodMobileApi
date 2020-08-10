using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Mapbox
{
    public class MapBoxGeometryDTO
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
}

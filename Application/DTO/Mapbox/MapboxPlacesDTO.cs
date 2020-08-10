using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Mapbox
{
    public class MapboxPlacesDTO
    {
        public List<string> query { get; set; }
        public List<MapboxFeatureDTO> features { get; set; }
    }
}

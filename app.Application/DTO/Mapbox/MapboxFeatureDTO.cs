using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Mapbox
{
    public class MapboxFeatureDTO
    {
        public string id { get; set; }
        public string type { get; set; }
        public List<string> place_type { get; set; }
        public int relevance { get; set; }
        //public MapboxPropertiesDTO properties { get; set; }
        public string text_pt { get; set; }
        public string place_name_pt { get; set; }
        public string text { get; set; }
        public string place_name { get; set; }
        public List<double> bbox { get; set; }
        public List<double> center { get; set; }
        public MapBoxGeometryDTO geometry { get; set; }
        //public List<MapboxContextDTO> context { get; set; }

    }
}

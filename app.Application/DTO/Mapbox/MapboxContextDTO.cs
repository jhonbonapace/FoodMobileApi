using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Mapbox
{
    public class MapboxContextDTO
    {
        public string id { get; set; }
        public string text_pt { get; set; }
        public string text { get; set; }
        public string wikidata { get; set; }
        public string language_pt { get; set; }
        public string language { get; set; }
        public string short_code { get; set; }
    }
}

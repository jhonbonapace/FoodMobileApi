using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public class MapBoxSettings
    {
        public string Access_token { get; set; }
        public bool Autocomplete { get; set; }
        public string Country { get; set; }
        public int Limit { get; set; }
        public string Endpoint { get; set; }
    }
}

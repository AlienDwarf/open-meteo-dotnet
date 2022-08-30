using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteo
{
    public class GeocodingApiResponse
    {
        [JsonPropertyName("results")]
        public LocationData[]? Locations { get; set; }
        public float Generationtime_ms { get; set; }
    }
}
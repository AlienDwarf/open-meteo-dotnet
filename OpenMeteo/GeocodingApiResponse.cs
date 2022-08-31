using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteo
{
    public class GeocodingApiResponse
    {
        /// <summary>
        /// Array of found locations
        /// </summary>
        /// <value></value>
        [JsonPropertyName("results")]
        public LocationData[]? Locations { get; set; }

        /// <summary>
        /// Generation time of the weather forecast in milliseconds.
        /// </summary>
        /// <value></value>
        public float Generationtime_ms { get; set; }
    }
}
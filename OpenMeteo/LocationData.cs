using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteo
{
    /// <summary>
    /// Returned by Geocoding Api.
    /// </summary>
    public class LocationData
    {
        /// <summary>
        /// Unique identifier for this exact location
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Location name. Localized following <see cref="GeocodingOptions.Language"/>
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Geographical WGS84 coordinates of this location
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Geographical WGS84 coordinates of this location
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Elevation above sea level in meters.
        /// </summary>
        public float Elevation { get; set; }
        public string? Timezone { get; set; }
        [JsonPropertyName("feature_code")]
        public string? FeatureCode { get; set; }
        [JsonPropertyName("country_code")]
        public string? CountyCode { get; set; }
        public string? Country { get; set; }
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }
        public int Population { get; set; }
        public string[]? Postcodes { get; set; }
        public string? Admin1 { get; set; }
        public string? Admin2 { get; set; }
        public string? Admin3 { get; set; }
        public string? Admin4 { get; set; }

        [JsonPropertyName("admin1_id")]
        public int Admin1Id { get; set; }

        [JsonPropertyName("admin2_id")]
        public int Admin2Id { get; set; }

        [JsonPropertyName("admin3_id")]
        public int Admin3Id { get; set; }

        [JsonPropertyName("admin4_id")]
        public int Admin4Id { get; set; }
    }
}

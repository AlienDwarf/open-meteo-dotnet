using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteo
{
    public class CityData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Elevation { get; set; }
        public string? Timezone { get; set; }
        [JsonPropertyName("feature_code")]
        public string? FeatureCode { get; set; }
        [JsonPropertyName("country_code")]
        public string? CountyCode { get; set; }
        public string? Country { get; set; }
        public int CountyId { get; set; }
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteo
{
    public class WeatherForecast
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Elevation { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public float GenerationTime { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public int UtcOffset { get; set; }
        public string? Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string? TimezoneAbbreviation { get; set; }

        [JsonPropertyName("current_weather")]
        public CurrentWeather? CurrentWeather { get; set; }

        [JsonPropertyName("hourly_units")]
        public Hourly_Units? Hourly_units { get; set; }

        [JsonPropertyName("hourly")]
        public Hourly? Hourly { get; set; }

        [JsonPropertyName("daily_units")]
        public Daily_Units? Daily_units { get; set; }

        [JsonPropertyName("daily")]
        public Daily? Daily { get; set; }
    }
}



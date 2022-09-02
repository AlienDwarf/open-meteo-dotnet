namespace OpenMeteo
{
    /// <summary>
    /// Air Quality Api response
    /// </summary>
    public class AirQuality
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float GenerationTime { get; set; }
        public int UtcOffset { get; set; }
        public string? Timezone { get; set; }
        public string? TimezoneAbbreviation { get; set; }
        public HourlyValues? Hourly { get; set; }
        public HourlyUnits? Hourly_Units { get; set; }

        public class HourlyUnits
        {
            public string? time { get; set; }
            public string? pm10 { get; set; }
            public string? pm2_5 { get; set; }
            public string? carbon_monoxide { get; set; }
            public string? nitrogen_dioxide { get; set; }
            public string? sulphur_dioxide { get; set; }
            public string? ozone { get; set; }
            public string? aerosol_optical_depth { get; set; }
            public string? dust { get; set; }
            public string? uv_index { get; set; }
            public string? uv_index_clear_sky { get; set; }
            public string? alder_pollen { get; set; }
            public string? birch_pollen { get; set; }
            public string? grass_pollen { get; set; }
            public string? mugwort_pollen { get; set; }
            public string? olive_pollen { get; set; }
            public string? ragweed_pollen { get; set; }
        }

        public class HourlyValues
        {
            public string[]? Time { get; set; }
            public float?[]? Pm10 { get; set; }
            public float?[]? Pm2_5 { get; set; }
            public float?[]? Carbon_monoxide { get; set; }
            public float?[]? Nitrogen_dioxide { get; set; }
            public float?[]? Sulphur_dioxide { get; set; }
            public float?[]? Ozone { get; set; }
            public float?[]? Aerosol_optical_depth { get; set; }
            public float?[]? Dust { get; set; }
            public float?[]? Uv_index { get; set; }
            public float?[]? Uv_index_clear_sky { get; set; }

            /// <summary>
            /// Only available in Europe during pollen season with 4 days forecast
            /// </summary>
            public float?[]? Alder_pollen { get; set; }

            /// <summary>
            /// Only available in Europe during pollen season with 4 days forecast
            /// </summary>
            public float?[]? Birch_pollen { get; set; }

            /// <summary>
            /// Only available in Europe during pollen season with 4 days forecast
            /// </summary>
            public float?[]? Grass_pollen { get; set; }

            /// <summary>
            /// Only available in Europe during pollen season with 4 days forecast
            /// </summary>
            public float?[]? Mugwort_pollen { get; set; }

            /// <summary>
            /// Only available in Europe during pollen season with 4 days forecast
            /// </summary>
            public float?[]? Olive_pollen { get; set; }

            /// <summary>
            /// Only available in Europe during pollen season with 4 days forecast
            /// </summary>
            public float?[]? Ragweed_pollen { get; set; }
        }
    }
}
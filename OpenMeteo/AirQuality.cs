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
            public string[]? time { get; set; }
            public float[]? pm10 { get; set; }
            public float[]? pm2_5 { get; set; }
            public float[]? carbon_monoxide { get; set; }
            public float[]? nitrogen_dioxide { get; set; }
            public float[]? sulphur_dioxide { get; set; }
            public float[]? ozone { get; set; }
            public float[]? aerosol_optical_depth { get; set; }
            public float[]? dust { get; set; }
            public float[]? uv_index { get; set; }
            public float[]? uv_index_clear_sky { get; set; }
            public float?[]? alder_pollen { get; set; }
            public float?[]? birch_pollen { get; set; }
            public float?[]? grass_pollen { get; set; }
            public float?[]? mugwort_pollen { get; set; }
            public float?[]? olive_pollen { get; set; }
            public float?[]? ragweed_pollen { get; set; }
        }
    }
}
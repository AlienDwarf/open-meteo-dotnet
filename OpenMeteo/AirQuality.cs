namespace OpenMeteo
{
    /// <summary>
    /// Air Quality Api response
    /// </summary>
    public class AirQuality
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float GenerationTime {get;set;}
        public int UtcOffset {get;set;}
        public string? Timezone {get;set;}
        public string? TimezoneAbbreviation {get;set;}
        public object? Hourly {get;set;}
        public object? Hourly_Units {get;set;}
    }
}
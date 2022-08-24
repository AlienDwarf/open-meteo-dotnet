using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteo
{
    public class Daily
    {
        public string[]? Time { get; set; }
        public float[]? Temperature_2m_max { get; set; }
        public float[]? Temperature_2m_min { get; set; }
        public float[]? Apparent_temperature_max { get; set; }
        public float[]? Apparent_temperature_min { get; set; }
        public float[]? Precipitation_sum { get; set; }
        public float[]? Precipitation_hours { get; set; }
        public float[]? Weathercode { get; set; }
        public string[]? Sunrise { get; set; }
        public string[]? Sunset { get; set; }
        public float[]? Windspeed_10m_max { get; set; }
        public float[]? Windgusts_10m_max { get; set; }
        public float[]? Winddirection_10m_dominant { get; set; }
        public float[]? Shortwave_radiation_sum { get; set; }
    }
}

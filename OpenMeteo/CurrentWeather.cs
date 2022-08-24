using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteo
{
    public class CurrentWeather
    {
        public string? Time { get; set; }
        public float Temperature { get; set; }
        public float Weathercode { get; set; }
        public float Windspeed { get; set; }
        public float WindDirection { get; set; }
    }
}

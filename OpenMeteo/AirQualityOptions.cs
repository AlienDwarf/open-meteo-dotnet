using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenMeteo
{
    public class AirQualityOptions
    {
        public float Latitude { get; set; }
        public float Longitude {get;set;}
        public object Hourly {get;set;}
        public string Domains {get;set;}
        public string Timeformat {get;set;}
        public string Timezone {get;set;}
        public int Past_Days {get;set;}
        public string Start_date {get;set;}
        public string End_date {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteo
{
    public class WeatherForecastOptions
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Temperature_Unit { get; set; }
        public string Windspeed_Unit { get; set; }
        public string Precipitation_Unit { get; set; }
        public string Timezone { get; set; }
        public HourlyOptions Hourly { get { return _hourly; } set { _hourly = value; } }
        public DailyOptions Daily { get { return _daily; } set { _daily = value; } }
        public bool Current_Weather { get; set; }
        public string Timeformat { get; set; }
        public int Past_Days { get; set; }

        private HourlyOptions _hourly = new HourlyOptions();
        private DailyOptions _daily = new DailyOptions();

        public WeatherForecastOptions(float latitude, float longitude, string temperature_Unit, string windspeed_Unit, string precipitation_Unit, string timezone, HourlyOptions hourly, DailyOptions daily, bool current_Weather, string timeformat, int past_Days)
        {
            Latitude = latitude;
            Longitude = longitude;
            Temperature_Unit = temperature_Unit;
            Windspeed_Unit = windspeed_Unit;
            Precipitation_Unit = precipitation_Unit;
            Timezone = timezone;
            Hourly = hourly;
            Daily = daily;
            Current_Weather = current_Weather;
            Timeformat = timeformat;
            Past_Days = past_Days;
        }
        public WeatherForecastOptions(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Temperature_Unit = "celsius";
            Windspeed_Unit = "kmh";
            Precipitation_Unit = "mm";
            Timeformat = "iso8601";
            Timezone = "auto";
        }
        public WeatherForecastOptions()
        {
            Latitude = 0f;
            Longitude = 0f;
            Temperature_Unit = "celsius";
            Windspeed_Unit = "kmh";
            Precipitation_Unit = "mm";
            Timeformat = "iso8601";
            Timezone = "auto";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteo
{
    public class WeatherForecastOptions
    {
        /// <summary>
        /// Geographical WGS84 coordinate of the location
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Geographical WGS84 coordinate of the location
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Default is "celsius". Use "fahrenheit" to convert temperature to fahrenheit
        /// </summary>
        public string Temperature_Unit { get; set; }

        /// <summary>
        /// Default is "kmh". Other options: "ms", "mph", "kn"
        /// </summary>
        public string Windspeed_Unit { get; set; }

        /// <summary>
        /// Default is "mm". Other options: "inch"
        /// </summary>
        public string Precipitation_Unit { get; set; }

        /// <summary>
        /// Default is "GMT". Any time zone name from the time zone database is supported.
        /// </summary>
        public string Timezone { get; set; }

        public HourlyOptions Hourly { get { return _hourly; } set { _hourly = value; } }
        public DailyOptions Daily { get { return _daily; } set { _daily = value; } }

        /// <summary>
        /// Default is "true".
        /// Include current weather conditions in API response.
        /// </summary>
        public bool Current_Weather { get; set; }

        /// <summary>
        /// Default is "iso8601". Other options: "unixtime". 
        /// Please note that all timestamp are in GMT+0!
        /// See https://open-meteo.com/en/docs for more info
        /// </summary>
        public string Timeformat { get; set; }

        /// <summary>
        /// Default is "0". Other options: "1", "2"
        /// </summary>
        /// <value></value>
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
            Timezone = "GMT";
            Current_Weather = true;
        }
        public WeatherForecastOptions()
        {
            Latitude = 0f;
            Longitude = 0f;
            Temperature_Unit = "celsius";
            Windspeed_Unit = "kmh";
            Precipitation_Unit = "mm";
            Timeformat = "iso8601";
            Timezone = "GMT";
            Current_Weather = true;
        }
    }
}

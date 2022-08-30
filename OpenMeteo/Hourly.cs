using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteo
{
    public class Hourly
    {
        public string[]? Time { get; set; }
        public float[]? Temperature_2m { get; set; }
        public float[]? Relativehumidity_2m { get; set; }
        public float[]? Dewpoint_2m { get; set; }
        public float[]? Apparent_temperature { get; set; }
        public float[]? Precipitation { get; set; }
        public float[]? Rain { get; set; }
        public float[]? Showers { get; set; }
        public float[]? Snowfall { get; set; }
        public float[]? Snow_depth { get; set; }
        public float[]? Freezinglevel_height { get; set; }
        public float[]? Weathercode { get; set; }
        public float[]? Pressure_msl { get; set; }
        public float[]? Surface_pressure { get; set; }
        public float[]? Cloudcover { get; set; }
        public float[]? Cloudcover_low { get; set; }
        public float[]? Cloudcover_mid { get; set; }
        public float[]? Cloudcover_high { get; set; }
        public float[]? Evapotranspiration { get; set; }
        public float[]? Et0_fao_evapotranspiration { get; set; }
        public float[]? Vapor_pressure_deficit { get; set; }
        public float[]? Windspeed_10m { get; set; }
        public float[]? Windspeed_80m { get; set; }
        public float[]? Windspeed_120m { get; set; }
        public float[]? Windspeed_180m { get; set; }
        public float[]? Winddirection_10m { get; set; }
        public float[]? Winddirection_80m { get; set; }
        public float[]? Winddirection_120m { get; set; }
        public float[]? Winddirection_180m { get; set; }
        public float[]? Windgusts_10m { get; set; }
        public float[]? Soil_temperature_0cm { get; set; }
        public float[]? Soil_temperature_6cm { get; set; }
        public float[]? Soil_temperature_18cm { get; set; }
        public float[]? Soil_temperature_54cm { get; set; }
        public float[]? Soil_moisture_0_1cm { get; set; }
        public float[]? Soil_moisture_1_3cm { get; set; }
        public float[]? Soil_moisture_3_9cm { get; set; }
        public float[]? Soil_moisture_9_27cm { get; set; }
        public float[]? Soil_moisture_27_81cm { get; set; }
        public float[]? Shortwave_radiation { get; set; }
        public float[]? Direct_radiation { get; set; }
        public float[]? Diffuse_radiation { get; set; }
        public float[]? Direct_normal_irradiance { get; set; }
        public float[]? Terrestrial_radiation { get; set; }
        public float[]? Shortwave_radiation_instant { get; set; }
        public float[]? Direct_radiation_instant { get; set; }
        public float[]? Diffuse_radiation_instant { get; set; }
        public float[]? Direct_normal_irradiance_instant { get; set; }
        public float[]? Terrestrial_radiation_instant { get; set; }
    }
}

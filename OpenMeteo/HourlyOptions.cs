using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteo
{
    public class HourlyOptions : List<string>
    {
        public static HourlyOptions All { get { return new HourlyOptions(_allHourlyParams); } }
        private static readonly string[] _allHourlyParams = new string[]
        {
            "temperature_2m",
            "relativehumidity_2m",
            "dewpoint_2m",
            "apparent_temperature",
            "pressure_msl",
            "cloudcover",
            "cloudcover_low",
            "cloudcover_mid",
            "cloudcover_high",
            "windspeed_10m",
            "windspeed_80m",
            "windspeed_120m",
            "windspeed_180m",
            "winddirection_10m",
            "winddirection_80m",
            "winddirection_120m",
            "winddirection_180m",
            "windgusts_10m",
            "shortwave_radiation",
            "direct_radiation",
            "diffuse_radiation",
            "vapor_pressure_deficit",
            "evapotranspiration",
            "precipitation",
            "weathercode",
            "snow_height",
            "freezinglevel_height",
            "soil_temperature_0cm",
            "soil_temperature_6cm",
            "soil_temperature_18cm",
            "soil_temperature_54cm",
            "soil_moisture_0_1cm",
            "soil_moisture_1_3cm",
            "soil_moisture_3_9cm",
            "soil_moisture_9_27cm",
            "soil_moisture_27_81cm"
        };
        public HourlyOptions(string[] parameters)
        {
            foreach (string s in parameters)
            {
                if (!IsValidParameter(s.ToLower()))
                    continue;
                Add(s.ToLower());
            }

        }
        public HourlyOptions(string parameter)
        {
            string s = parameter.ToLower();
            if (!IsValidParameter(s))
                throw new ArgumentException();
            Add(s);
        }

        public HourlyOptions()
        {

        }

        private bool IsValidParameter(string s)
        {
            bool found = false;
            foreach (string str in _allHourlyParams)
            {
                if (found) break;
                if (s == str)
                    found = true;
            }
            return found;
        }
    }
}

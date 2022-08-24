using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteo
{
    public class DailyOptions : List<string>
    {
        public static DailyOptions All { get { return new DailyOptions(_allDailyParams); } }
        private static readonly string[] _allDailyParams = new string[]
        {
            "temperature_2m_max",
            "temperature_2m_min",
            "apparent_temperature_max",
            "apparent_temperature_min",
            "precipitation_sum",
            "precipitation_hours",
            "weathercode",
            "sunrise",
            "sunset",
            "windspeed_10m_max",
            "windgusts_10m_max",
            "winddirection_10m_dominant",
            "shortwave_radiation_sum"
        };
        public DailyOptions(string[] parameters)
        {
            foreach (string s in parameters)
            {
                if (!IsValidParameter(s.ToLower()))
                    throw new ArgumentException(s + " is not a valid parameter");
                Add(s.ToLower());
            }
        }

        public DailyOptions(string parameter)
        {
            string s = parameter.ToLower();
            if (!IsValidParameter(s))
                throw new ArgumentException(s + " is not a valid parameter");
            Add(s);
        }

        public DailyOptions()
        {

        }

        private bool IsValidParameter(string s)
        {
            bool found = false;
            foreach (string str in _allDailyParams)
            {
                if (found) break;
                if (s == str)
                    found = true;
            }
            return found;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenMeteo
{
    public class DailyOptions
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
        public List<string> Parameter { get { return parameter; } }
        
        internal readonly List<string> parameter = new List<string>();
        public DailyOptions(string[] parameter)
        {
            foreach (string s in parameter)
            {
                if (!IsValidParameter(s.ToLower()))
                    throw new ArgumentException(s + " is not a valid parameter");
                this.parameter.Add(s);
            }
        }

        public DailyOptions(string parameter)
        {
            string s = parameter.ToLower();
            if (!IsValidParameter(s))
                throw new ArgumentException(s + " is not a valid parameter");
            this.parameter.Add(s);
        }

        public DailyOptions()
        {
            
        }

        public DailyOptions(DailyOptionsType parameter)
        {
            bool result = Add(parameter);
            if (!result)
                throw new ArgumentException();
        }

        public DailyOptions(DailyOptionsType[] parameter)
        {
            bool result = Add(parameter);
            if (!result)
                throw new ArgumentException();
        }

        /// <summary>
        /// Add parameter
        /// </summary>
        /// <param name="param"></param>
        /// <returns>True if successfully added else false</returns>
        public bool Add(DailyOptionsType param)
        {
            // Each enum variable represents an integer starting with 0.
            // So we can use our static string[] to get the string representation
            
            // Make sure we aren't our of array
            if ((int)param < 0 || (int)param >= _allDailyParams.Length) return false;

            string paramToAdd = _allDailyParams[(int)param];

            // Check that the parameter isn't already added
            if (this.parameter.Contains(paramToAdd)) return false;

            parameter.Add(paramToAdd);
            return true;
        }

        public bool Add(DailyOptionsType[] param)
        {
            foreach (DailyOptionsType paramToAdd in param)
            {
                if (!this.Add(paramToAdd))
                    return false;
            }
            return true;
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

    public enum DailyOptionsType
    {
        temperature_2m_max,
        temperature_2m_min,
        apparent_temperature_max,
        apparent_temperature_min,
        precipitation_sum,
        precipitation_hours,
        weathercode,
        sunrise,
        sunset,
        windspeed_10m_max,
        windgusts_10m_max,
        winddirection_10m_dominant,
        shortwave_radiation_sum
    }
}

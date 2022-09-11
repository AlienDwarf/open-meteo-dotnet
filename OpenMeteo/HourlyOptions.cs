using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenMeteo
{
    /// <summary>
    /// Hourly Weather Variables (https://open-meteo.com/en/docs)
    /// </summary>
    public class HourlyOptions : IEnumerable<HourlyOptionsParameter>, ICollection<HourlyOptionsParameter>
    {
        public static HourlyOptions All { get { return new HourlyOptions((HourlyOptionsParameter[])Enum.GetValues(typeof(HourlyOptionsParameter))); } }

        /// <summary>
        /// A copy of the current applied parameter. This is a COPY. Editing anything inside this copy won't be applied 
        /// </summary>
        public List<HourlyOptionsParameter> Parameter { get { return new List<HourlyOptionsParameter>(_parameter); } }

        public int Count => _parameter.Count;

        public bool IsReadOnly => false;

        [Obsolete]
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

        private readonly List<HourlyOptionsParameter> _parameter = new List<HourlyOptionsParameter>();
        /*public HourlyOptions(string[] parameter)
        {
            foreach (string s in parameter)
            {
                if (!IsValidParameter(s.ToLower()))
                    throw new ArgumentException();

                var toAdd = HourlyOptionsStringToEnum(s);
                if (toAdd != null)
                    this._parameter.Add(toAdd);
            }
        }

        public HourlyOptions(string parameter)
        {
            string s = parameter.ToLower();
            if (!IsValidParameter(s))
                throw new ArgumentException();
            this._parameter.Add(s);
        }
        */
        public HourlyOptions(HourlyOptionsParameter parameter)
        {
            Add(parameter);
        }

        public HourlyOptions(HourlyOptionsParameter[] parameter)
        {
            Add(parameter);
        }

        public HourlyOptions()
        {

        }

        public HourlyOptionsParameter this[int index]
        {
            get { return _parameter[index]; }
            set
            {
                _parameter[index] = value;
            }
        }

        public void Add(HourlyOptionsParameter param)
        {
            // Check that the parameter isn't already added
            if (this._parameter.Contains(param)) return;

            _parameter.Add(param);
        }

        public void Add(HourlyOptionsParameter[] param)
        {
            foreach (HourlyOptionsParameter paramToAdd in param)
            {
                Add(paramToAdd);
            }
        }

        [Obsolete]
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

        public IEnumerator<HourlyOptionsParameter> GetEnumerator()
        {
            return _parameter.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /*public void Add(string item)
        {
            // Make sure that item is a valid parameter
            if (!IsValidParameter(item)) return;

            _parameter.Add(item);
        }*/

        public void Clear()
        {
            _parameter.Clear();
        }

        public bool Contains(HourlyOptionsParameter item)
        {
            return _parameter.Contains(item);
        }

        public void CopyTo(HourlyOptionsParameter[] array, int arrayIndex)
        {
            _parameter.CopyTo(array, arrayIndex);
        }

        public bool Remove(HourlyOptionsParameter item)
        {
            return _parameter.Remove(item);
        }

        [Obsolete]
        public HourlyOptionsParameter? HourlyOptionsStringToEnum(string option)
        {
            if (!IsValidParameter(option)) return null;

            HourlyOptionsParameter toFind;

            // Get array index of valid parameter == (int)enum
            int index = Array.IndexOf(_allHourlyParams, option);

            // Again check that we found an index
            // (double check bc option we checked that option is a valid param already)
            if (index == -1) return null;

            // Check that index is defined in enum
            if (!Enum.IsDefined(typeof(DailyOptionsParameter), index)) return null;

            toFind = (HourlyOptionsParameter)index;

            // Return enum value
            return toFind;
        }
    }

    // This is converted to string so it has to be the exact same name like in 
    // https://open-meteo.com/en/docs #Hourly Parameter Definition
    public enum HourlyOptionsParameter
    {
        temperature_2m, 
        relativehumidity_2m,
        dewpoint_2m,
        apparent_temperature,
        precipitation,
        rain,
        showers,
        snowfall,
        snow_depth,
        freezinglevel_height,
        weathercode,
        pressure_msl,
        surface_pressure,
        cloudcover,
        cloudcover_low,
        cloudcover_mid,
        cloudcover_high,
        evapotranspiration,
        et0_fao_evapotranspiration,
        vapor_pressure_deficit,
        windspeed_10m,
        windspeed_80m,
        windspeed_120m,
        windspeed_180m,
        winddirection_10m,
        winddirection_80m,
        winddirection_120m,
        winddirection_180m,
        windgusts_10m,
        soil_temperature_0cm,
        soil_temperature_6cm,
        soil_temperature_18cm,
        soil_temperature_54cm,
        soil_moisture_0_1cm,
        soil_moisture_1_3cm,
        soil_moisture_3_9cm,
        soil_moisture_9_27cm,
        soil_moisture_27_81cm,
        shortwave_radiation,
        direct_radiation,
        diffuse_radiation,
        direct_normal_irradiance,
        terrestrial_radiation,
        shortwave_radiation_instant,
        direct_radiation_instant,
        diffuse_radiation_instant,
        direct_normal_irradiance_instant,
        terrestrial_radiation_instant
    }
}
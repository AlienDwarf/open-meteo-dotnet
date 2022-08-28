using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenMeteo
{
    public class DailyOptions : IEnumerable, ICollection<DailyOptionsType>
    {
        public static DailyOptions All { get { return new DailyOptions((DailyOptionsType[])Enum.GetValues(typeof(DailyOptionsType))); } }
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
        public List<DailyOptionsType> Parameter { get { return new List<DailyOptionsType>(_parameter); } }

        public int Count => _parameter.Count;

        public bool IsReadOnly => false;

        private readonly List<DailyOptionsType> _parameter = new List<DailyOptionsType>();
        /*public DailyOptions(string[] parameter)
        {
            foreach (string s in parameter)
            {
                if (!IsValidParameter(s.ToLower()))
                    throw new ArgumentException(s + " is not a valid parameter");
                this._parameter.Add(s);
            }
        }

        public DailyOptions(string parameter)
        {
            string s = parameter.ToLower();
            if (!IsValidParameter(s))
                throw new ArgumentException(s + " is not a valid parameter");
            this._parameter.Add(s);
        }*/

        public DailyOptions()
        {
            
        }

        public DailyOptions(DailyOptionsType parameter)
        {
            Add(parameter);
        }

        public DailyOptions(DailyOptionsType[] parameter)
        {
            Add(parameter);
        }

        /// <summary>
        /// Index the collection
        /// </summary>
        /// <param name="index"></param>
        /// <returns><see cref="string"/> DailyOptionsType as string representation at index</returns>
        public DailyOptionsType this[int index]
        {
            get { return _parameter[index]; }
            set
            {
                _parameter[index] = value;
            }
        }

        /// <summary>
        /// Add parameter
        /// </summary>
        /// <param name="param"></param>
        /// <returns>True if successfully added else false</returns>
        public void Add(DailyOptionsType param)
        {
            // Each enum variable represents an integer starting with 0.
            // So we can use our static string[] to get the string representation
            
            // Make sure we aren't our of array
            //if ((int)param < 0 || (int)param >= _allDailyParams.Length) return;

            //string paramToAdd = _allDailyParams[(int)param];

            // Check that the parameter isn't already added
            if (this._parameter.Contains(param)) return;

            _parameter.Add(param);
        }

        public void Add(DailyOptionsType[] param)
        {
            foreach (DailyOptionsType paramToAdd in param)
            {
                Add(paramToAdd);
            }
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

        private DailyOptionsType? DailyOptionsStringToEnum(string option)
        {
            if (!IsValidParameter(option)) return null;

            DailyOptionsType? toFind = null;

            // Get array index of valid parameter == (int)enum
            int index = Array.IndexOf(_allDailyParams, option);

            // Again check that we found an index
            // (double check bc option we checked that option is a valid param already)
            if (index == -1) return null;

            // Check that index is defined in enum
            if (!Enum.IsDefined(typeof(DailyOptionsType), index)) return null;
            
            // Return enum to 
            return toFind;
        }

        public void Clear()
        {
            _parameter.Clear();
        }

        public bool Contains(DailyOptionsType item)
        {
            return _parameter.Contains(item);
        }

        public bool Remove(DailyOptionsType item)
        {
            return _parameter.Remove(item);
        }

        public void CopyTo(DailyOptionsType[] array, int arrayIndex)
        {
            _parameter.CopyTo(array, arrayIndex);
        }

        public IEnumerator<DailyOptionsType> GetEnumerator()
        {
            return _parameter.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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

using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenMeteo
{
    public class DailyOptions : IEnumerable, ICollection<string>
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
        public List<string> Parameter { get { return _parameter; } }

        public int Count => _parameter.Count;

        public bool IsReadOnly => false;

        private readonly List<string> _parameter = new List<string>();
        public DailyOptions(string[] parameter)
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
        }

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
        public string this[int index]
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
            if ((int)param < 0 || (int)param >= _allDailyParams.Length) return;

            string paramToAdd = _allDailyParams[(int)param];

            // Check that the parameter isn't already added
            if (this._parameter.Contains(paramToAdd)) return;

            _parameter.Add(paramToAdd);
            return;
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
            string paramStringRepresentation = _allDailyParams[(int)item];
            bool found = false;

            foreach (var parameter in _parameter)
            {
                if (parameter.Equals(paramStringRepresentation))
                {
                    found = true;
                }
            }
            return found;
        }

        public void CopyTo(DailyOptionsType[] array, int arrayIndex)
        {
            // Error checking that all arguments are valid
            if (array == null) 
                throw new ArgumentNullException("array");
            // If we arrayIndex is out of range
            if (arrayIndex < 0 || arrayIndex >= _allDailyParams.Length) 
                throw new ArgumentOutOfRangeException("arrayIndex out of Range");
            // If we have less fields than needed
            if (Count > array.Length - arrayIndex) 
                throw new ArgumentException("The array has fewer elements than the collection");

            // Iterate through list and add each entry, start at arrayIndex
            for (int i = 0; i < _parameter.Count; i++)
            {
                DailyOptionsType? toAdd = DailyOptionsStringToEnum(_parameter[i]);
                if (toAdd != null)
                {
                    array[i + arrayIndex] = (DailyOptionsType)toAdd;
                }
            }
        }

        public bool Remove(DailyOptionsType item)
        {
            return _parameter.Remove(_allDailyParams[(int)item]);
        }

        public void Add(string item)
        {
            if (!IsValidParameter(item)) return;

            _parameter.Add(item);
        }

        public bool Contains(string item)
        {
            if (!IsValidParameter(item)) return false;
            return _parameter.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            _parameter.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            return _parameter.Remove(item);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _parameter.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _parameter.GetEnumerator();
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

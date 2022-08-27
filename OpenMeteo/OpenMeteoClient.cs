using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;

namespace OpenMeteo
{
    /// <summary>
    /// Handles GET Requests and performs API Calls.
    /// </summary>
    public class OpenMeteoClient
    {
        private readonly string _weatherApiUrl = "https://api.open-meteo.com/v1/forecast";
        private readonly string _geocodeApiUrl = "https://geocoding-api.open-meteo.com/v1/search";
        private readonly HttpController httpController;
        private readonly System.Globalization.CultureInfo _culture;

        /// <summary>
        /// Creates a new <seealso cref="OpenMeteoClient"/> object and sets the neccessary variables (httpController, CultureInfo)
        /// </summary>
        public OpenMeteoClient()
        {
            httpController = new HttpController();

            // Used to parse floats with "." (many countries "," is standard when parsing float to string) when creating query string
            _culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }

        /// <summary>
        /// Restores the original CultureInfo
        /// </summary>
        ~OpenMeteoClient()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = _culture;
        }

        /// <summary>
        /// Performs two GET-Requests (first geocoding api for latitude,longitude, then weather forecast)
        /// </summary>
        /// <param name="city">Name of city</param>
        /// <returns>If successful returns an awaitable Task containing WeatherForecast or NULL if request failed</returns>
        public async Task<WeatherForecast?> QueryAsync(string city)
        {
            GeocodingOptions geocodingOptions = new GeocodingOptions(city);

            // Get City Information
            GeocodingApiResponse? response = await GetGeocodingDataAsync(geocodingOptions);
            if (response == null || response.Cities == null)
                return null;

            WeatherForecastOptions options = new WeatherForecastOptions
            {
                Latitude = response.Cities[0].Latitude,
                Longitude = response.Cities[0].Longitude,
                Current_Weather = true
            };

            return await GetWeatherForecastAsync(options);
        }

        /// <summary>
        /// Performs two GET-Requests (first geocoding api for latitude,longitude, then weather forecast)
        /// </summary>
        /// <param name="options">Geocoding options</param>
        /// <returns>If successful awaitable <see cref="Task"/> or NULL</returns>
        public async Task<WeatherForecast?> QueryAsync(GeocodingOptions options)
        {
            // Get City Information
            GeocodingApiResponse? response = await GetCityGeocodingDataAsync(options);
            if (response == null || response.Cities == null)
                return null;

            WeatherForecastOptions weatherForecastOptions = new WeatherForecastOptions
            {
                Latitude = response.Cities[0].Latitude,
                Longitude = response.Cities[0].Longitude,
                Current_Weather = true
            };

            return await GetWeatherForecastAsync(weatherForecastOptions);
        }

        /// <summary>
        /// Performs one GET-Request
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Awaitable Task containing WeatherForecast or NULL</returns>
        public async Task<WeatherForecast?> QueryAsync(WeatherForecastOptions options)
        {
            try
            {
                return await GetWeatherForecastAsync(options);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Performs one GET-Request to get weather information
        /// </summary>
        /// <param name="latitude">City latitude</param>
        /// <param name="longitude">City longitude</param>
        /// <returns>Awaitable Task containing WeatherForecast or NULL</returns>
        public async Task<WeatherForecast?> QueryAsync(float latitude, float longitude)
        {
            WeatherForecastOptions options = new WeatherForecastOptions
            {
                Latitude = latitude,
                Longitude = longitude,
                Current_Weather = true
            };
            return await QueryAsync(options);
        }

        /// <summary>
        /// Performs one GET-Request to Open-Meteo Geocoding API 
        /// </summary>
        /// <param name="city">Name of city</param>
        /// <returns></returns>
        public async Task<GeocodingApiResponse?> GetCityGeocodingDataAsync(string city)
        {
            GeocodingOptions geocodingOptions = new GeocodingOptions(city);

            return await GetCityGeocodingDataAsync(geocodingOptions);
        }

        public async Task<GeocodingApiResponse?> GetCityGeocodingDataAsync(GeocodingOptions options)
        {
            return await GetGeocodingDataAsync(options);
        }

        /// <summary>
        /// Performs one GET-Request to get a (float, float) tuple
        /// </summary>
        /// <param name="city">Name of city</param>
        /// <returns>(latitude, longitude) tuple</returns>
        public async Task<(float latitude, float longitude)?> GetCityLatitudeLongitudeAsync(string city)
        {
            GeocodingApiResponse? response = await GetCityGeocodingDataAsync(city);
            if (response == null || response?.Cities == null)
                return null;
            return (response.Cities[0].Latitude, response.Cities[0].Longitude);
        }

        /// <summary>
        /// Converts a given weathercode to it's string representation
        /// </summary>
        /// <param name="weathercode"></param>
        /// <returns><see cref="string"/> Weathercode string representation</returns>
        public string WeathercodeToString(int weathercode)
        {
            switch (weathercode)
            {
                case 0:
                    return "Clear sky";
                case 1:
                    return "Mainly clear";
                case 2:
                    return "Partly cloudy";
                case 3:
                    return "Overcast";
                case 45:
                    return "Fog";
                case 48:
                    return "Depositing rime Fog";
                case 51:
                    return "Light drizzle";
                case 53:
                    return "Moderate drizzle";
                case 55:
                    return "Dense drizzle";
                case 56:
                    return "Light freezing drizzle";
                case 57:
                    return "Dense freezing drizzle";
                case 61:
                    return "Slight rain";
                case 63:
                    return "Moderate rain";
                case 65:
                    return "Heavy rain";
                case 66:
                    return "Light freezing rain";
                case 67:
                    return "Heavy freezing rain";
                case 71:
                    return "Slight snow fall";
                case 73:
                    return "Moderate snow fall";
                case 75:
                    return "Heavy snow fall";
                case 77:
                    return "Snow grains";
                case 80:
                    return "Slight rain showers";
                case 81:
                    return "Moderate rain showers";
                case 82:
                    return "Violent rain showers";
                case 85:
                    return "Slight snow showers";
                case 86:
                    return "Heavy snow showers";
                case 95:
                    return "Thunderstorm";
                case 96:
                    return "Thunderstorm with light hail";
                case 99:
                    return "Thunderstorm with heavy hail";
                default:
                    return "Invalid weathercode";
            }
        }

        private async Task<WeatherForecast?> GetWeatherForecastAsync(WeatherForecastOptions options)
        {
            try
            {
                HttpResponseMessage response = await httpController.Client.GetAsync(MergeUrlWithOptions(_weatherApiUrl, options));
                response.EnsureSuccessStatusCode();

                WeatherForecast? weatherForecast = await JsonSerializer.DeserializeAsync<WeatherForecast>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return weatherForecast;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }

        }

        private async Task<GeocodingApiResponse?> GetGeocodingDataAsync(GeocodingOptions options)
        {
            try
            {
                HttpResponseMessage response = await httpController.Client.GetAsync(MergeUrlWithOptions(_geocodeApiUrl, options));
                response.EnsureSuccessStatusCode();

                GeocodingApiResponse? geocodingData = await JsonSerializer.DeserializeAsync<GeocodingApiResponse>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return geocodingData;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Can't find " + options.Name + ". Please make sure that the name is valid.");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        [Obsolete]
        private string _MergeUrlWithOptions(string url, GeocodingOptions options)
        {
            if (options == null) return url;

            UriBuilder uri = new UriBuilder(url);
            bool isFirstParam = false;
            string paramToAdd = "";

            // If no query given, add '?' to start the query string
            if (uri.Query == string.Empty)
            {
                uri.Query = "?";

                // isFirstParam becomes true because the query string is new
                isFirstParam = true;
            }

            // Iterate through options object and get the key=value pairs
            foreach (PropertyInfo propertyInfo in options.GetType().GetProperties())
            {
                // If key:null ignore it
                if (propertyInfo.GetValue(options, null) == null)
                    continue;

                var key = propertyInfo.Name;
                var value = propertyInfo.GetValue(options, null);

                // if we got another object (Daily, Hourly) skip it
                if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
                    continue;
                // If value is an empty string ignore it
                if (propertyInfo.PropertyType == typeof(string))
                    if ((string)propertyInfo.GetValue(options, null) == string.Empty)
                        continue;

                // The first parameter starts without "&"
                if (isFirstParam)
                {
                    paramToAdd = key + "=" + value;
                    isFirstParam = false;
                }
                else
                {
                    paramToAdd = "&" + key + "=" + value;
                }

                // concatenate the string to query string
                uri.Query += paramToAdd;
            }

            // Finally return the whole url in lowercase
            return uri.ToString().ToLower();
        }

        [Obsolete]
        private string _MergeUrlWithOptions(string url, WeatherForecastOptions? options)
        {
            if (options == null) return url;

            UriBuilder uri = new UriBuilder(url);
            bool isFirstParam = false;
            string paramToAdd = "";


            // If no query given, add '?' to start the query string
            if (uri.Query == string.Empty)
            {
                uri.Query = "?";

                // isFirstParam becomes true because the query string is new
                isFirstParam = true;
            }

            // Iterate through options object and get the key=value pairs
            foreach (PropertyInfo propertyInfo in options.GetType().GetProperties())
            {
                // If key:null ignore it
                if (propertyInfo.GetValue(options, null) == null)
                    continue;

                var key = propertyInfo.Name;
                var value = propertyInfo.GetValue(options, null);

                // if we got another object (Daily, Hourly) skip it
                if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
                    continue;
                // If value is an empty string ignore it
                if (propertyInfo.PropertyType == typeof(string))
                    if ((string)propertyInfo.GetValue(options, null) == string.Empty)
                        continue;

                // The first parameter starts without "&"
                if (isFirstParam)
                {
                    paramToAdd = key + "=" + value;
                    isFirstParam = false;
                }
                else
                {
                    paramToAdd = "&" + key + "=" + value;
                }

                // concatenate the string to query string
                uri.Query += paramToAdd;
            }

            // Now add the classes Daily & Hourly

            // Check that Daily is not empty
            if (options.Daily.Count > 0)
            {
                // Add the parameters to query string.
                // (This CAN'T be the first paramter because latitude and longitude are required and already added)
                // So we do not need an additional check here
                uri.Query += "&daily=" + string.Join(",", options.Daily);
            }

            // Finally add Hourly
            if (options.Hourly.parameter.Count > 0)
            {
                uri.Query += "&hourly=" + string.Join(",", options.Hourly);
            }

            // Finally return the whole url in lowercase
            return uri.ToString().ToLower();
        }

        internal string MergeUrlWithOptions(string url, WeatherForecastOptions? options)
        {
            if (options == null) return url;

            UriBuilder uri = new UriBuilder(url);
            bool isFirstParam = false;

            // If no query given, add '?' to start the query string
            if (uri.Query == string.Empty)
            {
                uri.Query = "?";

                // isFirstParam becomes true because the query string is new
                isFirstParam = true;
            }

            // Add the properties

            // Begin with Latitude and Longitude since they're required
            if (isFirstParam)
                uri.Query += "latitude=" + options.Latitude;
            else
                uri.Query += "&latitude=" + options.Latitude;

            uri.Query += "&longitude=" + options.Longitude;

            if (options.Temperature_Unit != string.Empty)
                uri.Query += "&temperature_unit=" + options.Temperature_Unit;
            if (options.Windspeed_Unit != string.Empty)
                uri.Query += "&windspeed_unit=" + options.Windspeed_Unit;
            if (options.Precipitation_Unit != string.Empty)
                uri.Query += "&precipitation_unit=" + options.Precipitation_Unit;
            if (options.Timezone != string.Empty)
                uri.Query += "&timezone=" + options.Timezone;

            uri.Query += "&current_weather=" + options.Current_Weather;

            if (options.Timeformat != string.Empty)
                uri.Query += "&timeformat=" + options.Timeformat;

            uri.Query += "&past_days=" + options.Past_Days;

            // Now we iterate through hourly and daily

            // Hourly
            if (options.Hourly.parameter.Count > 0)
            {
                bool firstHourlyElement = true;
                uri.Query += "&hourly=";

                foreach (string s in options.Hourly.parameter)
                {
                    if (firstHourlyElement)
                    {
                        uri.Query += s;
                        firstHourlyElement = false;
                    }
                    else
                    {
                        uri.Query += "," + s;
                    }
                }
            }

            // Daily
            if (options.Daily.Count > 0)
            {
                bool firstDailyElement = true;
                uri.Query += "&daily=";
                foreach (string s in options.Daily)
                {
                    if (firstDailyElement)
                    {
                        uri.Query += s;
                        firstDailyElement = false;
                    }
                    else
                    {
                        uri.Query += "," + s;
                    }
                }
            }
            return uri.ToString();
        }

        /// <summary>
        /// Combines a given url with an options object to create a url for GET requests
        /// </summary>
        /// <returns>url+queryString</returns>
        internal string MergeUrlWithOptions(string url, GeocodingOptions options)
        {
            if (options == null) return url;

            UriBuilder uri = new UriBuilder(url);
            bool isFirstParam = false;

            // If no query given, add '?' to start the query string
            if (uri.Query == string.Empty)
            {
                uri.Query = "?";

                // isFirstParam becomes true because the query string is new
                isFirstParam = true;
            }

            // Now we check every property and set the value, if neccessary
            if (isFirstParam)
                uri.Query += "name=" + options.Name;
            else
                uri.Query += "&name=" + options.Name;

            if(options.Count >0)
                uri.Query += "&count=" + options.Count;
            
            if (options.Format != string.Empty)
                uri.Query += "&format=" + options.Format;

            if (options.Language != string.Empty)
                uri.Query += "&language=" + options.Language;

            return uri.ToString().ToLower();
        }
    }
}


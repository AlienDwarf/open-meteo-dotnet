using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;

namespace OpenMeteo
{
    public class OpenMeteoClient
    {
        private readonly string _weatherApiUrl = "https://api.open-meteo.com/v1/forecast";
        private readonly string _geocodeApiUrl = "https://geocoding-api.open-meteo.com/v1/search";
        private readonly HttpController httpController;
        private readonly System.Globalization.CultureInfo _culture;
        public OpenMeteoClient()
        {
            httpController = new HttpController();

            // Used to parse floats with "." (many countries "," is standard when parsing float to string) when creating query string
            _culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
        ~OpenMeteoClient()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = _culture;
        }

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

        public async Task<GeocodingApiResponse?> GetCityGeocodingDataAsync(string city)
        {
            GeocodingOptions geocodingOptions = new GeocodingOptions(city);

            return await GetCityGeocodingDataAsync(geocodingOptions);
        }

        public async Task<GeocodingApiResponse?> GetCityGeocodingDataAsync(GeocodingOptions options)
        {
            return await GetGeocodingDataAsync(options);
        }

        public async Task<(float latitude, float longitude)?> GetCityLatitudeLongitudeAsync(string city)
        {
            GeocodingApiResponse? response = await GetCityGeocodingDataAsync(city);
            if (response == null || response?.Cities == null)
                return null;
            return (response.Cities[0].Latitude, response.Cities[0].Longitude);
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

        private string MergeUrlWithOptions(string url, GeocodingOptions options)
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
        private string MergeUrlWithOptions(string url, WeatherForecastOptions? options)
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
            if (options.Hourly.Count > 0)
            {
                uri.Query += "&hourly=" + string.Join(",", options.Hourly);
            }

            // Finally return the whole url in lowercase
            return uri.ToString().ToLower();
        }
    }
}

